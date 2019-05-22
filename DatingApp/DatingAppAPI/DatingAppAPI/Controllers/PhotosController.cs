using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DatingAppAPI.Data;
using DatingAppAPI.Dtos;
using DatingAppAPI.Helpers;
using DatingAppAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DatingAppAPI.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public PhotosController(IDatingRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            this._repo = repo;
            this._mapper = mapper;
            this._cloudinaryConfig = cloudinaryConfig;

            Account acc = new Account(
                this._cloudinaryConfig.Value.CloudName,
                this._cloudinaryConfig.Value.ApiKey,
                this._cloudinaryConfig.Value.ApiSecret
            );

            this._cloudinary = new Cloudinary(acc);
        }

        [HttpGet("{id}",Name = "GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            Photo photoFromRepo = await _repo.GetPhoto(id);

            PhotoForReturnDto photo = _mapper.Map<PhotoForReturnDto>(photoFromRepo);

            return Ok(photo);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForUser(int userId, [FromForm]PhotoForCreationDto photoForCreationDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            User userFromRepo = await _repo.GetUser(userId);

            IFormFile file = photoForCreationDto.File;

            ImageUploadResult uploadResult = new ImageUploadResult();

            if(file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    ImageUploadParams uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            photoForCreationDto.Url = uploadResult.Uri.ToString();
            photoForCreationDto.PublicId = uploadResult.PublicId;

            Photo photo = _mapper.Map<Photo>(photoForCreationDto);

            if(!userFromRepo.Photos.Any(u => u.IsMain))
            {
                photo.IsMain = true;
            }

            userFromRepo.Photos.Add(photo);

            

            if ( await _repo.SaveAll())
            {
                PhotoForReturnDto photoForReturn = _mapper.Map<PhotoForReturnDto>(photo);
                return CreatedAtRoute("GetPhoto", new { id = photo.Id }, photoForReturn);
            }

            return BadRequest("Could not add the photo.");
        }

        [HttpPost("{id}/setMain")]
        public async Task<IActionResult> SetMainPhoto(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();

            }

            User user = await _repo.GetUser(userId);

            if (!user.Photos.Any(p => p.Id == id))
            {
                return Unauthorized();
            }

            Photo photoFromRepo = await _repo.GetPhoto(id);

            if(photoFromRepo.IsMain)
            {
                return BadRequest("This is already the main photo");
            }

            Photo currentMainPhoto = await _repo.GetMainPhotoForUser(userId);
            currentMainPhoto.IsMain = false;

            photoFromRepo.IsMain = true;

            if(await _repo.SaveAll())
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Could not set photo to main");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();

            }

            User user = await _repo.GetUser(userId);

            if (!user.Photos.Any(p => p.Id == id))
            {
                return Unauthorized();
            }

            Photo photoFromRepo = await _repo.GetPhoto(id);

            if (photoFromRepo.IsMain)
            {
                return BadRequest("You cannot delete your main photo");
            }

            if (photoFromRepo.PublicId != null)
            {
                DeletionParams deleteParams = new DeletionParams(photoFromRepo.PublicId);

                DeletionResult result = _cloudinary.Destroy(deleteParams);

                if (result.Result == "ok")
                {
                    _repo.Delete(photoFromRepo);

                }
            }

            if (photoFromRepo.PublicId == null)
            {
                _repo.Delete(photoFromRepo);
            }

            if(await _repo.SaveAll())
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to delete the photo");
            }
        }
    }
}

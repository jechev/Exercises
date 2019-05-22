using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DatingAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingAppAPI.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            User currentUser = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Username == username);

            if (currentUser == null)
            {
                return null;
            }

            if(!VerifyPasswordHash(password, currentUser.PasswordHash, currentUser.PasswordSalt))
            {
                return null;
            }

            return currentUser;
        }


        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePassword(password,out passwordHash,out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExist(string username)
        {
            if (await _context.Users.AnyAsync(u => u.Username == username))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512(passwordSalt))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}

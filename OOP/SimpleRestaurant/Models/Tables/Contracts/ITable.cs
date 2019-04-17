namespace SoftUniRestaurant.Models.Tables.Contracts
{
    public interface ITable
    {
        int TableNumber { get; set; }
        int Capacity { get; set; } 
        decimal PricePerPerson { get; set; }
        bool IsReserved { get; set; }
    }
}

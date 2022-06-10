using System.Linq;
namespace LapTopStore.Models
{
    public interface ILapTopStoreRepository
    {
        IQueryable<Laptop> Laptops { get; }
        void SaveLaptop(Laptop l);
        void CreateLaptop(Laptop l);
        void DeleteLaptop(Laptop l);
    }
}
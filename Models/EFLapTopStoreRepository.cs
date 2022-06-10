using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LapTopStore.Models
{
    public class EFLapTopStoreRepository : ILapTopStoreRepository
    {
        private LapTopStoreDbContext context;
        public EFLapTopStoreRepository(LapTopStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Laptop> Laptops => context.Laptops;

        public void CreateLaptop(Laptop l)
        {
            context.Add(l);
            context.SaveChanges();
        }
        public void DeleteLaptop(Laptop l)
        {
            context.Remove(l); context.SaveChanges();
        }
        public void SaveLaptop(Laptop l)
        {
            context.SaveChanges();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LapTopStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private LapTopStoreDbContext context;
        public EFOrderRepository(LapTopStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.Laptop);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Laptop));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}

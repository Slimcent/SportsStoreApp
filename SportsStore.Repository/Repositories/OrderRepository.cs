using Microsoft.EntityFrameworkCore;
using SportsStore.Data.Context;
using SportsStore.Models.Entities;
using SportsStore.Repository.Interfaces;
using System.Linq;

namespace SportsStore.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private SportsStoreDbContext _dbContext;

        public OrderRepository(SportsStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Order> Orders => _dbContext.Orders.Include(o => o.Lines)
            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            _dbContext.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                _dbContext.Orders.Add(order);
            }
            _dbContext.SaveChanges();
        }
    }
}

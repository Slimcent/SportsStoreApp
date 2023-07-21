using SportsStore.Models.Entities;
using System.Linq;

namespace SportsStore.Repository.Interfaces
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}

using SportsStore.Models.Entities;
using System.Linq;

namespace SportsStore.Repository.Interfaces
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
        void SaveProduct(Product p);
        void CreateProduct(Product p);
        void DeleteProduct(Product p);
    }
}

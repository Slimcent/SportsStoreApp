using SportsStore.Data.Context;
using SportsStore.Models.Entities;
using SportsStore.Repository.Interfaces;
using System.Linq;

namespace SportsStore.Repository.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private SportsStoreDbContext _dbContext;
        public StoreRepository(SportsStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Product> Products => _dbContext.Products;
    }
}

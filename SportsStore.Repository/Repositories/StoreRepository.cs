using SportsStore.Entities.Context;
using SportsStore.Entities.Models;
using SportsStore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

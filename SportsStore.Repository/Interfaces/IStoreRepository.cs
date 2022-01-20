using SportsStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Repository.Interfaces
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}

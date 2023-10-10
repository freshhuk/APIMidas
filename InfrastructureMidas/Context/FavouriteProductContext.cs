using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfrastructureMidas.Interfaces;
using DomainMidas.Entities;

namespace InfrastructureMidas.Context
{
    public class FavouriteProductContext : IDataContext<Product>
    {
        
        public Task AddAsync(Product item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}

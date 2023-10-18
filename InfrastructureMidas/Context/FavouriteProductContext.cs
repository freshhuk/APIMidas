using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfrastructureMidas.Interfaces;
using DomainMidas.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureMidas.Context
{
    public class FavouriteProductContext : DbContext ,IDataContext<Product> 
    {
        DbSet<Product> products { get; set; }
        private readonly IConfiguration _configuration;
        public FavouriteProductContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //for configuration sql connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

        }



        #region Realization interface
        public async Task AddAsync(Product item)
        {
            await products.AddAsync(item);

        }

        public void Delete(int id)
        {
            var model = products.Find(id);
            if(model != null)
            {
                products.Remove(model);
            }
        }

        public Product Get(int id)
        {
            var product = products.SingleOrDefault(t => t.Id == id);
            if (product == null)
            {
                // Можно выбросить исключение или выполнить другие действия по обработке
                throw new InvalidOperationException("Task not found.");
            }
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return products.OrderBy(t => t.Id);
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        public async Task Update(Product item)
        {
            var existingTask = await products.FindAsync(item.Id);
            if (existingTask != null)
            {
                // Производим обновление полей существующей задачи
                Entry(existingTask).CurrentValues.SetValues(item);

            }
        }
        #endregion

    }
}

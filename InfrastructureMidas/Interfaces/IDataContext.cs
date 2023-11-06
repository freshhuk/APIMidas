using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureMidas.Interfaces
{
    public interface IDataContext<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        Task AddAsync(T item);
        Task Update(T item);
        void Delete(int id);
        Task SaveChangesAsync();
        Task CreateDb();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task DeleteByIdAsync(int id);
        void Update(T model);
    }
}

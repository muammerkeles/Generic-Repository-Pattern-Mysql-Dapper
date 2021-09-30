using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Demo.Library.Abstract
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task Delete(long id);
        Task<T> GetByIdAsync(long id);
        Task<int> SaveRangeAsync(IEnumerable<T> listEntity);
        Task UpdateAsync(T t);
        Task InsertAsync(T tData);
        Task<long> InsertAsync(T tData,bool returnLastInsertedId);
    }
}

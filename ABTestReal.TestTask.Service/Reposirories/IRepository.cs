using ABTestReal.TestTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABTestReal.TestTask.Service.Reposirories
{
    public interface IRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetAll(CancellationToken cancel = default);       
        Task<T> GetById(int id, CancellationToken cancel = default);
        Task<T> Add(T item, CancellationToken cancel = default);
        Task<T> Update(T item, CancellationToken cancel = default);
        Task<T> Delete(T item, CancellationToken cancel = default);
        Task<T> DeleteById(int id, CancellationToken cancel = default);
    }
}

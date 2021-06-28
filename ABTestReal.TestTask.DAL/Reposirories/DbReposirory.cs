using ABTestReal.TestTask.DAL.Context;
using ABTestReal.TestTask.DAL.Entities;
using ABTestReal.TestTask.Service.Reposirories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABTestReal.TestTask.DAL.Reposirories
{
    /// <summary>
    /// Базовый репозиторий, работающий со всеми сущностями
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbReposirory<T> : IRepository<T> where T : Entity, new ()
    {
        private readonly DataDb _db;

        /// <summary>
        /// Список (набор) сущностей, хранящихся в базе данных
        /// </summary>
        protected DbSet<T> Set { get; }

        /// <summary>
        /// Уточнение списка (набора) сущностей  
        /// </summary>
        protected virtual IQueryable<T> Items => Set;

        public DbReposirory(DataDb db)
        {
            _db = db;
            Set =_db.Set<T>();
        }
        public async  Task<T> Add(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            await Set.AddAsync(item, cancel).ConfigureAwait(false);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return item;
        }

        public async Task<T> Delete(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            if (!await ExistId(item.Id, cancel))
            {
                return null;
            }

            _db.Remove(item);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return item;

        }

        public async Task<T> DeleteById(int id, CancellationToken cancel = default)
        {
            var item = Set.Local.FirstOrDefault(i => i.Id == id);

            if (item is null)
            {
                item = await Set
                    .Select(x => new T { Id = x.Id})
                    .FirstOrDefaultAsync(i => i.Id == id, cancel).ConfigureAwait(false);
            }

            if (item is null)
                return null;

            return await this.Delete(item, cancel).ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancel = default)
        {
            return await Items.ToArrayAsync(cancel).ConfigureAwait(false);
        }

        public async Task<T> GetById(int id, CancellationToken cancel = default)
        {
            switch (Items)
            {
                case DbSet<T> set:
                    return await set.FindAsync(new object[] { id }, cancel).ConfigureAwait(false);
                case { } items:
                    return await Items.FirstOrDefaultAsync(x => x.Id == id, cancel).ConfigureAwait(false);
                default:
                    throw new InvalidOperationException("Ошибка в определении источника данных"); 
            }
           
        }

        public async Task<T> Update(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            _db.Update(item);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return item;
        }

        public async Task<bool> ExistId(int id, CancellationToken cancel = default)
        {
            return await Set.AnyAsync(x => x.Id == id, cancel).ConfigureAwait(false);
        }
    }
}

using ABTestReal.TestTask.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABTestReal.TestTask.Interfaces.RollingRetentioService
{
    public interface IRollingRetentionService<T> where T : IUserEntity
    {
        /// <summary>
        /// возвращает Rolling Retention 
        /// </summary>
        /// <param name="userEntities">Пользователи</param>
        /// <param name="day">Интервал </param>
        /// <returns></returns>
        IEnumerable<int> GetRollingRetentionXDay(IEnumerable<T> userEntities, int day);
    }
}

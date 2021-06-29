using ABTestReal.TestTask.DAL.Entities;
using ABTestReal.TestTask.Interfaces.Entities;
using ABTestReal.TestTask.Interfaces.Reposirories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using ABTestReal.TestTask.Interfaces.RollingRetentioService;

namespace ABTestReal.TestTask.Services.RollingRetentioService
{
    public class RollingRetentionService<T> : IRollingRetentionService<T> where T : IUserEntity
    {
        
        public IEnumerable<int> GetRollingRetentionXDay(IEnumerable<T> userEntities, int day)
        {
            return  Enumerable.Range(1, day)
                     .Select(i => new
                     {
                         Key = i,
                         Values = userEntities.Where(d => (d.DateLastActivity - d.DateRegistration).Days >= i)
                     }).Select(x => (int)(((double)x.Values.Count() / (double)userEntities.Count()) * 100));                  
        }
    }
}

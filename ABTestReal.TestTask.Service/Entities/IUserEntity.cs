using System;
using System.Collections.Generic;
using System.Text;

namespace ABTestReal.TestTask.Interfaces.Entities
{
    public interface IUserEntity : IEntity
    {
        /// <summary>
        /// Дата регистрации пользователя
        /// </summary>
        public DateTime DateRegistration { get; }
        
        /// <summary>
        /// Дата последней активности пользователя
        /// </summary>
        public DateTime DateLastActivity { get; }
    }
}

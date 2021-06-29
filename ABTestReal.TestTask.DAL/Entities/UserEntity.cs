using ABTestReal.TestTask.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABTestReal.TestTask.DAL.Entities
{
    public class UserEntity : Entity, IUserEntity
    {        
        public DateTime DateRegistration { get; set; }
        public DateTime DateLastActivity { get; set; }        
    }
}

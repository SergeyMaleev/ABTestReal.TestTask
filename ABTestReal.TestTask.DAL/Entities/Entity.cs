using ABTestReal.TestTask.Service.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABTestReal.TestTask.DAL.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        
    }
}

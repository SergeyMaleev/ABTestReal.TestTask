using ABTestReal.TestTask.Service.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABTestReal.TestTask.DAL.Entities
{
    public abstract class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
        
    }
}

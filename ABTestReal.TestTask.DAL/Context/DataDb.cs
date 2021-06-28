using ABTestReal.TestTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABTestReal.TestTask.DAL.Context
{
    public class DataDb : DbContext
    {
        public DbSet<UserEntity> UserEntity { get; set; }

        public DataDb(DbContextOptions<DataDb> options) : base(options) { }      
    }
}

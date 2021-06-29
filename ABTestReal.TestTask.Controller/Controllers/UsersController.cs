using ABTestReal.TestTask.Controller.Controllers.Base;
using ABTestReal.TestTask.DAL.Entities;
using ABTestReal.TestTask.Interfaces.Reposirories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABTestReal.TestTask.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : EntityController<UserEntity>
    {
        public UsersController(IRepository<UserEntity> repository) : base(repository) { }       
    }
}

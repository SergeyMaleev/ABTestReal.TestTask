using ABTestReal.TestTask.DAL.Entities;
using ABTestReal.TestTask.Interfaces.Reposirories;
using ABTestReal.TestTask.Interfaces.RollingRetentioService;
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
    public class RollingRetentionController : ControllerBase
    {
        private readonly IRollingRetentionService<UserEntity> _retentionService;
        private readonly IRepository<UserEntity> _repository;

        public RollingRetentionController(IRollingRetentionService<UserEntity> retentionService, IRepository<UserEntity> repository)
        {
            _repository = repository;
            _retentionService = retentionService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var users = await _repository.GetAll();

            return Ok(_retentionService.GetRollingRetentionXDay(users, id));
        }
    }
}

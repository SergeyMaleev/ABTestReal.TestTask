using ABTestReal.TestTask.DAL.Entities;
using ABTestReal.TestTask.Service.Reposirories;
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
    public class UsersController : ControllerBase
    {
        private readonly IRepository<UserEntity> _repository;

        public UsersController(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers()
        {
           return Ok( await _repository.GetAll());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(int id)
        {
            var item = await _repository.GetById(id);

            if (item is not null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]       
        public async Task<IActionResult> Add(UserEntity item)
        {
            var result = await _repository.Add(item);

            return CreatedAtAction(nameof(GetUser), new { id = result.Id }, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(UserEntity item)
        {
            var result = await _repository.Update(item);

            if (result is null)
            {
                return NotFound(item);
            }

            return AcceptedAtAction(nameof(GetUser), new { id = result.Id }, result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(UserEntity item)
        {
            var result = await _repository.Delete(item);

            if (result is null)
            {
                return NotFound(item);
            }

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteById(id);

            if (result is null)
            {
                return NotFound(id);
            }

            return Ok(result);
        }
       

    }
}

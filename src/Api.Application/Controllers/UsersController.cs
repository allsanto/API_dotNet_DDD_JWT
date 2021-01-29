using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // BadRequest retorna um código HTTP 400, servidor não entendeu a requisição.
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e) // ArgumentException Para tratrar erros de controllers
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //localhost:5000/api/users/35432
        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // BadRequest retorna um código HTTP 400, servidor não entendeu a requisição.
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e) // ArgumentException Para tratrar erros de controllers
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserEntity user) // FromBody serve para um método que recebe um corpo
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // BadRequest retorna um código HTTP 400, servidor não entendeu a requisição.
            }

            try
            {
                var result = await _service.Post(user);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e) // ArgumentException Para tratrar erros de controllers
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserEntity user) // FromBody serve para um método que recebe um corpo
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(user);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e) // ArgumentException Para tratrar erros de controllers
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // BadRequest retorna um código HTTP 400, servidor não entendeu a requisição.
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e) // ArgumentException Para tratrar erros de controllers
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}

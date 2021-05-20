using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Items;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private IItemService _service;
        public ItemController(IItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch(ArgumentException ex)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetById")]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch(ArgumentException ex)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
       

    	[HttpPost]
        public async Task<ActionResult> Post([FromBody] ItemDto item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(item);

                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetById", new {id = result.Id})), result);
                }
                else
                {
                    return BadRequest();
                }                
            }
            catch(ArgumentException ex)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ItemDto item)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(item);

                if (result != null)
                {
                    return Ok(result);
                }
                else 
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(false);
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
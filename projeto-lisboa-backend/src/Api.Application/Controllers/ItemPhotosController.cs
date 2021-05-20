using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Items;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemPhotosController : ControllerBase
    {
        private IItemPhotosService _service;
        public ItemPhotosController(IItemPhotosService service)
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
        [Route("{id}")]
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

        //[HttpPost]
        //public async Task<ActionResult> Upload([FromForm] FileDto file)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        string fileName = $"file.FilenName_{Guid.NewGuid()}";

        //        string path = Path.Combine(Directory.GetCurrentDirectory(), "images", fileName);

        //        using(Stream s = new FileStream(path, FileMode.Create))
        //        {
        //            file.FormFile.CopyTo(s);
        //        }

        //        return Created(new Uri(Url.Link("GetById", new { fileName = fileName })), file);

        //        //var result = await _service.Post(item);

        //        //if (result != null)
        //        //{
        //        //    return Created(new Uri(Url.Link("GetById", new { id = result.Id })), result);
        //        //}
        //        //else
        //        //{
        //        //    return BadRequest();
        //        //}
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ItemPhotosDto item)
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
        public async Task<ActionResult> Put([FromBody] ItemPhotosDto item)
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
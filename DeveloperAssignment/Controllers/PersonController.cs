using Core.Entities;
using Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Security.Claims;

namespace DeveloperAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
          return Ok (await _repository.GetAll()); 

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetbyId(int id)
        {
            return Ok(await _repository.GetById(id));

        }

        [HttpPost]
        public async Task<ActionResult<Person>> Add(Person person)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(person);
                return Ok(person);

            }
            return BadRequest();


        }


        [HttpPut]
        public async Task<ActionResult> Update(int id, Person person)
        {
            try
            {
                if (id != person?.Id)
                    return BadRequest();
                var UpdatedPerson = await _repository.GetById(id);

                if (UpdatedPerson == null)
                    return NotFound();
                return Ok(await _repository.Update(person));

            }
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return Ok();
        }



        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            var person = await _repository.GetById(Id);

            if (Id != person?.Id)
                return BadRequest();
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.Delete(Id);

                    return Ok(person);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return Ok();
            

        }

       
    }
}

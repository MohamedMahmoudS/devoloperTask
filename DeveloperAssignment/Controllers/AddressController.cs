using Core.Entities;
using Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _repository;

        public AddressController(IAddressRepository repository)
        {
            _repository=repository; 
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetbyId(int id)
        {
            return Ok(await _repository.GetById(id));

        }

        [HttpPost]
        public async Task<ActionResult<Address>> Add(Address address)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(address);
                return Ok(address);

            }
            return BadRequest();


        }


        [HttpPut]
        public async Task<ActionResult> Update(int id, Address address)
        {
            try
            {
                if (id != address?.Id)
                    return BadRequest();
                var UpdatedAddress = await _repository.GetById(id);

                if (UpdatedAddress == null)
                    return NotFound();
                return Ok(await _repository.Update(address));

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
            var address = await _repository.GetById(Id);

            if (Id != address?.Id)
                return BadRequest();
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.Delete(Id);

                    return Ok(address);
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

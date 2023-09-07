using Core.Entities;
using Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PersonRepository : IPersonRepository
    {

        private readonly DBContext _dbContext;

        public PersonRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Person entity)
        {
            await _dbContext.Set<Person>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }

        

        public async Task<IEnumerable<Person>> Update(Person entity)
        {
            var result = await _dbContext.Person.FirstOrDefaultAsync(a => a.Id == entity.Id);
            if (result != null)
            {
                result.Name = entity.Name;
                result.Email = entity.Email;
                //result.Address.Country = entity.Address.Country;
                //result.Address.City = entity.Address.City;
                //result.Address.Building = entity.Address.Building;
                //result.Address.Floor = entity.Address.Floor;

                await _dbContext.SaveChangesAsync();
                return (IEnumerable<Person>)result;
            }
            return null; 

        }

        public async Task Delete(int Id)
        {
            
            var result = await _dbContext.Person.FirstOrDefaultAsync(x => x.Id == Id);
            if(result != null)
            {
                _dbContext.Person.Remove(result);
                await _dbContext.SaveChangesAsync();    
            }
            
        }
  
        public async Task<IEnumerable<PersonDTO>> GetAll()
        {
            return await _dbContext.Person
                .Include(a => a.Address)
                 .Select(a => new PersonDTO()
                 {
                     Id = a.Id,
                     Name = a.Name,
                     Email = a.Email,
                     Country = a.Address.Country,
                     City = a.Address.City,
                     Building = a.Address.Building,
                     Floor = a.Address.Floor,
                 })
                 .ToListAsync();

        }

        public async Task<PersonDTO?> GetById(int id)
        {
            return await _dbContext.Person
                 .Include(a => a.Address)
                 .Select(a => new PersonDTO()
                 {
                     Id = a.Id,
                     Name = a.Name,
                     Email = a.Email,
                     Country = a.Address.Country,
                     City = a.Address.City,
                     Building = a.Address.Building,
                     Floor = a.Address.Floor,
                 })

                .FirstOrDefaultAsync(a => a.Id == id);
        }

        
    }
}

using Core.Entities;
using Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AddressRepository :IAddressRepository
    {
        private readonly DBContext _dbContext;

        public AddressRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Address entity)
        {
            await _dbContext.Set<Address>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }



        public async Task<IEnumerable<Address>> Update(Address entity)
        {
            var result = await _dbContext.Address.FirstOrDefaultAsync(a => a.Id == entity.Id);
            if (result != null)
            {

                result.Country = entity.Country;
                result.City = entity.City;
                result.Building = entity.Building;
                result.Floor = entity.Floor;

                await _dbContext.SaveChangesAsync();
                return (IEnumerable<Address>)result;
            }
            return null;

        }

        public async Task Delete(int Id)
        {

            var result = await _dbContext.Address.FirstOrDefaultAsync(x => x.Id == Id);
            if (result != null)
            {
                _dbContext.Address.Remove(result);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await _dbContext.Address.ToListAsync();
               

        }

        public async Task<Address?> GetById(int id)
        {
            return await _dbContext.Address.FirstOrDefaultAsync(a => a.Id == id);
                
                
        }
    }
}

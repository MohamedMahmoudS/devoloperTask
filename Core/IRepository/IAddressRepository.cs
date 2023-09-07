using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IAddressRepository
    {
        Task Add(Address entity);
        Task<IEnumerable<Address>> Update(Address entity);
        Task Delete(int id);

        Task<IEnumerable<Address>> GetAll();

        Task<Address?> GetById(int id);
    }
}

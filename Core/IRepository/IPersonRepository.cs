using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IPersonRepository
    {
        Task Add(Person entity);
        Task<IEnumerable<Person>> Update(Person entity);
        Task Delete(int id);

        Task<IEnumerable<PersonDTO>> GetAll();

        Task<PersonDTO?> GetById(int id);



    }
}

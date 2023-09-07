using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public class PersonDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Building { get; set; }

        public string Floor { get; set; }



    }
}

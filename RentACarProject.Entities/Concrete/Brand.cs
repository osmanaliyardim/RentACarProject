using RentACarProject.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Entity.Concrete
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

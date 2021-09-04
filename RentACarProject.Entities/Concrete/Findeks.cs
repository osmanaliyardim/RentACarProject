using RentACarProject.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Entity.Concrete
{
    public class Findeks : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string NatinonalIdentity { get; set; }
        public short Score { get; set; }
    }
}

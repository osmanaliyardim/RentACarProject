﻿using RentACarProject.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Entity.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string NameSurname { get; set; }
        public string CardNumber { get; set; }
        public byte ExpMonth { get; set; }
        public byte ExpYear { get; set; }
        public string Cvc { get; set; }
        public string CardType { get; set; }
    }
}

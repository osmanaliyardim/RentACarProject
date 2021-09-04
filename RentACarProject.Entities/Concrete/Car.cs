﻿using RentACarProject.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Entity.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public short? MinFindeksScore { get; set; }
    }
}

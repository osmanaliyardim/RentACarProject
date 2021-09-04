﻿using RentACarProject.Core.Entity.Abstract;
using System;

namespace RentACarProject.Entity.Concrete
{
    public class CarImage : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}

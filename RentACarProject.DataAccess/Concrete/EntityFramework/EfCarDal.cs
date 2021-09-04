﻿using RentACarProject.Core.DataAccess.Concrete.EntityFramework;
using RentACarProject.DataAccess.Abstract;
using RentACarProject.DataAccess.Concrete.EntityFramework.Context;
using RentACarProject.Entity.Concrete;

namespace RentACarProject.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarProjectContext>, ICarDal
    {
    }
}

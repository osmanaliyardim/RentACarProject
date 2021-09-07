using RentACarProject.Core.DataAccess.Concrete.EntityFramework;
using RentACarProject.DataAccess.Abstract;
using RentACarProject.DataAccess.Concrete.EntityFramework.Context;
using RentACarProject.Entities.DTOs;
using RentACarProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RentACarProject.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null) //AutoMapper TODO
        {
            using (var context = new RentACarProjectContext())
            {
                var result = (from p in context.Cars
                             join b in context.Brands on p.BrandId equals b.Id
                             join c in context.Colors on p.ColorId equals c.Id
                             select new CarDetailDto
                             {
                                 Id = p.Id,
                                 CarName = p.Name,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 DailyPrice = p.DailyPrice,
                                 ModelYear = p.ModelYear
                             }).ToList();

                //return filter == null ? result : result.Where(filter);    TODO
                return result;
            }
        }
    }
}

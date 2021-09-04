using RentACarProject.Core.DataAccess.Abstract;
using RentACarProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
    }
}

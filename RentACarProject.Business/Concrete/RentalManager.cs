using RentACarProject.Business.Abstract;
using RentACarProject.Core.Utilities.Results.Abstract;
using RentACarProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        public IResult Add(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IResult CheckFindeksScoreSufficiency(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IResult CheckReturnDateByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult IsRentable(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}

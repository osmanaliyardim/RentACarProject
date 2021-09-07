using RentACarProject.Core.Utilities.Results.Abstract;
using RentACarProject.Entity.Concrete;
using System.Collections.Generic;

namespace RentACarProject.Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);
        IDataResult<List<Rental>> GetAllByCarId(int carId);
        IResult CheckReturnDateByCarId(int carId);
        IResult IsRentable(Rental rental);
        IResult CheckFindeksScoreSufficiency(Rental rental);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}

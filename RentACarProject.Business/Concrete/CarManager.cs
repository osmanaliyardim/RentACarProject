using RentACarProject.Business.Abstract;
using RentACarProject.Business.Constants;
using RentACarProject.Business.ValidationRules.FluentValidation;
using RentACarProject.Core.Aspects.Autofac.Validation;
using RentACarProject.Core.Utilities.Results.Abstract;
using RentACarProject.Core.Utilities.Results.Concrete;
using RentACarProject.DataAccess.Abstract;
using RentACarProject.Entities.DTOs;
using RentACarProject.Entity.Concrete;
using System.Collections.Generic;

namespace RentACarProject.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car> GetById()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorNameAndBrandName(string colorName, string brandName)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Car> GetCarsByBrandId(int brandId)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Car> GetCarsByColorId(int colorId)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}

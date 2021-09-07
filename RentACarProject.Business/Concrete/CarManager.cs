using RentACarProject.Business.Abstract;
using RentACarProject.Business.BusinessAspects.Autofac;
using RentACarProject.Business.Constants;
using RentACarProject.Business.ValidationRules.FluentValidation;
using RentACarProject.Core.Aspects.Autofac.Caching;
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

        [ValidationAspect(typeof(CarValidator), Priority = 2)]
        [SecuredOperation("car.add,admin,moderator", Priority = 1)]
        [CacheRemoveAspect("ICarService.Get", Priority = 3)] //Eğer başarıyla ekleme yapılırsa, Get ile başlayan tüm operasyonları bellekten uçur
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("car.delete,admin,moderator")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [SecuredOperation("car.list")]
        [CacheAspect(120)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<Car> GetById()
        {
            throw new System.NotImplementedException();
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            throw new System.NotImplementedException();
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName)
        {
            throw new System.NotImplementedException();
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName)
        {
            throw new System.NotImplementedException();
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorNameAndBrandName(string colorName, string brandName)
        {
            throw new System.NotImplementedException();
        }

        [CacheAspect]
        public IDataResult<Car> GetCarsByBrandId(int brandId)
        {
            throw new System.NotImplementedException();
        }

        [CacheAspect]
        public IDataResult<Car> GetCarsByColorId(int colorId)
        {
            throw new System.NotImplementedException();
        }

        [SecuredOperation("car.update,admin,moderator")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}

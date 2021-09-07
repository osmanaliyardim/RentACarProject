﻿using RentACarProject.Business.Abstract;
using RentACarProject.Business.BusinessAspects.Autofac;
using RentACarProject.Business.Constants;
using RentACarProject.Business.ValidationRules.FluentValidation;
using RentACarProject.Core.Aspects.Autofac.Validation;
using RentACarProject.Core.Utilities.Business;
using RentACarProject.Core.Utilities.Results.Abstract;
using RentACarProject.Core.Utilities.Results.Concrete;
using RentACarProject.DataAccess.Abstract;
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
        private readonly ICarService _carService;
        private readonly IFindeksService _findeksService;
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal, ICarService carService, IFindeksService findeksService)
        {
            _carService = carService;
            _findeksService = findeksService;
            _rentalDal = rentalDal;
        }

        [SecuredOperation("user,rental.get,moderator,admin")]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        [SecuredOperation("user,rental.get,moderator,admin")]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }

        [SecuredOperation("user,rental.add,moderator,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(IsRentable(rental), CheckFindeksScoreSufficiency(rental));
            if (result != null) return result;

            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);
        }

        [SecuredOperation("rental.update,moderator,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental customer)
        {
            _rentalDal.Update(customer);

            return new SuccessResult(Messages.RentalUpdated);
        }

        [SecuredOperation("rental.delete,moderator,admin")]
        public IResult Delete(Rental customer)
        {
            _rentalDal.Delete(customer);

            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult CheckReturnDateByCarId(int carId)
        {
            var result = _rentalDal.GetAll(x => x.CarId == carId && x.ReturnDate == null);
            if (result.Count > 0) return new ErrorResult(Messages.RentalUndeliveredCar);

            return new SuccessResult();
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult IsRentable(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);

            if (result.Any(r =>
                r.RentEndDate >= rental.RentStartDate &&
                r.RentStartDate <= rental.RentEndDate
            )) return new ErrorResult(Messages.RentalNotAvailable);

            return new SuccessResult();
        }

        public IResult CheckFindeksScoreSufficiency(Rental rental)
        {
            var car = _carService.GetById(rental.CarId).Data;
            var findeks = _findeksService.GetByCustomerId(rental.CustomerId).Data;

            if (findeks == null) return new ErrorResult(Messages.FindeksNotFound);
            if (findeks.Score < car.MinFindeksScore) return new ErrorResult(Messages.FindeksNotEnoughForCar);

            return new SuccessResult();
        }
    }
}

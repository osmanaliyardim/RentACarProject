using RentACarProject.Business.Abstract;
using RentACarProject.Business.Constants;
using RentACarProject.Core.Utilities.Results.Abstract;
using RentACarProject.Core.Utilities.Results.Concrete;
using RentACarProject.DataAccess.Abstract;
using RentACarProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentACarProject.Business.Concrete
{
    public class FakeFindeksManager : IFindeksService
    {
        private readonly IFindeksDal _findeksDal;

        public FakeFindeksManager(IFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }

        public IResult Add(Findeks findeks)
        {
            var calculatedFindeksScore = CalculateFindeksScore(findeks).Data;
            _findeksDal.Add(calculatedFindeksScore);

            return new SuccessResult(Messages.FindeksAdded);
        }

        // This is a fake calculation of findeks score (for simulation).
        public IDataResult<Findeks> CalculateFindeksScore(Findeks findeks)
        {
            findeks.Score = (short)new Random().Next(0, 1901);

            return new SuccessDataResult<Findeks>(findeks);
        }

        public IResult Delete(Findeks findeks)
        {
            _findeksDal.Delete(findeks);

            return new SuccessResult(Messages.FindeksDeleted);
        }

        public IDataResult<List<Findeks>> GetAll()
        {
            return new SuccessDataResult<List<Findeks>>(_findeksDal.GetAll());
        }

        public IDataResult<Findeks> GetByCustomerId(int customerId)
        {
            var findeks = _findeksDal.Get(x => x.CustomerId == customerId);
            if (findeks == null) return new ErrorDataResult<Findeks>(Messages.FindeksNotFound);

            return new SuccessDataResult<Findeks>(findeks);
        }

        public IDataResult<Findeks> GetById(int id)
        {
            return new SuccessDataResult<Findeks>(_findeksDal.Get(x => x.Id == id));
        }

        public IResult Update(Findeks findeks)
        {
            var calculatedFindeksScore = CalculateFindeksScore(findeks).Data;
            _findeksDal.Update(calculatedFindeksScore);

            return new SuccessResult(Messages.FindeksUpdated);
        }
    }
}

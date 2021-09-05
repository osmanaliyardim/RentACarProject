using RentACarProject.Core.Utilities.Results.Abstract;
using RentACarProject.Entity.Concrete;
using System.Collections.Generic;

namespace RentACarProject.Business.Abstract
{
    public interface IFindeksService
    {
        IDataResult<List<Findeks>> GetAll();
        IDataResult<Findeks> GetById(int id);
        IDataResult<Findeks> GetByCustomerId(int customerId);
        IResult Add(Findeks findeks);
        IResult Update(Findeks findeks);
        IResult Delete(Findeks findeks);

        IDataResult<Findeks> CalculateFindeksScore(Findeks findeks);
    }
}

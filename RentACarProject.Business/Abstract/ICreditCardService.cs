using RentACarProject.Core.Utilities.Results.Abstract;
using RentACarProject.Entity.Concrete;
using System.Collections.Generic;

namespace RentACarProject.Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAllByCustomerId(int customerId);
        IDataResult<CreditCard> GetById(int id);
        IResult Add(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
    }
}

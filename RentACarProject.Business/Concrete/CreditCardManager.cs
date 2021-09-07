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
    public class CreditCardManager : ICreditCardService
    {
        public IResult Add(CreditCard creditCard)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CreditCard creditCard)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CreditCard>> GetAllByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CreditCard> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

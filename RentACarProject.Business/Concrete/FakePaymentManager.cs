using RentACarProject.Business.Abstract;
using RentACarProject.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Business.Concrete
{
    public class FakePaymentManager : IPaymentService
    {
        public IResult MakePayment()
        {
            throw new NotImplementedException();
        }
    }
}

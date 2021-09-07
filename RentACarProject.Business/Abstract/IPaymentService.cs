using RentACarProject.Core.Utilities.Results.Abstract;

namespace RentACarProject.Business.Abstract
{
    public interface IPaymentService
    {
        IResult MakePayment();
    }
}

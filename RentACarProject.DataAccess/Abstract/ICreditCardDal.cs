using RentACarProject.Core.DataAccess.Abstract;
using RentACarProject.Entity.Concrete;

namespace RentACarProject.DataAccess.Abstract
{
    public interface ICreditCardDal : IEntityRepository<CreditCard>
    {
    }
}

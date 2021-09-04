using RentACarProject.Core.DataAccess.Concrete.EntityFramework;
using RentACarProject.Core.Entity.Concrete;
using RentACarProject.DataAccess.Abstract;
using RentACarProject.DataAccess.Concrete.EntityFramework.Context;

namespace RentACarProject.DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, RentACarProjectContext>, IOperationClaimDal
    {
    }
}

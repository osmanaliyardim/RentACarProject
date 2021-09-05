using RentACarProject.Core.Entity.Concrete;
using RentACarProject.Core.Utilities.Results.Abstract;
using System.Collections.Generic;

namespace RentACarProject.Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<List<UserOperationClaim>> GetAll();
        IDataResult<UserOperationClaim> GetById(int id);
        IResult Add(UserOperationClaim userOperationClaim);
        IResult Update(UserOperationClaim userOperationClaim);
        IResult Delete(UserOperationClaim userOperationClaim);

        IResult AddUserClaim(User user);
    }
}

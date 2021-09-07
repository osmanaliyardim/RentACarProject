using RentACarProject.Core.Entity.Concrete;
using System.Collections.Generic;

namespace RentACarProject.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}

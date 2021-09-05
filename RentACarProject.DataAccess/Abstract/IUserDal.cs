using RentACarProject.Core.DataAccess.Abstract;
using RentACarProject.Core.Entity.Concrete;
using RentACarProject.Entities.DTOs;
using System.Collections.Generic;

namespace RentACarProject.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);

        UserDetailDto GetUserDetail(string userMail);
    }
}

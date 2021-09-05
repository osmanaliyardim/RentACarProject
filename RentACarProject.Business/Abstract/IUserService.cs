using RentACarProject.Core.Entity.Concrete;
using RentACarProject.Core.Utilities.Results.Abstract;
using RentACarProject.Entities.DTOs;
using System.Collections.Generic;

namespace RentACarProject.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IDataResult<User> GetByMail(string email);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        
        IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdateDto);
        IDataResult<UserDetailDto> GetUserDetailByMail(string mail);

        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}

using RentACarProject.Core.Entity.Concrete;
using RentACarProject.Core.Utilities.Results.Abstract;
using RentACarProject.Core.Utilities.Security.JWT;
using RentACarProject.Entities.DTOs;
using System.Collections.Generic;

namespace RentACarProject.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForRegisterDto userForRegisterDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult IsAuthenticated(string email, List<string> requiredRoles);
    }
}

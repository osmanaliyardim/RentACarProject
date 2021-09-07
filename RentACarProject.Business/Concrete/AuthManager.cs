using RentACarProject.Business.Abstract;
using RentACarProject.Business.BusinessAspects.Autofac;
using RentACarProject.Business.Constants;
using RentACarProject.Core.Entity.Concrete;
using RentACarProject.Core.Utilities.Results.Abstract;
using RentACarProject.Core.Utilities.Results.Concrete;
using RentACarProject.Core.Utilities.Security.Hashing;
using RentACarProject.Core.Utilities.Security.JWT;
using RentACarProject.Entities.DTOs;
using RentACarProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentACarProject.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ICustomerService _customerService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IUserService _userService;

        public AuthManager(ICustomerService customerService, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService, IUserService userService)
        {
            _customerService = customerService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
            _userService = userService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claimResult = _userService.GetClaims(user);
            if (!claimResult.Success) return new ErrorDataResult<AccessToken>(claimResult.Message);

            var accessToken = _tokenHelper.CreateToken(user, claimResult.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        [SecuredOperation("user")]
        public IResult IsAuthenticated(string email, List<string> requiredRoles)
        {
            if(requiredRoles != null)
            {
                var user = _userService.GetByMail(email).Data;
                var userClaims = _userService.GetClaims(user).Data;
                var doesUserHaveRequiredRoles = requiredRoles.All(role => userClaims.Select(userClaims => userClaims.Name).Contains(role));

                if (!doesUserHaveRequiredRoles) return new ErrorResult(Messages.UnAuthorized);
            }

            return new SuccessResult(Messages.Authorized);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheckResult = _userService.GetByMail(userForLoginDto.Email);
            if (!userToCheckResult.Success) return new ErrorDataResult<User>(userToCheckResult.Message);

            var userToCheck = userToCheckResult.Data;
            if (userToCheck == null) return new ErrorDataResult<User>(Messages.UserNotFound);

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                return new ErrorDataResult<User>(Messages.WrongPassword);

            return new SuccessDataResult<User>(userToCheck, Messages.LoginSuccessfull);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHassh(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var newUser = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(newUser);

            var user = _userService.GetByMail(userForRegisterDto.Email).Data;
            _userOperationClaimService.AddUserClaim(user);

            var newCustomer = new Customer
            { 
                UserId = user.Id,
                CompanyName = $"{user.FirstName} {user.LastName}"
            };
            _customerService.Add(newCustomer);

            return new SuccessDataResult<User>(user, Messages.RegisterSuccessfull);
        }

        public IResult UserExists(string email)
        {
            var userResult = _userService.GetByMail(email);

            if (!userResult.Success) return new ErrorResult(userResult.Message);
            if (userResult.Data != null) return new ErrorResult(Messages.UserAlreadyExists);

            return new SuccessResult();
        }
    }
}

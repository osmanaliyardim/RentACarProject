using RentACarProject.Business.Abstract;
using RentACarProject.Business.BusinessAspects.Autofac;
using RentACarProject.Business.Constants;
using RentACarProject.Core.Entity.Concrete;
using RentACarProject.Core.Utilities.Results.Abstract;
using RentACarProject.Core.Utilities.Results.Concrete;
using RentACarProject.Core.Utilities.Security.Hashing;
using RentACarProject.DataAccess.Abstract;
using RentACarProject.Entities.DTOs;
using RentACarProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentACarProject.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IFindeksDal _findeksDal;
        private readonly IFindeksService _findeksService;
        private readonly IUserDal _userDal;

        public UserManager(ICustomerDal customerDal, IFindeksDal findeksDal, IFindeksService findeksService, IUserDal userDal)
        {
            _customerDal = customerDal;
            _findeksDal = findeksDal;
            _findeksService = findeksService;
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult(Messages.UserAdded);
        }

        [SecuredOperation("user.delete,admin,moderator")]
        public IResult Delete(User user)
        {
            _userDal.Add(user);

            return new SuccessResult(Messages.UserDeleted);
        }

        [SecuredOperation("user.get,admin,moderator")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        [SecuredOperation("user.get,admin,moderator")]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(x=>x.Id == id));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<UserDetailDto> GetUserDetailByMail(string mail)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetail(mail));
        }

        [SecuredOperation("user.update,admin,moderator")]
        public IResult Update(User user)
        {
            _userDal.Update(user);

            return new SuccessResult(Messages.UserUpdated);
        }

        [SecuredOperation("user")]
        public IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdateDto)
        {
            var user = GetById(userDetailForUpdateDto.Id).Data;

            if (!HashingHelper.VerifyPasswordHash(userDetailForUpdateDto.CurrentPassword, user.PasswordHash, user.PasswordSalt))
                return new ErrorResult(Messages.WrongPassword);

            user.FirstName = userDetailForUpdateDto.FirstName;
            user.LastName = userDetailForUpdateDto.LastName;

            if (!string.IsNullOrEmpty(userDetailForUpdateDto.NewPassword))
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHassh(userDetailForUpdateDto.NewPassword, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _userDal.Update(user);

            var customer = _customerDal.Get(x => x.Id == userDetailForUpdateDto.CustomerId);
            customer.CompanyName = userDetailForUpdateDto.CompanyName;

            _customerDal.Update(customer);

            if (!string.IsNullOrEmpty(userDetailForUpdateDto.NationalIdentity))
            {
                var findeks = _findeksService.GetByCustomerId(userDetailForUpdateDto.CustomerId).Data;

                if(findeks != null)
                {
                    var newFindeks = new Findeks
                    {
                        CustomerId = userDetailForUpdateDto.CustomerId,
                        NatinonalIdentity = userDetailForUpdateDto.NationalIdentity
                    };

                    _findeksService.Add(newFindeks);
                }
                else
                {
                    findeks.NatinonalIdentity = userDetailForUpdateDto.NationalIdentity;

                    var calculatedFindeksScore = _findeksService.CalculateFindeksScore(findeks).Data;

                    _findeksDal.Update(calculatedFindeksScore);
                }
            }

            return new SuccessResult(Messages.UserDetailsUpdated);
        }
    }
}

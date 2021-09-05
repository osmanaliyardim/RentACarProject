using RentACarProject.Core.DataAccess.Concrete.EntityFramework;
using RentACarProject.Core.Entity.Concrete;
using RentACarProject.DataAccess.Abstract;
using RentACarProject.DataAccess.Concrete.EntityFramework.Context;
using RentACarProject.Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace RentACarProject.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarProjectContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user) //Automapper incele TODO
        {
            using (var context = new RentACarProjectContext())
            {
                var result = (from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             }).ToList();

                return result;
            }
        }

        public UserDetailDto GetUserDetail(string userMail)
        {
            using (var context = new RentACarProjectContext())
            {
                var result = (from user in context.Users
                              join customer in context.Customers
                              on user.Id equals customer.UserId
                              where user.Email == userMail
                              select new UserDetailDto
                              {
                                  Id = user.Id,
                                  CustomerId = customer.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  Email = user.Email,
                                  CompanyName = customer.CompanyName
                              }).First();

                return result;
            }
        }
    }
}

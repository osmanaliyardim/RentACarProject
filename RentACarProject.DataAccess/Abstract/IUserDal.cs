﻿using RentACarProject.Core.DataAccess.Abstract;
using RentACarProject.Core.Entity.Concrete;

namespace RentACarProject.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}

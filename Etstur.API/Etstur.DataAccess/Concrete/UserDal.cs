using Etstur.DataAccess.Abstract;
using Etstur.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Etstur.DataAccess.Concrete
{
    public class UserDal : GenericRepository<User, ApplicationDbContext>, IUserDal
    {

    }
}

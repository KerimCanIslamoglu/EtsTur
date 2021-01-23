using Etstur.Business.Abstract;
using Etstur.DataAccess.Abstract;
using Etstur.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Etstur.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void CreateUser(User user)
        {
            _userDal.Create(user);
        }

        public List<User> GetUsers()
        {
            return _userDal.GetAll();
        }
    }
}

using Etstur.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Etstur.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetUsers();
        void CreateUser(User user);
    }
}

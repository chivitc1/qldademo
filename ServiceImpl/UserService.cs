using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons;
using Dto;
using Entity;
using ServiceContract;

namespace ServiceImpl
{
    public class UserService : IUserService
    {
        public bool Authenticate(UserLoginDto userInfo)
        {
            userInfo.Password = userInfo.Password.ToMD5Hash();
            using (var db = new A77DbContext())
            {
                
                if (db.User.Any(u => u.UserName.ToLower() == userInfo.UserName.ToLower() && userInfo.Password == u.Password))
                    return true;
            }
            return false;
            
        }

        public void ChangePassword(ChangePasswordDto userInfo)
        {
            throw new NotImplementedException();
        }
    }
}

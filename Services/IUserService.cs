using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;

namespace ServiceContract
{
    public interface IUserService
    {
        void Login(UserLoginDto userInfo);
        void ChangePassword(ChangePasswordDto userInfo);
    }
}

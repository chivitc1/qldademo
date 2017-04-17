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
        bool Authenticate(UserLoginDto userInfo);
        void ChangePassword(ChangePasswordDto userInfo);
    }
}

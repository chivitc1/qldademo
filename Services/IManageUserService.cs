using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;

namespace ServiceContract
{
    public interface IManageUserService
    {
        CreateUserResponse Create(CreateUserDto userInfo);
        void ResetPassword(ChangePasswordDto userInfo);
    }
}

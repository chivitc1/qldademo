using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using ServiceContract;

namespace ServiceImpl
{
    public class ManageUserService : IManageUserService
    {
        public CreateUserResponse Create(CreateUserDto userInfo)
        {
            var response = new CreateUserResponse();
            response.Code = CodeType.Created;
            response.Message = "Tạo user thành công.";
            response.Success = true;
            return response;
        }

        public void ResetPassword(ChangePasswordDto userInfo)
        {
            throw new NotImplementedException();
        }
    }
}

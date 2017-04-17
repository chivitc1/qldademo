using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Entity;
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

        public GetDSUserResponse GetDSUsers()
        {
            var response = new GetDSUserResponse();
            response.Success = false;
            using (var db = new A77DbContext())
            {
                var users = db.User.ToList();
                response.Data = new List<ViewUserDto>();
                foreach (var user in users)
                {
                    response.Data.Add(new ViewUserDto
                    {
                        UserName = user.UserName,
                        Code = user.Code,
                        Email = user.Email,
                        FullName = user.FullName
                    });
                }
                response.Success = true;
            }
            return response;
        }

        public void ResetPassword(ChangePasswordDto userInfo)
        {
            throw new NotImplementedException();
        }
    }
}

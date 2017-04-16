using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dto;
using ServiceContract;

namespace WebApi.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private readonly IManageUserService _manageUserService;

        
        public UserController(IManageUserService manageUserService)
        {
            _manageUserService = manageUserService;
        }

        [Route("Create")]
        [HttpPost]
        public CreateUserResponse Create(CreateUserDto userInfo)
        {
            return _manageUserService.Create(userInfo);
        }

        public void ResetPassword(ChangePasswordDto userInfo)
        {
            
        }
    }
}

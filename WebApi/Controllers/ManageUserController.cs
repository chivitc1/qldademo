using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Commons;
using Dto;
using ServiceContract;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [RoutePrefix("users")]
    [AuthorizationRequired]
    public class ManageUserController : ApiController
    {
        private IManageUserService _manageUserService;

        public ManageUserController(IManageUserService manageUserService)
        {
            _manageUserService = manageUserService;
        }

        [HttpGet]
        [Route("all")]
        //[ApiAuthenticationFilter(true)]
        public GetDSUserResponse GetAllUsers()
        {
            return _manageUserService.GetDSUsers();
        }

        /// <summary>
        /// input password is base64 encoded
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [Route("create")]
        [HttpPost]
        public CreateUserResponse Create(CreateUserDto userInfo)
        {
            //normalize username
            userInfo.UserName = userInfo.UserName.ToLower();
            //convert based64 password to md5
            var plainPassword = userInfo.Password.FromBase64ToPlainText();
            userInfo.Password = plainPassword.ToMD5Hash();
            return _manageUserService.Create(userInfo);
        }

        public void ResetPassword(ChangePasswordDto userInfo)
        {

        }

    }
}

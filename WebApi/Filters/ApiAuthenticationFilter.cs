using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using Dto;
using ServiceContract;
using ServiceImpl;
using StructureMap.Attributes;

namespace WebApi.Filters
{
    public class ApiAuthenticationFilter : GenericAuthenticationFilter
    {
        private IUserService _userService = new UserService();
//        [SetterProperty]
//        public IUserService userService
//        {
//            set { _userService = value; }
//            //get { return _userService; }
//        }
        /// <summary>
        /// Default Authentication Constructor
        /// </summary>
        public ApiAuthenticationFilter()
        {
        }

        /// <summary>
        /// AuthenticationFilter constructor with isActive parameter
        /// </summary>
        /// <param name="isActive"></param>
        public ApiAuthenticationFilter(bool isActive)
            : base(isActive)
        {
        }

        /// <summary>
        /// Protected overriden method for authorizing user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            var userInfo = new UserLoginDto
            {
                UserName = username,
                Password = password
            };
            var isAuthen = _userService.Authenticate(userInfo);
            if (isAuthen)
            {
                var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                    basicAuthenticationIdentity.UserName = username;
                return true;
            }
            return false;
        }
    }
}
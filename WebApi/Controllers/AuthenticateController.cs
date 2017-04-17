using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dto;
using ServiceContract;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [RoutePrefix("user")]
    [ApiAuthenticationFilter]
    public class AuthenticateController : ApiController
    {
        private readonly ITokenService _tokenService;

        
        public AuthenticateController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        [Route("authenticate")]
        //[ApiAuthenticationFilter(false)]
        public HttpResponseMessage Authenticate()
        {
            if (System.Threading.Thread.CurrentPrincipal == null ||
                !System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated) return null;
            var basicAuthenticationIdentity = 
                System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
            if (basicAuthenticationIdentity == null) return null;
            var userName = basicAuthenticationIdentity.UserName;
            return GetAuthToken(userName);
        }

        private HttpResponseMessage GetAuthToken(string userName)
        {
            var token = _tokenService.GenerateToken(userName);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token", token.AuthToken);
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
            return response;
        }
    }
}

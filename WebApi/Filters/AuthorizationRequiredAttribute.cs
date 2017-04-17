using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Commons;
using ServiceContract;
using ServiceImpl;

namespace WebApi.Filters
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        private const string Token = Constants.TokenHeaderName;
        private ITokenService _tokenService = new TokenService();

        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            if (filterContext.Request.Headers.Contains(Token))
            {
                var tokenValue = filterContext.Request.Headers.GetValues(Token).First();
                // Validate Token
                if (!_tokenService.ValidateToken(tokenValue))
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                    {
                        ReasonPhrase = "Invalid Request" 
                        
                    };
                    filterContext.Response = responseMessage;
                }
            }
            else
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
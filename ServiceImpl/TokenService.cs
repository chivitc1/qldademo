using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using ServiceContract;
using System.Configuration;
using System.Data.Entity.Migrations;
using Entity;

namespace ServiceImpl
{
    public class TokenService : ITokenService
    {
        private static double _SessionTimeout = Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]);
        public bool DeleteByUserName(string userName)
        {
            var response = false;

            using (var db = new A77DbContext())
            {
                var tokens = db.Token.Where(t => t.UserName == userName).ToList();
                db.Token.RemoveRange(tokens);
                db.SaveChanges();
                response = true;
            }
            return response;
        }

        public TokenDto GenerateToken(string userName)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(_SessionTimeout);
            var tokendomain = new Token
            {
                UserName = userName,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };
            using (var db = new A77DbContext())
            {
                //db.Token.Add(tokendomain);
                db.Token.AddOrUpdate(tokendomain);
                db.SaveChanges();
            }
            var tokenDto = new TokenDto
            {
                UserName = tokendomain.UserName,
                AuthToken = tokendomain.AuthToken,
                ExpiresOn = tokendomain.ExpiresOn,
                IssuedOn = tokendomain.IssuedOn
            };

            return tokenDto;
        }

        public bool Kill(string tokenId)
        {
            var response = false;

            using (var db = new A77DbContext())
            {
                var token = db.Token.Find(tokenId);
                if (token != null)
                {
                    db.Token.Remove(token);
                    db.SaveChanges();
                    response = true;
                }
            }
            return response;
        }

        public bool ValidateToken(string tokenId)
        {
            var response = false;
            using (var db = new A77DbContext())
            {
                var token = db.Token.SingleOrDefault(t => t.AuthToken == tokenId && t.ExpiresOn > DateTime.Now);
                if (token != null && !(token.ExpiresOn < DateTime.Now))
                {
                    token.ExpiresOn =
                        token.ExpiresOn.AddSeconds(_SessionTimeout);
                    db.SaveChanges();
                    response = true;
                }
            }
            return response;
        }
    }
}

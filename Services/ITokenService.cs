using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;

namespace ServiceContract
{
    public interface ITokenService
    {
        #region Interface member methods.
        /// <summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        TokenDto GenerateToken(string userName);

        /// <summary>
        /// Function to validate token againt expiry and existance in database.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        bool ValidateToken(string tokenId);

        /// <summary>
        /// Method to kill the provided token id.
        /// </summary>
        /// <param name="tokenId"></param>
        bool Kill(string tokenId);

        /// <summary>
        /// Delete tokens for the specific deleted user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool DeleteByUserName(string userName);
        #endregion
    }
}

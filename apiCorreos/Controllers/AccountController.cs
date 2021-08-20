using apiCorreos.Models;
using System.Web.Http;

namespace apiCorreos.Controllers
{
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        /// <summary>
        /// Metodo encargado de realizar la auteticacion del usuario
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login(LoginRequest loginRequest) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool isCredentialValid = loginRequest.Password == "12345";
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(loginRequest.Username);
                return Ok(token);
            }
            else {
                return Unauthorized(); //Status code 401
            }           
                
        }
    }
}

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Infra.CrossCutting2.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NetDocsCore2_1.Model;
using Microsoft.AspNetCore.Cors;

namespace NetDocsCore2_1.Controllers
{
    [Route("api/[controller]")] ///[action]
    [ApiController]
    [EnableCors("MyAllowSpecificOrigins")]
    public class LoginController : ControllerBase
    {
        #region Post Method to authentication
        /// <summary>
        /// Method to valid user acess and generate token as response
        /// </summary>
        /// <param name="User">User</param>
        /// <returns> Token JSON </returns>
        
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginController( [FromServices]TokenConfigurations tokenConfigurations,
                                 [FromServices]UserManager<ApplicationUser> userManager,
                                 [FromServices]SignInManager<ApplicationUser> signInManager,
                                 [FromServices]SigningConfigurations signingConfigurations)
        {
             _tokenConfigurations = tokenConfigurations;
             _signInManager = signInManager;
             _signingConfigurations = signingConfigurations;
             _userManager = userManager;
        }


        [AllowAnonymous]
        [HttpPost("Authentication")]
        public  ActionResult<object> PostSignIn( [FromBody]User usuario)
                                                //  [FromServices]UserManager<ApplicationUser> userManager,
                                                //  [FromServices]SignInManager<ApplicationUser> signInManager,
                                                //  [FromServices]SigningConfigurations signingConfigurations,
                                                //  [FromServices]TokenConfigurations tokenConfigurations)
        {
            try 
            {
                
            bool credenciaisValidas = false;
            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.UserID))
            {
                // Verifica a existência do usuário nas tabelas do
                // ASP.NET Core Identity
                 var userIdentity = _userManager.FindByNameAsync(usuario.UserID).Result;
                
                if (userIdentity != null)
                {
                    // Efetua o login com base no Id do usuário e sua senha
                    var resultadoLogin =  _signInManager.CheckPasswordSignInAsync(userIdentity, usuario.Password, false).Result;

                    if (resultadoLogin.Succeeded)
                    {
                        // Verifica se o usuário em questão possui
                        // a role Acesso-APIAlturas
                        credenciaisValidas = _userManager.IsInRoleAsync( userIdentity, Roles.ROLE_ADMIN ).Result;
                    }
                }
            }
            
            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.UserID, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserID)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfigurations.Issuer,
                    Audience = _tokenConfigurations.Audience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

               var obj =  new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };

                return Ok(obj);

            }
            else
            {
                var bad = new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
                return NotFound(bad);
            }

            }
            catch(Exception ex)
            {
                return NotFound(new {    created = false, message = ex.Message });
            }

        }
        
        #endregion
    

        #region Post Method to Sign Up
        [AllowAnonymous]
        [HttpPut("SignUp")]
        public async Task<IActionResult> PostSignUp( User user)
        {
            ResponseUser response = new ResponseUser();
            try
            {                
                if (user != null)
                {
                    var userIdentity = new ApplicationUser
                    {
                        Email = user.Email,
                        UserName = user.UserName
                    };

                    ApplicationUser userBD = await _userManager.FindByEmailAsync(userIdentity.Email);
                    // var ema = tes.Email;
                    // var em2 = tes.NormalizedEmail;

                    if (userBD == null)
                    {
                        var result = await _userManager.CreateAsync(userIdentity, user.Password);
                        if (result.Succeeded)
                        {
                            response.created = true;
                            response.messages = null;
                            response.user = new User{
                                Email = userIdentity.Email,
                                UserID = userIdentity.Id,
                                UserName = userIdentity.UserName
                            };

                            var token = CreateToken(userIdentity);

                            return Ok(token);
                        }

                        //response.messages = result.Errors ?? result.Errors;
                        //new {    created = false, message = result.Errors ?? result.Errors, User = "" }
                        response.created = false;
                        response.messages = result.Errors ?? result.Errors;
                        return Unauthorized( response );
                    }

                    return Ok(CreateToken(userBD));

                }

                IdentityError IdentityError = new IdentityError{Description = $"User name { user.Email } is already taken."};
                List<IdentityError> lisError = new List<IdentityError>();
                lisError.Add(IdentityError);
                response.created = false;
                response.messages = lisError;
                return BadRequest(response);
            }
            catch (System.Exception ex)
            {
                var errorList = new List<IdentityError>();
                errorList.Add(new IdentityError{Description = ex.Message});
                response.messages = errorList;
                return BadRequest(response);
            }
        }
        #endregion

        private object CreateToken(ApplicationUser usuario)
        {
            try
            {
                 ClaimsIdentity identity = new ClaimsIdentity(
                     new GenericIdentity(usuario.Id, "Login"),
                     new[] {
                         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                         new Claim(JwtRegisteredClaimNames.Website, usuario.Id)
                     }
                 );
                 DateTime dataCriacao = DateTime.Now;
                 DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);
                 var handler = new JwtSecurityTokenHandler();
                 var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                 {
                     Issuer = _tokenConfigurations.Issuer,
                     Audience = _tokenConfigurations.Audience,
                     SigningCredentials = _signingConfigurations.SigningCredentials,
                     Subject = identity,
                     NotBefore = dataCriacao,
                     Expires = dataExpiracao
                 });
                 var token = handler.WriteToken(securityToken);
                 var obj =  new
                                {
                                    authenticated = true,
                                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                                    accessToken = token,
                                    message = "OK"
                                };
                 return obj;                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
    
    
    
    }
}

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
using Infra.Context;

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

        readonly TokenConfigurations _tokenConfigurations;
        readonly SignInManager<ApplicationUser> _signInManager;
        readonly SigningConfigurations _signingConfigurations;
        readonly UserManager<ApplicationUser> _userManager;
        readonly ContextDB _contextDB;

        public LoginController([FromServices]TokenConfigurations tokenConfigurations,
                                 [FromServices]UserManager<ApplicationUser> userManager,
                                 [FromServices]SignInManager<ApplicationUser> signInManager,
                                 [FromServices]SigningConfigurations signingConfigurations,
                                [FromServices]ContextDB contextDB)
        {
            _tokenConfigurations = tokenConfigurations;
            _signInManager = signInManager;
            _signingConfigurations = signingConfigurations;
            _userManager = userManager;
            _contextDB = contextDB;
        }

        [AllowAnonymous]
        [HttpGet("Login")]
        public IActionResult GetLogin()
        {
            return Ok(new { Ok = "Sucesso" });
        }


        [AllowAnonymous]
        [HttpPost("Authentication")]
        public async Task<IActionResult> PostSignIn([FromBody]User usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return NotFound();

                ApplicationUser userIdentity = new ApplicationUser()
                {
                    Email = usuario.Email,
                    PasswordHash = usuario.Password,
                    UserName = usuario.Email
                };
                bool credenciaisValidas = false;


                if (usuario != null && !String.IsNullOrWhiteSpace(usuario.Email))
                {
                    // Verifica a existência do usuário nas tabelas do
                    // ASP.NET Core Identity
                    //var tes = _userManager.Users.ToList();
                    userIdentity = await _userManager.FindByEmailAsync(usuario.Email);

                    if (userIdentity != null)
                    {
                        // Efetua o login com base no Id do usuário e sua senha
                        var resultadoLogin = _signInManager.CheckPasswordSignInAsync(userIdentity, usuario.Password, false).Result;
                        credenciaisValidas = (resultadoLogin.Succeeded == true) ? resultadoLogin.Succeeded : false;
                    }
                }

                if (credenciaisValidas)
                {
                    var obj = CreateToken(userIdentity);
                    return Ok(obj);
                }
                else
                {
                    ResponseUser response = new ResponseUser();
                    var erros = new List<IdentityError>();
                    erros.Add(new IdentityError { Description = "Email/Password Invalid" });
                    response.messages = erros;
                    return Unauthorized(response);
                }

            }
            catch (Exception ex)
            {
                return NotFound(new { created = false, message = ex.Message });
            }

        }
        #endregion


        #region Post Method to Sign Up
        [AllowAnonymous]
        [HttpPut("SignUp")]
        public async Task<IActionResult> PostSignUp(User user)
        {
            ResponseUser response = new ResponseUser();
            try
            {

                if (!ModelState.IsValid)
                    return NotFound();

                if (user != null)
                {
                    var userIdentity = new ApplicationUser
                    {
                        Email = user.Email,
                        UserName = user.UserName
                    };

                    ApplicationUser userBD = await _userManager.FindByEmailAsync(userIdentity.Email);
                    if (userBD == null)
                    {
                        var result = await _userManager.CreateAsync(userIdentity, user.Password);
                        if (result.Succeeded)
                        {
                            var token = CreateToken(userIdentity);
                            return Ok(token); // Created()
                        }

                        response.created = false;
                        response.messages = result.Errors ?? result.Errors;
                        return Unauthorized(response);
                    }

                    return Ok(CreateToken(userBD));

                }

                IdentityError IdentityError = new IdentityError { Description = $"User name { user.Email } is already taken." };
                List<IdentityError> lisError = new List<IdentityError>();
                lisError.Add(IdentityError);
                response.created = false;
                response.messages = lisError;
                return BadRequest(response);
            }
            catch (System.Exception ex)
            {
                var errorList = new List<IdentityError>();
                errorList.Add(new IdentityError { Description = ex.Message });
                response.messages = errorList;
                return BadRequest(response);
            }
        }
        #endregion

        private object CreateToken(ApplicationUser usuario)
        {
            try
            {
                List<Claim> claims = new List<Claim>();
                //claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")));
                claims.Add(new Claim(JwtRegisteredClaimNames.NameId, usuario.Id));
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, usuario.Email));

                ClaimsIdentity identity = new ClaimsIdentity(claims.ToList()); //new GenericIdentity(usuario.Id, "Login"),

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao + TimeSpan.FromDays(_tokenConfigurations.Seconds);
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
                var obj = new
                {
                    authenticated = true,
                    accessToken = token
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

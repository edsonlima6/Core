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
using Infra.CrossCutting2.Context;
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
        
        [AllowAnonymous]
        [HttpPost("Authentication")]
        public  ActionResult<object> PostSignIn( [FromBody]User usuario,
                            [FromServices]UserManager<ApplicationUser> userManager,
                            [FromServices]SignInManager<ApplicationUser> signInManager,
                            [FromServices]SigningConfigurations signingConfigurations,
                            [FromServices]TokenConfigurations tokenConfigurations)
        {
            try 
            {
                
            bool credenciaisValidas = false;
            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.UserID))
            {
                // Verifica a existência do usuário nas tabelas do
                // ASP.NET Core Identity
                 var userIdentity = userManager.FindByNameAsync(usuario.UserID).Result;
                
                if (userIdentity != null)
                {
                    // Efetua o login com base no Id do usuário e sua senha
                    var resultadoLogin =  signInManager.CheckPasswordSignInAsync(userIdentity, usuario.Password, false).Result;

                    if (resultadoLogin.Succeeded)
                    {
                        // Verifica se o usuário em questão possui
                        // a role Acesso-APIAlturas
                        credenciaisValidas = userManager.IsInRoleAsync( userIdentity, Roles.ROLE_API_ALTURAS ).Result;
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
                DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
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
        public async Task<object> PostSignUp( User user,
                                              [FromServices]UserManager<ApplicationUser> userManager)
        {
            try
            {
                if (user != null)
                {
                    var userIdentity = new ApplicationUser
                    {
                        Email = user.Email,
                        UserName = user.UserName
                    };

                    if (await userManager.FindByEmailAsync(userIdentity.Email) == null)
                    {
                        var result = await userManager.CreateAsync(userIdentity, user.Password);
                        if (result.Succeeded)
                        {
                            return Ok(new {    created = true, message = userIdentity });
                        }

                        return BadRequest( new {    created = false, message = result.Errors ?? result.Errors } );
                    }

                    return Ok( new {    created = false, message = $"User name { user.Email } is already taken." } );

                }
                return Ok(user);
            }
            catch (System.Exception ex)
            {
                return BadRequest( new {    created = false, message = ex.Message });
            }
        }
        #endregion

    
    
    
    
    
    }
}

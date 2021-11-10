using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SpMedicalGroup.webApi.Domains;
using SpMedicalGroup.webApi.Interfaces;
using SpMedicalGroup.webApi.Repositories;
using SpMedicalGroup.webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel Login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(Login.Email, Login.Senha);
                if (usuarioBuscado == null)
                {
                    return NotFound("Email e/ou Senha inválidos");
                }
                var Claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoDeUsuario.ToString())
                    };

                    var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SenaiSpMedicalGroup.webapi"));
                    var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
                    var meuToken = new JwtSecurityToken(
                            issuer: "SpMedicalGroup.webApi",
                            audience: "SpMedicalGroup.webApi",
                            claims: Claims,
                            expires: DateTime.Now.AddMinutes(60),
                            signingCredentials: Creds
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                    });
            }
            catch(Exception Erro)
            {
                return BadRequest(Erro.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.webApi.Domains;
using SpMedicalGroup.webApi.Interfaces;
using SpMedicalGroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepositorio { get; set; }
        public UsuariosController()
        {
            UsuarioRepositorio = new UsuarioRepository();
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario NovoUsuario)
        {
            try
            {
                if(NovoUsuario == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Informe todos os dados necessários"
                    });
                }
                UsuarioRepositorio.Cadastrar(NovoUsuario);
                return StatusCode(201, new
                {
                    Mensagem = "Usuario cadastrado",
                    NovoUsuario
                });
            } catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            if (UsuarioRepositorio.ListarUsuarios() == null)
            {
                return NotFound(new
                {
                    Mensagem = "Nenhum usuario cadastrado até o momento"
                });
            }

            return Ok(UsuarioRepositorio.ListarUsuarios());
        }

        [Authorize(Roles = "1")]
        [HttpPut("Atualizar/{IdUsuario}")]
        public IActionResult Atualizar(int IdUsuario, Usuario UsuarioAtualizado)
        {
            try
            {
                if (IdUsuario <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Informe um ID válido"
                    });
                }
                if (UsuarioAtualizado == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Informe os dados necessários"
                    });
                }
                if (UsuarioRepositorio.BuscarPorId(IdUsuario) != null)
                {
                    UsuarioRepositorio.Atualizar(IdUsuario, UsuarioAtualizado);
                    return StatusCode(200, new
                    {
                        Mensagem = "O usuario informado foi atualizado!",
                        UsuarioAtualizado
                    });
                }
                else return NotFound("Usuário inexistente");
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro.Message);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Informe um ID válido"
                    });
                }
                if (UsuarioRepositorio.BuscarPorId(id) == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Usuário inexistente"
                    });
                }
                UsuarioRepositorio.Deletar(id);
                return StatusCode(200, new
                {
                    Mensagem = "Usuario informado deletado com sucesso"
                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }
    }
}

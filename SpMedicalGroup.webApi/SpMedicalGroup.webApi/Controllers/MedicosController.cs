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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository MedicoRepositorio { get; set; }
        private IUsuarioRepository UsuarioRepositorio { get; set; }

        public MedicosController()
        {
            MedicoRepositorio = new MedicoRepository();
            UsuarioRepositorio = new UsuarioRepository();
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(Medico NovoMedico)
        {
            try
            {
                if (UsuarioRepositorio.BuscarPorId(NovoMedico.IdUsuario.GetValueOrDefault()) != null || NovoMedico.Crm == null || NovoMedico.IdAreaMedico <= 0 || NovoMedico.IdClinica <= 0)
                {
                    return BadRequest("Dados Inválidos");
                }

                MedicoRepositorio.Cadastrar(NovoMedico);
                return Ok(new
                {
                    Mensagem = "Um novo médico foi cadastrado",
                    NovoMedico
                });
            }
            catch(Exception Erro)
            {
                return BadRequest(Erro.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult ListarTodos()
        {
            return Ok(MedicoRepositorio.ListarTodos());
        }

        [HttpGet("{IdMedico}")]
        [Authorize(Roles = "1,3")]
        public IActionResult BuscarPorId(int IdMedico)
        {
            try
            {
                if (MedicoRepositorio.BuscarPorId(IdMedico) != null)
                {
                    return Ok(MedicoRepositorio.BuscarPorId(IdMedico));
                }
                else return NotFound("Id inválido");
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [HttpDelete("{IdMedicoDeletado}")]
        [Authorize(Roles = "1")]
        public IActionResult Deletar(int IdMedicoDeletado)
        {
            try
            {
                if (MedicoRepositorio.BuscarPorId(IdMedicoDeletado) != null)
                {
                    MedicoRepositorio.Deletar(IdMedicoDeletado);
                    return NoContent();
                }
                else return NotFound("Id de médico inválido");
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }

        [HttpPut("{IdMedicoAtualizado}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(int IdMedico, Medico MedicoAtualizado)
        {
            try
            {
                if (UsuarioRepositorio.BuscarPorId(MedicoAtualizado.IdUsuario.GetValueOrDefault()).IdTipoDeUsuario != 2)
                {
                    return BadRequest("O usuário deve ser do tipo 'Médico'");
                }
                if (MedicoRepositorio.BuscarPorId(IdMedico) != null)
                {
                    MedicoRepositorio.Atualizar(IdMedico, MedicoAtualizado);
                    return NoContent();
                }
                else return NotFound("Id de médico inválido");
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
                throw;
            }
        }
    }
}

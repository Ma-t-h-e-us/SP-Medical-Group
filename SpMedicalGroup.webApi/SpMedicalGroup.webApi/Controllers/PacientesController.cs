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
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository PacienteRepositorio { get; set; }
        private IUsuarioRepository UsuarioRepositorio { get; set; }

        public PacientesController()
        {
            PacienteRepositorio = new PacienteRepository();
            UsuarioRepositorio = new UsuarioRepository();
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(Paciente NovoPaciente)
        {
            try
            {
                if (UsuarioRepositorio.BuscarPorId(NovoPaciente.IdUsuario.GetValueOrDefault()) != null || NovoPaciente.Cpf == null || NovoPaciente.DataNascimento > DateTime.Now || NovoPaciente.Rg == null || NovoPaciente.Telefone == null || NovoPaciente.Endereco == null || NovoPaciente.IdUsuario == null)
                {
                    return BadRequest("Dados Inválidos");
                }

                PacienteRepositorio.Cadastrar(NovoPaciente);
                return Ok(new
                {
                    Mensagem = "Um novo paciente foi cadastrado",
                    NovoPaciente
                });
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(PacienteRepositorio.ListarTodos());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro.Message);
            }
        }

        [HttpGet("{IdPaciente}")]
        [Authorize(Roles = "1,2")]
        public IActionResult BuscarPorId(int IdPaciente)
        {
            try
            {
                if (PacienteRepositorio.BuscarPorId(IdPaciente) != null)
                {
                    return Ok(PacienteRepositorio.BuscarPorId(IdPaciente));
                }
                else return NotFound("Id inválido");
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [HttpDelete("{IdPacienteDeletado}")]
        [Authorize(Roles = "1")]
        public IActionResult Deletar(int IdPacienteDeletado)
        {
            try
            {
                if (PacienteRepositorio.BuscarPorId(IdPacienteDeletado) != null)
                {
                    PacienteRepositorio.Deletar(IdPacienteDeletado);
                    return NoContent();
                }
                else return NotFound("Id do paciente inválido");
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [HttpPut("{IdPacienteAtualizado}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(int IdPaciente, Paciente PacienteAtualizado)
        {
            try
            {
                if (UsuarioRepositorio.BuscarPorId(PacienteAtualizado.IdUsuario.GetValueOrDefault()).IdTipoDeUsuario != 3)
                {
                    return BadRequest("O usuário deve ser do tipo 'Paciente'");
                }
                if (PacienteRepositorio.BuscarPorId(IdPaciente) != null)
                {
                    PacienteRepositorio.Atualizar(IdPaciente, PacienteAtualizado);
                    return NoContent();
                }
                else return NotFound("Id do paciente inválido");
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }
    }
}

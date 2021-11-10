using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SpMedicalGroup.webApi.Domains;
using SpMedicalGroup.webApi.Interfaces;
using SpMedicalGroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository ConsultaRepositorio { get; set; }
        private IMedicoRepository MedicoRepositorio { get; set; }

        public ConsultasController()
        {
            ConsultaRepositorio = new ConsultaRepository();
            MedicoRepositorio = new MedicoRepository();
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastrarConsulta(Consulta NovaConsulta)
        {
            try
            {
                if (NovaConsulta == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "A consulta está incompleta"
                    });
                }
                if (NovaConsulta.DataConsulta <= DateTime.Now)
                {
                    return BadRequest("Data de ajendamento inválida");
                }
                ConsultaRepositorio.CadastrarConsulta(NovaConsulta);
                return StatusCode(201, new
                {
                    Mensagem = "Consulta ajendada",
                    NovaConsulta
                });
            } catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
            
        }

        [Authorize(Roles = "1")]
        [HttpPatch("Cancelar/{id}")]
        public IActionResult Cancelar(int id)
        {
            if (id <= 0 || ConsultaRepositorio.BuscarPorId(id) == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Id invalido ou inexistente"
                });
            }
            ConsultaRepositorio.Cancelar(id);
            return StatusCode(204, new
            {
                Mensagem = "A Consulta foi cancelada com sucesso"
            });
        }

        [Authorize(Roles = "1,3")]
        [HttpGet("Listar/Minhas")]
        public IActionResult ListarMinhasConsultas()
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

            int idTipo = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value);

            List<Consulta> ListaConsultas = ConsultaRepositorio.ListarMinhasConsultas(id, idTipo);

            if (ListaConsultas.Count == 0)
            {
                return NotFound(new
                {
                    Mensagem = "Nenhuma consulta foi encontrada"
                });
            }

            if (idTipo == 2)
            {
                return Ok(new
                {
                    Mensagem = $"Paciente buscado tem {ConsultaRepositorio.ListarMinhasConsultas(id, idTipo).Count} consultas",
                    ListaConsultas
                });
            }

            if (idTipo == 3)
            {
                return Ok(new
                {
                    Mensagem = $"Médico buscado tem {ConsultaRepositorio.ListarMinhasConsultas(id, idTipo).Count} consultas",
                    ListaConsultas
                });
            }
            return BadRequest();
        }

        [Authorize(Roles = "3")]
        [HttpPatch("Descricao/{id}")]
        public IActionResult AlterarDescricao(Consulta ConsultaAtualizada, int id)
        {
            Consulta ConsultaBuscada = ConsultaRepositorio.BuscarPorId(id);
            int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            int IdMedico = MedicoRepositorio.BuscarPorId(IdUsuario).IdMedico;

            if (ConsultaAtualizada.Descricao == null)
            {
                return BadRequest(new
                {
                    Mensagem = "É necessário informar a nova descrição"
                });
            }

            if (id <= 0 || ConsultaRepositorio.BuscarPorId(id) == null)
            {
                return NotFound(new
                {
                    Mensagem = "Id informado invalido ou inexistente"
                });
            }

            if (ConsultaBuscada.IdMedico != IdMedico)
            {
                return Unauthorized(new
                {
                    Mensagem = "Somente o médico da consulta pode alterar a descrição"
                });
            }

            ConsultaRepositorio.AlterarDescricao(ConsultaAtualizada.Descricao, id);

            return Ok(new
            {
                Mensagem = "Descrição da consulta alterada com sucesso",
                ConsultaAtualizada
            });
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodas()
        {
            if (ConsultaRepositorio.ListarTodas().Count == 0)
            {
                return BadRequest(new
                {
                    Mensagem = "Nenhuma consulta encontrada"
                });
            }

            return Ok(ConsultaRepositorio.ListarTodas());
        }
    }
}

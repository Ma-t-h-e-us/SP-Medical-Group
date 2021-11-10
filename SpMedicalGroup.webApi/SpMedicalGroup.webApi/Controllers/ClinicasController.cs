using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ClinicasController : ControllerBase
    {
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]
        public class ClinicaController : ControllerBase
        {
            private IClinicaRepository ClinicaRepositorio { get; set; }

            public ClinicaController()
            {
                ClinicaRepositorio = new ClinicaRepository();
            }

            [Authorize(Roles = "1")]
            [HttpPost]
            public IActionResult Cadastrar(Clinica NovaClinica)
            {
                try
                {

                    if (NovaClinica == null)
                    {
                        return BadRequest(new
                        {
                            Mensagem = "Os valores inseridos são inválidos!"
                        });
                    }
                    ClinicaRepositorio.CadastrarClinica(NovaClinica);

                    return StatusCode(201, new
                    {
                        Mensagem = "A instituição foi cadastrada com sucesso",
                        NovaClinica
                    });
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }

            }

            [Authorize(Roles = "1")]
            [HttpGet]
            public IActionResult Listar()
            {
                try
                {
                    List<Clinica> lista = ClinicaRepositorio.ListarTodas();

                    if (lista == null)
                    {
                        return StatusCode(404, new
                        {
                            Mensagem = "Não há nenhuma instituição cadastrada!"
                        });
                    }

                    return Ok(new
                    {
                        Mensagem = $"Foram encontradas {lista.Count()} clínicas",
                        lista
                    });
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }

            [Authorize(Roles = "1")]
            [HttpPut("{id:int}")]
            public IActionResult Atualizar(int id, Clinica ClinicaAtualizada)
            {
                try
                {
                    if (id <= 0)
                    {
                        return BadRequest(new
                        {
                            Mensagem = "Insira um id válido"
                        });
                    }

                    if (ClinicaRepositorio.BuscarClinica(id) == null)
                    {
                        return StatusCode(404, new
                        {
                            Mensagem = "Não há nenhuma clínica com o id informado!"
                        });
                    }
                    if (ClinicaAtualizada.Cnpj == null || ClinicaAtualizada.Endereco == null || ClinicaAtualizada.NomeFantasia == null || ClinicaAtualizada.RazaoSocial == null || ClinicaAtualizada.Cnpj.Length != 14)
                    {
                        return BadRequest(new
                        {
                            Mensagem = "As informações inseridas são inválidas!"
                        });
                    }

                    ClinicaRepositorio.Atualizar(id, ClinicaAtualizada);
                    return Ok(new
                    {
                        Mensagem = "A clínica foi atualizada com sucesso!",
                        ClinicaAtualizada
                    });
                }
                catch (Exception Erro)
                {

                    return BadRequest(Erro.Message);
                }
            }

            [Authorize(Roles = "1")]
            [HttpDelete("{id:int}")]
            public IActionResult Deletar(int id)
            {
                try
                {
                    if (id <= 0)
                    {
                        return BadRequest(new
                        {
                            Mensagem = "Insira um id válido"
                        });
                    }

                    if (ClinicaRepositorio.BuscarClinica(id) == null)
                    {
                        return StatusCode(404, new
                        {
                            Mensagem = "Não há nenhuma clínica com o id informado!"
                        });
                    }

                    ClinicaRepositorio.Deletar(id);
                    return Ok(new
                    {
                        Mensagem = "A clínica foi excluída com sucesso!",
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SpMedicalGroup.webApi.Contexts;
using SpMedicalGroup.webApi.Domains;
using SpMedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();
        public void AlterarDescricao(string descricao, int id)
        {
            Consulta consultaBuscada = BuscarPorId(id);

            if (descricao != null)
            {
                consultaBuscada.Descricao = descricao;
                ctx.Consulta.Update(consultaBuscada);
                ctx.SaveChanges();
            };
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == id);
        }

        public void CadastrarConsulta(Consulta NovaConsulta)
        {
            NovaConsulta.IdSituacao = 3;
            ctx.Consulta.Add(NovaConsulta);
            ctx.SaveChanges();
        }

        public void Cancelar(int Id)
        {
            Consulta consultaBuscada = BuscarPorId(Id);

            consultaBuscada.IdSituacao = 2;
            consultaBuscada.Descricao = "Consulta Cancelada";

            ctx.Consulta.Update(consultaBuscada);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Consulta.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Consulta> ListarMinhasConsultas(int id, int IdTipoUsuario)
        {
            //Consultas Médico
            if (IdTipoUsuario == 2)
            {
                Medico medico = ctx.Medicos.FirstOrDefault(m => m.IdUsuario == id);
                int idMedico = medico.IdMedico;

                return ctx.Consulta
                                .Where(c => c.IdMedico == idMedico)
                                .AsNoTracking()
                                .Select(C => new Consulta()
                                {
                                    IdConsulta = C.IdConsulta,
                                    IdSituacao = C.IdSituacao,
                                    IdPaciente = C.IdPaciente,
                                    IdMedico = C.IdMedico,
                                    DataConsulta = C.DataConsulta,
                                    Descricao = C.Descricao,
                                    IdMedicoNavigation = new Medico()
                                    {
                                        IdUsuario = C.IdMedicoNavigation.IdUsuario,
                                        IdClinica = C.IdMedicoNavigation.IdClinica,
                                        IdAreaMedico = C.IdMedicoNavigation.IdAreaMedico,
                                        IdAreaMedicoNavigation = new AreaMedico()
                                        {
                                            Descricao = C.IdMedicoNavigation.IdAreaMedicoNavigation.Descricao
                                        },
                                        IdClinicaNavigation = new Clinica()
                                        {
                                            HorarioInicioFuncionamento = C.IdMedicoNavigation.IdClinicaNavigation.HorarioInicioFuncionamento,
                                            HorarioFimFuncionamento = C.IdMedicoNavigation.IdClinicaNavigation.HorarioFimFuncionamento,
                                            Endereco = C.IdMedicoNavigation.IdClinicaNavigation.Endereco,
                                            RazaoSocial = C.IdMedicoNavigation.IdClinicaNavigation.RazaoSocial,
                                            NomeFantasia = C.IdMedicoNavigation.IdClinicaNavigation.NomeFantasia,
                                            Cnpj = C.IdMedicoNavigation.IdClinicaNavigation.Cnpj
                                        },
                                        IdUsuarioNavigation = new Usuario()
                                        {
                                            Email = C.IdMedicoNavigation.IdUsuarioNavigation.Email,
                                        },
                                        Crm = C.IdMedicoNavigation.Crm,
                                        Nome = C.IdMedicoNavigation.Nome
                                    },
                                    IdPacienteNavigation = new Paciente()
                                    {
                                        IdUsuario = C.IdPacienteNavigation.IdUsuario,
                                        Telefone = C.IdPacienteNavigation.Telefone,
                                        Cpf = C.IdPacienteNavigation.Cpf,
                                        Endereco = C.IdPacienteNavigation.Endereco,
                                        Rg = C.IdPacienteNavigation.Rg,
                                        DataNascimento = C.IdPacienteNavigation.DataNascimento,
                                        NomePaciente = C.IdPacienteNavigation.NomePaciente,
                                        IdUsuarioNavigation = new Usuario()
                                        {
                                            Email = C.IdPacienteNavigation.IdUsuarioNavigation.Email,
                                        }
                                    }
                                }).ToList();
            } 
            //Consultas Pacientes
            else if (IdTipoUsuario == 3)
            {
                Paciente paciente = ctx.Pacientes.FirstOrDefault(p => p.IdUsuario == id);
                int idPaciente = paciente.IdPaciente;

                return ctx.Consulta
                                .Where(c => c.IdPaciente == idPaciente)
                                .AsNoTracking()
                                .Select(C => new Consulta()
                                {
                                    IdConsulta = C.IdConsulta,
                                    IdSituacao = C.IdSituacao,
                                    IdPaciente = C.IdPaciente,
                                    IdMedico = C.IdMedico,
                                    DataConsulta = C.DataConsulta,
                                    Descricao = C.Descricao,
                                    IdMedicoNavigation = new Medico()
                                    {
                                        IdUsuario = C.IdMedicoNavigation.IdUsuario,
                                        IdClinica = C.IdMedicoNavigation.IdClinica,
                                        IdAreaMedico = C.IdMedicoNavigation.IdAreaMedico,
                                        IdAreaMedicoNavigation = new AreaMedico()
                                        {
                                            Descricao = C.IdMedicoNavigation.IdAreaMedicoNavigation.Descricao
                                        },
                                        IdClinicaNavigation = new Clinica()
                                        {
                                            HorarioInicioFuncionamento = C.IdMedicoNavigation.IdClinicaNavigation.HorarioInicioFuncionamento,
                                            HorarioFimFuncionamento = C.IdMedicoNavigation.IdClinicaNavigation.HorarioFimFuncionamento,
                                            Endereco = C.IdMedicoNavigation.IdClinicaNavigation.Endereco,
                                            RazaoSocial = C.IdMedicoNavigation.IdClinicaNavigation.RazaoSocial,
                                            NomeFantasia = C.IdMedicoNavigation.IdClinicaNavigation.NomeFantasia,
                                            Cnpj = C.IdMedicoNavigation.IdClinicaNavigation.Cnpj
                                        },
                                        IdUsuarioNavigation = new Usuario()
                                        {
                                            Email = C.IdMedicoNavigation.IdUsuarioNavigation.Email,
                                        },
                                        Crm = C.IdMedicoNavigation.Crm,
                                        Nome = C.IdMedicoNavigation.Nome
                                    },
                                    IdPacienteNavigation = new Paciente()
                                    {
                                        IdUsuario = C.IdPacienteNavigation.IdUsuario,
                                        Telefone = C.IdPacienteNavigation.Telefone,
                                        Cpf = C.IdPacienteNavigation.Cpf,
                                        Endereco = C.IdPacienteNavigation.Endereco,
                                        Rg = C.IdPacienteNavigation.Rg,
                                        DataNascimento = C.IdPacienteNavigation.DataNascimento,
                                        NomePaciente = C.IdPacienteNavigation.NomePaciente,
                                        IdUsuarioNavigation = new Usuario()
                                        {
                                            Email = C.IdPacienteNavigation.IdUsuarioNavigation.Email,
                                        }
                                    }
                                }).ToList();
            }
            return null;
        }

        public List<Consulta> ListarTodas()
        {
            return ctx.Consulta.Select(C => new Consulta()
            {
                IdConsulta = C.IdConsulta,
                IdSituacao = C.IdSituacao,
                IdPaciente = C.IdPaciente,
                IdMedico = C.IdMedico,
                DataConsulta = C.DataConsulta,
                Descricao = C.Descricao,
                IdMedicoNavigation = new Medico()
                {
                    IdUsuario = C.IdMedicoNavigation.IdUsuario,
                    IdClinica = C.IdMedicoNavigation.IdClinica,
                    IdAreaMedico = C.IdMedicoNavigation.IdAreaMedico,
                    IdAreaMedicoNavigation = new AreaMedico()
                    {
                        Descricao = C.IdMedicoNavigation.IdAreaMedicoNavigation.Descricao
                    },
                    IdClinicaNavigation = new Clinica()
                    {
                        HorarioInicioFuncionamento = C.IdMedicoNavigation.IdClinicaNavigation.HorarioInicioFuncionamento,
                        HorarioFimFuncionamento = C.IdMedicoNavigation.IdClinicaNavigation.HorarioFimFuncionamento,
                        Endereco = C.IdMedicoNavigation.IdClinicaNavigation.Endereco,
                        RazaoSocial = C.IdMedicoNavigation.IdClinicaNavigation.RazaoSocial,
                        NomeFantasia = C.IdMedicoNavigation.IdClinicaNavigation.NomeFantasia,
                        Cnpj = C.IdMedicoNavigation.IdClinicaNavigation.Cnpj
                    },
                    IdUsuarioNavigation = new Usuario()
                    {
                        Email = C.IdMedicoNavigation.IdUsuarioNavigation.Email,
                    },
                    Crm = C.IdMedicoNavigation.Crm,
                    Nome = C.IdMedicoNavigation.Nome
                },
                IdPacienteNavigation = new Paciente()
                {
                    IdUsuario = C.IdPacienteNavigation.IdUsuario,
                    Telefone = C.IdPacienteNavigation.Telefone,
                    Cpf = C.IdPacienteNavigation.Cpf,
                    Endereco = C.IdPacienteNavigation.Endereco,
                    Rg = C.IdPacienteNavigation.Rg,
                    DataNascimento = C.IdPacienteNavigation.DataNascimento,
                    NomePaciente = C.IdPacienteNavigation.NomePaciente,
                    IdUsuarioNavigation = new Usuario()
                    {
                        Email = C.IdPacienteNavigation.IdUsuarioNavigation.Email,
                    }
                }
            }).ToList();
        }
    }
}

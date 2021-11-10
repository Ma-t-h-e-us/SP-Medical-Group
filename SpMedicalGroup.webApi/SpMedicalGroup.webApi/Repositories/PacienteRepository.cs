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
    public class PacienteRepository : IPacienteRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();
        public void Atualizar(int id, Paciente PacienteAtualizado)
        {
            Paciente pacienteBuscado = BuscarPorId(id);

            if (pacienteBuscado != null)
            {
                pacienteBuscado.Rg = PacienteAtualizado.Rg;
                pacienteBuscado.Cpf = PacienteAtualizado.Cpf;
                pacienteBuscado.IdUsuario = PacienteAtualizado.IdUsuario;
                pacienteBuscado.IdPaciente = PacienteAtualizado.IdPaciente;
                pacienteBuscado.Telefone = PacienteAtualizado.Telefone;
                pacienteBuscado.Endereco = PacienteAtualizado.Endereco;
                pacienteBuscado.NomePaciente = PacienteAtualizado.NomePaciente;

                ctx.Pacientes.Update(pacienteBuscado);
                ctx.SaveChanges();
            }
        }

        public Paciente BuscarPorId(int id)
        {
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);
        }

        public void Cadastrar(Paciente NovoPaciente)
        {
            ctx.Pacientes.Add(NovoPaciente);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Pacientes.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes
                    .AsNoTracking()
                    .Include(p => p.IdUsuarioNavigation)
                    .ToList();
        }
    }
}

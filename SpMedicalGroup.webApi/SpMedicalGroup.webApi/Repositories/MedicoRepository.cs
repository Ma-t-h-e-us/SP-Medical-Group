using SpMedicalGroup.webApi.Contexts;
using SpMedicalGroup.webApi.Domains;
using SpMedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();
        public void Atualizar(int IdMedico, Medico MedicoAtualizado)
        {
            Medico medicoBuscado = BuscarPorId(IdMedico);

            if (medicoBuscado != null)
            {
                medicoBuscado.IdAreaMedico = MedicoAtualizado.IdAreaMedico;
                medicoBuscado.Crm = MedicoAtualizado.Crm;
                medicoBuscado.IdClinica = MedicoAtualizado.IdClinica;
                medicoBuscado.Nome = MedicoAtualizado.Nome;

                ctx.Update(medicoBuscado);
                ctx.SaveChanges();
            }
        }

        public Medico BuscarPorId(int IdMedico)
        {
            return ctx.Medicos.FirstOrDefault(m => m.IdMedico == IdMedico);
        }

        public void Cadastrar(Medico NovoMedico)
        {
            ctx.Medicos.Add(NovoMedico);
            ctx.SaveChanges();
        }

        public void Deletar(int IdMedico)
        {
            ctx.Medicos.Remove(BuscarPorId(IdMedico));
            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos.ToList();
        }
    }
}


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
    public class ClinicaRepository : IClinicaRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();

        public void Atualizar(int id, Clinica ClinicaAtualizada)
        {
            Clinica ClinicaBuscada = BuscarClinica(id);
            if (ClinicaAtualizada.Endereco != null || ClinicaAtualizada.Cnpj != null || ClinicaAtualizada.NomeFantasia != null || ClinicaAtualizada.RazaoSocial != null)
            {
                ClinicaBuscada.Endereco = ClinicaAtualizada.Endereco;
                ClinicaBuscada.Cnpj = ClinicaAtualizada.Cnpj;
                ClinicaBuscada.NomeFantasia = ClinicaAtualizada.NomeFantasia;
                ClinicaBuscada.RazaoSocial = ClinicaAtualizada.RazaoSocial;

                ctx.Clinicas.Update(ClinicaBuscada);

                ctx.SaveChanges();
            }
        }

        public Clinica BuscarClinica(int id)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == id);
        }

        public void CadastrarClinica(Clinica NovaClinica)
        {
            ctx.Clinicas.Add(NovaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Clinicas.Remove(BuscarClinica(id));

            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodas()
        {
            return ctx.Clinicas
                    .AsNoTracking()
                    .Include(c => c.Medicos)
                    .ToList();
        }
    }
}

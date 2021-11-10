using SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.Interfaces
{
    interface IClinicaRepository
    {
        void CadastrarClinica(Clinica NovaClinica);
        void Atualizar(int id, Clinica ClinicaAtualizada);
        List<Clinica> ListarTodas();
        void Deletar(int id);
        Clinica BuscarClinica(int id);
    }
}

using SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.Interfaces
{
    interface IMedicoRepository
    {
        void Cadastrar(Medico NovoMedico);
        List<Medico> ListarTodos();
        Medico BuscarPorId(int IdMedico);
        void Deletar(int IdMedico);
        void Atualizar(int IdMedico, Medico MedicoAtualizado);
    }
}

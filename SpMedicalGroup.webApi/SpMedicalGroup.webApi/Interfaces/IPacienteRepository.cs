using SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> ListarTodos();

        void Cadastrar(Paciente NovoPaciente);

        void Deletar(int id);

        void Atualizar(int id, Paciente PacienteAtualizado);

        Paciente BuscarPorId(int id);
    }
}

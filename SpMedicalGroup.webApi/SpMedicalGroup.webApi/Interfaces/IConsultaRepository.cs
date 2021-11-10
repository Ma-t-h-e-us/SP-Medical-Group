using SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.Interfaces
{
    interface IConsultaRepository
    {
        List<Consulta> ListarTodas();

        List<Consulta> ListarMinhasConsultas(int id, int IdTipoUsuario);


        void CadastrarConsulta(Consulta NovaConsulta);


        void Cancelar(int Id);


        void Deletar(int id);


        void AlterarDescricao(string descricao, int id);


        Consulta BuscarPorId(int id);
    }
}

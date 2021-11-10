using Microsoft.AspNetCore.Http;
using SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarUsuarios();

        void Cadastrar(Usuario NovoUsuario);

        Usuario Login(string Email, string Senha);

        void Deletar(int id);

        Usuario BuscarPorId(int id);

        void Atualizar(int id, Usuario UsuarioAtualizado);

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpMedicalGroup.webApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "Id de usuário necessário")]
        public int? IdUsuario { get; set; }
        public string NomePaciente { get; set; }

        [Required(ErrorMessage = "RG necessário")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "CPF necessário")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Endereço necessário")]
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}

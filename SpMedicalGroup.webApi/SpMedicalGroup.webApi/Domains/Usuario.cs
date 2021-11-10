using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpMedicalGroup.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public byte? IdTipoDeUsuario { get; set; }

        [Required(ErrorMessage = "Email necessário")]
        public string Email { get; set; }

        [StringLength(30,MinimumLength = 6, ErrorMessage = "Tamanho da senha deve ser maior ou igual a 6")]
        [Required(ErrorMessage = "Senha necessária")]
        public string Senha { get; set; }

        public virtual TipoDeUsuario IdTipoDeUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}

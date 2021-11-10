using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpMedicalGroup.webApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdClinica { get; set; }

        [Required(ErrorMessage = "Endereço necessário")]
        public string Endereco { get; set; }
        public DateTime HorarioInicioFuncionamento { get; set; }
        public DateTime HorarioFimFuncionamento { get; set; }

        [Required(ErrorMessage = "CNPJ necessário")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Nome Fantasia necessário")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Razão social necessária")]
        public string RazaoSocial { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}

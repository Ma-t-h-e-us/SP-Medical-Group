using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpMedicalGroup.webApi.Domains
{
    public partial class Consulta
    {
        public long IdConsulta { get; set; }

        [Required(ErrorMessage = "Id do médico necessário")]
        public int? IdMedico { get; set; }

        [Required(ErrorMessage = "Id do paciente necessário")]
        public int? IdPaciente { get; set; }
        public byte? IdSituacao { get; set; }

        [Required(ErrorMessage = "Data e horário necessários")]
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}

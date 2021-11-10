using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpMedicalGroup.webApi.Domains
{
    public partial class AreaMedico
    {
        public AreaMedico()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdAreaMedico { get; set; }

        [Required(ErrorMessage = "Nome da área do médico necessário")]
        public string Descricao { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}

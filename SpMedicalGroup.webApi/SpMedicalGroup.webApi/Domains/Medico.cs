using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpMedicalGroup.webApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdMedico { get; set; }

        [Required(ErrorMessage = "Id de usuário necessário")]
        public int? IdUsuario { get; set; }
        public short? IdAreaMedico { get; set; }
        public short? IdClinica { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage = "CRM necessário")]
        public string Crm { get; set; }

        public virtual AreaMedico IdAreaMedicoNavigation { get; set; }
        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}

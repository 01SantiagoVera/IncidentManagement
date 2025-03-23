using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IncidentManagement.Entities.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string Email { get; set; }

        public bool IsTechnician { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Incident> ReportedIncidents { get; set; }
        public virtual ICollection<Incident> AssignedIncidents { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
} 
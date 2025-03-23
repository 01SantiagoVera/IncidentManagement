using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IncidentManagement.Entities.Models
{
    public class Incident
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(200, ErrorMessage = "El título no puede exceder los 200 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Description { get; set; }

        [Required]
        public IncidentStatus Status { get; set; }

        [Required]
        public Priority Priority { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        [Required]
        public int ReporterId { get; set; }
        public virtual User Reporter { get; set; }

        public int? AssignedTechnicianId { get; set; }
        public virtual User AssignedTechnician { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }

    public enum IncidentStatus
    {
        Open,
        InProgress,
        Resolved,
        Closed
    }

    public enum Priority
    {
        Low,
        Medium,
        High,
        Critical
    }
} 
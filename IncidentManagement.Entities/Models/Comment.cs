using System;
using System.ComponentModel.DataAnnotations;

namespace IncidentManagement.Entities.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El contenido del comentario es obligatorio")]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public int IncidentId { get; set; }
        public virtual Incident Incident { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
} 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaBackend.Models
{
    [Table("Contacto")]
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TipoDeContacto { get; set; } = string.Empty;

        [Required]
        
        public string Nombre { get; set; } =  string.Empty;

        [Required]
       
        public string Telefono { get; set; } =  string.Empty;

        public string? Comentarios { get; set; }
    
      // Aquí usamos jsonb de PostgreSQL para guardar campos dinámicos
  
        public string? CamposAdicionales { get; set; } 
    }
}
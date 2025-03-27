using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdminInterface.Server.Models
{
    public class Incident
    {
        [Key]
        public int ID_Incident { get; set; }
        [ForeignKey("Equipement")]
        public int ID_Equipement { get; set; }
        [Required]
        public string Rapport_Incident { get; set; }
        public Equipement Equipement { get; set; }
    }
}

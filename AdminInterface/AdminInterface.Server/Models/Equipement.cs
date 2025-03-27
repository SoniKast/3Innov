using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdminInterface.Server.Models
{
    public class Equipement
    {
        [Key]
        public int ID_Equipement { get; set; }

        [ForeignKey("GroupeMonitoring")]
        public int ID_Groupe { get; set; }
        [Required]
        public string Type_equipement { get; set; }
        [Required]
        public string Description_equipement { get; set; }
        [Required]
        public string Marque { get; set; }
        [Required]
        public string Modele { get; set; }
        [Required]
        public string Commentaire { get; set; }
        [Required]
        public string Adresse_IP { get; set; }

        public GroupeMonitoring Groupe { get; set; }
        public List<Incident> Incidents { get; set; } = new();
    }
}

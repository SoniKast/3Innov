using System.ComponentModel.DataAnnotations;

namespace AdminInterface.Server.Models
{
    public class GroupeMonitoring
    {
        [Key]
        public int ID_Groupe { get; set; }
        [Required]
        public string Nom_GroupeM { get; set; }
        [Required]
        public string Droits { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Equipement> Equipements { get; set; } = new();
    }
}

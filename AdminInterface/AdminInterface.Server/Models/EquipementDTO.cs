
namespace AdminInterface.Server.Models
{
    public class EquipementDTO
    {
        public string Type_equipement { get; set; }
        public string Description_equipement { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string Commentaire { get; set; }
        public string Adresse_IP { get; set; }
        public int Groupe { get; set; } // ID du groupe
    }
}

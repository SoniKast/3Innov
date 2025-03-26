namespace AdminInterface.Server.Models
{
    public class Equipement
    {
        public int ID_Equipement { get; set; }
        public int ID_Groupe { get; set; }
        public string Type_Equipement { get; set; }
        public string Description_Equipement { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string Commentaire { get; set; }
        public string Adresse_IP { get; set; }

        public GroupeMonitoring Groupe { get; set; }
        public List<Incident> Incidents { get; set; } = new();
    }
}

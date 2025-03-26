namespace AdminInterface.Server.Models
{
    public class GroupeMonitoring
    {
        public int ID_Groupe { get; set; }
        public string Nom_GroupeM { get; set; }
        public string Droits { get; set; }
        public string Description { get; set; }
        public List<Equipement> Equipements { get; set; } = new();
    }
}

namespace AdminInterface.Server.Models
{
    public class Incident
    {
        public int ID_Incident { get; set; }
        public int ID_Equipement { get; set; }
        public string Rapport_Incident { get; set; }

        public Equipement Equipement { get; set; }
    }
}

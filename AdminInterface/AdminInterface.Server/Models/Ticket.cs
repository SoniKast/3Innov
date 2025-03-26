namespace AdminInterface.Server.Models
{
    public class Ticket
    {
        public int ID_Ticket { get; set; }
        public int ID_Utilisateur { get; set; }
        public int ID_Incident { get; set; }
        public string Etat_Ticket { get; set; }
        public string Nom_Ticket { get; set; }
        public string Description_Ticket { get; set; }
        public string Type_de_tickets { get; set; }
        public string Commentaire { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public Incident Incident { get; set; }
    }
}

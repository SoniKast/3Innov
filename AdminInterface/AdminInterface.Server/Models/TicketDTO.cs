
namespace AdminInterface.Server.Models
{
    public class TicketDTO
    {
        public int ID_Ticket { get; set; }
        public string Nom_Ticket { get; set; }
        public string Description_Ticket { get; set; }
        public string Etat_Ticket { get; set; }
        public string UtilisateurName { get; set; } // Concatenating first and last name or just using full name
        public string IncidentRapport { get; set; }
    }

}

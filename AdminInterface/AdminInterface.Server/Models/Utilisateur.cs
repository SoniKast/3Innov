using System.Net.Sockets;

namespace AdminInterface.Server.Models

{
    public class Utilisateur
    {
        public int ID_Utilisateur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Mot_de_pass { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
    }
}

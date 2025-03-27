using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace AdminInterface.Server.Models

{
    public class Utilisateur
    {
        [Key]
        public int ID_Utilisateur { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, PasswordPropertyText]
        public string Mot_de_pass { get; set; }
        [Required]
        public string Type { get; set; }

        public List<Ticket> Tickets { get; set; } = new();
    }
}

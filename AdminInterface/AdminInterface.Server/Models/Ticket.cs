﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdminInterface.Server.Models
{
    public class Ticket
    {
        [Key]
        public int ID_Ticket { get; set; }

        [Required]
        public string Etat_Ticket { get; set; }

        [Required]
        public string Nom_Ticket { get; set; }

        [Required]
        public string Description_Ticket { get; set; }

        [Required]
        public string Type_de_tickets { get; set; }

        [Required]
        public int ID_Utilisateur { get; set; }

        [Required]
        public int ID_Incident { get; set; }

        [ForeignKey("ID_Utilisateur")]
        public Utilisateur? Utilisateur { get; set; }

        [ForeignKey("ID_Incident")]
        public Incident? Incident { get; set; }
    }

}

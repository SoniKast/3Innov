using System;

namespace TicketInterface
{
    public static class SessionManager
    {
        public static int UserID { get; set; } // ID de l'utilisateur connecté
        public static string UserName { get; set; } // Nom de l'utilisateur connecté
        public static string UserEmail { get; set; } // Email de l'utilisateur connecté
        public static bool IsLoggedIn => UserID > 0; // Vérifie si un utilisateur est connecté

        public static void ClearSession()
        {
            UserID = 0;
            UserName = null;
            UserEmail = null;
        }
    }
}

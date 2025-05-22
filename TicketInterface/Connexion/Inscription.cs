using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TicketInterface
{
    public partial class Inscription : Form
    {
        private string connectionString = "Server=localhost;Database=innovationprojet2025;Uid=root;Pwd=root;";
        private Form1 formConnexion; // Référence au formulaire de connexion

        // Constructeur avec une instance de Form1
        public Inscription(Form1 formConnexion)
        {
            InitializeComponent();
            this.formConnexion = formConnexion;
        }

        private void ButtonInscription_Click(object sender, EventArgs e)
        {
            string nom = nomTextbox.Text.Trim();
            string prenom = prenomTextbox.Text.Trim();
            string email = emailTextbox.Text.Trim();
            string motDePasse = MdpTextbox.Text;

            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(motDePasse))
            {
                MessageBox.Show("Veuillez remplir tous les champs !");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("L'adresse e-mail est invalide. Assurez-vous qu'elle contient '@', un point et un domaine valide.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO utilisateur (nom, prenom, Email, Mot_de_pass) VALUES (@Nom, @Prenom, @Email, @MotDePasse)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nom", nom);
                        cmd.Parameters.AddWithValue("@Prenom", prenom);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@MotDePasse", motDePasse);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Inscription réussie ! Vous pouvez maintenant vous connecter.");
                            this.Close(); // Fermer le formulaire d'inscription
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de l'inscription. Veuillez réessayer.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur : {ex.Message}");
                }
            }
        }

        private void LienConnexion_Click(object sender, EventArgs e)
        {
            this.Close(); // Fermer le formulaire d'inscription
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Réaffiche le formulaire de connexion lorsque ce formulaire est fermé
        private void Inscription_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formConnexion != null)
            {
                formConnexion.Show();
            }
        }
    }
}

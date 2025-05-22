using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace TicketInterface
{
    public partial class Form1 : Form
    {
        // Chaîne de connexion à la base de données
        private string connectionString = "Server=localhost;Database=innovationprojet2025;Uid=root;Pwd=root;";

        public Form1()
        {
            InitializeComponent();
        }

        private void MdpOublie_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fonctionnalité à implémenter : Réinitialiser le mot de passe.");
        }

        private void EmailLabel_Click(object sender, EventArgs e)
        {
        }

        private void emailTextbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void MdpTextbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Inscription_Click(object sender, EventArgs e)
        {
            // Ouvrir le formulaire d'inscription avec une référence à ce formulaire
            Inscription inscriptionForm = new Inscription(this);
            inscriptionForm.Show();
            this.Hide();
        }


        private void Titre_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = emailTextbox.Text;
            string password = MdpTextbox.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez remplir tous les champs !");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Requête SQL pour vérifier les identifiants
                    string query = "SELECT * FROM utilisateur WHERE Email = @Email LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hashedPassword = reader["Mot_de_pass"].ToString();

                                // Vérifie le mot de passe fourni avec le hash
                                if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                                {
                                    SessionManager.UserID = Convert.ToInt32(reader["ID_Utilisateur"]);
                                    SessionManager.UserName = $"{reader["prenom"]} {reader["nom"]}";
                                    SessionManager.UserEmail = email;

                                    MessageBox.Show($"Bienvenue, {SessionManager.UserName} !");

                                    InterfacePrincipale mainForm = new InterfacePrincipale();
                                    mainForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Mot de passe incorrect.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Email ou mot de passe incorrect.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la connexion : {ex.Message}");
                }
            }
        }
    }
}

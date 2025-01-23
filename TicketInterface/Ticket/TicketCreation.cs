using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TicketInterface
{
    public partial class TicketCreation : Form
    {
        private string connectionString = "Server=localhost;Database=innovationprojet2025;Uid=root;Pwd=;";
        public TicketCreation()
        {
            InitializeComponent();
            LoadIncidents(); // Charger les incidents au démarrage
        }
        private void LoadIncidents()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))  // Changer SqlConnection par MySqlConnection
                {
                    connection.Open();
                    string query = "SELECT ID_Incident, Rapport_Incident FROM incident";
                    using (MySqlCommand command = new MySqlCommand(query, connection))  // Changer SqlCommand par MySqlCommand
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())  // Changer SqlDataReader par MySqlDataReader
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            // Remplir le comboBox avec les données
                            comboBox2.DisplayMember = "Rapport_Incident";
                            comboBox2.ValueMember = "ID_Incident";
                            comboBox2.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des incidents : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Dans la méthode CreerTicket_Click()
        private void CreerTicket_Click(object sender, EventArgs e)
        {
            // Récupérer les données de l'interface
            string nomTicket = NomTicketTextbox.Text;
            string description = LabelTextBox.Text;
            string typeTicket = comboBox1.SelectedItem?.ToString();
            string commentaire = textBox1.Text;

            // Récupérer l'ID de l'incident sélectionné dans comboBox2
            int idIncident = (comboBox2.SelectedValue != null) ? Convert.ToInt32(comboBox2.SelectedValue) : 0;

            // Vérification des champs requis
            if (string.IsNullOrWhiteSpace(nomTicket) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(typeTicket) || idIncident == 0)
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires et sélectionner un incident.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Connexion à la base de données
            using (MySqlConnection connection = new MySqlConnection(connectionString))  // Changer SqlConnection par MySqlConnection
            {
                try
                {
                    connection.Open();

                    // Préparer la commande d'insertion
                    string query = @"
                    INSERT INTO Ticket (ID_Utilisateur, ID_Incident, Etat_Ticket, nom_ticket, Description_ticket, Type_de_tickets, Commentaire)
                    VALUES (@ID_Utilisateur, @ID_Incident, @Etat_Ticket, @nom_ticket, @Description_ticket, @Type_de_tickets, @Commentaire)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))  // Changer SqlCommand par MySqlCommand
                    {
                        // Remplacer les paramètres
                        command.Parameters.AddWithValue("@ID_Utilisateur", SessionManager.UserID); // Remplacez par l'ID utilisateur actif
                        command.Parameters.AddWithValue("@ID_Incident", idIncident); // Utilisation de l'ID de l'incident sélectionné
                        command.Parameters.AddWithValue("@Etat_Ticket", "ouvert");
                        command.Parameters.AddWithValue("@nom_ticket", nomTicket);
                        command.Parameters.AddWithValue("@Description_ticket", description);
                        command.Parameters.AddWithValue("@Type_de_tickets", typeTicket);
                        command.Parameters.AddWithValue("@Commentaire", commentaire);

                        // Exécuter la commande
                        command.ExecuteNonQuery();
                    }

                    // Message de confirmation
                    MessageBox.Show("Le ticket a été créé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Fermer la fenêtre actuelle
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la création du ticket : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

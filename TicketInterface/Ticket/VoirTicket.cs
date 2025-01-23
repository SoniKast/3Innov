using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TicketInterface
{
    public partial class VoirTicket : Form
    {
        private string connectionString = "Server=localhost;Database=innovationprojet2025;Uid=root;Pwd=;";

        public VoirTicket()
        {
            InitializeComponent();
            LoadTickets(); // Charger les tickets au démarrage
        }

        /// <summary>
        /// Charge les données de la table Ticket dans le DataGridView
        /// </summary>
        private void LoadTickets()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Requête pour récupérer les données de la table Ticket
                    string query = @"
                        SELECT 
                            t.ID_Ticket AS 'ID Ticket',
                            t.nom_ticket AS 'Nom du Ticket',
                            t.Type_de_tickets AS 'Type',
                            t.Description_ticket AS 'Description',
                            t.Etat_Ticket AS 'État',
                            t.Commentaire AS 'Commentaire',
                            u.nom AS 'Utilisateur',
                            i.Rapport_Incident AS 'Incident'
                        FROM 
                            Ticket t
                        LEFT JOIN 
                            Utilisateur u ON t.ID_Utilisateur = u.ID_Utilisateur
                        LEFT JOIN 
                            Incident i ON t.ID_Incident = i.ID_Incident";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Remplir le DataGridView avec les données
                            dataGridView1.DataSource = dataTable;

                            // Rendre le DataGridView en lecture seule
                            dataGridView1.ReadOnly = true;

                            // Adapter automatiquement la largeur des colonnes
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                            // Empêcher la sélection des lignes entières
                            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                            // Supprimer la possibilité d'ajouter ou de supprimer des lignes
                            dataGridView1.AllowUserToAddRows = false;
                            dataGridView1.AllowUserToDeleteRows = false;

                            // Supprimer l'édition des cellules
                            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des tickets : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

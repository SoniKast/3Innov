using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TicketInterface
{
    public partial class VoirEquipement : Form
    {
        private string connectionString = "Server=localhost;Database=innovationprojet2025;Uid=root;Pwd=;";

        public VoirEquipement()
        {
            InitializeComponent();
            LoadEquipements(); // Charger les équipements au démarrage
        }

        /// <summary>
        /// Charge les données de la table Equipement dans le DataGridView
        /// </summary>
        private void LoadEquipements()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Requête pour récupérer les données de la table Equipement
                    string query = @"
                        SELECT 
                            e.ID_Equipement AS 'ID Equipement',
                            e.Marque AS 'Marque',
                            e.Modele AS 'Modele',
                            e.Type_equipement AS 'Type',
                            e.Description_equipement AS 'Description',
                            g.nom_groupem AS 'Groupe'
                        FROM 
                            Equipement e
                        LEFT JOIN 
                            Groupemonitoring g 
                        ON 
                            e.ID_Groupe = g.ID_Groupe";

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
                MessageBox.Show($"Erreur lors du chargement des équipements : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

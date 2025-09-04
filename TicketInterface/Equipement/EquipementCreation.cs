using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TicketInterface
{
    public partial class EquipementCreation : Form
    {
        private string connectionString = "Server=localhost;Database=innovationprojet2025;Uid=root;Pwd=root;";

        public EquipementCreation()
        {
            InitializeComponent();
            LoadGroupes(); // Charger les groupes dans le ComboBox au démarrage
        }

        /// <summary>
        /// Charge les groupes dans le ComboBox
        /// </summary>
        private void LoadGroupes()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ID_Groupe, nom_groupem FROM groupemonitoring";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            // Remplir le comboBox avec les données
                            GroupeCombo.DisplayMember = "nom_groupem";
                            GroupeCombo.ValueMember = "ID_Groupe";
                            GroupeCombo.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des groupes : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gère l'événement de clic pour enregistrer un équipement
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            string marque = MarquetextBox.Text;
            string modele = textBox2.Text;
            string typeEquipement = textBox1.Text;
            string description = richTextBox1.Text;
            string commentaire = textBox3.Text;

            // Récupérer l'ID du groupe sélectionné
            int idGroupe = (GroupeCombo.SelectedValue != null) ? Convert.ToInt32(GroupeCombo.SelectedValue) : 0;

            // Vérifier si les champs requis sont remplis
            if (string.IsNullOrWhiteSpace(marque) || string.IsNullOrWhiteSpace(modele) || string.IsNullOrWhiteSpace(typeEquipement) || idGroupe == 0)
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires et sélectionner un groupe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Enregistrer les données dans la base
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO equipement (ID_Groupe, Type_equipement, Description_equipement, Marque, Modele, Commentaire)
                        VALUES (@ID_Groupe, @Type_equipement, @Description_equipement, @Marque, @Modele, @Commentaire)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID_Groupe", idGroupe);
                        command.Parameters.AddWithValue("@Type_equipement", typeEquipement);
                        command.Parameters.AddWithValue("@Description_equipement", description);
                        command.Parameters.AddWithValue("@Marque", marque);
                        command.Parameters.AddWithValue("@Modele", modele);
                        command.Parameters.AddWithValue("@Commentaire", commentaire);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("L'équipement a été enregistré avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Fermer la fenêtre actuelle
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement de l'équipement : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

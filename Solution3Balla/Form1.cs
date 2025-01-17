using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Solution3Balla
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=localhost;Database=innovationprojet2025;Uid=root;Pwd=mdp;";
        private DataTable currentDataTable;
        private string currentTableName;

        public Form1()
        {
            InitializeComponent();
            ticketsToolStripMenuItem.Click += TicketsToolStripMenuItem_Click;
            equipementToolStripMenuItem.Click += EquipementToolStripMenuItem_Click;
            ouvrirUnLogToolStripMenuItem.Click += OuvrirUnLogToolStripMenuItem_Click;
            enregistrerDansLaBaseToolStripMenuItem.Click += EnregistrerDansLaBaseToolStripMenuItem_Click;
            enregistrerDansUnLogToolStripMenuItem.Click += EnregistrerDansUnLogToolStripMenuItem_Click;

            // Charger la vue "Equipement" par défaut
            LoadData("equipement");
        }

        private void LoadData(string tableName)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"SELECT * FROM {tableName};";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            currentDataTable = new DataTable();
                            adapter.Fill(currentDataTable);
                            dataGridView1.DataSource = currentDataTable;
                            currentTableName = tableName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}");
            }
        }

        private void TicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData("ticket");
        }

        private void EquipementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData("equipement");
        }

        private void OuvrirUnLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Fichiers XML (*.xml)|*.xml";
                openFileDialog.Title = "Ouvrir un fichier XML";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.ReadXml(openFileDialog.FileName);
                        dataGridView1.DataSource = dataTable;
                        currentDataTable = dataTable;

                        MessageBox.Show("Fichier XML chargé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de l'ouverture du fichier XML : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void EnregistrerDansUnLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDataTable == null)
            {
                MessageBox.Show("Aucune donnée à sauvegarder.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ouvrir une boîte de dialogue pour demander un titre pour la table
            using (Form inputDialog = new Form())
            {
                inputDialog.Width = 400;
                inputDialog.Height = 150;
                inputDialog.Text = "Nom de la table";

                Label label = new Label() { Left = 20, Top = 20, Text = "Entrez un nom pour la table : " };
                TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
                Button confirmationButton = new Button() { Text = "OK", Left = 280, Width = 80, Top = 80, DialogResult = DialogResult.OK };

                inputDialog.Controls.Add(label);
                inputDialog.Controls.Add(textBox);
                inputDialog.Controls.Add(confirmationButton);
                inputDialog.AcceptButton = confirmationButton;

                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    string tableName = textBox.Text.Trim();

                    if (!string.IsNullOrEmpty(tableName))
                    {
                        currentDataTable.TableName = tableName; // Définir le nom de la table
                    }
                    else
                    {
                        MessageBox.Show("Le nom de la table ne peut pas être vide. Opération annulée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // Annuler si l'utilisateur ferme la boîte de dialogue
                    return;
                }
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Fichiers XML (*.xml)|*.xml";
                saveFileDialog.Title = "Enregistrer les données en tant que fichier XML";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        currentDataTable.WriteXml(saveFileDialog.FileName, XmlWriteMode.WriteSchema);
                        MessageBox.Show("Fichier XML enregistré avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de l'enregistrement du fichier XML : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void EnregistrerDansLaBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDataTable == null || string.IsNullOrEmpty(currentTableName))
            {
                MessageBox.Show("Aucune donnée à enregistrer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Valider les colonnes du DataTable
                    if (!ValidateColumns(currentDataTable, currentTableName))
                    {
                        MessageBox.Show("Les colonnes du fichier XML ne correspondent pas à la table cible.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (DataRow row in currentDataTable.Rows)
                    {
                        string query;
                        if (row.RowState == DataRowState.Modified)
                        {
                            // Requête SQL pour les mises à jour
                            query = currentTableName == "equipement"
                                ? @"UPDATE equipement
                            SET ID_Groupe = @ID_Groupe, Type_equipement = @Type_equipement, Description_equipement = @Description_equipement, 
                                Marque = @Marque, Modele = @Modele, Commentaire = @Commentaire
                            WHERE ID_Equipement = @ID_Equipement"
                                : @"UPDATE ticket
                            SET ID_Utilisateur = @ID_Utilisateur, ID_Incident = @ID_Incident, Etat_Ticket = @Etat_Ticket,
                                nom_ticket = @nom_ticket, Description_ticket = @Description_ticket, 
                                Type_de_tickets = @Type_de_tickets, Commentaire = @Commentaire
                            WHERE ID_Ticket = @ID_Ticket";
                        }
                        else if (row.RowState == DataRowState.Added)
                        {
                            // Requête SQL pour les insertions
                            query = currentTableName == "equipement"
                                ? @"INSERT INTO equipement (ID_Equipement, ID_Groupe, Type_equipement, Description_equipement, Marque, Modele, Commentaire)
                            VALUES (@ID_Equipement, @ID_Groupe, @Type_equipement, @Description_equipement, @Marque, @Modele, @Commentaire)"
                                : @"INSERT INTO ticket (ID_Ticket, ID_Utilisateur, ID_Incident, Etat_Ticket, nom_ticket, Description_ticket, Type_de_tickets, Commentaire)
                            VALUES (@ID_Ticket, @ID_Utilisateur, @ID_Incident, @Etat_Ticket, @nom_ticket, @Description_ticket, @Type_de_tickets, @Commentaire)";
                        }
                        else
                        {
                            // Ignorer les lignes non modifiées
                            continue;
                        }

                        // Préparer et exécuter la commande SQL
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            foreach (DataColumn col in currentDataTable.Columns)
                            {
                                cmd.Parameters.AddWithValue($"@{col.ColumnName}", row[col]);
                            }

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Les données ont été enregistrées avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentDataTable.AcceptChanges(); // Confirmer les changements
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement dans la base : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Méthode pour valider les colonnes
        private bool ValidateColumns(DataTable dataTable, string tableName)
        {
            try
            {
                // Dictionnaire des colonnes attendues pour chaque table
                var expectedColumns = new Dictionary<string, List<string>>
        {
            {
                "equipement",
                new List<string> { "ID_Equipement", "ID_Groupe", "Type_equipement", "Description_equipement", "Marque", "Modele", "Commentaire" }
            },
            {
                "ticket",
                new List<string> { "ID_Ticket", "ID_Utilisateur", "ID_Incident", "Etat_Ticket", "nom_ticket", "Description_ticket", "Type_de_tickets", "Commentaire" }
            }
        };

                // Vérifier si la table cible est connue
                if (!expectedColumns.ContainsKey(tableName))
                {
                    MessageBox.Show($"La table '{tableName}' n'est pas reconnue.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Comparer les colonnes attendues avec celles du DataTable
                var actualColumns = dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
                var missingColumns = expectedColumns[tableName].Except(actualColumns).ToList();

                if (missingColumns.Any())
                {
                    MessageBox.Show($"Colonnes manquantes : {string.Join(", ", missingColumns)}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la validation des colonnes : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Surcharge pour détecter les raccourcis clavier
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S)) // Vérifier si Ctrl+S est pressé
            {
                EnregistrerDansLaBaseToolStripMenuItem_Click(this, EventArgs.Empty); // Appeler la méthode d'enregistrement
                return true; // Empêcher la propagation de l'événement
            }

            return base.ProcessCmdKey(ref msg, keyData); // Passer l'événement au gestionnaire par défaut
        }
    }
}

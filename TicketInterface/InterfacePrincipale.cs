using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketInterface
{
    public partial class InterfacePrincipale : Form
    {
        public InterfacePrincipale()
        {
            InitializeComponent();
        }

        private void déconnexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Nettoyer la session
            SessionManager.ClearSession();

            // Ouvrir le formulaire de connexion
            Form1 loginForm = new Form1();
            loginForm.Show();

            // Fermer l'interface principale
            this.Close();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Fermer complètement l'application
        }

        private void créerUnTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreerUnTicket();
        }

        private void voirSesTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VoirSesTickets();
        }

        private void enregistrerSonÉquipementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreerEquipement();
        }

        private void voirSonÉquipementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VoirSonEquipement();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreerUnTicket();
        }

        private void InterfacePrincipale_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void EnregistrerEquipement_Click(object sender, EventArgs e)
        {
            CreerEquipement();
        }

        private void CreerUnTicket()
        {
            // Créer une instance du formulaire TicketCreation
            TicketCreation ticketForm = new TicketCreation();

            // Afficher le formulaire comme modal
            this.Enabled = false; // Désactiver l'interface principale
            ticketForm.FormClosed += (s, args) => this.Enabled = true; // Réactiver à la fermeture
            ticketForm.ShowDialog(); // Ouvre en mode modal
        }
        private void CreerEquipement()
        {
            // Créer une instance du formulaire EquipementCreation
            EquipementCreation equipementForm = new EquipementCreation();

            // Afficher le formulaire comme modal
            this.Enabled = false; // Désactiver l'interface principale
            equipementForm.FormClosed += (s, args) => this.Enabled = true; // Réactiver à la fermeture
            equipementForm.ShowDialog(); // Ouvre en mode modal
        }

        private void VoirSesTickets()
        {
            VoirTicket ticket = new VoirTicket();

            this.Enabled = false;
            ticket.FormClosed += (s, args) => this.Enabled = true;
            ticket.ShowDialog();
        }

        private void VoirSonEquipement()
        {
            VoirEquipement equipement = new VoirEquipement();

            this.Enabled = false;
            equipement.FormClosed += (s, args) => this.Enabled = true;
            equipement.ShowDialog();
        }

        private void VoirTicket_Click(object sender, EventArgs e)
        {
            VoirSesTickets();
        }

        private void VoirEquipement_Click(object sender, EventArgs e)
        {
            VoirSonEquipement();
        }
    }
}

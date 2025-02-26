namespace TicketInterface
{
    partial class Inscription
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Titre = new System.Windows.Forms.Label();
            this.MdpLabel = new System.Windows.Forms.Label();
            this.MdpTextbox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            this.ButtonInscription = new System.Windows.Forms.Button();
            this.PrenomInscription = new System.Windows.Forms.Label();
            this.prenomTextbox = new System.Windows.Forms.TextBox();
            this.NomInscription = new System.Windows.Forms.Label();
            this.nomTextbox = new System.Windows.Forms.TextBox();
            this.LienConnexion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Titre
            // 
            this.Titre.AutoSize = true;
            this.Titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titre.Location = new System.Drawing.Point(112, 58);
            this.Titre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Titre.Name = "Titre";
            this.Titre.Size = new System.Drawing.Size(370, 39);
            this.Titre.TabIndex = 15;
            this.Titre.Text = "Bienvenue sur Gestiam";
            this.Titre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MdpLabel
            // 
            this.MdpLabel.AutoSize = true;
            this.MdpLabel.Location = new System.Drawing.Point(164, 293);
            this.MdpLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MdpLabel.Name = "MdpLabel";
            this.MdpLabel.Size = new System.Drawing.Size(89, 16);
            this.MdpLabel.TabIndex = 12;
            this.MdpLabel.Text = "Mot de passe";
            // 
            // MdpTextbox
            // 
            this.MdpTextbox.Location = new System.Drawing.Point(168, 313);
            this.MdpTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MdpTextbox.Name = "MdpTextbox";
            this.MdpTextbox.Size = new System.Drawing.Size(284, 22);
            this.MdpTextbox.TabIndex = 3;
            this.MdpTextbox.UseSystemPasswordChar = true;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(164, 245);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(41, 16);
            this.EmailLabel.TabIndex = 10;
            this.EmailLabel.Text = "Email";
            // 
            // emailTextbox
            // 
            this.emailTextbox.Location = new System.Drawing.Point(168, 265);
            this.emailTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(284, 22);
            this.emailTextbox.TabIndex = 2;
            // 
            // ButtonInscription
            // 
            this.ButtonInscription.Location = new System.Drawing.Point(216, 375);
            this.ButtonInscription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonInscription.Name = "ButtonInscription";
            this.ButtonInscription.Size = new System.Drawing.Size(177, 41);
            this.ButtonInscription.TabIndex = 5;
            this.ButtonInscription.Text = "Inscription";
            this.ButtonInscription.UseVisualStyleBackColor = true;
            this.ButtonInscription.Click += new System.EventHandler(this.ButtonInscription_Click);
            // 
            // PrenomInscription
            // 
            this.PrenomInscription.AutoSize = true;
            this.PrenomInscription.Location = new System.Drawing.Point(164, 194);
            this.PrenomInscription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PrenomInscription.Name = "PrenomInscription";
            this.PrenomInscription.Size = new System.Drawing.Size(54, 16);
            this.PrenomInscription.TabIndex = 19;
            this.PrenomInscription.Text = "Prénom";
            // 
            // prenomTextbox
            // 
            this.prenomTextbox.Location = new System.Drawing.Point(168, 214);
            this.prenomTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.prenomTextbox.Name = "prenomTextbox";
            this.prenomTextbox.Size = new System.Drawing.Size(284, 22);
            this.prenomTextbox.TabIndex = 1;
            // 
            // NomInscription
            // 
            this.NomInscription.AutoSize = true;
            this.NomInscription.Location = new System.Drawing.Point(164, 146);
            this.NomInscription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NomInscription.Name = "NomInscription";
            this.NomInscription.Size = new System.Drawing.Size(36, 16);
            this.NomInscription.TabIndex = 17;
            this.NomInscription.Text = "Nom";
            // 
            // nomTextbox
            // 
            this.nomTextbox.Location = new System.Drawing.Point(168, 166);
            this.nomTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nomTextbox.Name = "nomTextbox";
            this.nomTextbox.Size = new System.Drawing.Size(284, 22);
            this.nomTextbox.TabIndex = 0;
            // 
            // LienConnexion
            // 
            this.LienConnexion.AutoSize = true;
            this.LienConnexion.BackColor = System.Drawing.SystemColors.Control;
            this.LienConnexion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LienConnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LienConnexion.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LienConnexion.Location = new System.Drawing.Point(164, 341);
            this.LienConnexion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LienConnexion.Name = "LienConnexion";
            this.LienConnexion.Size = new System.Drawing.Size(119, 17);
            this.LienConnexion.TabIndex = 4;
            this.LienConnexion.Text = "Déjà un compte ?";
            this.LienConnexion.Click += new System.EventHandler(this.LienConnexion_Click);
            // 
            // Inscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 490);
            this.Controls.Add(this.LienConnexion);
            this.Controls.Add(this.PrenomInscription);
            this.Controls.Add(this.prenomTextbox);
            this.Controls.Add(this.NomInscription);
            this.Controls.Add(this.nomTextbox);
            this.Controls.Add(this.Titre);
            this.Controls.Add(this.MdpLabel);
            this.Controls.Add(this.MdpTextbox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.emailTextbox);
            this.Controls.Add(this.ButtonInscription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Inscription";
            this.Text = "Ticket Box";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inscription_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titre;
        private System.Windows.Forms.Label MdpLabel;
        private System.Windows.Forms.TextBox MdpTextbox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox emailTextbox;
        private System.Windows.Forms.Button ButtonInscription;
        private System.Windows.Forms.Label PrenomInscription;
        private System.Windows.Forms.TextBox prenomTextbox;
        private System.Windows.Forms.Label NomInscription;
        private System.Windows.Forms.TextBox nomTextbox;
        private System.Windows.Forms.Label LienConnexion;
    }
}
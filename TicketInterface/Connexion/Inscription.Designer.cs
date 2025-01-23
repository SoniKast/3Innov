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
            this.Titre.Location = new System.Drawing.Point(84, 47);
            this.Titre.Name = "Titre";
            this.Titre.Size = new System.Drawing.Size(295, 31);
            this.Titre.TabIndex = 15;
            this.Titre.Text = "Bienvenue sur Gestiam";
            this.Titre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MdpLabel
            // 
            this.MdpLabel.AutoSize = true;
            this.MdpLabel.Location = new System.Drawing.Point(123, 238);
            this.MdpLabel.Name = "MdpLabel";
            this.MdpLabel.Size = new System.Drawing.Size(71, 13);
            this.MdpLabel.TabIndex = 12;
            this.MdpLabel.Text = "Mot de passe";
            // 
            // MdpTextbox
            // 
            this.MdpTextbox.Location = new System.Drawing.Point(126, 254);
            this.MdpTextbox.Name = "MdpTextbox";
            this.MdpTextbox.Size = new System.Drawing.Size(214, 20);
            this.MdpTextbox.TabIndex = 3;
            this.MdpTextbox.UseSystemPasswordChar = true;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(123, 199);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(32, 13);
            this.EmailLabel.TabIndex = 10;
            this.EmailLabel.Text = "Email";
            // 
            // emailTextbox
            // 
            this.emailTextbox.Location = new System.Drawing.Point(126, 215);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(214, 20);
            this.emailTextbox.TabIndex = 2;
            // 
            // ButtonInscription
            // 
            this.ButtonInscription.Location = new System.Drawing.Point(162, 305);
            this.ButtonInscription.Name = "ButtonInscription";
            this.ButtonInscription.Size = new System.Drawing.Size(133, 33);
            this.ButtonInscription.TabIndex = 5;
            this.ButtonInscription.Text = "Inscription";
            this.ButtonInscription.UseVisualStyleBackColor = true;
            this.ButtonInscription.Click += new System.EventHandler(this.ButtonInscription_Click);
            // 
            // PrenomInscription
            // 
            this.PrenomInscription.AutoSize = true;
            this.PrenomInscription.Location = new System.Drawing.Point(123, 158);
            this.PrenomInscription.Name = "PrenomInscription";
            this.PrenomInscription.Size = new System.Drawing.Size(43, 13);
            this.PrenomInscription.TabIndex = 19;
            this.PrenomInscription.Text = "Prénom";
            // 
            // prenomTextbox
            // 
            this.prenomTextbox.Location = new System.Drawing.Point(126, 174);
            this.prenomTextbox.Name = "prenomTextbox";
            this.prenomTextbox.Size = new System.Drawing.Size(214, 20);
            this.prenomTextbox.TabIndex = 1;
            // 
            // NomInscription
            // 
            this.NomInscription.AutoSize = true;
            this.NomInscription.Location = new System.Drawing.Point(123, 119);
            this.NomInscription.Name = "NomInscription";
            this.NomInscription.Size = new System.Drawing.Size(29, 13);
            this.NomInscription.TabIndex = 17;
            this.NomInscription.Text = "Nom";
            // 
            // nomTextbox
            // 
            this.nomTextbox.Location = new System.Drawing.Point(126, 135);
            this.nomTextbox.Name = "nomTextbox";
            this.nomTextbox.Size = new System.Drawing.Size(214, 20);
            this.nomTextbox.TabIndex = 0;
            // 
            // LienConnexion
            // 
            this.LienConnexion.AutoSize = true;
            this.LienConnexion.BackColor = System.Drawing.SystemColors.ControlDark;
            this.LienConnexion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LienConnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LienConnexion.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LienConnexion.Location = new System.Drawing.Point(123, 277);
            this.LienConnexion.Name = "LienConnexion";
            this.LienConnexion.Size = new System.Drawing.Size(91, 13);
            this.LienConnexion.TabIndex = 4;
            this.LienConnexion.Text = "Déjà un compte ?";
            this.LienConnexion.Click += new System.EventHandler(this.LienConnexion_Click);
            // 
            // Inscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 398);
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
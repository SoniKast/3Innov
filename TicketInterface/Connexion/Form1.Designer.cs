namespace TicketInterface
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new System.Windows.Forms.Button();
            emailTextbox = new System.Windows.Forms.TextBox();
            EmailLabel = new System.Windows.Forms.Label();
            MdpLabel = new System.Windows.Forms.Label();
            MdpTextbox = new System.Windows.Forms.TextBox();
            Inscription = new System.Windows.Forms.Label();
            Titre = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(160, 300);
            button1.Margin = new System.Windows.Forms.Padding(4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(155, 38);
            button1.TabIndex = 4;
            button1.Text = "Connexion";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // emailTextbox
            // 
            emailTextbox.Location = new System.Drawing.Point(113, 152);
            emailTextbox.Margin = new System.Windows.Forms.Padding(4);
            emailTextbox.Name = "emailTextbox";
            emailTextbox.Size = new System.Drawing.Size(249, 23);
            emailTextbox.TabIndex = 0;
            emailTextbox.TextChanged += emailTextbox_TextChanged;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new System.Drawing.Point(109, 134);
            EmailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new System.Drawing.Size(36, 15);
            EmailLabel.TabIndex = 2;
            EmailLabel.Text = "Email";
            EmailLabel.Click += EmailLabel_Click;
            // 
            // MdpLabel
            // 
            MdpLabel.AutoSize = true;
            MdpLabel.Location = new System.Drawing.Point(109, 202);
            MdpLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            MdpLabel.Name = "MdpLabel";
            MdpLabel.Size = new System.Drawing.Size(77, 15);
            MdpLabel.TabIndex = 4;
            MdpLabel.Text = "Mot de passe";
            // 
            // MdpTextbox
            // 
            MdpTextbox.Location = new System.Drawing.Point(113, 220);
            MdpTextbox.Margin = new System.Windows.Forms.Padding(4);
            MdpTextbox.Name = "MdpTextbox";
            MdpTextbox.Size = new System.Drawing.Size(249, 23);
            MdpTextbox.TabIndex = 2;
            MdpTextbox.UseSystemPasswordChar = true;
            MdpTextbox.TextChanged += MdpTextbox_TextChanged;
            // 
            // Inscription
            // 
            Inscription.AutoSize = true;
            Inscription.BackColor = System.Drawing.SystemColors.Control;
            Inscription.Cursor = System.Windows.Forms.Cursors.Hand;
            Inscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            Inscription.ForeColor = System.Drawing.SystemColors.Highlight;
            Inscription.Location = new System.Drawing.Point(113, 179);
            Inscription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Inscription.Name = "Inscription";
            Inscription.Size = new System.Drawing.Size(87, 13);
            Inscription.TabIndex = 1;
            Inscription.Text = "Pas de compte ?";
            Inscription.Click += Inscription_Click;
            // 
            // Titre
            // 
            Titre.AutoSize = true;
            Titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Titre.Location = new System.Drawing.Point(70, 50);
            Titre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Titre.Name = "Titre";
            Titre.Size = new System.Drawing.Size(295, 31);
            Titre.TabIndex = 7;
            Titre.Text = "Bienvenue sur Gestiam";
            Titre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            Titre.Click += Titre_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(477, 411);
            Controls.Add(Titre);
            Controls.Add(Inscription);
            Controls.Add(MdpLabel);
            Controls.Add(MdpTextbox);
            Controls.Add(EmailLabel);
            Controls.Add(emailTextbox);
            Controls.Add(button1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "Form1";
            Text = "Ticket Box";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox emailTextbox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label MdpLabel;
        private System.Windows.Forms.TextBox MdpTextbox;
        private System.Windows.Forms.Label Inscription;
        private System.Windows.Forms.Label Titre;
    }
}


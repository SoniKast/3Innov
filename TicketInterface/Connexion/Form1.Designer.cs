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
            this.button1 = new System.Windows.Forms.Button();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.MdpLabel = new System.Windows.Forms.Label();
            this.MdpTextbox = new System.Windows.Forms.TextBox();
            this.MdpOublie = new System.Windows.Forms.Label();
            this.Inscription = new System.Windows.Forms.Label();
            this.Titre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "Connexion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // emailTextbox
            // 
            this.emailTextbox.Location = new System.Drawing.Point(97, 132);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(214, 20);
            this.emailTextbox.TabIndex = 0;
            this.emailTextbox.TextChanged += new System.EventHandler(this.emailTextbox_TextChanged);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(94, 116);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(32, 13);
            this.EmailLabel.TabIndex = 2;
            this.EmailLabel.Text = "Email";
            this.EmailLabel.Click += new System.EventHandler(this.EmailLabel_Click);
            // 
            // MdpLabel
            // 
            this.MdpLabel.AutoSize = true;
            this.MdpLabel.Location = new System.Drawing.Point(94, 175);
            this.MdpLabel.Name = "MdpLabel";
            this.MdpLabel.Size = new System.Drawing.Size(71, 13);
            this.MdpLabel.TabIndex = 4;
            this.MdpLabel.Text = "Mot de passe";
            // 
            // MdpTextbox
            // 
            this.MdpTextbox.Location = new System.Drawing.Point(97, 191);
            this.MdpTextbox.Name = "MdpTextbox";
            this.MdpTextbox.Size = new System.Drawing.Size(214, 20);
            this.MdpTextbox.TabIndex = 2;
            this.MdpTextbox.UseSystemPasswordChar = true;
            this.MdpTextbox.TextChanged += new System.EventHandler(this.MdpTextbox_TextChanged);
            // 
            // MdpOublie
            // 
            this.MdpOublie.AutoSize = true;
            this.MdpOublie.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MdpOublie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MdpOublie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MdpOublie.ForeColor = System.Drawing.SystemColors.Highlight;
            this.MdpOublie.Location = new System.Drawing.Point(97, 214);
            this.MdpOublie.Name = "MdpOublie";
            this.MdpOublie.Size = new System.Drawing.Size(111, 13);
            this.MdpOublie.TabIndex = 3;
            this.MdpOublie.Text = "Mot de passe oublié ?";
            this.MdpOublie.Click += new System.EventHandler(this.MdpOublie_Click);
            // 
            // Inscription
            // 
            this.Inscription.AutoSize = true;
            this.Inscription.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Inscription.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Inscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inscription.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Inscription.Location = new System.Drawing.Point(97, 155);
            this.Inscription.Name = "Inscription";
            this.Inscription.Size = new System.Drawing.Size(87, 13);
            this.Inscription.TabIndex = 1;
            this.Inscription.Text = "Pas de compte ?";
            this.Inscription.Click += new System.EventHandler(this.Inscription_Click);
            // 
            // Titre
            // 
            this.Titre.AutoSize = true;
            this.Titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titre.Location = new System.Drawing.Point(60, 43);
            this.Titre.Name = "Titre";
            this.Titre.Size = new System.Drawing.Size(295, 31);
            this.Titre.TabIndex = 7;
            this.Titre.Text = "Bienvenue sur Gestiam";
            this.Titre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Titre.Click += new System.EventHandler(this.Titre_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(409, 356);
            this.Controls.Add(this.Titre);
            this.Controls.Add(this.Inscription);
            this.Controls.Add(this.MdpOublie);
            this.Controls.Add(this.MdpLabel);
            this.Controls.Add(this.MdpTextbox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.emailTextbox);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Ticket Box";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox emailTextbox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label MdpLabel;
        private System.Windows.Forms.TextBox MdpTextbox;
        private System.Windows.Forms.Label MdpOublie;
        private System.Windows.Forms.Label Inscription;
        private System.Windows.Forms.Label Titre;
    }
}


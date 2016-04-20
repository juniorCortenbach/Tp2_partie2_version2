namespace tp2_partie1
{
    partial class FrmGestionJeu
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
            this.btnImages = new System.Windows.Forms.Button();
            this.lblAffichage = new System.Windows.Forms.Label();
            this.btnTablau = new System.Windows.Forms.Button();
            this.pnlCartes = new System.Windows.Forms.PictureBox();
            this.btnCréer = new System.Windows.Forms.Button();
            this.lblGestionDecks = new System.Windows.Forms.Label();
            this.btnModifier = new System.Windows.Forms.Button();
            this.lblTitreJeu = new System.Windows.Forms.Label();
            this.dgvCartes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCartes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImages
            // 
            this.btnImages.Location = new System.Drawing.Point(12, 47);
            this.btnImages.Name = "btnImages";
            this.btnImages.Size = new System.Drawing.Size(118, 34);
            this.btnImages.TabIndex = 1;
            this.btnImages.Text = "Images";
            this.btnImages.UseVisualStyleBackColor = true;
            this.btnImages.Click += new System.EventHandler(this.btnImages_Click_1);
            // 
            // lblAffichage
            // 
            this.lblAffichage.AutoSize = true;
            this.lblAffichage.BackColor = System.Drawing.Color.Transparent;
            this.lblAffichage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAffichage.ForeColor = System.Drawing.Color.White;
            this.lblAffichage.Location = new System.Drawing.Point(98, 12);
            this.lblAffichage.Name = "lblAffichage";
            this.lblAffichage.Size = new System.Drawing.Size(85, 20);
            this.lblAffichage.TabIndex = 2;
            this.lblAffichage.Text = "Affichage :";
            // 
            // btnTablau
            // 
            this.btnTablau.Location = new System.Drawing.Point(136, 47);
            this.btnTablau.Name = "btnTablau";
            this.btnTablau.Size = new System.Drawing.Size(118, 34);
            this.btnTablau.TabIndex = 3;
            this.btnTablau.Text = "Tabulaire";
            this.btnTablau.UseVisualStyleBackColor = true;
            this.btnTablau.Click += new System.EventHandler(this.button2_Click);
            // 
            // pnlCartes
            // 
            this.pnlCartes.Location = new System.Drawing.Point(272, 58);
            this.pnlCartes.Name = "pnlCartes";
            this.pnlCartes.Size = new System.Drawing.Size(630, 331);
            this.pnlCartes.TabIndex = 4;
            this.pnlCartes.TabStop = false;
            this.pnlCartes.Click += new System.EventHandler(this.imgCartes_Click);
            // 
            // btnCréer
            // 
            this.btnCréer.Location = new System.Drawing.Point(12, 142);
            this.btnCréer.Name = "btnCréer";
            this.btnCréer.Size = new System.Drawing.Size(118, 34);
            this.btnCréer.TabIndex = 5;
            this.btnCréer.Text = "Créer";
            this.btnCréer.UseVisualStyleBackColor = true;
            this.btnCréer.Click += new System.EventHandler(this.btnCréer_Click);
            // 
            // lblGestionDecks
            // 
            this.lblGestionDecks.AutoSize = true;
            this.lblGestionDecks.BackColor = System.Drawing.Color.Transparent;
            this.lblGestionDecks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestionDecks.ForeColor = System.Drawing.Color.White;
            this.lblGestionDecks.Location = new System.Drawing.Point(71, 107);
            this.lblGestionDecks.Name = "lblGestionDecks";
            this.lblGestionDecks.Size = new System.Drawing.Size(141, 20);
            this.lblGestionDecks.TabIndex = 6;
            this.lblGestionDecks.Text = "Gestion des decks";
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(136, 142);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(118, 34);
            this.btnModifier.TabIndex = 7;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // lblTitreJeu
            // 
            this.lblTitreJeu.AutoSize = true;
            this.lblTitreJeu.BackColor = System.Drawing.Color.Transparent;
            this.lblTitreJeu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitreJeu.Location = new System.Drawing.Point(430, 24);
            this.lblTitreJeu.Name = "lblTitreJeu";
            this.lblTitreJeu.Size = new System.Drawing.Size(218, 31);
            this.lblTitreJeu.TabIndex = 8;
            this.lblTitreJeu.Text = "Jeu HearthStone";
            // 
            // dgvCartes
            // 
            this.dgvCartes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartes.Location = new System.Drawing.Point(272, 58);
            this.dgvCartes.Name = "dgvCartes";
            this.dgvCartes.Size = new System.Drawing.Size(630, 331);
            this.dgvCartes.TabIndex = 9;
            this.dgvCartes.Visible = false;
            // 
            // FrmGestionJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 532);
            this.Controls.Add(this.dgvCartes);
            this.Controls.Add(this.lblTitreJeu);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.lblGestionDecks);
            this.Controls.Add(this.btnCréer);
            this.Controls.Add(this.pnlCartes);
            this.Controls.Add(this.btnTablau);
            this.Controls.Add(this.lblAffichage);
            this.Controls.Add(this.btnImages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmGestionJeu";
            this.Text = "Jeu HearhStone";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCartes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImages;
        private System.Windows.Forms.Label lblAffichage;
        private System.Windows.Forms.Button btnTablau;
        private System.Windows.Forms.PictureBox pnlCartes;
        private System.Windows.Forms.Button btnCréer;
        private System.Windows.Forms.Label lblGestionDecks;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Label lblTitreJeu;
        private System.Windows.Forms.DataGridView dgvCartes;
    }
}


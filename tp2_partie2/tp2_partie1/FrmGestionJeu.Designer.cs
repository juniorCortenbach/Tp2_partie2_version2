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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionJeu));
            this.tblCarte = new System.Windows.Forms.DataGridView();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Etc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImages = new System.Windows.Forms.Button();
            this.lblAffichage = new System.Windows.Forms.Label();
            this.btnTablau = new System.Windows.Forms.Button();
            this.imgCartes = new System.Windows.Forms.PictureBox();
            this.btnCréer = new System.Windows.Forms.Button();
            this.lblGestionDecks = new System.Windows.Forms.Label();
            this.btnModifier = new System.Windows.Forms.Button();
            this.lblTitreJeu = new System.Windows.Forms.Label();
            this.lstPourTest = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblCarte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCartes)).BeginInit();
            this.SuspendLayout();
            // 
            // tblCarte
            // 
            this.tblCarte.AllowUserToResizeColumns = false;
            this.tblCarte.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tblCarte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblCarte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nom,
            this.Type,
            this.Etc});
            this.tblCarte.Location = new System.Drawing.Point(323, 71);
            this.tblCarte.Name = "tblCarte";
            this.tblCarte.Size = new System.Drawing.Size(450, 340);
            this.tblCarte.TabIndex = 0;
            // 
            // nom
            // 
            this.nom.HeaderText = "nom";
            this.nom.Name = "nom";
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // Etc
            // 
            this.Etc.HeaderText = "Etc";
            this.Etc.Name = "Etc";
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
            // imgCartes
            // 
            this.imgCartes.Location = new System.Drawing.Point(323, 71);
            this.imgCartes.Name = "imgCartes";
            this.imgCartes.Size = new System.Drawing.Size(450, 340);
            this.imgCartes.TabIndex = 4;
            this.imgCartes.TabStop = false;
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
            this.lblTitreJeu.Size = new System.Drawing.Size(203, 31);
            this.lblTitreJeu.TabIndex = 8;
            this.lblTitreJeu.Text = "Jeu HeartStone";
            // 
            // lstPourTest
            // 
            this.lstPourTest.FormattingEnabled = true;
            this.lstPourTest.Location = new System.Drawing.Point(323, 71);
            this.lstPourTest.Name = "lstPourTest";
            this.lstPourTest.Size = new System.Drawing.Size(450, 342);
            this.lstPourTest.TabIndex = 9;
            this.lstPourTest.SelectedIndexChanged += new System.EventHandler(this.lstPourTest_SelectedIndexChanged);
            // 
            // FrmGestionJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 532);
            this.Controls.Add(this.lstPourTest);
            this.Controls.Add(this.lblTitreJeu);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.lblGestionDecks);
            this.Controls.Add(this.btnCréer);
            this.Controls.Add(this.imgCartes);
            this.Controls.Add(this.btnTablau);
            this.Controls.Add(this.lblAffichage);
            this.Controls.Add(this.btnImages);
            this.Controls.Add(this.tblCarte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmGestionJeu";
            this.Text = "Jeu HearStone";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblCarte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCartes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblCarte;
        private System.Windows.Forms.Button btnImages;
        private System.Windows.Forms.Label lblAffichage;
        private System.Windows.Forms.Button btnTablau;
        private System.Windows.Forms.PictureBox imgCartes;
        private System.Windows.Forms.Button btnCréer;
        private System.Windows.Forms.Label lblGestionDecks;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Label lblTitreJeu;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Etc;
        private System.Windows.Forms.ListBox lstPourTest;
    }
}


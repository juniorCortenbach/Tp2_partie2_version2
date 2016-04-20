#region MÉTADONNÉES
/* Nom du fichier         : A CHANGER
 * Nom du programmeur     : Maxim Desloges et Junior Cortenbach
 * Date                   : 30 mars 2016
*/
#endregion


#region USING

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media; //Permet d'utiliser la class media

#endregion


namespace tp2_partie1
{
    /// <summary>
    /// Formulaire de gestion du jeu.
    /// </summary>
    public partial class FrmGestionJeu : Form
    {

        #region ATTRIBUTS

        /// <summary>
        /// Son de type SoundPlayer.
        /// </summary>
        private SoundPlayer _joueurDeSons;

        /// <summary>
        /// Création de l'objet _s de type SoundPlayer.
        /// </summary>
        private SoundPlayer _s = new SoundPlayer(tp2_partie1.Properties.Resources.btnCliquer);

        /// <summary>
        /// permet de savoir quelle bouton a été cliquer. 
        /// </summary>
        private byte _affichageSelectionner;

        private HearthstoneData _gestion;

        HearthstoneData data = new HearthstoneData();

        /// <summary>
        /// La liste des Cartes (une liste générique).
        /// </summary>
        private List<Carte> _lesCartes;


        /// <summary>
        /// Objet permettant de lier la liste des cartes au DataGridView.
        /// </summary>
        private BindingSource _sourceCartes;

        #endregion

        #region PROPRIÉTÉS

        /// <summary>
        /// Permet de savoir quelle bouton a été cliquer. 
        /// </summary>
        public byte AffichageSelectionner
        {
            get { return this._affichageSelectionner; }
            set { this._affichageSelectionner = value; }
        }

        public List<Carte> LesCartes
        {
            get { return this._lesCartes; }
            set { this._lesCartes = value; }
        }

        /// <summary>
        /// Objet permettant de lier la liste des employés au DataGridView.
        /// </summary>
        private BindingSource SourceCarte
        {
            get { return this._sourceCartes; }
            set { this._sourceCartes = value; }
        }

        #endregion

        #region CONSTRUCTEURS
       
        public FrmGestionJeu()
        {
            InitializeComponent();
            ///Chargement du son lors de la sélection d'un bouton.
            this._joueurDeSons = new SoundPlayer("btnCliquer.wav");
            this.dgvCartes = new System.Windows.Forms.DataGridView();

        }
        #endregion

        #region MÉTHODES






        private void Form1_Load(object sender, EventArgs e)
        {
            this.dgvCartes.Show();

     
            this._gestion = new HearthstoneData();


  

            //Affichage du tableaux
            //=====================
            
            // Création d'un liste vide de cartes; on doit faire ceci avant d'assigner la liste à l'objet "BindingSource".
            this.LesCartes = new List<Carte>();
           
            // Ajout de 4 cartes "hard-coded".

            //this.LesCartes.Add();

            // Tri de la liste des  cartes
            this.LesCartes.Sort();

            // Création du "BindingSource" qui fera le lien entre la liste des cartes et le "DataGridView" (c'est un intermédiaire).
            this.SourceCarte = new BindingSource();

            // La liste de cartes devient la source de données du "BindingSource".
            this.SourceCarte.DataSource = this.LesCartes;


            // Le "BindingSource" devient la source de données du "DataGridView".
            this.dgvCartes.DataSource = this.SourceCarte;

            
            // Modification de l'apparence du "DataGridView"
            // =============================================

            // Récupération de la colonne pour le nom
            DataGridViewColumn colNom = this.dgvCartes.Columns["Nom"];
            // Modification du titre de la colonne
            colNom.HeaderText = "Nom";
            // Modification de la largeur de la colonne.
            colNom.Width = 60;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Affichage des images des cartes.
            this.pnlCartes.Hide();        
            
            
            //Affichage du tableau de cartes.
            this.dgvCartes.Show();
            //Retrait des mages des cartes du formulaire.
            this.pnlCartes.Hide();
            //Exécution du son.
            this._s.Play(); //Joue du sons.
        }

        private void btnCher_Click(object sender, EventArgs e)
        {
            //Joue du son.
            this._s.Play();
        }

        private void btnImages_Click_1(object sender, EventArgs e)
        {
            //Affichage des images des cartes.
            this.pnlCartes.Show();
            this.dgvCartes.Hide();
            //Retrait du tableau de cartes du formulaire.
            this.dgvCartes.Hide();
            //Joue du son.
            this._s.Play();

            //Affichage de l'image 
            //====================

            //Trouver l'id
            List<string> lstid = new List<string>();

            for (int i = 0; i < this._gestion.LesCartes.Length; i++)
            {
                const string lien = "http://wow.zamimg.com/images/hearthstone/cards/enus/original/";
                string id = this._gestion.LesCartes[i].Id.ToString();
                string idConverti = lien + id + ".png";
                lstid.Add(idConverti);
            }
        

            int noLigne = 0;
            int noCol = 0;

            for (int i = 0; i < this.data.LesCartes.Length; i++)
            {
                // Changement de ligne, si nécessaire (3 PictureBox par colonne).
                if (noCol == 3)
                {
                    noLigne++;
                    noCol = 0;
                }
                // Création et configuration du PictureBox.
                PictureBox pb = new PictureBox();
                pb.ImageLocation = lstid[i];
                pb.Size = new Size(153, 228);
                pb.Location = new Point(noCol * 307, noLigne * 456);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;

                // Ajout de l'événement "Click" sur le PictureBox.
                pb.Click += pictureBoxImageCartes_Click;

                // Ajout du PictureBox dans le Panel.
                this.pnlCartes.Controls.Add(pb);



            }


        }

        // ReSharper disable once PrivateMembersMustHaveComments
        // ReSharper disable once UnusedParameter.Local
        private void pictureBoxImageCartes_Click(object sender, EventArgs e)
        {

        }


        private void btnModifier_Click(object sender, EventArgs e)
        {
            //Change la valeur de AffichageSelectionner
            this.AffichageSelectionner = 2;
            //Affichage des images des cartes.
            this.pnlCartes.Show();
            //retrait du tableau de cartes du formulaire.
            this.dgvCartes.Hide();
            //Joue du son.
            this._s.Play();
            //Création du nouveau formulaire.
            FrmGestionDecks f2 = new FrmGestionDecks(this);
            //Affichage du nouveau formulaire.
            f2.Show();
        }

        private void btnCréer_Click(object sender, EventArgs e)
        {
            //Change la valeur de AffichageSelectionner
            this.AffichageSelectionner = 1;
            //Joue du son.
            this._s.Play();
            //Création du nouveau formulaire.
            FrmGestionDecks f2 = new FrmGestionDecks(this);
            //Affichage du nouveau formulaire.
            f2.Show();
        }

        #endregion

        private void lstPourTest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void imgCartes_Click(object sender, EventArgs e)
        {

        }

        private void tblCarte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}

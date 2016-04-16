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

        
        #endregion



        #region MÉTHODES

        public FrmGestionJeu()
        {
            InitializeComponent();
            ///Chargement du son lors de la sélection d'un bouton.
            this._joueurDeSons = new SoundPlayer("btnCliquer.wav");
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
            HearthstoneData data = new HearthstoneData();
            this._gestion = new HearthstoneData();
            this.lstPourTest.Items.Add(this._gestion.LesCartes[3]);

            //for (int i = 0; i < 100; i++)
            //{
            //    this.lstPourTest.Items.Add(Utilitaire.ChargerCartes(HearthstoneData.CheminFichierCarte));
            //}
            
           //Retrait des images des cartes et du tableau de cartes du formulaire.
           this.imgCartes.Hide();
            this.tblCarte.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Affichage du tableau de cartes.
            this.tblCarte.Show();
            //Retrait des mages des cartes du formulaire.
            this.imgCartes.Hide();
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
            this.imgCartes.Show();
            //Retrait du tableau de cartes du formulaire.
            this.tblCarte.Hide();
            //Joue du son.
            this._s.Play();  
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            //Change la valeur de AffichageSelectionner
            this.AffichageSelectionner = 2;
            //Affichage des images des cartes.
            this.imgCartes.Show();
            //retrait du tableau de cartes du formulaire.
            this.tblCarte.Hide();
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
    }
}

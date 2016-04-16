#region MÉTADONNÉES
/* Nom du fichier         : A CHANGER
 * Nom du programmeur     : Maxim Desloges et Junior Cortenbach
 * Date                   : 30 mars 2016
 */
#endregion

#region USING
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace tp2_partie1
{
    /// <summary>
    /// Classe contenant les informations relatives au deck du héro.
    /// </summary>
    public class Deck
    {
        #region ATTRIBUTS

        /// <summary>
        /// Héro (avec toutes informations du héro contenues dans 
        /// la classe Heros).
        /// </summary>
        private Heros _heros;

        /// <summary>
        /// Tableau de cartes.
        /// </summary>
        private List <DeckEntree> _lstCartesAvecQt;

        /// <summary>
        /// Nom du deck.
        /// </summary>
        private string _nom;

        /// <summary>
        /// Le nombre de cartes présentes dans le deck.
        /// </summary>
        private byte _nbTotalCartes;
        #endregion

        #region PROPRIÉTÉS

        /// <summary>
        /// Héro (avec toutes informations du héro
        /// contenues dans la classe Heros).
        /// </summary>
        public Heros Heros
        {
            get { return this._heros; }
            set
            {
                // Validation du héro.
                // ===================
                // Le héro ne doit pas être nul.
                if (value == null)
                    throw new ArgumentNullException("Le héro pour le deck ne doit pas être nul.");
            }
        }

        /// <summary>
        /// Tableau de cartes.
        /// </summary>
        public List<DeckEntree> LstCartesAvecQt
        {
            get { return this._lstCartesAvecQt; }
            set { this._lstCartesAvecQt = value; }
        }

        /// <summary>
        /// Nom du deck.
        /// </summary>
        public string Nom
        {
            get { return this._nom; }
            set
            {
                // Validation du nom
                // ===================
                // Le nom ne doit pas être nul.
                if (value == null)
                    throw new ArgumentNullException(null, "Le nom ne doit pas être nul.");
                // Retrait des espaces superflus (seulement si le titre n'est pas nul, autrement ça va lever l'exception NullReferenceExcpetion).
                String nomTrime = value.Trim();
                // Le nom doit contenir au moins 3 caractères.
                if (nomTrime.Length < 3)
                    throw new ArgumentException("Le nom doit contenir au moins 3 caractères.");
                // Le titre est valide; on le conserve dans l'attribut.
                this._nom = nomTrime;
             
            }
        }

        /// <summary>
        /// Le nombre de cartes présentes dans le deck.
        /// </summary>
        public byte NbTotalCartes
        {
            get { return this._nbTotalCartes; }
            set
            {
                if(this._nbTotalCartes<1)
                    throw new ArgumentOutOfRangeException("Le nombre de copies d'une carte doit être d'au moins 1.");
                this._nbTotalCartes = value;
            }
        }

        #endregion

        #region CONSTANTES


        public const byte NbMaxCartesDansDeck=30;
        public const byte QtMaxCarteLegendaire=1;
        public const byte QtMaxCarteNonLegendaire=2;
    
        #endregion

        #region CONSTRUCTEUR

        /// <summary>
        /// Constructeur paramétré qui accepte les trois attributs d'un deck.
        /// </summary>
        public Deck(string nom, Heros heros)
        {
            this.Nom = nom;
            this.Heros = heros;
        }

        #endregion 

        #region MÉTHODES

        public void AjouterCartes(Carte carteAjoutee, byte nbCopies)
        {
            byte nbCartesLegendaires=0;
            //Restrictions:
            // nbCopies en cas de carte légendaire ne peut pas être > ou < que 1.
            // Une carte ne peut être ajouté si le nombre de cartes déjà présent est 30.

            //Prévoir que la carte ajoutée peut déjà être présente dans le deck et ne pourra
            //être ajoutée qu'une seule fois, si elle ne s'y retrouve qu'une seule fois.

            //Comment j'fais pour déterminer le nombre de cartes légendaires si
            //j'peux pas détermienr la rareté des cartes contenues dans le deck?
            for (int i = 0; i < this.NbTotalCartes; i++)
            {
                if (carteAjoutee.Rarete == CarteRarete.Legendary);
                nbCartesLegendaires++;
            }

            if(carteAjoutee == null)
                throw  new ArgumentNullException("La carte ne doit pas être nulle.");

            if(nbCopies == 0)
                throw new ArgumentOutOfRangeException("Le nombre de copies d'une carte doit être d'au moins 1.");

            if (carteAjoutee.Rarete == CarteRarete.Legendary && nbCopies > 1)
                throw new ArgumentOutOfRangeException("Le nombre maximal de copies d'une carte légendaire doit être de 1.");

            if(this.NbTotalCartes == Deck.NbMaxCartesDansDeck)
                throw new ArgumentException("La quantité de cartes présentes dans le deck ne peut pas dépasser 30.");

            if(carteAjoutee.Rarete != CarteRarete.Legendary && nbCopies > 2)
                throw new InvalidOperationException("Le nombre total de copies d'une carte non légendaire doit être d'au plus 2.");
            if(carteAjoutee.Rarete == CarteRarete.Legendary && nbCopies < 1)
                throw new InvalidOperationException("Le nombre total de copies d'une carte légendaire doit être d'au plus 1.");
            if(nbCopies > Deck.QtMaxCarteNonLegendaire && carteAjoutee.Rarete == CarteRarete.Legendary)
                throw new ArgumentException("Le nombre de copies d'une même carte ne peut être supérieur à 2.");

            Carte nouvelleCarte = new Carte(carteAjoutee.Type, carteAjoutee.Id, carteAjoutee.Nom, carteAjoutee.Extension,
                carteAjoutee.Rarete, carteAjoutee.Cout, carteAjoutee.Texte, carteAjoutee.Classe, carteAjoutee.Attaque,
                carteAjoutee.Durabilite, carteAjoutee.Race, carteAjoutee.Vie);

            if (nbCopies > 1)
            {
                Carte secondeNouvelleCarte = new Carte(carteAjoutee.Type, carteAjoutee.Id, carteAjoutee.Nom, carteAjoutee.Extension,
                carteAjoutee.Rarete, carteAjoutee.Cout, carteAjoutee.Texte, carteAjoutee.Classe,carteAjoutee.Attaque,
                carteAjoutee.Durabilite, carteAjoutee.Race, carteAjoutee.Vie);
            }


        }

        public byte ObtenirQtCarte(Carte carteLue)
        {
            if (this.LstCartesAvecQt == null)
                throw new ArgumentNullException("La liste de carte ne doit pas être nulle.");
            if (carteLue == null)
                throw new ArgumentNullException("La carte ne doit pas être nulle.");


            byte quantiteCarte = 0;

            for (int i = 0; i <= this.LstCartesAvecQt.Count; i++)
            {
                if (this.LstCartesAvecQt[i].Carte == carteLue)
                    quantiteCarte++;   
            }
            
            return quantiteCarte;
        }

        public int RetirerCarte(Carte carteRetiree, bool toutesCopiesRetirees)
        {
            int nbCopiesRetirees = ObtenirQtCarte(carteRetiree);

            int indiceCarte = 0;

            for (int i = 0; i < this.LstCartesAvecQt.Count; i++)
            {
                this.LstCartesAvecQt[i].Carte.Id = carteRetiree.Id;
                indiceCarte = i;
            }

            if (toutesCopiesRetirees)
                this.LstCartesAvecQt = null;
            else
                this.LstCartesAvecQt.Remove(this.LstCartesAvecQt[indiceCarte]);
                nbCopiesRetirees = 1;

            return nbCopiesRetirees;
        }

        #endregion

    }
}

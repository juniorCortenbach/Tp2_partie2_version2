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
        private List<DeckEntree> _lstCartesAvecQt;

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
                    throw new ArgumentNullException(null, "Le héro pour le deck ne doit pas être nul.");
                else
                    this._heros = value;
            }
        }

        /// <summary>
        /// Tableau de cartes.
        /// </summary>
        public List<DeckEntree> LstCartesAvecQt
        {
            get { return this._lstCartesAvecQt; }
            set
            {
                if (value == null)
                    throw new NullReferenceException("La quantité est nulle.");

                    this._lstCartesAvecQt = value;
            }
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
                    throw new ArgumentNullException("Le nom du deck ne doit pas être nul.");
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
            set { this._nbTotalCartes = value; }
        }

        #endregion

        #region CONSTANTES


        public const byte NbMaxCartesDansDeck = 30;
        public const byte QtMaxCarteLegendaire = 1;
        public const byte QtMaxCarteNonLegendaire = 2;

        #endregion

        #region CONSTRUCTEUR

        /// <summary>
        /// Constructeur paramétré qui accepte les deux attributs d'un deck.
        /// </summary>
        public Deck(string nom, Heros heros)
        {
            this.Nom = nom;
            this.Heros = heros;
            this.LstCartesAvecQt = new List<DeckEntree>();
        }

        #endregion

        #region MÉTHODES
        int indiceCarteDansLst = 0;
        public void AjouterCartes(Carte carteAjoutee, byte nbCopies)
        {
            bool carteDejaPresente = false;
            byte nbTotalCopies = 1;

            if (carteAjoutee == null)
                throw new ArgumentNullException("La carte ne doit pas être nulle.");

            for (int i = 0; i < this.NbTotalCartes; i++)
            {
                if (!(this.LstCartesAvecQt.Count > 1))
                {
                    if (this.LstCartesAvecQt[i].Carte.CompareTo(carteAjoutee) == 0)
                    {
                        carteDejaPresente = true;
                        this.indiceCarteDansLst = i;

                        //if(this. > 1)
                        nbTotalCopies++;
                    }
                }
                else
                    if (this.LstCartesAvecQt[i].Carte.CompareTo(carteAjoutee) == 0)
                    {
                        carteDejaPresente = true;
                        this.indiceCarteDansLst = i;

                        //if(this. > 1)
                        nbTotalCopies++;
                    }
            }

            if (nbCopies < 1)
                throw new ArgumentOutOfRangeException("Le nombre de copies d'une carte doit être d'au moins 1.");
            if ((carteAjoutee.Rarete != CarteRarete.Legendary) && (nbCopies > 2))
                throw new ArgumentOutOfRangeException("Le nombre total de copies d'une carte non légendaire doit être d'au plus 2.");
            if ((carteAjoutee.Rarete != CarteRarete.Legendary) && (nbTotalCopies > 2))
                throw new InvalidOperationException("Le nombre total de copies d'une carte non légendaire doit être d'au plus 2.");
            if ((carteAjoutee.Rarete == CarteRarete.Legendary) && (nbTotalCopies < 1))
                throw new ArgumentOutOfRangeException("Le nombre minimale de copies d'une carte légendaire doit être de 1.");
            //if ((carteAjoutee.Rarete == CarteRarete.Legendary) && (nbTotalCopies > ))
                //throw new ArgumentOutOfRangeException("Le nombre maximale de copies d'une carte légendaire doit être de 2.");
            if ((carteAjoutee.Rarete == CarteRarete.Legendary) && (nbCopies > 1))
                throw new ArgumentOutOfRangeException("Le nombre total de copies d'une carte légendaire doit être d'au plus 1.");
            //if ((carteAjoutee.Rarete == CarteRarete.Legendary) && (nbTotalCopies > 1))
            //    throw new InvalidOperationException("Le nombre total de copies d'une carte légendaire doit être d'au plus 1.");

            if (this.NbTotalCartes == Deck.NbMaxCartesDansDeck)
                throw new InvalidOperationException("Le nombre total de cartes dans le deck doit être d'au plus 30.");

            if (carteAjoutee.Classe != this.Heros.Classe && carteAjoutee.Classe != HerosClasse.Neutre)
                throw new ArgumentException("La carte ne peut pas être ajoutée au deck car elle ne possède pas la bonne classe.");

            if (nbCopies > 1)
            {
                Carte nouvelleCarte = new Carte(carteAjoutee.Type, carteAjoutee.Id, carteAjoutee.Nom,
                    carteAjoutee.Extension,
                    carteAjoutee.Rarete, carteAjoutee.Cout, carteAjoutee.Texte, carteAjoutee.Classe,
                    carteAjoutee.Attaque,
                    carteAjoutee.Vie, carteAjoutee.Race, carteAjoutee.Durabilite);

                if (carteDejaPresente)
                    this.LstCartesAvecQt[this.indiceCarteDansLst].Qt++;
                if(!carteDejaPresente)
                {
                    this.LstCartesAvecQt.Add(new DeckEntree(nouvelleCarte, nbCopies));
                    carteDejaPresente = true;
                }

            }
            else
            {
                Carte nouvelleCarte = new Carte(carteAjoutee.Type, carteAjoutee.Id, carteAjoutee.Nom,
                    carteAjoutee.Extension,
                    carteAjoutee.Rarete, carteAjoutee.Cout, carteAjoutee.Texte, carteAjoutee.Classe,
                    carteAjoutee.Attaque,
                    carteAjoutee.Vie, carteAjoutee.Race, carteAjoutee.Durabilite);

                if (carteDejaPresente)
                    this.LstCartesAvecQt[this.indiceCarteDansLst].Qt++;
                if (!carteDejaPresente)
                    this.LstCartesAvecQt.Add(new DeckEntree(nouvelleCarte, 1));

            }

            //int testCount = this.LstCartesAvecQt.Count;
            this.NbTotalCartes += nbCopies;
        }

        public byte ObtenirQtCarte(Carte carteLue)
        {
            if (this.LstCartesAvecQt == null)
                throw new ArgumentNullException("La liste de carte ne doit pas être nulle.");

            if (this.LstCartesAvecQt.Count < 0)
                throw new ArgumentOutOfRangeException("La valeur ne peut être négative");

            //if (this.LstCartesAvecQt.Count == 0)
            //    throw new ArgumentOutOfRangeException("La valeur ne peut être nulle");

            if (carteLue == null)
                throw new ArgumentNullException("La carte ne doit pas être nulle.");


            byte quantiteCarte = 0;
            bool carteTrouve = true;

            int i = 0;
            //for (int i = 0; i <= this.LstCartesAvecQt.Count; i++)
            //{

            //    if (this.LstCartesAvecQt.Count != 0 && this.LstCartesAvecQt[i].Carte.CompareTo(carteLue) == 0)
            //        quantiteCarte++;

            //    //if (quantiteCarte == 0)
            //    //    throw new ArgumentOutOfRangeException("La liste de carte ne doit pas être nulle.");

            //}

            if (this.LstCartesAvecQt.Count != 0)
            {
                do
                {
                    if (this.LstCartesAvecQt[i].Carte.CompareTo(carteLue) == 0)
                        quantiteCarte++;
                    else
                    carteTrouve = false;

                    i++;
                } while (i <= this.LstCartesAvecQt[this.indiceCarteDansLst].Qt-1 || !carteTrouve);
            }

            return quantiteCarte;
        }

        public int RetirerCarte(Carte carteRetiree, bool toutesCopiesRetirees)
        {
            int nbCopiesRetirees = ObtenirQtCarte(carteRetiree);

            int indiceCarte = 0;

            if (this.LstCartesAvecQt == null)
                throw new NullReferenceException("La liste de cartes est nulle.");


            for (int i = 0; i < this.LstCartesAvecQt.Count; i++)
            {
                if (this.LstCartesAvecQt[i].Carte.Id == carteRetiree.Id)
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

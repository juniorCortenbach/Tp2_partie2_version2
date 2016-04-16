#region MÉTADONNÉES
/* Nom du fichier         : A CHANGER
 * Nom du programmeur     : Maxim Desloges et Junior Cortenbach
 * Date                   : 30 mars 2016
 */
#endregion

#region USING

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

#endregion

namespace tp2_partie1
{
    /// <summary>
    /// Classe contenant toutes les informations relatives aux cartes.
    /// </summary>
    public class Carte : IComparable<Carte>
    {
        #region CONSTANTE

        public const byte CoutMax = 20;
        public const byte AttaqueMax = 12;
        public const byte VieMax = 15;
        public const byte DurabiliteMax = 8;

        #endregion
        #region ATTRIBUTS

        /// <summary>
        /// Le nombre de points d'attaque de la carte.
        /// </summary>
        private sbyte _attaque;

        /// <summary>
        /// La classe du héros.
        /// </summary>
        private HerosClasse _classe;

        /// <summary>
        /// Le coût de la carte.
        /// </summary>
        private ushort _cout;

        /// <summary>
        /// Les points de la durabilité de la carte.
        /// </summary>
        private sbyte _durabilite;

        /// <summary>
        /// L'extension de la carte.
        /// </summary>
        private CarteExtension _extension;

        /// <summary>
        /// L'ID de la carte.
        /// </summary>
        private string _id;

        /// <summary>
        /// Les mécaniques de la carte.
        /// </summary>
        private List<CarteMecanique> _lstMeca;

        /// <summary>
        /// Le nom de la carte.
        /// </summary>
        private string _nom;

        /// <summary>
        /// Race du serviteur.
        /// </summary>
        private ServiteurRace _race;

        /// <summary>
        /// La rareté de la carte.
        /// </summary>
        private CarteRarete _rarete;

        /// <summary>
        /// 
        /// </summary>
        private string _regexId;

        /// <summary>
        /// Contient du texte décrivant la carte.
        /// </summary>
        private string _texte;

        /// <summary>
        /// Le type de créature.
        /// </summary>
        private CarteType _type;

        /// <summary>
        /// Le nombre de points de vie de la carte.
        /// </summary>
        private sbyte _vie;

        #endregion

        #region PROPRIÉTÉS

        /// <summary>
        /// Le nombre de points d'attaque de la carte.
        /// </summary>
        public sbyte Attaque
        {
            get { return this._attaque; }
            set
            {
                // Validation de l'attaque doit être compris entre 0 et 12 et être de type serviteur ou arme.
                // ==========================================================================================
                if ((this.Type != CarteType.Spell) && ((value < 0) || (value > 12)))
                    throw new ArgumentOutOfRangeException("L'attaque doit être entre 0 et 12, inclusivement. et le type doit être serviteur ou arme");

                // Validation de l'attaque doit être -1 et le type doit être sort
                // ======================================================
                if ((this.Type == CarteType.Spell) && (value != -1))
                      throw new ArgumentOutOfRangeException("Les points d'attaque doivent être à -1 pour une carte qui n'est pas de type serviteur ou arme.");


                // L'attaque prévue est valide; on la conserve dans l'attribut. 
                this._attaque = value;
            }
        }

        /// <summary>
        /// La classe du héros.
        /// </summary>
        public HerosClasse Classe
        {
            get { return this._classe; }
            set { this._classe = value; }
        }

        /// <summary>
        /// Coût de la carte.
        /// </summary>
        public ushort Cout
        {
            get { return this._cout; }
            set
            {
                // Validation du cout d'une carte
                // ==============================
                if (value > 20)
                    throw new ArgumentOutOfRangeException(                        "Le cout de la carte est de 0 et 20, inclusivement.");
                // Le cout prévue est valide; on la conserve dans l'attribut.
                this._cout = value;
            }
        }

        /// <summary>
        /// Les points de durabilite de la carte.
        /// </summary>
        public sbyte Durabilite
        {
            get { return this._durabilite; }
            set
            {
                // Validation de la durabilité entre 1 et 8 inclusivement pour les carte arme.
                // ===========================================================================
                if ((this.Type == CarteType.Weapon) && ((value < 1) || (value > 8)))
                    throw new ArgumentOutOfRangeException("La durabilité doit être entre 1 et 8, inclusivement. et le type doit être arme");
                if ((this.Type != CarteType.Weapon) && (value != -1))
                    throw new ArgumentOutOfRangeException("Pour les cartes de type (serviteur et sort), la valeur doit être obligatoirement être -1");


                // La durabilité prévue est valide; on la conserve dans l'attribut. 
                this._durabilite = value;
            }
        }

        /// <summary>
        /// L'extension de la carte.
        /// </summary>
        public CarteExtension Extension
        {
            get { return this._extension; }
            set { this._extension = value; }
        }

        /// <summary>
        /// L'ID de la carte.
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("L'ID ne doit pas être nul.");
                // Retrait des espaces superflus (seulement si le titre n'est pas nul, autrement ça va lever l'exception NullReferenceExcpetion).
                String idTrime = value.Trim();
                // Le nom doit contenir au moins 3 caractères.
                if (idTrime.Length < 3)
                    throw new ArgumentException("Le nom doit contenir au moins 3 caractères.");

                if(!idTrime.Contains("_"))
                    throw new ArgumentException("Il manque un _");
                if(idTrime.Contains("+"))
                    throw new ArgumentException("ne peu contenir de plus");


                string[] partie = idTrime.Split('_');
                
                if(partie[0].Length>6)
                    throw new ArgumentException("La première partie est trop longue");
                if (partie[1].Length > 4)
                    throw new ArgumentException("La deuxième partie est trop longue");
               


                //Regex qui valide l'id de la carte
                Regex idCarteRegex = new Regex("[a-zA-Z0-9]{2,6}_[0-9]{1,3}");



                //Valide que la carte 
                if (!idCarteRegex.IsMatch(value))
                {
                    throw new ArgumentException("L'id doit contenir entre 2 et 6 caractères parmi les lettres minuscules et majuscules et les chiffres de (0 à 9) suivit du caractère de soulignement, _ entre 1 et 3 chiffres de (0 à 9)");
                }


                // L'id prévue est valide; on la conserve dans l'attribut.
                this._id = idTrime;
            }
        }

        /// <summary>
        /// Les mécaniques de la carte.
        /// </summary>
        public List<CarteMecanique> LstMeca
        {
            get { return this._lstMeca; }
            set
            {
                //A faire
                this._lstMeca = value;
            }
        }

        /// <summary>
        /// Le nom de la carte.
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
                    throw new ArgumentNullException("Le nom ne doit pas être nul.");
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
        /// Race du serviteur.
        /// </summary>
        public ServiteurRace Race
        {
            get { return this._race; }
            set
            {
                if ((this.Type != CarteType.Minion)&&(value != ServiteurRace.Aucune))
                    throw new ArgumentException("Une carte qui n'est pas de type serviteur ne doit avoir aucune race.");
          
                this._race = value;
            }
        }


        /// <summary>
        /// La rareté de la carte.
        /// </summary>
        public CarteRarete Rarete
        {
            get { return this._rarete; }
            set { this._rarete = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string RegexId
        {
            get { return this._regexId; }
            set { this._regexId = value; }
        }

        /// <summary>
        /// Contient du texte décrivant la carte.
        /// </summary>
        public string Texte
        {
            get { return this._texte; }
            set
            {
                String texteTrime = null;
                // Validation du texte
                // ===================
                // Le titre ne doit pas être nul.
                if (value != null)
                {
                   texteTrime = value.Trim();
                }
                this._texte = texteTrime;
            }
        }

        /// <summary>
        /// Le type de créature.
        /// </summary>
        public CarteType Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        /// <summary>
        /// Le nombre de points de vie de la carte.
        /// </summary>
        public sbyte Vie
        {
            get { return this._vie; }
            set
            {
                // Validation de la vie 
                // ==========================================================================================
                if ((this.Type == CarteType.Spell) && (value != -1))
                    throw new ArgumentOutOfRangeException("Les points de vie doivent être à -1 pour une carte qui n'est pas de type serviteur.");
                if ((this.Type == CarteType.Weapon) && (value != -1))
                    throw new ArgumentOutOfRangeException("Les points de vie doivent être à -1 pour une carte qui n'est pas de type serviteur.");

                if ((this.Type == CarteType.Minion) && ((value < 1) || (value > 15)))
                    throw new ArgumentOutOfRangeException("La vie doit être entre 1 et 15, inclusivement. et le type doit être un serviteur");
        
                // La vie prévue est valide; on la conserve dans l'attribut. 
                this._vie = value;
            }
        }

        #endregion


        #region CONSTRUCTEUR

        public Carte(CarteType type, string id, string nom, CarteExtension extension,
            CarteRarete rarete, ushort cout, string texte, HerosClasse classe, sbyte attaque, sbyte vie,
             ServiteurRace raceServiteur, sbyte durabilite)
        {
            this.Type = type;
            this.Id = id;
            this.Nom = nom;
            this.Extension = extension;
            this.Rarete = rarete;
            this.Cout = cout;
            this.Texte = texte;
            this.Classe = classe;
            this.Attaque = attaque;
            this.Durabilite = durabilite;
            this.Race = raceServiteur;
            this.Vie = vie;
            this.LstMeca = new List<CarteMecanique>();
        }

        #endregion

        #region MÉTHODES


        /// <summary>
        /// Permet de comparer deux cartes.
        /// </summary>
        /// <returns></returns>
        public int CompareTo(Carte autreCarte)
        {
            // Le premier critère de tri est l'id des cartes.
            // Note : "CompareTo" est déjà définie pour des nombres.
            int resComp = this.Id.CompareTo(autreCarte.Id);
            // Est-ce que les identifiants sont différents ?
            if (resComp != 0)
            {
                // Id différents.
                // On retourne le résultat de la comparaison.
                // Note : Si on veut un tri en ordre décroissant d'id, il faut multiplier par -1.
                return resComp;
            }
            else
            {
                // Les deux carte ont le même Identifiant.
                // Le deuxième critère de tri est le nom (insensible à la case et aux accents).
                return String.Compare(this.Nom, autreCarte.Nom, CultureInfo.CurrentCulture,
                    CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace);
            }
        }

        /// <summary>
        /// Permet d'ajouter une mécaniques
        /// </summary>
        /// <returns></returns>
        public void AjouterMecanique(CarteMecanique mecanique)
        {
            //Vérifie si la liste contiens déjà une mécaniques.
            if (this.LstMeca.Contains(mecanique))
            {
                throw new InvalidOperationException("Impossible d'ajouter une mécanique déjà présente.");
            }
            //Ajoute mécaniques à la liste s'il est manquant. 
            this.LstMeca.Add(mecanique);
        }

        #endregion

    }
}

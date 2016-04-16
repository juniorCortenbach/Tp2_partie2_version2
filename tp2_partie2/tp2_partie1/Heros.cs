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
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
#endregion

namespace tp2_partie1
{
    /// <summary>
    /// Classe contenant tout le contenu relatif à un héro.
    /// </summary>
    public class Heros
    {
        #region ATTRIBUTS

        /// <summary>
        /// La classe du héro.
        /// </summary>
        private HerosClasse _classe;

        /// <summary>
        /// L'extension du héro.
        /// </summary>
        private CarteExtension _extension;

        /// <summary>
        /// L'identifiant du héro.
        /// </summary>
        private string _id;
         
        /// <summary>
        /// Le nom du héro.
        /// </summary>
        private string _nom;

        /// <summary>
        /// La rareté du héro.
        /// </summary>
        private CarteRarete _rarete;

        /// <summary>
        /// wtf is this?
        /// </summary>
        private byte _regexId;

        /// <summary>
        /// Les points de vie du héro.
        /// </summary>
        private byte _vie;

        #endregion


        #region CONSTANTES
       
       public const byte VieMin = 10;
       public const byte VieMax=100;

        #endregion

        #region PROPRIÉTÉS

        /// <summary>
        /// La classe du héro.
        /// </summary>
        public HerosClasse Classe
        {
            get { return this._classe; }
            set
            {
             if(value == HerosClasse.Neutre)
                 throw new ArgumentException("Un héro ne peut pas avoir la classe neutre");
                this._classe = value;
            }
        }

        /// <summary>
        /// L'extension du héro.
        /// </summary>
        public CarteExtension Extension
        {
            get { return this._extension; }
            set { this._extension = value; }
        }

        /// <summary>
        /// L'identifiant du héro.
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set
            {
                // Validation de l'ID
                // ===================
                // L'ID ne doit pas être nul.
                if (value == null)
                    throw new ArgumentNullException("L'id ne peut être null");
                //Regex qui valide l'id de l'héros 
                Regex idHerosRegexTest1 = new Regex("HERO_[0-9]{2}[A-Z]");
                if (idHerosRegexTest1.IsMatch(value))
                    throw new ArgumentException("L'identifiant du héro est invalide.");
                Regex idHerosRegexTest2 = new Regex("HERO_[0-9]{1}[a-z]");
                if (idHerosRegexTest2.IsMatch(value))
                    throw new ArgumentException("L'identifiant du héro est invalide.");
                Regex idHerosRegexTest3 = new Regex("HERO_[0-9]{3}");
                if (idHerosRegexTest3.IsMatch(value))
                    throw new ArgumentException("L'identifiant du héro est invalide.");
                Regex idHerosRegexTest4 = new Regex(".*_HERO_.*");
                if (idHerosRegexTest4.IsMatch(value))
                    throw new ArgumentException("L'identifiant du héro est invalide.");
                Regex idHerosRegexTest5 = new Regex("HERO_[0-9]{2}[a-z]{2}");
                if (idHerosRegexTest5.IsMatch(value))
                    throw new ArgumentException("L'identifiant du héro est invalide.");



                // Retrait des espaces superflus (seulement si le titre n'est pas nul, autrement ça va lever l'exception NullReferenceExcpetion).
                String idTrime = value.Trim();

                // L'id prévue est valide; on la conserve dans l'attribut.
             this._id = idTrime;
            }
        }

        /// <summary>
        /// Le nom du unité.
        /// </summary>
        public string Nom
        {
            get { return this._nom; }
            set
            {
                // Validation de la longueur du nom
                // ===================
                // Le nom ne doit pas est être null
                if (value == null)
                    throw new ArgumentNullException("Le nom ne doit pas être nul.");
                String nomTrime = value.Trim();
                // Le nom doit contenir au moins 3 caractères.
                if (nomTrime.Length < 3)
                    throw new ArgumentException("Le nom doit contenir au moins 3 caractères.");
                // Le nom est valide; on le conserve dans l'attribut.
                this._nom = nomTrime;
            }
        }

        /// <summary>
        /// La rareté du héro.
        /// </summary>
        public CarteRarete Rarete
        {
            get { return this._rarete; }
            set { this._rarete = value; }
        }

        public byte RegexId
        {
            get { return this._regexId; }
            set { this._regexId = value; }
        }
        /// <summary>
        /// Les points de vie du héro.
        /// </summary>
        public byte Vie
        {
            get { return this._vie; }
            set
            {
                // Validation de la vie qui doit être entre 10 et 100
                // ==================================================
                if ((value < 10) || (value > 100))
                    throw new ArgumentOutOfRangeException("La vie du héros doit être entre 10 et 100, inclusivement.");
                // La vie est valide; on la conserve dans l'attribut.
                this._vie = value;
            }
        }

        #endregion


        #region CONSTRUCTEUR

        /// <summary>
        /// Constructeur paramétré.
        /// </summary>
        /// <param name="classe"></param>
        /// <param name="extension"></param>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        /// <param name="rarete"></param>
        /// <param name="regexId"></param>
        /// <param name="vie"></param>
        public Heros(string id, string nom, CarteExtension extension, CarteRarete rarete, HerosClasse classe, byte vie)
        {
            this.Id = id;
            this.Nom = nom;
            this.Extension = extension;
            this.Rarete = rarete;
            this.Classe = classe;
            this.Vie = vie;
        }


        #endregion

    }
}

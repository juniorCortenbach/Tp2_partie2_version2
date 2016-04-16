#region MÉTADONNÉES
/* Nom du fichier         : A CHANGER
 * Nom du programmeur     : Maxim Desloges et Junior Cortenbach
 * Date                   : 30 mars 2016
 */
#endregion

#region USING

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


#endregion

namespace tp2_partie1
{
    public class HearthstoneData
    {

        #region CONSTANTE
       
        /// <summary>
        /// Constante qui contient le chemin qui contient le fichier xml qui contient les données. 
        /// </summary>
        public const String CheminFichierCarte= "cards-collectible.xml";  

        #endregion

        #region ATTRIBUTS
        
        /// <summary>
        /// Tableaux de cartes. 
        /// </summary>
        private Carte[] _lesCartes;
        
        /// <summary>
        /// Tableaux de héros.
        /// </summary>
        private Heros[] _lesHeros;

        #endregion 

        #region PROPRIÉTÉS
        /// <summary>
        /// Tableaux de héros.
        /// </summary>
        public Heros[] LesHeros
        {
            get { return this._lesHeros; }
            set { this._lesHeros = value; }
        }

        /// <summary>
        /// Tableaux de cartes. 
        /// </summary>
        public Carte[] LesCartes
        {
            get { return this._lesCartes; }
            set { this._lesCartes = value; }
        }

        #endregion

        #region CONSTRUCTEUR

        /// <summary>
        /// Constructeur paramétré qui accepte les attributs de cartes et de de héros.
        /// </summary>
        public HearthstoneData()
        {
            this.LesCartes = Utilitaire.ChargerCartes(HearthstoneData.CheminFichierCarte);
            this.LesHeros = Utilitaire.ChargerHeros(HearthstoneData.CheminFichierCarte);
        }
        #endregion

        #region MÉTHODES


        /// <summary>
        /// Prend en paramètre l’identifiant d’une carte et retourne la carte correspondante si l’identifiant est valide; retourne « null » si
        /// l’identifiant est invalide.
        /// </summary>
        /// <returns></returns>
        public Carte RechercherCarteParId(string carteRecherchee)
        {
            if (this.LesCartes == null)
                throw new ArgumentException("L'Id du heros ne doit pas être une chaîne vide.");
            if (this.LesCartes.Equals(""))
                throw new ArgumentException("L'Id du heros ne doit pas être une chaîne vide.");
            if(carteRecherchee == null)
                throw new ArgumentNullException("L'Id du heros ne doit pas être une chaîne vide.");

            //string idTrouver;

            //try
            //{
            //    idTrouver = carteRecherchee.Split('_').Last();
            //}
            //catch (FileNotFoundException fnfe)
            //{
            //    Console.WriteLine("Le fichier n'existe pas.");
            //    Console.WriteLine("Message système : {0}", fnfe.Message);
            //}


            for (int i = 0; i < this.LesCartes.Length; i++)
            {
                if (this._lesCartes[i].Id.Trim() == carteRecherchee.Trim())
                {
                    return this.LesCartes[i];
                }
            }


            return null;
     


        }
        
        /// <summary>
        /// Prend en paramètre l’identifiant d’un héros et retourne le héros correspondant si l’identifiant est valide; retourne « null » si
        /// l’identifiant est invalide.
        /// </summary>
        /// <returns></returns>
        public Heros RechercherHeroParId(string heroRechercher)
        {
            if (this.LesHeros == null)
                throw new ArgumentNullException("la valeur du heros rechercher est null");
            if (this.LesHeros.Equals(""))
                throw new ArgumentException("L'Id du heros ne doit pas être une chaîne vide.");
      

            for (int i = 0; i < this.LesHeros.Length; i++)
            {
                if (this._lesHeros[i].Id.Trim() == heroRechercher.Trim())
                {
                    return this.LesHeros[i];
                }
            }
            return null;

          
        }
        /// <summary>
        /// Prend en paramètre tous les critères de recherche (vous référez à la section « Critères pour la recherche de cartes » plus haut
        /// pour l’ordre des paramètres et leur signification). Retourne une liste générique de « Carte » correspondant aux critères de
        /// recherche et triée premièrement selon le coût (en ordre croissant) et, par la suite, selon le nom (en ordre croissant et
        /// insensible à la casse et aux accents).
        /// </summary>
        /// <param name="?"></param>
        public List <Carte> RechercherCartes(CarteType type, String nomPartiel, List<CarteExtension> extensions, CarteRarete rarete,
            sbyte coutMin, sbyte coutMax, string textePartiel, HerosClasse classe, List<CarteMecanique> mecaniques,
            sbyte attaqueMin, sbyte attaqueMax, sbyte vieMin, sbyte vieMax, ServiteurRace race, sbyte durabiliteMin,
            sbyte durabiliteMax)
        {
            return null;
        }

        #endregion


    }

  
}

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
        /// Prend en paramètre tous les critères de recherche (vous référez à la section « Critères pour la recherche de cartes » plus haut
        /// pour l’ordre des paramètres et leur signification). Retourne une liste générique de « Carte » correspondant aux critères de
        /// recherche et triée premièrement selon le coût (en ordre croissant) et, par la suite, selon le nom (en ordre croissant et
        /// insensible à la casse et aux accents).
        /// </summary>
        /// <param name="?"></param>
        public List<Carte> RechercherCartes(CarteType type, String nomPartiel, List<CarteExtension> lstExtensions, CarteRarete rarete,
            sbyte coutMin,sbyte coutMax, string textePartiel,HerosClasse classe, List<CarteMecanique> lstMecaniques, 
            sbyte attaqueMin, sbyte attaqueMax, sbyte vieMin, sbyte vieMax,ServiteurRace race, sbyte durabiliteMin,
            sbyte durabiliteMax)
        {
            bool typeCorrespondACarte = false;
            bool nomCorrespondACarte = false;
            bool extensionCorrespondACarte = false;
            bool rareteCorrespondACarte = false;
            bool coutMinCorrespondACarte = false;
            bool coutMaxCorrespondACarte = false;
            bool texteCorrespondACarte = false;
            bool classeCorrespondACarte = false;
            bool mecaniqueCorrespondACarte = false;
            bool attaqueMinCorrespondACarte = false;
            bool attaqueMaxCorrespondACarte = false;
            bool vieMinCorrespondACarte = false;
            bool vieMaxCorrespondACarte = false;
            bool raceCorrespondACarte = false;
            bool durabiliteMinCorrespondACarte = false;
            bool durabiliteMaxCorrespondACarte = false;
            List<Carte> lstCartesTrouvees = null;

            for (int i = 0; i < this.LesCartes.Length; i++)
            {
                //Vérification de correspondance entre le type donné
                //et le type de la carte.
                if (this.LesCartes[i].Type == type)
                {
                    typeCorrespondACarte = true;
                }

                //Vérification de correspondance entre le nom donné
                //et le nom de la carte.
                if (this.LesCartes[i].Nom == nomPartiel)
                {
                    nomCorrespondACarte = true;
                } 

                //Boucle de vérification de correspondance
                //entre les extensions données et l'extension de la carte.
                for (int j = 0; j < lstExtensions.Count; j++)
                {
                    if (this.LesCartes[i].Extension ==  lstExtensions[j])
                    {
                        extensionCorrespondACarte = true;
                    }
                }

                //Boucle de vérification de correspondance 
                //à la liste mécanique d'une carte lue.
                for (int j = 0; j < lstMecaniques.Count; j++)
                {
                    //Pour les listes mécaniques de la carte lue...
                    for (int k = 0; k < this.LesCartes[i].LstMeca.Count; k++)
                    {
                        //Si la mécanique lue de la carte lue correspond à la mécanique lue de la liste de mécaniques.
                        //La mécanique correspond.
                        if (this.LesCartes[i].LstMeca[k] == lstMecaniques[j])
                        {
                            mecaniqueCorrespondACarte = true;
                        }

                    }
                }

                //Vérification de correspondance entre le cout min. donné
                //et le coût min. de la carte.
                if (this.LesCartes[i].Cout >= coutMin)
                {
                    coutMinCorrespondACarte = true;
                } 

                //Si tous les éléments données correspondent aux éléments de la carte lue,
                //La carte lue est ajouté aux résultats de recherche.
                if(typeCorrespondACarte && nomCorrespondACarte && extensionCorrespondACarte)
                    lstCartesTrouvees.Add(this.LesCartes[i]);
            }
        }

        /// <summary>
        /// Prend en paramètre l’identifiant d’une carte et retourne la carte correspondante si l’identifiant est valide; retourne « null » si
        /// l’identifiant est invalide.
        /// </summary>
        /// <returns></returns>
        public Carte RechercherCarteParId(string idCarteRecherchee)
        {

           Carte carteATrouve = null;


            for (int i = 0; i < this.LesCartes.Length; i++)
            {

                if (idCarteRecherchee.Trim() == this.LesCartes[i].Id.Trim())
                {
                    carteATrouve = this.LesCartes[i];
         
                }
            }

            return carteATrouve;
        }
        /// <summary>
        /// Prend en paramètre l’identifiant d’un héros et retourne le héros correspondant si l’identifiant est valide; retourne « null » si
        /// l’identifiant est invalide.
        /// </summary>
        /// <returns></returns>
        public Heros RechercherHeroParId(string idHeroRechercher)
        {

            if (idHeroRechercher == "")
                throw new ArgumentNullException("L'identifiant est inexistant.");

            Heros heroATrouve;

                idHeroRechercher = idHeroRechercher.Trim();

            for (int i = 0; i < this.LesHeros.Length; i++)
            {
                if (idHeroRechercher == this.LesHeros[i].Id)
                    heroATrouve = this.LesHeros[i];
            }
            return null;
        }

        #endregion


    }

  
}

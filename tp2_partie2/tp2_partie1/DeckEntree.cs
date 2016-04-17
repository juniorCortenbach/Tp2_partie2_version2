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
#endregion


namespace tp2_partie1
{
    public class DeckEntree
    {

        #region ATTRIBUTS

        /// <summary>
        /// Objet carte
        /// </summary>
        private Carte _carte;

        /// <summary>
        /// Quantité de carte
        /// </summary>
        private byte _qt;

        #endregion

        #region PROPRIÉTÉS
        /// <summary>
        /// Objet carte.
        /// </summary>
        public Carte Carte
        {
            get { return this._carte; }
            set
            {
                //if (value == null)
                    //throw new ArgumentNullException("La carte ne doit pas être nulle.");
                
                this._carte = value;
            }
        }

        /// <summary>
        /// Quantité de cartes.
        /// </summary>
        public byte Qt
        {
            get { return this._qt; }
            set { this._qt = value; }
        }
        #endregion

        #region CONSTRUCTEUR

        /// <summary>
        /// Constructeur paramétré qui accepte des cartes avec une quantité de cartes.
        /// </summary>
        /// <param name="carte"></param>
        /// <param name="qt"></param>
        public DeckEntree(Carte carte, byte qt )
        {
            if(carte == null)
                throw new ArgumentNullException("La carte ne doit pas être nulle.");

            if(!(qt > 0))
                throw new ArgumentOutOfRangeException("La quantité doit être plus grande que 0.");
            if(!(qt <= 2))
                throw new ArgumentOutOfRangeException("La quantité ne peut être plus grande que 2.");
            if(qt > 1 && carte.Rarete == CarteRarete.Legendary)
                throw new ArgumentOutOfRangeException("La quantité d'une carte légendaire" +
                                                      "ne peut être plus grande que 1.");
            this._carte = carte;
            this._qt = qt;
        }

        #endregion



    }
}

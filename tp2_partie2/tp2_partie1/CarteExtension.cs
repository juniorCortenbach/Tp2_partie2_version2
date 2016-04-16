#region MÉTADONNÉES
/* Nom du fichier         : A CHANGER
 * Nom du programmeur     : Maxim Desloges et Junior Cortenbach
 * Date                   : 30 mars 2016
 */
#endregion

#region USING
using System.ComponentModel;
#endregion

namespace tp2_partie1
{
    /// <summary>
    /// Énumération des configurations possibles.
    /// </summary>
    public enum CarteExtension
    {
        [Description("Cartes de base")]
        Core,
        [Description("La Malédiction de Naxxramas")]
        Naxx,
        [Description("Le Mont Rochenoire")]
        Brm,
        [Description("La Ligue des Explorateurs")]
        Loe,
        [Description("Gobelins et Gnomes")]
        Gvg,
        [Description("Le Grand Tournoi")]
        Tgt,
        [Description("Expert-1")]
        Expert1,
        [Description("Récompenses")]
        Reward,
        [Description("Promotions")]
        Promo,
        [Description("Nouvelles Apparences de Héros")]
        Heroskins
    }
}
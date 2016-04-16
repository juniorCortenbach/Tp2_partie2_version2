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
    /// Représente les différentes raretés des cartes de Hearthstone.
    /// </summary>
    public enum CarteRarete
    {
        [Description("Basique")]
        Free,
        [Description("Commune")]
        Common,
        [Description("Rare")]
        Rare,
        [Description("Épique")]
        Epic,
        [Description("Légendaire")]
        Legendary,
    }
}
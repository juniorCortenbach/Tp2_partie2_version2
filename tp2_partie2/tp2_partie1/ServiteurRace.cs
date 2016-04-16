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
    /// Représente les différentes races de serviteurs de Hearthstone.
    /// </summary>
    public enum ServiteurRace
    {
        Aucune,
        [Description("Bête")]
        Beast,
        [Description("Démon")]
        Demon,
        Dragon,
        [Description("Méca")]
        Mechanical,
        Murloc,
        Pirate,
        Totem
    }
}
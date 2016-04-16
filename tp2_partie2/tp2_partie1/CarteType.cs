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
    /// Représente les différents types de cartes de Hearthstone.
    /// </summary>
    public enum CarteType
    {
        [Description("Serviteur")] Minion,
        [Description("Sort")] Spell,
        [Description("Arme")] Weapon,
    }
}

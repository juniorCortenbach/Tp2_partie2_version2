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
    /// Représente les différentes classes de héros de Hearthstone.
    /// </summary>
    public enum HerosClasse
    {
        // Permet d'indiquer qu'une carte est accessible à toutes les classes de héros;
        // elle n'est liée à aucun héro en particulier.
        Neutre,
        [Description("Druide")]
        Druid,
        [Description("Chasseur")]
        Hunter,
        [Description("Mage")]
        Mage,
        [Description("Paladin")]
        Paladin,
        [Description("Prêtre")]
        Priest,
        [Description("Voleur")]
        Rogue,
        [Description("Chaman")]
        Shaman,
        [Description("Démoniste")]
        Warlock,
        [Description("Guerrier")]
        Warrior
    }
}

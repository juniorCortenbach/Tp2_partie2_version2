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
    /// Représente les différentes mécaniques des cartes de Hearthstone.
    /// </summary>
    public enum CarteMecanique
    {
        AdjacentBuff,
        Aura,
        [Description("Cri de guerre")]
        Battlecry,
        Charge,
        Combo,
        [Description("Râle d'agonie")]
        Deathrattle,
        [Description("Bouclier divin")]
        DivineShield,
        [Description("Accès de rage")]
        Enraged,
        [Description("Distraction")]
        Forgetful,
        [Description("Gèle")]
        Freeze,
        ImmuneToSpellPower,
        [Description("Exaltation")]
        Inspire,
        InvisibleDeathrattle,
        [Description("Surcharge")]
        Overload,
        [Description("Empoisonné")]
        Poisonous,
        Secret,
        Silence,
        [Description("Dégâts des sorts")]
        SpellPower,
        [Description("Camouflage")]
        Stealth,
        [Description("Provocation")]
        Taunt,
        [Description("Furie des vents")]
        Windfury
    }
}
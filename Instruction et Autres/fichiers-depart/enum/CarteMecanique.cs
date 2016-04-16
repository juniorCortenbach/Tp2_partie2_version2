#region MÉTADONNÉES

// Nom du fichier : CarteMecanique.cs
// Auteur : Stéphane Lapointe (slapointe)
// Date de création : 2016-02-26
// Date de modification : 2016-03-21

#endregion

#region USING

using System.ComponentModel;

#endregion

namespace VOTRE_NAMESPACE
{
    /// <summary>
    /// Représente les différentes mécaniques des cartes de Hearthstone.
    /// </summary>
    public enum CarteMecanique
    {
        AdjacentBuff,
        Aura,
        [Description("Cri de guerre")] Battlecry,
        Charge,
        Combo,
        [Description("Râle d'agonie")] Deathrattle,
        [Description("Bouclier divin")] DivineShield,
        [Description("Accès de rage")] Enraged,
        [Description("Distraction")] Forgetful,
        [Description("Gèle")] Freeze,
        ImmuneToSpellPower,
        [Description("Exaltation")] Inspire,
        InvisibleDeathrattle,
        [Description("Surcharge")] Overload,
        [Description("Empoisonné")] Poisonous,
        Secret,
        Silence,
        [Description("Dégâts des sorts")] SpellPower,
        [Description("Camouflage")] Stealth,
        [Description("Provocation")] Taunt,
        [Description("Furie des vents")] Windfury
    }
}
#region MÉTADONNÉES

// Nom du fichier : HeroClasse.cs
// Auteur : Stéphane Lapointe (slapointe)
// Date de création : 2016-02-26
// Date de modification : 2016-02-26

#endregion

#region USING

using System.ComponentModel;

#endregion

namespace VOTRE_NAMESPACE
{
    /// <summary>
    /// Représente les différentes classes de héros de Hearthstone.
    /// </summary>
    public enum HerosClasse
    {
        // Permet d'indiquer qu'une carte est accessible à toutes les classes de héros;
        // elle n'est liée à aucun héro en particulier.
        Neutre,
        [Description("Druide")] Druid,
        [Description("Chasseur")] Hunter,
        [Description("Mage")] Mage,
        [Description("Paladin")] Paladin,
        [Description("Prêtre")] Priest,
        [Description("Voleur")] Rogue,
        [Description("Chaman")] Shaman,
        [Description("Démoniste")] Warlock,
        [Description("Guerrier")] Warrior
    }
}
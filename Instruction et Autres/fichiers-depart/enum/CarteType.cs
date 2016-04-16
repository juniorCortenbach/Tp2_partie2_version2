#region MÉTADONNÉES

// Nom du fichier : CarteType.cs
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
    /// Représente les différents types de cartes de Hearthstone.
    /// </summary>
    public enum CarteType
    {
        [Description("Serviteur")] Minion,
        [Description("Sort")] Spell,
        [Description("Arme")] Weapon,
    }
}
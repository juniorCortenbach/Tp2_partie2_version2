#region MÉTADONNÉES

// Nom du fichier : CarteRarete.cs
// Auteur : Stéphane Lapointe (slapointe)
// Date de création : 2016-02-25
// Date de modification : 2016-02-26

#endregion

#region USING

using System.ComponentModel;

#endregion

namespace VOTRE_NAMESPACE
{
    /// <summary>
    /// Représente les différentes raretés des cartes de Hearthstone.
    /// </summary>
    public enum CarteRarete
    {
        [Description("Basique")] Free,
        [Description("Commune")] Common,
        [Description("Rare")] Rare,
        [Description("Épique")] Epic,
        [Description("Légendaire")] Legendary,
    }
}
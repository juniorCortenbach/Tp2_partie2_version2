#region MÉTADONNÉES

// Nom du fichier : ServiteurRace.cs
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
    /// Représente les différentes races de serviteurs de Hearthstone.
    /// </summary>
    public enum ServiteurRace
    {
        Aucune,
        [Description("Bête")] Beast,
        [Description("Démon")] Demon,
        Dragon,
        [Description("Méca")] Mechanical,
        Murloc,
        Pirate,
        Totem
    }
}
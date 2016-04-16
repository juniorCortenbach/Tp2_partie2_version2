#region MÉTADONNÉES

// Nom du fichier : CarteExtension.cs
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
    ///  Représente les différentes extensions de Hearthstone.
    /// </summary>
    public enum CarteExtension
    {
        [Description("Cartes de base")] Core,
        [Description("La Malédiction de Naxxramas")] Naxx,
        [Description("Le Mont Rochenoire")] Brm,
        [Description("La Ligue des Explorateurs")] Loe,
        [Description("Gobelins et Gnomes")] Gvg,
        [Description("Le Grand Tournoi")] Tgt,
        [Description("Expert-1")] Expert1,
        [Description("Récompenses")] Reward,
        [Description("Promotions")] Promo,
        [Description("Nouvelles Apparences de Héros")] Heroskins
    }
}
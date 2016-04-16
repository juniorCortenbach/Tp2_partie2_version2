#region MÉTADONNÉES

// Nom du fichier : TestDeckEntree.cs
// Auteur : Stéphane Lapointe (slapointe)
// Date de création : 2016-03-02
// Date de modification : 2016-03-17

#endregion

#region USING

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tp2_partie1;

#endregion

namespace TestsUnitaires
{
    /// <summary>
    /// Tests unitaires pour la classe "DeckEntree".
    /// </summary>
    [TestClass]
    public class TestsDeckEntree
    {
        #region MÉTHODES

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        public void TestConstructeurDeckEntree()
        {
            Carte serviteurNonLegendaire = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            Carte serviteurLegendaire = new Carte(CarteType.Minion, "AT_063", "Acidmaw", CarteExtension.Tgt,
                CarteRarete.Legendary, 7, "Whenever another minion takes damage, destroy it.", HerosClasse.Neutre,
                4, 2, ServiteurRace.Beast, -1);

            Carte sort = new Carte(CarteType.Spell, "EX1_132", "Eye for an Eye", CarteExtension.Expert1,
                CarteRarete.Common, 1,
                "Secret: When your hero takes damage, deal that much damage to the enemy hero.",
                HerosClasse.Paladin, -1, -1, ServiteurRace.Aucune, -1);

            Carte arme = new Carte(CarteType.Weapon, "EX1_567", "Doomhammer", CarteExtension.Expert1,
                CarteRarete.Epic, 5, "Windfury, Overload: (2)", HerosClasse.Shaman, 2, -1,
                ServiteurRace.Aucune, 8);

            DeckEntree de1 = new DeckEntree(serviteurNonLegendaire, 1);
            Assert.AreSame(serviteurNonLegendaire, de1.Carte);
            Assert.AreEqual(1, de1.Qt);

            DeckEntree de2 = new DeckEntree(serviteurNonLegendaire, 2);
            Assert.AreSame(serviteurNonLegendaire, de2.Carte);
            Assert.AreEqual(2, de2.Qt);

            DeckEntree de3 = new DeckEntree(serviteurLegendaire, 1);
            Assert.AreSame(serviteurLegendaire, de3.Carte);
            Assert.AreEqual(1, de3.Qt);

            DeckEntree de4 = new DeckEntree(sort, 1);
            Assert.AreSame(sort, de4.Carte);
            Assert.AreEqual(1, de4.Qt);

            DeckEntree de5 = new DeckEntree(arme, 2);
            Assert.AreSame(arme, de5.Carte);
            Assert.AreEqual(2, de5.Qt);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "La carte ne doit pas être nulle.")]
        public void TestConstructeurDeckEntreeExceptionCarteNulle()
        {
            // ReSharper disable once UnusedVariable
            DeckEntree de = new DeckEntree(null, 1);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Le nombre de copies d'une carte doit être d'au moins 1.")]
        public void TestConstructeurDeckEntreeExceptionQtInvalide1()
        {
            Carte serviteur = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            // ReSharper disable once UnusedVariable
            // Test : Qt = 0 ==> Trop petite (carte non légendaire).
            DeckEntree de = new DeckEntree(serviteur, 0);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Le nombre de copies d'une carte doit être d'au moins 1.")]
        public void TestConstructeurDeckEntreeExceptionQtInvalide2()
        {
            Carte serviteur = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Legendary, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            // ReSharper disable once UnusedVariable
            // Test : Qt = 0 ==> Trop petite (carte légendaire).
            DeckEntree de = new DeckEntree(serviteur, 0);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Le nombre maximal de copies d'une carte non légendaire doit être de 2.")]
        public void TestConstructeurDeckEntreeExceptionQtInvalide3()
        {
            Carte serviteur = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            // ReSharper disable once UnusedVariable
            // Test : Qt = 3 ==> Trop grande.
            DeckEntree de = new DeckEntree(serviteur, 3);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Le nombre maximal de copies d'une carte légendaire doit être de 1.")]
        public void TestConstructeurDeckEntreeExceptionQtInvalide4()
        {
            Carte serviteurLegendaire = new Carte(CarteType.Minion, "AT_063", "Acidmaw", CarteExtension.Tgt,
                CarteRarete.Legendary, 7, "Whenever another minion takes damage, destroy it.", HerosClasse.Neutre,
                4, 2, ServiteurRace.Beast, -1);

            // ReSharper disable once UnusedVariable
            // Test : Qt = 2 ==> Trop grande.
            DeckEntree de = new DeckEntree(serviteurLegendaire, 2);
        }

        #endregion
    }
}
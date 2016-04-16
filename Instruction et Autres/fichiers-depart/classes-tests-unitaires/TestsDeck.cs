#region MÉTADONNÉES

// Nom du fichier : TestsDeck.cs
// Auteur : Stéphane Lapointe (slapointe)
// Date de création : 2016-03-03
// Date de modification : 2016-03-20

#endregion

#region USING

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2_Solution_Classes;

#endregion

namespace TestsUnitaires
{
    /// <summary>
    /// Tests unitaires pour la classe "Deck".
    /// </summary>
    [TestClass]
    public class TestsDeck
    {
        #region MÉTHODES

        /// <summary>
        /// Tests unitaires pour les constantes.
        /// </summary>
        [TestMethod]
        public void TestConstantesDeck()
        {
            Assert.AreEqual(2, Deck.QtMaxCarteNonLegendaire);
            Assert.AreEqual(1, Deck.QtMaxCarteLegendaire);
            Assert.AreEqual(30, Deck.NbMaxCartesDansDeck);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        public void TestConstructeurDeck()
        {
            Heros heroMage = new Heros("HERO_08", "Jaina Proudmoore", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Mage, 30);
            Deck deck = new Deck("   Mischievous Wizards   ", heroMage);

            Assert.AreEqual("Mischievous Wizards", deck.Nom);
            Assert.AreSame(heroMage, deck.Heros);
            Assert.AreEqual(0, deck.LstCartesAvecQt.Count);
            // Test de la propriété qui permet d'obtenir le nombre total de cartes dans le deck.
            Assert.AreEqual(0, deck.NbTotalCartes);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException), "Le nom du deck ne doit pas être nul.")]
        public void TestConstructeurDeckExceptionNomNul()
        {
            Heros heroMage = new Heros("HERO_08", "Jaina Proudmoore", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Mage, 30);
            // ReSharper disable once UnusedVariable
            Deck deck = new Deck(null, heroMage);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException),
            "Le nom du deck doit contenir un minimum de 3 caractères.")]
        public void TestConstructeurDeckExceptionNomInvalide()
        {
            Heros heroMage = new Heros("HERO_08", "Jaina Proudmoore", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Mage, 30);
            // ReSharper disable once UnusedVariable
            Deck deck = new Deck("  Yo     ", heroMage);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException), "Le héro pour le deck ne doit pas être nul.")]
        public void TestConstructeurDeckExceptionHeroNul()
        {
            // ReSharper disable once UnusedVariable
            Deck deck = new Deck("nom_deck", null);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "AjouterCartes".
        /// </summary>
        [TestMethod]
        public void TestAjouterCartes1()
        {
            // Tests : Ajouter des cartes une copie à la fois.

            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

            Carte carteNeutreNonLegendaire = new Carte(CarteType.Minion, "GVG_103", "Micro Machine",
                CarteExtension.Gvg, CarteRarete.Common, 2, "At the start of each turn, gain +1 Attack.",
                HerosClasse.Neutre, 1, 2, ServiteurRace.Mechanical, -1);

            Carte carteNeutreLegendaire = new Carte(CarteType.Minion, "LOE_077", "Brann Bronzebeard",
                CarteExtension.Loe, CarteRarete.Legendary, 3, "Your Battlecries trigger twice.",
                HerosClasse.Neutre, 2, 4, ServiteurRace.Aucune, -1);

            Carte carteWarriorNonLegendaire = new Carte(CarteType.Weapon, "GVG_054", "Ogre Warmaul",
                CarteExtension.Gvg, CarteRarete.Common, 3,
                "50% chance to attack the wrong enemy.",
                HerosClasse.Warrior, 4, -1, ServiteurRace.Aucune, 2);

            Carte carteWarriorLegendaire = new Carte(CarteType.Minion, "GVG_056", "Iron Juggernaut",
                CarteExtension.Gvg, CarteRarete.Legendary, 6,
                "Battlecry: Shuffle a Mine into your opponent's deck. When drawn, it explodes for 10 damage.",
                HerosClasse.Warrior, 6, 5, ServiteurRace.Mechanical, -1);

            // Ajout de cartes neutres
            // =======================
            deckWarrior.AjouterCartes(carteNeutreNonLegendaire, 1);
            Assert.AreEqual(1, deckWarrior.LstCartesAvecQt.Count);
            Assert.AreEqual(1, deckWarrior.NbTotalCartes);

            deckWarrior.AjouterCartes(carteNeutreNonLegendaire, 1);
            // Les deux copies de la carte doivent être dans le même objet "DeckEntree".
            Assert.AreEqual(1, deckWarrior.LstCartesAvecQt.Count);
            Assert.AreEqual(2, deckWarrior.NbTotalCartes);

            deckWarrior.AjouterCartes(carteNeutreLegendaire, 1);
            Assert.AreEqual(2, deckWarrior.LstCartesAvecQt.Count);
            Assert.AreEqual(3, deckWarrior.NbTotalCartes);

            // Ajout de cartes Warrior
            // =======================
            deckWarrior.AjouterCartes(carteWarriorNonLegendaire, 1);
            Assert.AreEqual(3, deckWarrior.LstCartesAvecQt.Count);
            Assert.AreEqual(4, deckWarrior.NbTotalCartes);

            deckWarrior.AjouterCartes(carteWarriorNonLegendaire, 1);
            // Les deux copies de la carte doivent être dans le même objet "DeckEntree".
            Assert.AreEqual(3, deckWarrior.LstCartesAvecQt.Count);
            Assert.AreEqual(5, deckWarrior.NbTotalCartes);

            deckWarrior.AjouterCartes(carteWarriorLegendaire, 1);
            Assert.AreEqual(4, deckWarrior.LstCartesAvecQt.Count);
            Assert.AreEqual(6, deckWarrior.NbTotalCartes);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "AjouterCartes".
        /// </summary>
        [TestMethod]
        public void TestAjouterCartes2()
        {
            // Tests : Ajouter des cartes deux copies à la fois.

            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

            Carte carteNeutreNonLegendaire = new Carte(CarteType.Minion, "GVG_103", "Micro Machine",
                CarteExtension.Gvg, CarteRarete.Common, 2, "At the start of each turn, gain +1 Attack.",
                HerosClasse.Neutre, 1, 2, ServiteurRace.Mechanical, -1);

            Carte carteWarriorNonLegendaire = new Carte(CarteType.Weapon, "GVG_054", "Ogre Warmaul",
                CarteExtension.Gvg, CarteRarete.Common, 3,
                "50% chance to attack the wrong enemy.",
                HerosClasse.Warrior, 4, -1, ServiteurRace.Aucune, 2);

            // Ajout de cartes neutres
            // =======================
            deckWarrior.AjouterCartes(carteNeutreNonLegendaire, 2);
            Assert.AreEqual(1, deckWarrior.LstCartesAvecQt.Count);
            Assert.AreEqual(2, deckWarrior.NbTotalCartes);

            // Ajout de cartes Warrior
            // =======================
            deckWarrior.AjouterCartes(carteWarriorNonLegendaire, 2);
            Assert.AreEqual(2, deckWarrior.LstCartesAvecQt.Count);
            Assert.AreEqual(4, deckWarrior.NbTotalCartes);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "AjouterCartes".
        /// </summary>
        [TestMethod]
        public void TestAjouterCartes3()
        {
            // Tests : Remplir le deck au complet.

            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

            for (int i = 1; i <= Deck.NbMaxCartesDansDeck; i++)
            {
                Carte carte = new Carte(CarteType.Minion, "LOE_0" + i, "nom_carte_" + i, CarteExtension.Loe,
                    CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);
                deckWarrior.AjouterCartes(carte, 1);
            }

            Assert.AreEqual(30, deckWarrior.LstCartesAvecQt.Count);
            Assert.AreEqual(30, deckWarrior.NbTotalCartes);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "AjouterCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException), "La carte ne doit pas être nulle.")]
        public void TestAjouterCartesExceptionCarteNulle()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

            deckWarrior.AjouterCartes(null, 1);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "AjouterCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException),
            "La carte ne peut pas être ajoutée au deck car elle ne possède pas la bonne classe.")]
        public void TestAjouterCartesExceptionCarteMauvaiseClasse()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);
            Carte carteMage = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Mage, 2, 3, ServiteurRace.Aucune, -1);

            deckWarrior.AjouterCartes(carteMage, 1);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "AjouterCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Le nombre de copies d'une carte doit être d'au moins 1.")]
        public void TestAjouterCartesExceptionQtInvalide1()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);
            Carte carteNonLegendaire = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            // Test : Qt = 0 ==> Trop petite (carte non légendaire).
            deckWarrior.AjouterCartes(carteNonLegendaire, 0);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "AjouterCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Le nombre de copies d'une carte doit être d'au moins 1.")]
        public void TestAjouterCartesExceptionQtInvalide2()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);
            Carte carteLegendaire = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Legendary, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            // Test : Qt = 0 ==> Trop petite (carte légendaire).
            deckWarrior.AjouterCartes(carteLegendaire, 0);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "AjouterCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Le nombre maximal de copies d'une carte non légendaire doit être de 2.")]
        public void TestAjouterCartesExceptionQtInvalide3()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);
            Carte carteNonLegendaire = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            // Test : Qt = 3 ==> Trop grande.
            deckWarrior.AjouterCartes(carteNonLegendaire, 3);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "AjouterCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException),
            "Le nombre maximal de copies d'une carte légendaire doit être de 1.")]
        public void TestAjouterCartesExceptionQtInvalide4()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);
            Carte carteLegendaire = new Carte(CarteType.Minion, "AT_063", "Acidmaw", CarteExtension.Tgt,
                CarteRarete.Legendary, 7, "Whenever another minion takes damage, destroy it.", HerosClasse.Neutre,
                4, 2, ServiteurRace.Beast, -1);

            // Test : Qt = 2 ==> Trop grande.
            deckWarrior.AjouterCartes(carteLegendaire, 2);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "AjouterCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException),
            "Le nombre total de copies d'une carte non légendaire doit être d'au plus 2.")]
        public void TestAjouterCartesExceptionQtInvalide5()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);
            Carte carteNonLegendaire = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            deckWarrior.AjouterCartes(carteNonLegendaire, 1);
            deckWarrior.AjouterCartes(carteNonLegendaire, 1);
            deckWarrior.AjouterCartes(carteNonLegendaire, 1);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "AjouterCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException),
            "Le nombre total de copies d'une carte non légendaire doit être d'au plus 2.")]
        public void TestAjouterCartesExceptionQtInvalide6()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);
            Carte carteNonLegendaire = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            deckWarrior.AjouterCartes(carteNonLegendaire, 2);
            deckWarrior.AjouterCartes(carteNonLegendaire, 1);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "AjouterCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException),
            "Le nombre total de copies d'une carte légendaire doit être d'au plus 1.")]
        public void TestAjouterCartesExceptionQtInvalide7()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);
            Carte carteLegendaire = new Carte(CarteType.Minion, "AT_063", "Acidmaw", CarteExtension.Tgt,
                CarteRarete.Legendary, 7, "Whenever another minion takes damage, destroy it.", HerosClasse.Neutre,
                4, 2, ServiteurRace.Beast, -1);

            deckWarrior.AjouterCartes(carteLegendaire, 1);
            deckWarrior.AjouterCartes(carteLegendaire, 1);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "AjouterCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException),
            "Le nombre total de cartes dans le deck doit être d'au plus 30.")]
        public void TestAjouterCartesExceptionNbMaxCartesDepasse()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

            // Ajout d'une carte de plus que le maximum permis.
            for (int i = 1; i <= Deck.NbMaxCartesDansDeck + 1; i++)
            {
                Carte carte = new Carte(CarteType.Minion, "LOE_0" + i, "nom_carte_" + i, CarteExtension.Loe,
                    CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);
                deckWarrior.AjouterCartes(carte, 1);
            }
        }

        /// <summary>
        /// Tests unitaires pour la méthode "ObtenirQtCarte".
        /// </summary>
        [TestMethod]
        public void TestObtenirQtCarte()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

            Carte carteNonLegendaire1 = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            Carte carteNonLegendaire2 = new Carte(CarteType.Spell, "LOE_002", "nom_carte", CarteExtension.Naxx,
                CarteRarete.Epic, 5, "texte_carte", HerosClasse.Warrior, -1, -1, ServiteurRace.Aucune, -1);

            Carte carteLegendaire = new Carte(CarteType.Minion, "AT_063", "Acidmaw", CarteExtension.Tgt,
                CarteRarete.Legendary, 7, "Whenever another minion takes damage, destroy it.",
                HerosClasse.Neutre, 4, 2, ServiteurRace.Beast, -1);

            Assert.AreEqual(0, deckWarrior.ObtenirQtCarte(carteNonLegendaire1));
            deckWarrior.AjouterCartes(carteNonLegendaire1, 1);
            Assert.AreEqual(1, deckWarrior.ObtenirQtCarte(carteNonLegendaire1));
            deckWarrior.AjouterCartes(carteNonLegendaire1, 1);
            Assert.AreEqual(2, deckWarrior.ObtenirQtCarte(carteNonLegendaire1));

            Assert.AreEqual(0, deckWarrior.ObtenirQtCarte(carteNonLegendaire2));
            deckWarrior.AjouterCartes(carteNonLegendaire2, 2);
            Assert.AreEqual(2, deckWarrior.ObtenirQtCarte(carteNonLegendaire2));

            Assert.AreEqual(0, deckWarrior.ObtenirQtCarte(carteLegendaire));
            deckWarrior.AjouterCartes(carteLegendaire, 1);
            Assert.AreEqual(1, deckWarrior.ObtenirQtCarte(carteLegendaire));
        }

        /// <summary>
        /// Tests unitaires pour la méthode "ObtenirQtCarte".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException), "La carte ne doit pas être nulle.")]
        public void TestObtenirQtCarteExceptionCarteNulle()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

            deckWarrior.ObtenirQtCarte(null);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "RetirerCarte".
        /// </summary>
        [TestMethod]
        public void TestRetirerCarteUneSeuleCopie()
        {
            // Tests : Retirer des cartes une seule copie à la fois.

            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

            Carte carteNonLegendaire1 = new Carte(CarteType.Minion, "GVG_103", "Micro Machine",
                CarteExtension.Gvg, CarteRarete.Common, 2, "At the start of each turn, gain +1 Attack.",
                HerosClasse.Neutre, 1, 2, ServiteurRace.Mechanical, -1);

            Carte carteNonLegendaire2 = new Carte(CarteType.Weapon, "GVG_054", "Ogre Warmaul",
                CarteExtension.Gvg, CarteRarete.Common, 3,
                "50% chance to attack the wrong enemy.",
                HerosClasse.Warrior, 4, -1, ServiteurRace.Aucune, 2);

            Carte carteLegendaire1 = new Carte(CarteType.Minion, "LOE_077", "Brann Bronzebeard",
                CarteExtension.Loe, CarteRarete.Legendary, 3, "Your Battlecries trigger twice.",
                HerosClasse.Neutre, 2, 4, ServiteurRace.Aucune, -1);

            Carte carteLegendaire2 = new Carte(CarteType.Minion, "GVG_056", "Iron Juggernaut",
                CarteExtension.Gvg, CarteRarete.Legendary, 6,
                "Battlecry: Shuffle a Mine into your opponent's deck. When drawn, it explodes for 10 damage.",
                HerosClasse.Warrior, 6, 5, ServiteurRace.Mechanical, -1);

            // Ajout de cartes.
            deckWarrior.AjouterCartes(carteNonLegendaire1, 1);
            deckWarrior.AjouterCartes(carteNonLegendaire2, 2);

            deckWarrior.AjouterCartes(carteLegendaire1, 1);
            deckWarrior.AjouterCartes(carteLegendaire2, 1);

            // Retrait de cartes.
            Assert.AreEqual(1, deckWarrior.RetirerCarte(carteNonLegendaire1, false));
            Assert.AreEqual(0, deckWarrior.ObtenirQtCarte(carteNonLegendaire1));

            Assert.AreEqual(1, deckWarrior.RetirerCarte(carteNonLegendaire2, false));
            Assert.AreEqual(1, deckWarrior.ObtenirQtCarte(carteNonLegendaire2));
            deckWarrior.AjouterCartes(carteNonLegendaire2, 1);
            Assert.AreEqual(1, deckWarrior.RetirerCarte(carteNonLegendaire2, false));
            Assert.AreEqual(1, deckWarrior.ObtenirQtCarte(carteNonLegendaire2));
            Assert.AreEqual(1, deckWarrior.RetirerCarte(carteNonLegendaire2, true));
            Assert.AreEqual(0, deckWarrior.ObtenirQtCarte(carteNonLegendaire2));

            Assert.AreEqual(1, deckWarrior.RetirerCarte(carteLegendaire1, true));
            Assert.AreEqual(0, deckWarrior.ObtenirQtCarte(carteLegendaire1));

            Assert.AreEqual(1, deckWarrior.RetirerCarte(carteLegendaire2, false));
            Assert.AreEqual(0, deckWarrior.ObtenirQtCarte(carteLegendaire2));
            deckWarrior.AjouterCartes(carteLegendaire2, 1);
            Assert.AreEqual(1, deckWarrior.RetirerCarte(carteLegendaire2, false));
            Assert.AreEqual(0, deckWarrior.ObtenirQtCarte(carteLegendaire2));
        }

        /// <summary>
        /// Tests unitaires pour la méthode "RetirerCarte".
        /// </summary>
        [TestMethod]
        public void TestRetirerCartePlusieursCopies()
        {
            // Tests : Retirer des cartes plusieurs copies à la fois.

            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

            Carte carteNonLegendaire1 = new Carte(CarteType.Minion, "GVG_103", "Micro Machine",
                CarteExtension.Gvg, CarteRarete.Common, 2, "At the start of each turn, gain +1 Attack.",
                HerosClasse.Neutre, 1, 2, ServiteurRace.Mechanical, -1);

            Carte carteNonLegendaire2 = new Carte(CarteType.Weapon, "GVG_054", "Ogre Warmaul",
                CarteExtension.Gvg, CarteRarete.Common, 3,
                "50% chance to attack the wrong enemy.",
                HerosClasse.Warrior, 4, -1, ServiteurRace.Aucune, 2);

            // Ajout de cartes.
            deckWarrior.AjouterCartes(carteNonLegendaire1, 2);
            deckWarrior.AjouterCartes(carteNonLegendaire2, 1);
            deckWarrior.AjouterCartes(carteNonLegendaire2, 1);

            // Retrait de cartes.
            Assert.AreEqual(2, deckWarrior.RetirerCarte(carteNonLegendaire1, true));
            Assert.AreEqual(0, deckWarrior.ObtenirQtCarte(carteNonLegendaire1));

            Assert.AreEqual(2, deckWarrior.RetirerCarte(carteNonLegendaire2, true));
            Assert.AreEqual(0, deckWarrior.ObtenirQtCarte(carteNonLegendaire2));
            deckWarrior.AjouterCartes(carteNonLegendaire2, 2);
            Assert.AreEqual(2, deckWarrior.RetirerCarte(carteNonLegendaire2, true));
            Assert.AreEqual(0, deckWarrior.ObtenirQtCarte(carteNonLegendaire2));
        }

        /// <summary>
        /// Tests unitaires pour la méthode "RetirerCarte".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException), "La carte ne doit pas être nulle.")]
        public void TestRetirerCarteExceptionCarteNulle()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

            deckWarrior.RetirerCarte(null, false);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "RetirerCarte".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException), "La carte n'est pas dans le deck.")]
        public void TestRetirerCarteExceptionCartePasDansDeck1()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

            Carte carte = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            deckWarrior.RetirerCarte(carte, false);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "RetirerCarte".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException), "La carte n'est pas dans le deck.")]
        public void TestRetirerCarteExceptionCartePasDansDeck2()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

            Carte carte = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            deckWarrior.AjouterCartes(carte, 1);

            deckWarrior.RetirerCarte(carte, false);
            deckWarrior.RetirerCarte(carte, false);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "RetirerCarte".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException), "La carte n'est pas dans le deck.")]
        public void TestRetirerCarteExceptionCartePasDansDeck3()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

            Carte carte = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            deckWarrior.AjouterCartes(carte, 2);

            deckWarrior.RetirerCarte(carte, false);
            deckWarrior.RetirerCarte(carte, false);
            deckWarrior.RetirerCarte(carte, true);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "RetirerCarte".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException), "La carte n'est pas dans le deck.")]
        public void TestRetirerCarteExceptionCartePasDansDeck4()
        {
            Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Warrior, 30);
            Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

            Carte carte = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Loe,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            deckWarrior.AjouterCartes(carte, 2);

            deckWarrior.RetirerCarte(carte, true);
            deckWarrior.RetirerCarte(carte, true);
        }

        #endregion
    }
}
#region MÉTADONNÉES

// Nom du fichier : TestsUtilitaire.cs
// Auteur : Stéphane Lapointe (slapointe)
// Date de création : 2016-03-18
// Date de modification : 2016-03-18

#endregion

#region USING

using System;
using System.IO;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tp2_partie1;

#endregion

namespace TestsUnitaires
{
    /// <summary>
    /// Tests unitaires pour la classe "Utilitaire".
    /// </summary>
    [TestClass]
    public class TestsUtilitaire
    {
        #region MÉTHODES

      // ChargerHero
        // ===========

        /// <summary>
        /// Tests unitaires pour la méthode "ChargerHero".
        /// </summary>
        [TestMethod]
        public void TestChargerHeros()
        {
            Heros[] heros = Utilitaire.ChargerHeros("cards-collectible.xml");

            Assert.AreEqual(12, heros.Length);

            // Test : Premier héro.
            Assert.AreEqual("HERO_08", heros[0].Id);
            Assert.AreEqual("Jaina Proudmoore", heros[0].Nom);
            Assert.AreEqual(CarteExtension.Core, heros[0].Extension);
            Assert.AreEqual(CarteRarete.Free, heros[0].Rarete);
            Assert.AreEqual(HerosClasse.Mage, heros[0].Classe);
            Assert.AreEqual(30, heros[0].Vie);

            // Test : Dernier héro.
            Assert.AreEqual("HERO_05a", heros[heros.Length - 1].Id);
            Assert.AreEqual("Alleria Windrunner", heros[heros.Length - 1].Nom);
            Assert.AreEqual(CarteExtension.Heroskins, heros[heros.Length - 1].Extension);
            Assert.AreEqual(CarteRarete.Epic, heros[heros.Length - 1].Rarete);
            Assert.AreEqual(HerosClasse.Hunter, heros[heros.Length - 1].Classe);
            Assert.AreEqual(30, heros[heros.Length - 1].Vie);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "ChargerHero".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Le nom du fichier ne doit pas être nul.")]
        public void TestChargerHerosExceptionNomFichierNul()
        {
            Utilitaire.ChargerHeros(null);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "ChargerHero".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Le nom du fichier est invalide.")]
        public void TestChargerHerosExceptionNomFichierVide()
        {
            Utilitaire.ChargerHeros("   ");
        }

        /// <summary>
        /// Tests unitaires pour la méthode "ChargerHero".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Le chemin pour accéder au fichier est invalide.")]
        public void TestChargerHerosExceptionNomFichierInvalide()
        {
            Utilitaire.ChargerHeros("nom_invalide.xml");
        }

        /// <summary>
        /// Tests unitaires pour la méthode "ChargerHero".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(XmlException), "Le fichier n'est pas un fichier XML valide.")]
        public void TestChargerHerosExceptionXmlNonValide()
        {
            String nomFichierXmlInvalide = "xml_non_valide.xml";
            StreamWriter sw = new StreamWriter(nomFichierXmlInvalide, false);
            sw.WriteLine("Pas du XML.");
            sw.Close();
            Utilitaire.ChargerHeros(nomFichierXmlInvalide);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "ChargerHero".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Impossible d'ouvrir le fichier XML.")]
        public void TestChargerHerosExceptionDossierInvalide()
        {
            Utilitaire.ChargerHeros("dossier_invalide/cards-collectible.xml");
        }

        /// <summary>
        /// Tests unitaires pour la méthode "ChargerHero".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Impossible d'ouvrir le fichier XML.")]
        public void TestChargerHerosExceptionCheminTropLong()
        {
            // Création d'un chemin trop long.
            String chemin = new string('x', 300) + ".xml";
            Utilitaire.ChargerHeros(chemin);
        }

        // ChargerCartes
        // =============

        /// <summary>
        /// Tests unitaires pour la méthode "ChargerCartes".
        /// </summary>
        [TestMethod]
        public void TestChargerCartes()
        {

            Carte[] cartes = Utilitaire.ChargerCartes("cards-collectible.xml");

            
        
            Assert.AreEqual(743, cartes.Length);
            
            // Test : Première carte.
            Assert.AreEqual(CarteType.Minion, cartes[0].Type);
            Assert.AreEqual("LOE_061", cartes[0].Id);
            Assert.AreEqual("Anubisath Sentinel", cartes[0].Nom);
            Assert.AreEqual(CarteExtension.Loe, cartes[0].Extension);
            Assert.AreEqual(CarteRarete.Common, cartes[0].Rarete);
            Assert.AreEqual(5, cartes[0].Cout);
            Assert.AreEqual("Deathrattle: Give a random friendly minion +3/+3.", cartes[0].Texte);
            Assert.AreEqual(HerosClasse.Neutre, cartes[0].Classe);
            Assert.AreEqual(1, cartes[0].LstMeca.Count);
            Assert.AreEqual(CarteMecanique.Deathrattle, cartes[0].LstMeca[0]);
            Assert.AreEqual(4, cartes[0].Attaque);
            Assert.AreEqual(4, cartes[0].Vie);
            Assert.AreEqual(ServiteurRace.Aucune, cartes[0].Race);
            Assert.AreEqual(-1, cartes[0].Durabilite);

            // Test : Dernière carte.
            Assert.AreEqual(CarteType.Minion, cartes[cartes.Length - 1].Type);
            Assert.AreEqual("EX1_350", cartes[cartes.Length - 1].Id);
            Assert.AreEqual("Prophet Velen", cartes[cartes.Length - 1].Nom);
            Assert.AreEqual(CarteExtension.Expert1, cartes[cartes.Length - 1].Extension);
            Assert.AreEqual(CarteRarete.Legendary, cartes[cartes.Length - 1].Rarete);
            Assert.AreEqual(7, cartes[cartes.Length - 1].Cout);
            Assert.AreEqual("Double the damage and healing of your spells and Hero Power.",
                cartes[cartes.Length - 1].Texte);
            Assert.AreEqual(HerosClasse.Priest, cartes[cartes.Length - 1].Classe);
            Assert.AreEqual(0, cartes[cartes.Length - 1].LstMeca.Count);
            Assert.AreEqual(7, cartes[cartes.Length - 1].Attaque);
            Assert.AreEqual(7, cartes[cartes.Length - 1].Vie);
            Assert.AreEqual(ServiteurRace.Aucune, cartes[cartes.Length - 1].Race);
            Assert.AreEqual(-1, cartes[cartes.Length - 1].Durabilite);

            // Test : Sort.
            Assert.AreEqual(CarteType.Spell, cartes[373].Type);
            Assert.AreEqual("EX1_137", cartes[373].Id);
            Assert.AreEqual("Headcrack", cartes[373].Nom);
            Assert.AreEqual(CarteExtension.Expert1, cartes[373].Extension);
            Assert.AreEqual(CarteRarete.Rare, cartes[373].Rarete);
            Assert.AreEqual(3, cartes[373].Cout);
            Assert.AreEqual("Deal $2 damage to the enemy hero. Combo: Return this to your hand next turn.",
                cartes[373].Texte);
            Assert.AreEqual(HerosClasse.Rogue, cartes[373].Classe);
            Assert.AreEqual(1, cartes[373].LstMeca.Count);
            Assert.AreEqual(CarteMecanique.Combo, cartes[373].LstMeca[0]);
            Assert.AreEqual(-1, cartes[373].Attaque);
            Assert.AreEqual(-1, cartes[373].Vie);
            Assert.AreEqual(ServiteurRace.Aucune, cartes[373].Race);
            Assert.AreEqual(-1, cartes[373].Durabilite);

            // Test : Arme avec 2 mécaniques.
            Assert.AreEqual(CarteType.Weapon, cartes[31].Type);
            Assert.AreEqual("EX1_133", cartes[31].Id);
            Assert.AreEqual("Perdition's Blade", cartes[31].Nom);
            Assert.AreEqual(CarteExtension.Expert1, cartes[31].Extension);
            Assert.AreEqual(CarteRarete.Rare, cartes[31].Rarete);
            Assert.AreEqual(3, cartes[31].Cout);
            Assert.AreEqual("Battlecry: Deal 1 damage. Combo: Deal 2 instead.", cartes[31].Texte);
            Assert.AreEqual(HerosClasse.Rogue, cartes[31].Classe);
            Assert.AreEqual(2, cartes[31].LstMeca.Count);
            Assert.AreEqual(CarteMecanique.Battlecry, cartes[31].LstMeca[0]);
            Assert.AreEqual(CarteMecanique.Combo, cartes[31].LstMeca[1]);
            Assert.AreEqual(2, cartes[31].Attaque);
            Assert.AreEqual(-1, cartes[31].Vie);
            Assert.AreEqual(ServiteurRace.Aucune, cartes[31].Race);
            Assert.AreEqual(2, cartes[31].Durabilite);

            // Test : Un serviteur avec une race et pas de mécanique.
            Assert.AreEqual(CarteType.Minion, cartes[24].Type);
            Assert.AreEqual("GVG_018", cartes[24].Id);
            Assert.AreEqual("Mistress of Pain", cartes[24].Nom);
            Assert.AreEqual(CarteExtension.Gvg, cartes[24].Extension);
            Assert.AreEqual(CarteRarete.Rare, cartes[24].Rarete);
            Assert.AreEqual(2, cartes[24].Cout);
            Assert.AreEqual("Whenever this minion deals damage, restore that much Health to your hero.",
                cartes[24].Texte);
            Assert.AreEqual(HerosClasse.Warlock, cartes[24].Classe);
            Assert.AreEqual(0, cartes[24].LstMeca.Count);
            Assert.AreEqual(1, cartes[24].Attaque);
            Assert.AreEqual(4, cartes[24].Vie);
            Assert.AreEqual(ServiteurRace.Demon, cartes[24].Race);
            Assert.AreEqual(-1, cartes[24].Durabilite);
          
        }

        /// <summary>
        /// Tests unitaires pour la méthode "ChargerCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Le nom du fichier ne doit pas être nul.")]
        public void TestChargerCartesExceptionNomFichierNul()
        {
            Utilitaire.ChargerCartes(null);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "ChargerCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Le nom du fichier est invalide.")]
        public void TestChargerCartesExceptionNomFichierVide()
        {
            Utilitaire.ChargerCartes("   ");
        }

        /// <summary>
        /// Tests unitaires pour la méthode "ChargerCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Le chemin pour accéder au fichier est invalide.")]
        public void TestChargerCartesExceptionNomFichierInvalide()
        {
            Utilitaire.ChargerCartes("nom_invalide.xml");
        }

        /// <summary>
        /// Tests unitaires pour la méthode "ChargerCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(XmlException), "Le fichier n'est pas un fichier XML valide.")]
        public void TestChargerCartesExceptionXmlNonValide()
        {
            String nomFichierXmlInvalide = "xml_non_valide.xml";
            StreamWriter sw = new StreamWriter(nomFichierXmlInvalide, false);
            sw.WriteLine("Pas du XML.");
            sw.Close();
            Utilitaire.ChargerCartes(nomFichierXmlInvalide);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "ChargerCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Impossible d'ouvrir le fichier XML.")]
        public void TestChargerCartesExceptionDossierInvalide()
        {
           Utilitaire.ChargerCartes("dossier_invalide/cards-collectible.xml");
        }

        /// <summary>
        /// Tests unitaires pour la méthode "ChargerCartes".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Impossible d'ouvrir le fichier XML.")]
        public void TestChargerCartesExceptionCheminTropLong()
        {
            // Création d'un chemin trop long.
            String chemin = new string('x', 300) + ".xml";
            Utilitaire.ChargerCartes(chemin);
        }
        /*   
            // EnregisterDeck
            // ==============

            /// <summary>
            /// Tests unitaires pour la méthode "EnregisterDeck".
            /// </summary>
            [TestMethod]
            public void TestEnregisterDeck1()
            {
                Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                    HerosClasse.Warrior, 30);
                Deck deckWarrior = new Deck("Warriors forever", heroWarrior);

                Utilitaire.EnregisterDeck("warriors_forever.xml", deckWarrior);

                // ***NOTE*** : Pour vérifier le bon fonctionnement de l'enregistrement, consultez
                // le fichier "warriors_forever.xml" qui a été créé dans le dossier /bin/Debug/Decks"
                // du dossier du projet pour les tests.
                // De plus, exécutez le test de chargement qui lui est associé, soit "TestChargerDeck1".
            }
        
            /// <summary>
            /// Tests unitaires pour la méthode "EnregisterDeck".
            /// </summary>
            [TestMethod]
            public void TestEnregisterDeck2()
            {
                Heros heroWarrior = new Heros("HERO_01", "Garrosh Hellscream", CarteExtension.Core, CarteRarete.Free,
                    HerosClasse.Warrior, 30);
                Deck deckWarrior = new Deck("Warriors forever v2", heroWarrior);

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

                // Ajout de cartes dans le deck.
                deckWarrior.AjouterCartes(carteNonLegendaire1, 1);
                deckWarrior.AjouterCartes(carteNonLegendaire2, 2);
                deckWarrior.AjouterCartes(carteLegendaire1, 1);
                deckWarrior.AjouterCartes(carteLegendaire2, 1);

                Utilitaire.EnregisterDeck("warriors_forever_v2.xml", deckWarrior);

                // ***NOTE*** : Pour vérifier le bon fonctionnement de l'enregistrement, consultez
                // le fichier "warriors_forever_v2.xml" qui a été créé dans le dossier /bin/Debug/Decks"
                // du dossier du projet pour les tests.
                // De plus, exécutez le test de chargement qui lui est associé, soit "TestChargerDeck2".
            }

            // ChargerDeck
            // ===========

            /// <summary>
            /// Tests unitaires pour la méthode "ChargerDeck".
            /// </summary>
            [TestMethod]
            public void TestChargerDeck1()
            {
                // ***NOTE*** : Pour exécuter ce test, vous devez préalablement exécuter avec succès
                // le test d'enregistrement du deck qui lui est associé, soit "TestEnregisterDeck1".
                TestEnregisterDeck1();

                HearthstoneData hData = new HearthstoneData();

                Deck deckCharge = Utilitaire.ChargerDeck("warriors_forever.xml", hData);

                Assert.AreEqual("Warriors forever", deckCharge.Nom);
                Assert.AreSame(hData.RechercherHeroParId("HERO_01"), deckCharge.Heros);
                Assert.AreEqual(0, deckCharge.NbTotalCartes);
                Assert.AreEqual(0, deckCharge.ObtenirQtCarte(hData.RechercherCarteParId("LOE_061")));
            }

            /// <summary>
            /// Tests unitaires pour la méthode "ChargerDeck".
            /// </summary>
            [TestMethod]
            public void TestChargerDeck2()
            {
                // ***NOTE*** : Pour exécuter ce test, vous devez préalablement exécuter avec succès
                // le test d'enregistrement du deck qui lui est associé, soit "TestEnregisterDeck2".
                TestEnregisterDeck2();

                HearthstoneData hData = new HearthstoneData();

                Deck deckCharge = Utilitaire.ChargerDeck("warriors_forever_v2.xml", hData);

                Assert.AreEqual("Warriors forever v2", deckCharge.Nom);
                Assert.AreSame(hData.RechercherHeroParId("HERO_01"), deckCharge.Heros);
                Assert.AreEqual(5, deckCharge.NbTotalCartes);
                Assert.AreEqual(4, deckCharge.LstCartesAvecQt.Count);

                Assert.AreEqual(1, deckCharge.ObtenirQtCarte(hData.RechercherCarteParId("GVG_103")));
                Assert.AreEqual(2, deckCharge.ObtenirQtCarte(hData.RechercherCarteParId("GVG_054")));
                Assert.AreEqual(1, deckCharge.ObtenirQtCarte(hData.RechercherCarteParId("LOE_077")));
                Assert.AreEqual(1, deckCharge.ObtenirQtCarte(hData.RechercherCarteParId("GVG_056")));
                Assert.AreEqual(0, deckCharge.ObtenirQtCarte(hData.RechercherCarteParId("LOE_061")));
            }

            /// <summary>
            /// Tests unitaires pour la méthode "ChargerDeck".
            /// </summary>
            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException),
                "Les données de Hearthstone ne doivent pas être à nul.")]
            public void TestChargerDeckExceptionHearthstoneDataNul()
            {
                // ***NOTE*** : Pour exécuter ce test, vous devez préalablement exécuter avec succès
                // le test d'enregistrement du deck qui lui est associé, soit "TestEnregisterDeck1".

                // ReSharper disable once UnusedVariable
                Deck deckCharge = Utilitaire.ChargerDeck("warriors_forever.xml", null);
            }

            /// <summary>
            /// Tests unitaires pour la méthode "ChargerDeck".
            /// </summary>
            [TestMethod]
            [ExpectedException(typeof(Exception),
                "Le deck fait référence à un héro qui n'existe pas (identifiant invalide).")]
            public void TestChargerDeckExceptionIdHeroInvalide()
            {
                Heros heroImaginaire = new Heros("HERO_99", "Hyper Strong Prof", CarteExtension.Reward,
                    CarteRarete.Legendary, HerosClasse.Paladin, 100);
                Deck deck = new Deck("Mon héro imaginaire", heroImaginaire);

                String nomFichierDeck = "id_hero_invalide.xml";

                Utilitaire.EnregisterDeck(nomFichierDeck, deck);

                // ReSharper disable once UnusedVariable
                Deck deckCharge = Utilitaire.ChargerDeck(nomFichierDeck, new HearthstoneData());
            }

            /// <summary>
            /// Tests unitaires pour la méthode "ChargerDeck".
            /// </summary>
            [TestMethod]
            [ExpectedException(typeof(Exception),
                "Le deck fait référence à une carte qui n'existe pas (identifiant invalide).")]
            public void TestChargerDeckExceptionIdCarteInvalide()
            {
                Heros heroMage = new Heros("HERO_08", "Jaina Proudmoore", CarteExtension.Core, CarteRarete.Free,
                    HerosClasse.Mage, 30);
                Deck deck = new Deck("Mon deck avec ma carte imaginaire", heroMage);
                Carte carteImaginaire = new Carte(CarteType.Minion, "EXP_999", "The Ultimate Destroyer",
                    CarteExtension.Reward, CarteRarete.Legendary, 10, "Destroy all other minions", HerosClasse.Mage,
                    10, 10, ServiteurRace.Totem, -1);

                deck.AjouterCartes(carteImaginaire, 1);

                String nomFichierDeck = "id_carte_invalide.xml";

                Utilitaire.EnregisterDeck(nomFichierDeck, deck);

                // ReSharper disable once UnusedVariable
                Deck deckCharge = Utilitaire.ChargerDeck(nomFichierDeck, new HearthstoneData());
            } */

        #endregion
    }
}
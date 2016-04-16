#region MÉTADONNÉES

// Nom du fichier : TestsHearthstoneData.cs
// Auteur : Stéphane Lapointe (slapointe)
// Date de création : 2016-03-18
// Date de modification : 2016-03-29

#endregion

#region USING

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2_Solution_Classes;

#endregion

namespace TestsUnitaires
{
    /// <summary>
    /// Tests unitaires pour la classe "HearthstoneData".
    /// </summary>
    [TestClass]
    public class TestsHearthstoneData
    {
        #region MÉTHODES

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        public void TestConstructeurHearthstoneData()
        {
            HearthstoneData hData = new HearthstoneData();

            Assert.AreEqual(12, hData.LesHeros.Length);

            // Test : Premier héro.
            Assert.AreEqual("HERO_08", hData.LesHeros[0].Id);
            Assert.AreEqual("Jaina Proudmoore", hData.LesHeros[0].Nom);

            // Test : Dernier héro.
            Assert.AreEqual("HERO_05a", hData.LesHeros[hData.LesHeros.Length - 1].Id);
            Assert.AreEqual("Alleria Windrunner", hData.LesHeros[hData.LesHeros.Length - 1].Nom);

            Assert.AreEqual(743, hData.LesCartes.Length);


            // Test : Première carte.
            Assert.AreEqual(CarteType.Minion, hData.LesCartes[0].Type);
            Assert.AreEqual("LOE_061", hData.LesCartes[0].Id);
            Assert.AreEqual("Anubisath Sentinel", hData.LesCartes[0].Nom);

            // Test : Dernière carte.
            Assert.AreEqual(CarteType.Minion, hData.LesCartes[hData.LesCartes.Length - 1].Type);
            Assert.AreEqual("EX1_350", hData.LesCartes[hData.LesCartes.Length - 1].Id);
            Assert.AreEqual("Prophet Velen", hData.LesCartes[hData.LesCartes.Length - 1].Nom);

            // Test : Sort.
            Assert.AreEqual(CarteType.Spell, hData.LesCartes[373].Type);
            Assert.AreEqual("EX1_137", hData.LesCartes[373].Id);
            Assert.AreEqual("Headcrack", hData.LesCartes[373].Nom);

            // Test : Arme.
            Assert.AreEqual(CarteType.Weapon, hData.LesCartes[31].Type);
            Assert.AreEqual("EX1_133", hData.LesCartes[31].Id);
            Assert.AreEqual("Perdition's Blade", hData.LesCartes[31].Nom);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "RechercherHeroParId".
        /// </summary>
        [TestMethod]
        public void TestRechercherHeroParId()
        {
            HearthstoneData hData = new HearthstoneData();

            // Test : Premier héro.
            Assert.AreEqual(hData.LesHeros[0], hData.RechercherHeroParId(hData.LesHeros[0].Id));
            // Test : Dernier héro.
            Assert.AreEqual(hData.LesHeros[hData.LesHeros.Length - 1],
                hData.RechercherHeroParId(hData.LesHeros[hData.LesHeros.Length - 1].Id));
            // Test : Trim
            Assert.AreEqual(hData.LesHeros[5], hData.RechercherHeroParId(" " + hData.LesHeros[5].Id + "    "));
            
            // Test : Id inexistant.
            Assert.IsNull(hData.RechercherHeroParId("HERO_99"));
            Assert.IsNull(hData.RechercherHeroParId("   "));
            Assert.IsNull(hData.RechercherHeroParId(""));
            // Test : Id nul.
            Assert.IsNull(hData.RechercherHeroParId(null));
        }

        /// <summary>
        /// Tests unitaires pour la méthode "RechercherCarteParId".
        /// </summary>
        [TestMethod]
        public void TestRechercherCarteParId()
        {
            HearthstoneData hData = new HearthstoneData();

            // Test : Première carte.
            Assert.AreEqual(hData.LesCartes[0], hData.RechercherCarteParId(hData.LesCartes[0].Id));
            // Test : Dernière carte.
            Assert.AreEqual(hData.LesCartes[hData.LesCartes.Length - 1],
                hData.RechercherCarteParId(hData.LesCartes[hData.LesCartes.Length - 1].Id));
            // Test : Sort.
            Assert.AreEqual(hData.LesCartes[373], hData.RechercherCarteParId(hData.LesCartes[373].Id));
            // Test : Arme.
            Assert.AreEqual(hData.LesCartes[31], hData.RechercherCarteParId(hData.LesCartes[31].Id));
            // Test : Trim
            Assert.AreEqual(hData.LesCartes[31],
                hData.RechercherCarteParId("  " + hData.LesCartes[31].Id + " "));

            // Test : Id inexistant.
            Assert.IsNull(hData.RechercherCarteParId("ABC_123"));
            Assert.IsNull(hData.RechercherCarteParId(" "));
            Assert.IsNull(hData.RechercherCarteParId(""));
            // Test : Id nul.
            Assert.IsNull(hData.RechercherCarteParId(null));
        }

        /// <summary>
        /// Tests unitaires pour la méthode "RechercherCartes".
        /// </summary>
        [TestMethod]
        public void TestRechercherCartesAucunCritere()
        {
            HearthstoneData hData = new HearthstoneData();
            List<Carte> lstCartesTrouvees;

            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), null,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.IsNull(lstCartesTrouvees);

            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), "    ", new List<CarteExtension>(), (CarteRarete) (-1),
                -1, -1, "   ", (HerosClasse) (-1), new List<CarteMecanique>(),
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.IsNull(lstCartesTrouvees);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "RechercherCartes".
        /// </summary>
        [TestMethod]
        public void TestRechercherCartesUnSeulCritere()
        {
            HearthstoneData hData = new HearthstoneData();
            List<Carte> lstCartesTrouvees;

            // Par type :
            lstCartesTrouvees = hData.RechercherCartes(
                CarteType.Minion, null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), null,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(496, lstCartesTrouvees.Count);
            Assert.AreEqual("LOEA10_3", lstCartesTrouvees[0].Id);
            Assert.AreEqual("EX1_620", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Par nom partiel :
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), " mani ", null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), null,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(2, lstCartesTrouvees.Count);
            Assert.AreEqual("EX1_393", lstCartesTrouvees[0].Id);
            Assert.AreEqual("EX1_564", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Par extension :
            List<CarteExtension> lstExtensions = new List<CarteExtension>();
            lstExtensions.Add(CarteExtension.Naxx);
            lstExtensions.Add(CarteExtension.Gvg);
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, lstExtensions, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), null,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(153, lstCartesTrouvees.Count);
            Assert.AreEqual("GVG_093", lstCartesTrouvees[0].Id);
            Assert.AreEqual("FP1_020", lstCartesTrouvees[1].Id);
            Assert.AreEqual("GVG_121", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Par rareté :
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, CarteRarete.Rare,
                -1, -1, null, (HerosClasse) (-1), null,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(182, lstCartesTrouvees.Count);
            Assert.AreEqual("GVG_093", lstCartesTrouvees[0].Id);
            Assert.AreEqual("LOE_026", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Par coût minimal :
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                8, -1, null, (HerosClasse) (-1), null,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(44, lstCartesTrouvees.Count);
            Assert.AreEqual("NEW1_010", lstCartesTrouvees[0].Id);
            Assert.AreEqual("EX1_620", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Par coût maximal :
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, 5, null, (HerosClasse) (-1), null,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(601, lstCartesTrouvees.Count);
            Assert.AreEqual("CS2_041", lstCartesTrouvees[0].Id);
            Assert.AreEqual("GVG_014", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Par texte partiel :
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, "Rand add CA", (HerosClasse) (-1), null,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(5, lstCartesTrouvees.Count);
            Assert.AreEqual("FP1_011", lstCartesTrouvees[0].Id);
            Assert.AreEqual("AT_118", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, "  miniON  DRAW   card ", (HerosClasse) (-1), null,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(16, lstCartesTrouvees.Count);
            Assert.AreEqual("EX1_363", lstCartesTrouvees[0].Id);
            Assert.AreEqual("AT_072", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Par classe :
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, HerosClasse.Hunter, null,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(49, lstCartesTrouvees.Count);
            Assert.AreEqual("CS2_084", lstCartesTrouvees[0].Id);
            Assert.AreEqual("EX1_543", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Par mécaniques :
            List<CarteMecanique> lstMecaniques = new List<CarteMecanique>();

            // Une mécanique :
            lstMecaniques.Add(CarteMecanique.Deathrattle);
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), lstMecaniques,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(47, lstCartesTrouvees.Count);
            Assert.AreEqual("GVG_082", lstCartesTrouvees[0].Id);
            Assert.AreEqual("BRM_027", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Deux mécaniques :
            lstMecaniques.Add(CarteMecanique.Taunt);
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), lstMecaniques,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(6, lstCartesTrouvees.Count);
            Assert.AreEqual("FP1_024", lstCartesTrouvees[0].Id);
            Assert.AreEqual("EX1_383", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Trois mécaniques :
            lstMecaniques.Add(CarteMecanique.DivineShield);
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), lstMecaniques,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(1, lstCartesTrouvees.Count);
            Assert.AreEqual("EX1_383", lstCartesTrouvees[0].Id);

            // Par attaque minimale :
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), null,
                8, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(27, lstCartesTrouvees.Count);
            Assert.AreEqual("GVG_016", lstCartesTrouvees[0].Id);
            Assert.AreEqual("EX1_620", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Par attaque maximale :
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), null,
                -1, 2, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(198, lstCartesTrouvees.Count);
            Assert.AreEqual("LOEA10_3", lstCartesTrouvees[0].Id);
            Assert.AreEqual("LOE_089", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Par vie minimale :
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), null,
                -1, -1, 10, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(5, lstCartesTrouvees.Count);
            Assert.AreEqual("AT_125", lstCartesTrouvees[0].Id);
            Assert.AreEqual("NEW1_030", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Par vie maximale :
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), null,
                -1, -1, -1, 2, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(131, lstCartesTrouvees.Count);
            Assert.AreEqual("LOEA10_3", lstCartesTrouvees[0].Id);
            Assert.AreEqual("AT_063", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Par race :
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), null,
                -1, -1, -1, -1, ServiteurRace.Demon, -1, -1);

            Assert.AreEqual(21, lstCartesTrouvees.Count);
            Assert.AreEqual("CS2_059", lstCartesTrouvees[0].Id);
            Assert.AreEqual("GVG_021", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Par durabilité minimale :
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), null,
                -1, -1, -1, -1, (ServiteurRace) (-1), 4, -1);

            Assert.AreEqual(5, lstCartesTrouvees.Count);
            Assert.AreEqual("CS2_091", lstCartesTrouvees[0].Id);
            Assert.AreEqual("EX1_567", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Par durabilité maximale :
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), null,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, 3);

            Assert.AreEqual(18, lstCartesTrouvees.Count);
            Assert.AreEqual("LOE_118", lstCartesTrouvees[0].Id);
            Assert.AreEqual("EX1_411", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "RechercherCartes".
        /// </summary>
        [TestMethod]
        public void TestRechercherCartesPlusieursCritere()
        {
            HearthstoneData hData = new HearthstoneData();
            List<Carte> lstCartesTrouvees;

            // Test : Trop de critères; retourne une liste vide.
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, CarteRarete.Legendary,
                -1, -1, null, HerosClasse.Paladin, null,
                -1, -1, -1, -1, ServiteurRace.Beast, -1, -1);

            Assert.AreEqual(0, lstCartesTrouvees.Count);

            // Test :
            //  - Type = Minion
            //  - Nom partiel = "der"
            //  - Extensions = {Core, Loe, Naxx}
            //  - Rareté = Free
            //  - Classe = Neutre
            List<CarteExtension> lstExtensions = new List<CarteExtension>();
            lstExtensions.Add(CarteExtension.Loe);
            lstExtensions.Add(CarteExtension.Naxx);
            lstExtensions.Add(CarteExtension.Expert1);
            lstCartesTrouvees = hData.RechercherCartes(
                CarteType.Minion, "der", lstExtensions, CarteRarete.Common,
                -1, -1, null, HerosClasse.Neutre, null,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(5, lstCartesTrouvees.Count);
            Assert.AreEqual("FP1_028", lstCartesTrouvees[0].Id);
            Assert.AreEqual("NEW1_018", lstCartesTrouvees[1].Id);
            Assert.AreEqual("EX1_096", lstCartesTrouvees[2].Id);
            Assert.AreEqual("EX1_020", lstCartesTrouvees[3].Id);
            Assert.AreEqual("LOE_047", lstCartesTrouvees[4].Id);

            // Test :
            //  - Coût Min = 3
            //  - Coût Max = 6
            //  - Texte Partiel = "health restore HERO"
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                3, 6, "health restore HERO", (HerosClasse) (-1), null,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(10, lstCartesTrouvees.Count);
            Assert.AreEqual("CS2_061", lstCartesTrouvees[0].Id);
            Assert.AreEqual("CS2_097", lstCartesTrouvees[4].Id);
            Assert.AreEqual("EX1_309", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Test :
            //  - Mécanique = {Charge}
            //  - Attaque min = 2
            //  - Vie max = 5
            List<CarteMecanique> lstMecaniques = new List<CarteMecanique>();
            lstMecaniques.Add(CarteMecanique.Charge);
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), lstMecaniques,
                2, -1, -1, 5, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(11, lstCartesTrouvees.Count);
            Assert.AreEqual("CS2_173", lstCartesTrouvees[0].Id);
            Assert.AreEqual("NEW1_011", lstCartesTrouvees[4].Id);
            Assert.AreEqual("NEW1_010", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Test :
            //  - Mécanique = {Charge, DivineShield}
            //  - Attaque max = 3
            //  - Vie min = 3
            lstMecaniques.Clear();
            lstMecaniques.Add(CarteMecanique.Charge);
            lstMecaniques.Add(CarteMecanique.DivineShield);
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), lstMecaniques,
                -1, 3, 3, -1, (ServiteurRace) (-1), -1, -1);

            Assert.AreEqual(1, lstCartesTrouvees.Count);
            Assert.AreEqual("NEW1_010", lstCartesTrouvees[0].Id);

            // Test :
            //  - Vie min = 2
            //  - Vie max = 5
            //  - HerosClasse = Hunter
            //  - Race = Beast
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, HerosClasse.Hunter, null,
                -1, -1, 2, 5, ServiteurRace.Beast, -1, -1);

            Assert.AreEqual(9, lstCartesTrouvees.Count);
            Assert.AreEqual("AT_058", lstCartesTrouvees[0].Id);
            Assert.AreEqual("BRM_014", lstCartesTrouvees[4].Id);
            Assert.AreEqual("AT_063", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Test :
            //  - Attaque min = 2
            //  - Attaque max = 2
            //  - Durabilité min = 3
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, (CarteRarete) (-1),
                -1, -1, null, (HerosClasse) (-1), null,
                2, 2, -1, -1, (ServiteurRace) (-1), 3, -1);

            Assert.AreEqual(5, lstCartesTrouvees.Count);
            Assert.AreEqual("LOE_118", lstCartesTrouvees[0].Id);
            Assert.AreEqual("GVG_059", lstCartesTrouvees[2].Id);
            Assert.AreEqual("EX1_567", lstCartesTrouvees[lstCartesTrouvees.Count - 1].Id);

            // Test :
            //  - Type = Weapon
            //  - Nom partiel = "Hammer"
            //  - Coût min = 3
            //  - Durabilité max = 4
            lstCartesTrouvees = hData.RechercherCartes(
                CarteType.Weapon, " Hammer", null, (CarteRarete) (-1),
                3, -1, null, (HerosClasse) (-1), null,
                -1, -1, -1, -1, (ServiteurRace) (-1), -1, 4);

            Assert.AreEqual(2, lstCartesTrouvees.Count);
            Assert.AreEqual("GVG_059", lstCartesTrouvees[0].Id);
            Assert.AreEqual("AT_050", lstCartesTrouvees[1].Id);

            // Test :
            //  - Rareté = Common
            //  - Coût max = 3
            //  - Durabilité min = 2
            //  - Durabilité max = 3

            // GABARIT
            lstCartesTrouvees = hData.RechercherCartes(
                (CarteType) (-1), null, null, CarteRarete.Common,
                -1, 3, null, (HerosClasse) (-1), null,
                -1, -1, -1, -1, (ServiteurRace) (-1), 2, 3);

            Assert.AreEqual(3, lstCartesTrouvees.Count);
            Assert.AreEqual("GVG_043", lstCartesTrouvees[0].Id);
            Assert.AreEqual("EX1_247", lstCartesTrouvees[1].Id);
            Assert.AreEqual("GVG_054", lstCartesTrouvees[2].Id);
        }

        #endregion

        // TODO : liste vide.
    }
}
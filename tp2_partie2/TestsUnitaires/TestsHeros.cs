#region MÉTADONNÉES

// Nom du fichier : TestsHeros.cs
// Auteur : Stéphane Lapointe (slapointe)
// Date de création : 2016-03-01
// Date de modification : 2016-03-24

#endregion

#region USING

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tp2_partie1;

#endregion

namespace TestsUnitaires
{
    /// <summary>
    /// Tests unitaires pour la classe "Heros".
    /// </summary>
    [TestClass]
    public class TestsHeros
    {
        #region MÉTHODES

        /// <summary>
        /// Tests unitaires pour les constantes.
        /// </summary>
        [TestMethod]
        public void TestConstantesCarte()
        {
            Assert.AreEqual(10, Heros.VieMin);
            Assert.AreEqual(100, Heros.VieMax);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        public void TestConstructeurHero()
        {
            // Tests :
            //     - "Trim" pour l'identifiant et le nom.
            //     - Cas limite (max.) pour les points de vie.
            Heros heros = new Heros("  HERO_99z ", "  Super Stef   ", CarteExtension.Expert1, CarteRarete.Legendary,
                HerosClasse.Warlock, 100);

            Assert.AreEqual("HERO_99z", heros.Id);
            Assert.AreEqual("Super Stef", heros.Nom);
            Assert.AreEqual(CarteExtension.Expert1, heros.Extension);
            Assert.AreEqual(CarteRarete.Legendary, heros.Rarete);
            Assert.AreEqual(HerosClasse.Warlock, heros.Classe);
            Assert.AreEqual(100, heros.Vie);

            // Tests :
            //     - Cas limite pour le nom (min. 3 caractères).
            //     - Cas limite (min.) pour les points de vie.
            heros = new Heros("HERO_01", "PKP", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Priest, 10);
            Assert.AreEqual("HERO_01", heros.Id);
            Assert.AreEqual("PKP", heros.Nom);
            Assert.AreEqual(CarteExtension.Core, heros.Extension);
            Assert.AreEqual(CarteRarete.Free, heros.Rarete);
            Assert.AreEqual(HerosClasse.Priest, heros.Classe);
            Assert.AreEqual(10, heros.Vie);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "L'identifiant du héro ne doit pas être nul.")]
        public void TestConstructeurHeroExceptionIdNul()
        {
            // ReSharper disable once UnusedVariable
            Heros heros = new Heros(null, "Jaina Proudmoore", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Mage, 30);
        }

        /// <summary>
        /// Tests unitaires pour le "Constructeur".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "L'identifiant du héro est invalide.")]
        public void TestConstructeurHeroExceptionIdInvalide1()
        {
            // ReSharper disable once UnusedVariable
            Heros heros = new Heros("MON_HERO_99", "Jaina Proudmoore", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Mage, 30);
        }

        /// <summary>
        /// Tests unitaires pour le "Constructeur".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "L'identifiant du héro est invalide.")]
        public void TestConstructeurHeroExceptionIdInvalide2()
        {
            // ReSharper disable once UnusedVariable
            Heros heros = new Heros("HERO_999", "Jaina Proudmoore", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Mage, 30);
        }

        /// <summary>
        /// Tests unitaires pour le "Constructeur".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "L'identifiant du héro est invalide.")]
        public void TestConstructeurHeroExceptionIdInvalide3()
        {
            // ReSharper disable once UnusedVariable
            Heros heros = new Heros("HERO_9w", "Jaina Proudmoore", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Mage, 30);
        }

        /// <summary>
        /// Tests unitaires pour le "Constructeur".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "L'identifiant du héro est invalide.")]
        public void TestConstructeurHeroExceptionIdInvalide4()
        {
            // ReSharper disable once UnusedVariable
            Heros heros = new Heros("HERO_00Z", "Jaina Proudmoore", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Mage, 30);
        }

        /// <summary>
        /// Tests unitaires pour le "Constructeur".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "L'identifiant du héro est invalide.")]
        public void TestConstructeurHeroExceptionIdInvalide5()
        {
            // ReSharper disable once UnusedVariable
            Heros heros = new Heros("HERO_12ab", "Jaina Proudmoore", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Mage, 30);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Le nom du héro ne doit pas être nul.")]
        public void TestConstructeurHeroExceptionNomNul()
        {
            // ReSharper disable once UnusedVariable
            Heros heros = new Heros("HERO_08", null, CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Mage, 30);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Le nom du héro doit contenir un minimum de 3 caractères.")]
        public void TestConstructeurHeroExceptionNomInvalide()
        {
            // ReSharper disable once UnusedVariable
            Heros heros = new Heros("HERO_08", "  XY   ", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Mage, 30);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Un héro ne peut pas avoir la classe neutre")]
        public void TestConstructeurHeroExceptionClasseInvalide()
        {
            // ReSharper disable once UnusedVariable
            Heros heros = new Heros("HERO_08", "Jaina Proudmoore", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Neutre, 30);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Les points de vie du héro doivent être entre 10 et 100 inclusivement.")]
        public void TestConstructeurHeroExceptionVieInvalide1()
        {
            // ReSharper disable once UnusedVariable
            // Test : Vie = 9 ==> Trop petit.
            Heros heros = new Heros("HERO_08", "Jaina Proudmoore", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Mage, 9);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Les points de vie du héro doivent être entre 10 et 100 inclusivement.")]
        public void TestConstructeurHeroExceptionVieInvalide2()
        {
            // ReSharper disable once UnusedVariable
            // Test : Vie = 101 ==> Trop grand.
            Heros heros = new Heros("HERO_08", "Jaina Proudmoore", CarteExtension.Core, CarteRarete.Free,
                HerosClasse.Mage, 101);
        }

        #endregion
    }
}
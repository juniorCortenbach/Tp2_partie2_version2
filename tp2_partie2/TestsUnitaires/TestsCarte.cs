#region MÉTADONNÉES

// Nom du fichier : TestsCarte.cs
// Auteur : Stéphane Lapointe (slapointe)
// Date de création : 2016-03-01
// Date de modification : 2016-03-29

#endregion

#region USING

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tp2_partie1;

#endregion

namespace TestsCarte
{
    /// <summary>
    /// Tests unitaires pour la classe "Carte".
    /// </summary>
    [TestClass]
    public class TestsCarte
    {
        #region MÉTHODES

        /// <summary>
        /// Tests unitaires pour les constantes.
        /// </summary>
        [TestMethod]
        public void TestConstantesCarte()
        {
            Assert.AreEqual(20, Carte.CoutMax);
            Assert.AreEqual(12, Carte.AttaqueMax);
            Assert.AreEqual(15, Carte.VieMax);
            Assert.AreEqual(8, Carte.DurabiliteMax);
        }
        

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        public void TestConstructeurCarte()
        {
            // Test Minion :
            // ===========
            //     - "Trim" pour l'identifiant, le nom et le texte.
            //     - Cas limite pour l'identifiant (le moins possible de caractères).
            //     - Cas limites (max.) pour le coût (20), les points d'attaque (12) et les points de vie (15).
            //     - Cas limite pour la liste des mécaniques (vide).
            //     - Cas limite (valeur bidon) pour durabilité (-1).
            Carte carte = new Carte(CarteType.Minion, "  A0_9 ", " nom_carte   ", CarteExtension.Core,
                CarteRarete.Free, 20, "     texte_carte ", HerosClasse.Neutre, 12, 15, ServiteurRace.Aucune, -1);

            Assert.AreEqual(CarteType.Minion, carte.Type);
            Assert.AreEqual("A0_9", carte.Id);
            Assert.AreEqual("nom_carte", carte.Nom);
            Assert.AreEqual(CarteExtension.Core, carte.Extension);
            Assert.AreEqual(CarteRarete.Free, carte.Rarete);
            Assert.AreEqual(20, carte.Cout);
            Assert.AreEqual("texte_carte", carte.Texte);
            Assert.AreEqual(HerosClasse.Neutre, carte.Classe);
            Assert.AreEqual(0, carte.LstMeca.Count);
            Assert.AreEqual(12, carte.Attaque);
            Assert.AreEqual(15, carte.Vie);
            Assert.AreEqual(ServiteurRace.Aucune, carte.Race);
            Assert.AreEqual(-1, carte.Durabilite);

            // Test Minion :
            // ===========
            //     - Cas limite pour l'identifiant (le plus possible de caractères).
            //     - Cas limite pour le nom (min. 3 caractères).
            //     - Cas limite pour le texte (null).
            //     - Cas limites (min.) pour le coût (0), les points d'attaque (0) et les points de vie (1).
            carte = new Carte(CarteType.Minion, "aB0yZ9_950a", "Spy", CarteExtension.Gvg, CarteRarete.Legendary,
                0, null, HerosClasse.Shaman, 0, 1, ServiteurRace.Beast, -1);

            Assert.AreEqual(CarteType.Minion, carte.Type);
            Assert.AreEqual("aB0yZ9_950a", carte.Id);
            Assert.AreEqual("Spy", carte.Nom);
            Assert.AreEqual(CarteExtension.Gvg, carte.Extension);
            Assert.AreEqual(CarteRarete.Legendary, carte.Rarete);
            Assert.AreEqual(0, carte.Cout);
            Assert.AreEqual(null, carte.Texte);
            Assert.AreEqual(HerosClasse.Shaman, carte.Classe);
            Assert.AreEqual(0, carte.LstMeca.Count);
            Assert.AreEqual(0, carte.Attaque);
            Assert.AreEqual(1, carte.Vie);
            Assert.AreEqual(ServiteurRace.Beast, carte.Race);
            Assert.AreEqual(-1, carte.Durabilite);

            // Test Spell :
            // ==========
            //     - Cas limites (valeurs bidons) pour les points d'attaque (-1) et les points de vie (-1).
            carte = new Carte(CarteType.Spell, "bof_12", "Eye for an Eye", CarteExtension.Expert1, CarteRarete.Common,
                1, "Secret: When your hero takes damage, deal that much damage to the enemy hero.",
                HerosClasse.Paladin, -1, -1, ServiteurRace.Aucune, -1);

            Assert.AreEqual(CarteType.Spell, carte.Type);
            Assert.AreEqual("bof_12", carte.Id);
            Assert.AreEqual("Eye for an Eye", carte.Nom);
            Assert.AreEqual(CarteExtension.Expert1, carte.Extension);
            Assert.AreEqual(CarteRarete.Common, carte.Rarete);
            Assert.AreEqual(1, carte.Cout);
            Assert.AreEqual("Secret: When your hero takes damage, deal that much damage to the enemy hero.", carte.Texte);
            Assert.AreEqual(HerosClasse.Paladin, carte.Classe);
            Assert.AreEqual(0, carte.LstMeca.Count);
            Assert.AreEqual(-1, carte.Attaque);
            Assert.AreEqual(-1, carte.Vie);
            Assert.AreEqual(ServiteurRace.Aucune, carte.Race);
            Assert.AreEqual(-1, carte.Durabilite);

            // Test Weapon :
            // ===========
            //     - Cas limite pour le texte (chaîne vide).
            //     - Cas limite (max.) pour la durabilité (8).
            carte = new Carte(CarteType.Weapon, "00000_0a", "Doomhammer", CarteExtension.Expert1, CarteRarete.Epic,
                5, "", HerosClasse.Shaman, 2, -1, ServiteurRace.Aucune, 8);

            Assert.AreEqual(CarteType.Weapon, carte.Type);
            Assert.AreEqual("00000_0a", carte.Id);
            Assert.AreEqual("Doomhammer", carte.Nom);
            Assert.AreEqual(CarteExtension.Expert1, carte.Extension);
            Assert.AreEqual(CarteRarete.Epic, carte.Rarete);
            Assert.AreEqual(5, carte.Cout);
            Assert.AreEqual("", carte.Texte);
            Assert.AreEqual(HerosClasse.Shaman, carte.Classe);
            Assert.AreEqual(0, carte.LstMeca.Count);
            Assert.AreEqual(2, carte.Attaque);
            Assert.AreEqual(-1, carte.Vie);
            Assert.AreEqual(ServiteurRace.Aucune, carte.Race);
            Assert.AreEqual(8, carte.Durabilite);

            // Test Weapon :
            // ===========
            //     - Cas limite pour le texte ("Trim" qui donne chaîne vide).
            //     - Cas limite (min.) pour la durabilité (1).
            carte = new Carte(CarteType.Weapon, "aa_999q", "Doomhammer", CarteExtension.Expert1, CarteRarete.Epic,
                5, "   ", HerosClasse.Shaman, 2, -1, ServiteurRace.Aucune, 1);

            Assert.AreEqual("aa_999q", carte.Id);
            Assert.AreEqual("", carte.Texte);
            Assert.AreEqual(1, carte.Durabilite);
        }

        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "L'identifiant de la carte ne doit pas être nul.")]
        public void TestConstructeurCarteExceptionIdNul()
        {
            // ReSharper disable once UnusedVariable
            Carte carte = new Carte(CarteType.Minion, null, "nom_carte", CarteExtension.Core, CarteRarete.Free,
                3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);
        }
       
        /// <summary>
        /// Tests unitaires pour le constructeur.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "L'identifiant de la carte est invalide.")]
        public void TestConstructeurCarteExceptionIdInvalide1()
        {
            // ReSharper disable once UnusedVariable
            Carte carte = new Carte(CarteType.Minion, "A_12", "nom_carte", CarteExtension.Core, CarteRarete.Free,
                3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);
        }
     
       /// <summary>
       /// Tests unitaires pour le constructeur.
       /// </summary>
       [TestMethod]
       [ExpectedException(typeof(ArgumentException), "L'identifiant de la carte est invalide.")]
       public void TestConstructeurCarteExceptionIdInvalide2()
       {
           // ReSharper disable once UnusedVariable
           Carte carte = new Carte(CarteType.Minion, "abcdefg_12", "nom_carte", CarteExtension.Core, CarteRarete.Free,
               3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);
       }

       /// <summary>
       /// Tests unitaires pour le constructeur.
       /// </summary>
       [TestMethod]
       [ExpectedException(typeof(ArgumentException), "L'identifiant de la carte est invalide.")]
       public void TestConstructeurCarteExceptionIdInvalide3()
       {
           // ReSharper disable once UnusedVariable
           Carte carte = new Carte(CarteType.Minion, "ab+cd_12", "nom_carte", CarteExtension.Core, CarteRarete.Free,
               3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);
       }

       /// <summary>
       /// Tests unitaires pour le constructeur.
       /// </summary>
       [TestMethod]
       [ExpectedException(typeof(ArgumentException), "L'identifiant de la carte est invalide.")]
       public void TestConstructeurCarteExceptionIdInvalide4()
       {
           // ReSharper disable once UnusedVariable
           Carte carte = new Carte(CarteType.Minion, "abcd12", "nom_carte", CarteExtension.Core, CarteRarete.Free,
               3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);
       }
       
    /// <summary>
    /// Tests unitaires pour le constructeur.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "L'identifiant de la carte est invalide.")]
    public void TestConstructeurCarteExceptionIdInvalide5()
    {
        // ReSharper disable once UnusedVariable
        Carte carte = new Carte(CarteType.Minion, "abcd_", "nom_carte", CarteExtension.Core, CarteRarete.Free,
            3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);
    }

    /// <summary>
    /// Tests unitaires pour le constructeur.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "L'identifiant de la carte est invalide.")]
    public void TestConstructeurCarteExceptionIdInvalide6()
    {
        // ReSharper disable once UnusedVariable
        Carte carte = new Carte(CarteType.Minion, "abcd_1234", "nom_carte", CarteExtension.Core, CarteRarete.Free,
            3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);
    }

    /// <summary>
    /// Tests unitaires pour le constructeur.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "L'identifiant de la carte est invalide.")]
    public void TestConstructeurCarteExceptionIdInvalide7()
    {
        // ReSharper disable once UnusedVariable
        Carte carte = new Carte(CarteType.Minion, "abcd_12X", "nom_carte", CarteExtension.Core, CarteRarete.Free,
            3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);
    }

    /// <summary>
    /// Tests unitaires pour le constructeur.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "L'identifiant de la carte est invalide.")]
    public void TestConstructeurCarteExceptionIdInvalide8()
    {
        // ReSharper disable once UnusedVariable
        Carte carte = new Carte(CarteType.Minion, "abcd_12ab", "nom_carte", CarteExtension.Core, CarteRarete.Free,
            3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);
    }

    /// <summary>
    /// Tests unitaires pour le constructeur.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException), "Le nom de la carte ne doit pas être nul.")]
    public void TestConstructeurCarteExceptionNomNul()
    {
        // ReSharper disable once UnusedVariable
        Carte carte = new Carte(CarteType.Minion, "LOE_001", null, CarteExtension.Core, CarteRarete.Free,
            3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);
    }

    /// <summary>
    /// Tests unitaires pour le constructeur.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "Le nom de la carte doit contenir un minimum de 3 caractères.")]
    public void TestConstructeurCarteExceptionNomInvalide()
    {
        // ReSharper disable once UnusedVariable
        Carte carte = new Carte(CarteType.Minion, "LOE_001", "  Jo ", CarteExtension.Core, CarteRarete.Free,
            3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);
    }

    /// <summary>
    /// Tests unitaires pour le constructeur.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException),
        "Le coût de la carte doit être entre 0 et 20 inclusivement.")]
    public void TestConstructeurCarteExceptionCoutInvalide()
    {
        // ReSharper disable once UnusedVariable
        // Test : Coût = 21 ==> Trop grand.
        Carte carte = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Core, CarteRarete.Free,
            21, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);
    }

    /// <summary>
    /// Tests unitaires pour le constructeur.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException),
        "Les points d'attaque doivent être compris entre 0 et 12 inclusivement pour une carte qui est de type serviteur ou arme."
        )]
    public void TestConstructeurCarteExceptionAttaqueInvalide1()
    {
        // ReSharper disable once UnusedVariable
        // Test : Attaque = -1 (serviteur) ==> Trop petit.
        Carte carte = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Core, CarteRarete.Free,
            3, "texte_carte", HerosClasse.Neutre, -1, 3, ServiteurRace.Aucune, -1);
    }
       
   /// <summary>
   /// Tests unitaires pour le constructeur.
   /// </summary>
   [TestMethod]
   [ExpectedException(typeof(ArgumentOutOfRangeException),
       "Les points d'attaque doivent être compris entre 0 et 12 inclusivement pour une carte qui est de type serviteur ou arme."
       )]
   public void TestConstructeurCarteExceptionAttaqueInvalide2()
   {
       // ReSharper disable once UnusedVariable
       // Test : Attaque = 13 (serviteur) ==> Trop grand.
       Carte carte = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Core, CarteRarete.Free,
           3, "texte_carte", HerosClasse.Neutre, 13, 3, ServiteurRace.Aucune, -1);
   }

   /// <summary>
   /// Tests unitaires pour le constructeur.
   /// </summary>
   [TestMethod]
   [ExpectedException(typeof(ArgumentOutOfRangeException),
       "Les points d'attaque doivent être compris entre 0 et 12 inclusivement pour une carte qui est de type serviteur ou arme."
       )]
   public void TestConstructeurCarteExceptionAttaqueInvalide3()
   {
       // ReSharper disable once UnusedVariable
       // Test : Attaque = -1 (arme) ==> Trop petit.
       Carte carte = new Carte(CarteType.Weapon, "GVG_059", "Coghammer", CarteExtension.Gvg, CarteRarete.Epic,
           3, "Battlecry: Give a random friendly minion Divine Shield and Taunt.",
           HerosClasse.Paladin, -1, -1, ServiteurRace.Aucune, 3);
   }

   /// <summary>
   /// Tests unitaires pour le constructeur.
   /// </summary>
   [TestMethod]
   [ExpectedException(typeof(ArgumentOutOfRangeException),
       "Les points d'attaque doivent être compris entre 0 et 12 inclusivement pour une carte qui est de type serviteur ou arme."
       )]
   public void TestConstructeurCarteExceptionAttaqueInvalide4()
   {
       // ReSharper disable once UnusedVariable
       // Test : Attaque = 13 (arme) ==> Trop grand.
       Carte carte = new Carte(CarteType.Weapon, "GVG_059", "Coghammer", CarteExtension.Gvg, CarteRarete.Epic,
           3, "Battlecry: Give a random friendly minion Divine Shield and Taunt.",
           HerosClasse.Paladin, 13, -1, ServiteurRace.Aucune, 3);
   }

   /// <summary>
   /// Tests unitaires pour le constructeur.
   /// </summary>
   [TestMethod]
   [ExpectedException(typeof(ArgumentOutOfRangeException),
       "Les points d'attaque doivent être à -1 pour une carte qui n'est pas de type serviteur ou arme."
       )]
   public void TestConstructeurCarteExceptionAttaqueInvalide5()
   {
       // ReSharper disable once UnusedVariable
       // Test : Attaque = 2 (sort) ==> Interdit.
       Carte carte = new Carte(CarteType.Spell, "EX1_132", "Eye for an Eye", CarteExtension.Expert1,
           CarteRarete.Common, 1,
           "Secret: When your hero takes damage, deal that much damage to the enemy hero.",
           HerosClasse.Paladin, 2, -1, ServiteurRace.Aucune, -1);
   }

   /// <summary>
   /// Tests unitaires pour le constructeur.
   /// </summary>
   [TestMethod]
   [ExpectedException(typeof(ArgumentOutOfRangeException),
       "Les points de vie doivent être compris entre 1 et 15 inclusivement pour une carte qui est de type serviteur."
       )]
   public void TestConstructeurCarteExceptionVieInvalide1()
   {
       // ReSharper disable once UnusedVariable
       // Test : Vie = 0 (serviteur) ==> Interdit.
       Carte carte = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Core,
           CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 0, ServiteurRace.Aucune, -1);
   }
       
  /// <summary>
  /// Tests unitaires pour le constructeur.
  /// </summary>
  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException),
      "Les points de vie doivent être compris entre 1 et 15 inclusivement pour une carte qui est de type serviteur."
      )]
  public void TestConstructeurCarteExceptionVieInvalide2()
  {
      // ReSharper disable once UnusedVariable
      // Test : Vie = -1 (serviteur) ==> Interdit.
      Carte carte = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Core,
          CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, -1, ServiteurRace.Aucune, -1);
  }

  /// <summary>
  /// Tests unitaires pour le constructeur.
  /// </summary>
  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException),
      "Les points de vie doivent être compris entre 1 et 15 inclusivement pour une carte qui est de type serviteur."
      )]
  public void TestConstructeurCarteExceptionVieInvalide3()
  {
      // ReSharper disable once UnusedVariable
      // Test : Vie = -2 (serviteur) ==> Trop petit.
      Carte carte = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Core,
          CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, -2, ServiteurRace.Aucune, -1);
  }

  /// <summary>
  /// Tests unitaires pour le constructeur.
  /// </summary>
  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException),
      "Les points de vie doivent être compris entre 1 et 15 inclusivement pour une carte qui est de type serviteur."
      )]
  public void TestConstructeurCarteExceptionVieInvalide4()
  {
      // ReSharper disable once UnusedVariable
      // Test : Vie = 16 (serviteur) ==> Trop grand.
      Carte carte = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Core,
          CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 16, ServiteurRace.Aucune, -1);
  }

  /// <summary>
  /// Tests unitaires pour le constructeur.
  /// </summary>
  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException),
      "Les points de vie doivent être à -1 pour une carte qui n'est pas de type serviteur.")]
  public void TestConstructeurCarteExceptionVieInvalide5()
  {
      // ReSharper disable once UnusedVariable
      // Test : Vie != -1 (sort) ==> Interdit.
      Carte carte = new Carte(CarteType.Spell, "EX1_132", "Eye for an Eye", CarteExtension.Expert1,
          CarteRarete.Common, 1,
          "Secret: When your hero takes damage, deal that much damage to the enemy hero.",
          HerosClasse.Paladin, -1, 5, ServiteurRace.Aucune, -1);
  }

  /// <summary>
  /// Tests unitaires pour le constructeur.
  /// </summary>
  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException),
      "Les points de vie doivent être à -1 pour une carte qui n'est pas de type serviteur.")]
  public void TestConstructeurCarteExceptionVieInvalide6()
  {
      // ReSharper disable once UnusedVariable
      // Test : Vie != -1 (arme) ==> Interdit.
      Carte carte = new Carte(CarteType.Weapon, "GVG_059", "Coghammer", CarteExtension.Gvg, CarteRarete.Epic,
          3, "Battlecry: Give a random friendly minion Divine Shield and Taunt.",
          HerosClasse.Paladin, 3, 2, ServiteurRace.Aucune, 3);
  }


  /// <summary>
  /// Tests unitaires pour le constructeur.
  /// </summary>
  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException),
      "Les points de durabilité doivent être compris entre 1 et 8 inclusivement pour une carte qui est de type arme."
      )]
  public void TestConstructeurCarteExceptionDurabiliteInvalide1()
  {
      // ReSharper disable once UnusedVariable
      // Test : Durabilité = 0 (arme) ==> Interdit.
      Carte carte = new Carte(CarteType.Weapon, "GVG_059", "Coghammer", CarteExtension.Gvg,
          CarteRarete.Epic, 3, "Battlecry: Give a random friendly minion Divine Shield and Taunt.",
          HerosClasse.Paladin, 3, -1, ServiteurRace.Aucune, 0);
  }

  /// <summary>
  /// Tests unitaires pour le constructeur.
  /// </summary>
  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException),
      "Les points de durabilité doivent être compris entre 1 et 8 inclusivement pour une carte qui est de type arme."
      )]
  public void TestConstructeurCarteExceptionDurabiliteInvalide2()
  {
      // ReSharper disable once UnusedVariable
      // Test : Durabilité = -1 (arme) ==> Interdit.
      Carte carte = new Carte(CarteType.Weapon, "GVG_059", "Coghammer", CarteExtension.Gvg,
          CarteRarete.Epic, 3, "Battlecry: Give a random friendly minion Divine Shield and Taunt.",
          HerosClasse.Paladin, 3, -1, ServiteurRace.Aucune, -1);
  }

  /// <summary>
  /// Tests unitaires pour le constructeur.
  /// </summary>
  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException),
      "Les points de durabilité doivent être compris entre 1 et 8 inclusivement pour une carte qui est de type arme."
      )]
  public void TestConstructeurCarteExceptionDurabiliteInvalide3()
  {
      // ReSharper disable once UnusedVariable
      // Test : Durabilité = -2 (arme) ==> Trop petit.
      Carte carte = new Carte(CarteType.Weapon, "GVG_059", "Coghammer", CarteExtension.Gvg,
          CarteRarete.Epic, 3, "Battlecry: Give a random friendly minion Divine Shield and Taunt.",
          HerosClasse.Paladin, 3, -1, ServiteurRace.Aucune, -2);
  }

  /// <summary>
  /// Tests unitaires pour le constructeur.
  /// </summary>
  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException),
      "Les points de durabilité doivent être compris entre 1 et 8 inclusivement pour une carte qui est de type arme."
      )]
  public void TestConstructeurCarteExceptionDurabiliteInvalide4()
  {
      // ReSharper disable once UnusedVariable
      // Test : Durabilité = 9 (arme) ==> Trop grand.
      Carte carte = new Carte(CarteType.Weapon, "GVG_059", "Coghammer", CarteExtension.Gvg,
          CarteRarete.Epic, 3, "Battlecry: Give a random friendly minion Divine Shield and Taunt.",
          HerosClasse.Paladin, 3, -1, ServiteurRace.Aucune, 9);
  }

  /// <summary>
  /// Tests unitaires pour le constructeur.
  /// </summary>
  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException),
      "Les points de durabilité doivent être à -1 pour une carte qui n'est pas de type arme.")]
  public void TestConstructeurCarteExceptionDurabiliteInvalide5()
  {
      // ReSharper disable once UnusedVariable
      // Test : Durabilité != -1 (serviteur) ==> Interdit.
      Carte carte = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Core,
          CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, 5);
  }

  /// <summary>
  /// Tests unitaires pour le constructeur.
  /// </summary>
  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException),
      "Les points de durabilité doivent être à -1 pour une carte qui n'est pas de type arme.")]
  public void TestConstructeurCarteExceptionDurabiliteInvalide6()
  {
      // ReSharper disable once UnusedVariable
      // Test : Durabilité != -1 (sort) ==> Interdit.
      Carte carte = new Carte(CarteType.Spell, "EX1_132", "Eye for an Eye", CarteExtension.Expert1,
          CarteRarete.Common, 1,
          "Secret: When your hero takes damage, deal that much damage to the enemy hero.",
          HerosClasse.Paladin, -1, -1, ServiteurRace.Aucune, 3);
  }
       
 /// <summary>
 /// Tests unitaires pour le constructeur.
 /// </summary>
 [TestMethod]
 [ExpectedException(typeof(ArgumentException),
     "Une carte qui n'est pas de type serviteur ne doit avoir aucune race.")]
 public void TestConstructeurCarteExceptionRaceInvalide1()
 {
     // ReSharper disable once UnusedVariable
     // Test : Race != Neutre (sort) ==> Interdit.
     Carte carte = new Carte(CarteType.Spell, "EX1_132", "Eye for an Eye", CarteExtension.Expert1,
         CarteRarete.Common, 1,
         "Secret: When your hero takes damage, deal that much damage to the enemy hero.",
         HerosClasse.Paladin, -1, -1, ServiteurRace.Demon, -1);
 }

 /// <summary>
 /// Tests unitaires pour le constructeur.
 /// </summary>
 [TestMethod]
 [ExpectedException(typeof(ArgumentException),
     "Une carte qui n'est pas de type serviteur ne doit avoir aucune race.")]
 public void TestConstructeurCarteExceptionRaceInvalide2()
 {
     // ReSharper disable once UnusedVariable
     // Test : Race != Neutre (arme) ==> Interdit.
     Carte carte = new Carte(CarteType.Weapon, "GVG_059", "Coghammer", CarteExtension.Gvg,
         CarteRarete.Epic, 3, "Battlecry: Give a random friendly minion Divine Shield and Taunt.",
         HerosClasse.Paladin, 3, -1, ServiteurRace.Totem, 3);
 }

 /// <summary>
 /// Tests unitaires pour la méthode "AjouterMecanique".
 /// </summary>
 [TestMethod]
 public void TestAjouterMecanique()
 {
     Carte carte = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Core,
         CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

     carte.AjouterMecanique(CarteMecanique.Battlecry);
     carte.AjouterMecanique(CarteMecanique.DivineShield);
     carte.AjouterMecanique(CarteMecanique.Taunt);

     Assert.IsTrue(carte.LstMeca.Contains(CarteMecanique.Battlecry));
     Assert.IsTrue(carte.LstMeca.Contains(CarteMecanique.DivineShield));
     Assert.IsTrue(carte.LstMeca.Contains(CarteMecanique.Taunt));

     Assert.IsFalse(carte.LstMeca.Contains(CarteMecanique.AdjacentBuff));
 }

 /// <summary>
 /// Tests unitaires pour la méthode "AjouterMecanique".
 /// </summary>
 [TestMethod]
 [ExpectedException(typeof(InvalidOperationException),
     "Impossible d'ajouter une mécanique déjà présente.")]
 public void TestAjouterMecaniqueExceptionMecaDejaPresente()
 {
     Carte carte = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Core,
         CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

     carte.AjouterMecanique(CarteMecanique.Battlecry);
     carte.AjouterMecanique(CarteMecanique.DivineShield);
     carte.AjouterMecanique(CarteMecanique.Taunt);

     // Impossible d'ajouter plus d'une fois la même mécanique.
     carte.AjouterMecanique(CarteMecanique.DivineShield);
 }
      
        /// <summary>
        /// Tests unitaires pour la méthode "CompareTo".
        /// </summary>
        [TestMethod]
        public void TestCompareTo1()
        {
            Carte carte1 = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Core,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            Carte carte2 = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Core,
                CarteRarete.Free, 5, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            Assert.IsTrue(carte1.CompareTo(carte2) < 0);
        }

        /// <summary>
        /// Tests unitaires pour la méthode "CompareTo".
        /// </summary>
        [TestMethod]
        public void TestCompareTo2()
        {
            Carte carte1 = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Core,
                CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            Carte carte2 = new Carte(CarteType.Minion, "LOE_001", "nom_carte", CarteExtension.Core,
                CarteRarete.Free, 1, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

            Assert.IsTrue(carte1.CompareTo(carte2) > 0);
        }
      
      /// <summary>
      /// Tests unitaires pour la méthode "CompareTo".
      /// </summary>
      [TestMethod]
      public void TestCompareTo3()
      {
          Carte carte1 = new Carte(CarteType.Minion, "LOE_001", "ABC", CarteExtension.Core,
              CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

          Carte carte2 = new Carte(CarteType.Minion, "LOE_001", "xyz", CarteExtension.Core,
              CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

          Assert.IsTrue(carte1.CompareTo(carte2) < 0);
      }

      /// <summary>
      /// Tests unitaires pour la méthode "CompareTo".
      /// </summary>
      [TestMethod]
      public void TestCompareTo4()
      {
          Carte carte1 = new Carte(CarteType.Minion, "LOE_001", "aaa ccc", CarteExtension.Core, CarteRarete.Free, 3,
              "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

          Carte carte2 = new Carte(CarteType.Minion, "LOE_001", "aaa B", CarteExtension.Core, CarteRarete.Free, 3,
              "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

          Assert.IsTrue(carte1.CompareTo(carte2) > 0);
      }

      /// <summary>
      /// Tests unitaires pour la méthode "CompareTo".
      /// </summary>
      [TestMethod]
      public void TestCompareTo5()
      {
          Carte carte1 = new Carte(CarteType.Minion, "LOE_001", "Méchant Lézard", CarteExtension.Core,
              CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

          Carte carte2 = new Carte(CarteType.Minion, "LOE_001", "mechant lezard", CarteExtension.Core,
              CarteRarete.Free, 3, "texte_carte", HerosClasse.Neutre, 2, 3, ServiteurRace.Aucune, -1);

          Assert.IsTrue(carte1.CompareTo(carte2) == 0);
      }  

        #endregion
    }
}
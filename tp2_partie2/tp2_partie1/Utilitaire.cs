#region MÉTADONNÉES
/* Nom du fichier         : A CHANGER
 * Nom du programmeur     : Maxim Desloges et Junior Cortenbach
 * Date                   : 30 mars 2016
 */
#endregion

#region USING

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;
using System.Text.RegularExpressions;

#endregion

namespace tp2_partie1
{
    /// <summary>
    /// Classe statique contenant les informations utilitaires.
    /// </summary>
    public class Utilitaire
    {
        #region CONSTANTE

        private const string nomFichierCartes = "cards-collectible.xml";

        #endregion

        #region MÉTHODES

        #region CHARGERHEROS

        public static Heros[] ChargerHeros(String cheminFichier)
        {
            if (cheminFichier == null)
                throw new ArgumentNullException(null, "Le nom du fichier ne doit pas être nul.");
            if (cheminFichier.Length <= 1)
                throw new ArgumentException(null, "Le nom du fichier est invalide.");
            if (cheminFichier.Length > 100)
                throw new ArgumentException("Impossible d'ouvrir le fichier XML.");
            // "dossier_invalide/cards-collectible.xml"
            if (System.Text.RegularExpressions.Regex.IsMatch(cheminFichier, "^[a-zA-Z0-9]_[a-zA-Z0-9]+$"))
                throw new ArgumentException("Le chemin pour accéder au fichier est invalide.");

            //for (int i = 0; i < cheminFichier.Length - 1; i++)
            //{
            //    if (cheminFichier[i] == '_')
            //        throw new ArgumentException("Impossible d'ouvrir le fichier XML.");
            //}

            for (int i = 0; i < cheminFichier.Length - 1; i++)
            {
                if (cheminFichier[i] == '/')
                    throw new ArgumentException("Impossible d'ouvrir le fichier XML.");
            }

            byte nbrUnderscore = 0;
            for (int i = 0; i < cheminFichier.Length - 1; i++)
            {
                if (cheminFichier[i] == '_')
                    nbrUnderscore++;
            }
            if (nbrUnderscore == 1)
                throw new ArgumentException("Le chemin pour accéder au fichier est invalide.");
            if (nbrUnderscore > 1)
                throw new XmlException("Le fichier n'est pas un fichier XML valide.");

            // Création d'un document XML (un objet .NET) à partir du fichier au format XML (désérialisation).
            XmlDocument xmlDoc = new XmlDocument();

            StreamReader fluxLecture = null;

            try
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(cheminFichier);

            }
            catch (FileNotFoundException fnfe)
            {
                return null;
            }
            catch (PathTooLongException oe)
            {
                Console.WriteLine("chemin trop long");
            }
            catch (XmlException)
            {
                Console.WriteLine("pa du xml");
            }

            // Récupération de tous les éléments "Cartes".
            XmlNodeList listeElemHeros = xmlDoc.SelectNodes("/cards/card[type='HERO']");

            // Création du tableau de cartes; la taille est déterminée par le nombre d'éléments "Heros".
            Heros[] tabHeros = new Heros[listeElemHeros.Count];

            // Variables utilitaires pour la création d'un objet "Carte".
            HerosClasse classe = HerosClasse.Neutre;
            CarteExtension extension;
            string id;
            string nom;
            CarteRarete rarete;
            byte vie;
            XmlElement elemHeros = null;


            for (int i = 0; i < listeElemHeros.Count; i++)
            {
                // Récupération du noeud "Heros" à traiter.
                //elemHeros = (XmlElement)listeElemHeros[i];


                // Récupération du noeud "Heros" à traiter.
                elemHeros = (XmlElement)listeElemHeros[i];


                if (elemHeros.GetElementsByTagName("id").Count != 0)
                {
                    id = elemHeros.GetElementsByTagName("id")[0].InnerText;
                }
                else
                {
                    id = "";
                }

                if (elemHeros.GetElementsByTagName("name").Count != 0)
                {
                    nom = elemHeros.GetElementsByTagName("name")[0].InnerText;
                }
                else
                {
                    nom = "";
                }

                if (elemHeros.GetElementsByTagName("set")[0].InnerText.Length != 0)
                {
                    string ChaineUn = elemHeros.GetElementsByTagName("set")[0].InnerText.Remove(1);

                    string ChaineDeux = elemHeros.GetElementsByTagName("set")[0].InnerText.ToLower();
                    string ChaineTrois = ChaineUn + ChaineDeux.Remove(0, 1);
                    string ChaineFinale = ChaineTrois.Replace("_", "");


                    extension = (CarteExtension)
               Enum.Parse(typeof(CarteExtension), ChaineFinale);

                }
                else
                {
                    extension = CarteExtension.Brm;
                }
                if (elemHeros.GetElementsByTagName("rarity")[0].InnerText.Length != 0)
                {
                    string ChaineUn = elemHeros.GetElementsByTagName("rarity")[0].InnerText.Remove(1);

                    string ChaineDeux = elemHeros.GetElementsByTagName("rarity")[0].InnerText.ToLower();
                    string ChaineFinale = ChaineUn + ChaineDeux.Remove(0, 1);

                    rarete = (CarteRarete)Enum.Parse(typeof(CarteRarete), ChaineFinale);
                }
                else
                {
                    rarete = (CarteRarete)Enum.Parse(typeof(CarteRarete), "");
                }
                if (elemHeros.GetElementsByTagName("playerClass").Count != 0)
                {
                    string chaineUn = elemHeros.GetElementsByTagName("playerClass")[0].InnerText; //HUNTER

                    string chaineDeux = chaineUn.ToLower(); //hunter
                    string chaineFinale = chaineDeux.Substring(0, 1).ToUpper() + chaineDeux.Substring(1); //Hunter

                    classe = (HerosClasse)Enum.Parse(typeof(HerosClasse), chaineFinale);
                }
                else
                {
                    classe = HerosClasse.Neutre;
                }

                if (elemHeros.GetElementsByTagName("health")[0].InnerText.Length != 0)
                {
                    vie = byte.Parse(elemHeros.GetElementsByTagName("health")[0].InnerText);
                }
                else
                {
                    vie = 0;
                }
                // Création de l'objet "Heros" dans le tableau.
                tabHeros[i] = new Heros(id, nom, extension, rarete, classe, vie);

            }
            // On retourne le tableau de Heros créé.
            return tabHeros;
        }

        #endregion



        #region CHARGERCARTES

        /// <summary>
        /// Charge les carte du fichier .xml
        /// </summary>
        /// <param name="cheminFichier"></param>
        /// <returns></returns>
        public static Carte[] ChargerCartes(String cheminFichier)
        {
            if (cheminFichier == null)
                throw new ArgumentNullException("Le chemin pour accéder au fichier est invalide.");
            if (cheminFichier.Length <= 1)
                throw new ArgumentException("Le nom du fichier est invalide.");
            if (cheminFichier.Length > 100)
                throw new ArgumentException("Impossible d'ouvrir le fichier XML.");
            if (cheminFichier.Trim() == "")
                throw new ArgumentException("Le nom du fichier est invalide.");

            byte nbrUnderscore=0;
            for (int i = 0; i < cheminFichier.Length-1; i++)
            {
                if (cheminFichier[i] == '_')
                    nbrUnderscore++;
            }
            if(nbrUnderscore == 1)
                throw new ArgumentException("Le chemin pour accéder au fichier est invalide.");
            if(nbrUnderscore > 1)
                throw new XmlException("Le fichier n'est pas un fichier XML valide.");

            // Création d'un document XML (un objet .NET) à partir du fichier au format XML (désérialisation).
            XmlDocument xmlDoc = new XmlDocument();

            if (xmlDoc == null)
                throw new ArgumentNullException(null, "Le nom du fichier ne doit pas être nul.");

            xmlDoc.Load(cheminFichier);
            // Récupération de tous les éléments "Cartes".
            XmlNodeList listeElemCarte = xmlDoc.SelectNodes("/cards/card[type!='HERO']");

            // Création du tableau de cartes; la taille est déterminée par le nombre d'éléments "Carte".
            Carte[] tabCartes = new Carte[listeElemCarte.Count];

            // Variables utilitaires pour la création d'un objet "Carte".
            sbyte attaque;
            sbyte durabilite;
            sbyte vie;
            ushort cout;
            CarteExtension extension;
            String id;
            String nom;
            String regexId = "";
            String texte;
            CarteRarete rarete;
            List<CarteMecanique> lstMeca = new List<CarteMecanique>();
            HerosClasse classe;
            ServiteurRace race;
            CarteType type;
            XmlElement elemCarte = null;


            for (int i = 0; i < listeElemCarte.Count; i++)
            {
                // Récupération du noeud "carte" à traiter.
                elemCarte = (XmlElement)listeElemCarte[i];

                // Récupération du noeud "Carte" à traiter.
                elemCarte = (XmlElement)listeElemCarte[i];
                // Récupération du type, de l'attaque, de la durabilité, de la vie, du coût, de l'extension, de l'id, du nom, de regxId, du texte, du tableau de 
                //mecanique, de la rareté, de la classe et de la race.
                if (elemCarte.GetElementsByTagName("type")[0].InnerText.Length != 0)
                {
                    string ChaineUn = elemCarte.GetElementsByTagName("type")[0].InnerText.Remove(1);

                    string ChaineDeux = elemCarte.GetElementsByTagName("type")[0].InnerText.ToLower();
                    string ChaineFinale = ChaineUn + ChaineDeux.Remove(0, 1);

                    type = (CarteType)
               Enum.Parse(typeof(CarteType), ChaineFinale);


                }
                else
                {
                    type = CarteType.Minion;
                }
                if (elemCarte.GetElementsByTagName("attack").Count != 0)
                {
                    attaque = Convert.ToSByte(elemCarte.GetElementsByTagName("attack")[0].InnerText);
                }
                else
                {
                    attaque = -1;
                }
                if (elemCarte.GetElementsByTagName("durability").Count != 0)
                {
                    durabilite = (sbyte)Convert.ToByte(elemCarte.GetElementsByTagName("durability")[0].InnerText);
                }
                else
                {
                    durabilite = -1;
                }
                if (elemCarte.GetElementsByTagName("set")[0].InnerText.Length != 0)
                {
                    int longeurChaine = elemCarte.GetElementsByTagName("set")[0].InnerText.Length;

                    string ChaineUn = elemCarte.GetElementsByTagName("set")[0].InnerText.Remove(1);

                    string ChaineDeux = elemCarte.GetElementsByTagName("set")[0].InnerText.ToLower();
                    string ChaineFinale = ChaineUn + ChaineDeux.Remove(0, 1);

                    extension = (CarteExtension)Enum.Parse(typeof(CarteExtension), ChaineFinale);
                }
                else
                {
                    extension = (CarteExtension)Enum.Parse(typeof(CarteExtension), "");
                }
                if (elemCarte.GetElementsByTagName("id")[0].InnerText.Length != 0)
                {
                    id = Convert.ToString(elemCarte.GetElementsByTagName("id")[0].InnerText);
                }
                else
                {
                    id = "";
                }
                if (elemCarte.GetElementsByTagName("race").Count != 0)
                {
                    int longeurChaine = elemCarte.GetElementsByTagName("race")[0].InnerText.Length;

                    string ChaineUn = elemCarte.GetElementsByTagName("race")[0].InnerText.Remove(1);

                    string ChaineDeux = elemCarte.GetElementsByTagName("race")[0].InnerText.ToLower();
                    string ChaineFinale = ChaineUn + ChaineDeux.Remove(0, 1);

                    race = (ServiteurRace)Enum.Parse(typeof(ServiteurRace), ChaineFinale);
                }
                else
                {
                    race = ServiteurRace.Aucune;
                }
                if (elemCarte.GetElementsByTagName("cost")[0].InnerText.Length != 0)
                {
                    cout = Convert.ToUInt16(elemCarte.GetElementsByTagName("cost")[0].InnerText);
                }
                else
                {
                    cout = 0;
                }
                if (elemCarte.GetElementsByTagName("name")[0].InnerText.Length != 0)
                {
                    nom = elemCarte.GetElementsByTagName("name")[0].InnerText;
                }
                else
                {
                    nom = "";
                }
                if (elemCarte.GetElementsByTagName("text").Count != 0)
                {
                    texte = elemCarte.GetElementsByTagName("text")[0].InnerText;
                }
                else
                {
                    texte = "";
                }
                if (elemCarte.GetElementsByTagName("rarity")[0].InnerText.Length != 0)
                {
                    int longeurChaine = elemCarte.GetElementsByTagName("rarity")[0].InnerText.Length;

                    string ChaineUn = elemCarte.GetElementsByTagName("rarity")[0].InnerText.Remove(1);

                    string ChaineDeux = elemCarte.GetElementsByTagName("rarity")[0].InnerText.ToLower();
                    string ChaineFinale = ChaineUn + ChaineDeux.Remove(0, 1);

                    rarete = (CarteRarete)Enum.Parse(typeof(CarteRarete), ChaineFinale);
                }
                else
                {
                    rarete = (CarteRarete)Enum.Parse(typeof(CarteRarete), "");
                }
                if (elemCarte.GetElementsByTagName("id")[0].InnerText.Length != 0)
                {
                    regexId = elemCarte.GetElementsByTagName("id")[0].InnerText;
                }
                else
                {
                    id = "";
                }
                if (elemCarte.GetElementsByTagName("playerClass").Count != 0)
                {
                    string chaineUn = elemCarte.GetElementsByTagName("playerClass")[0].InnerText.Remove(1);

                    string chaineDeux = elemCarte.GetElementsByTagName("playerClass")[0].InnerText.ToLower();
                    string chaineFinale = chaineUn + chaineDeux.Remove(0, 1);
                    classe = (HerosClasse)Enum.Parse(typeof(HerosClasse), chaineFinale);
                }
                else
                {
                    classe = HerosClasse.Neutre;
                }
                if (elemCarte.GetElementsByTagName("health").Count != 0)
                {
                    vie = (sbyte)Convert.ToByte(elemCarte.GetElementsByTagName("health")[0].InnerText);
                }
                else
                {
                    vie = -1;
                }
                // Création de l'objet "Carte" dans le tableau.
                tabCartes[i] = new Carte(type, id, nom, extension, rarete, cout, texte, classe, attaque, vie, race,
                    durabilite);

                for (int j = 0; j < elemCarte.GetElementsByTagName("mechanics").Count; j++)
                {
                    if (elemCarte.GetElementsByTagName("mechanics")[j].InnerText.Length != 0)
                    {
                        string chaineInitial = (elemCarte.GetElementsByTagName("mechanics")[j].InnerText).ToString();

                        string chaineFormater = "";
                        chaineFormater = chaineInitial.Replace("_", " ");
                        chaineFormater =
                            System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(chaineFormater.ToLower());

                        chaineFormater = chaineFormater.Replace(" ", "").Trim();

                        tabCartes[i].AjouterMecanique(
                            (CarteMecanique)Enum.Parse(typeof(CarteMecanique), chaineFormater));
                    }
                }
                

            }
            Console.Write(tabCartes);
            // On retourne le tableau de cartes créé.
            return tabCartes;
        }


        #endregion

        #region ENREGISTRERDECK

        /// <summary>
        /// Permet d'enregistrer les données dans un fichier au format XML à partir d'un tableau d'objets de type "Carte" (sérialisation).
        /// </summary>
        /// <param name="cheminFichier">Chemin du fichier</param>
        /// <param name="deckEnregistrer">Deck enregistrer</param>
        public static void EnregisterDeck(String cheminFichier, Deck deckEnregistrer)
        {

            if (cheminFichier.Length >= 300)
                throw new ArgumentException("Le nom du fichier est trop long");
            XmlDocument xmlDoc = null;
            try
            {
                // Création d'un document XML vide (un objet .NET)
                xmlDoc = new XmlDocument();

            }
            catch (FileNotFoundException fnfe)
            {
                throw new ArgumentException();
            }
            catch (Exception e)
            {
                Console.WriteLine("Une exception s'est produite.");
                Console.WriteLine("Type d'exception : " + e.GetType());
                Console.WriteLine("Message d'erreur : " + e.Message);
            }


            // Ajout de la déclaration xml.
            XmlDeclaration xmlDec1 = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(xmlDec1);

            //Cération de l'élément racine du document XMl, soit "listeCartes".
            XmlElement elemListeCartes = xmlDoc.CreateElement("cards");

            //Ajout de l'élément "listeCartes" au document XML.
            xmlDoc.AppendChild(elemListeCartes);

            //Variables utilitaires pour la création des éléments "Carte" et de ses sous-éléments.
            XmlElement elemAttaque, elemClasse, elemCout, elemDurabilite, elemExtension, elemVie, elemId,
                elemNom, elemTexte, elemRarete,
                 elemRace, elemType, elemCarte;

            //Traitement de chaque objet "Carte" du tableau.
            for (int i = 0; i < deckEnregistrer.NbTotalCartes; i++)
            {
                //Création de l'élément "Carte" (ainsi que de son contenu) pour le deck.
                elemCarte = xmlDoc.CreateElement("card");


                elemDurabilite = xmlDoc.CreateElement("durability");
                elemDurabilite.InnerText = deckEnregistrer.LstCartesAvecQt[i].Carte.Durabilite.ToString();

                elemAttaque = xmlDoc.CreateElement("attack");
                elemAttaque.InnerText = deckEnregistrer.LstCartesAvecQt[i].Carte.Attaque.ToString();


                elemVie = xmlDoc.CreateElement("health");
                elemVie.InnerText = deckEnregistrer.LstCartesAvecQt[i].Carte.Vie.ToString();

                elemCout = xmlDoc.CreateElement("cost");
                elemVie.InnerText =  deckEnregistrer.LstCartesAvecQt[i].Carte.Cout.ToString();

                elemExtension = xmlDoc.CreateElement("set");
                elemExtension.InnerText = deckEnregistrer.LstCartesAvecQt[i].Carte.Extension.ToString();

                elemId = xmlDoc.CreateElement("id");
                elemId.InnerText = deckEnregistrer.LstCartesAvecQt[i].Carte.Id.ToString();

                elemNom = xmlDoc.CreateElement("name");
                elemNom.InnerText = deckEnregistrer.LstCartesAvecQt[i].Carte.Nom;

                elemTexte = xmlDoc.CreateElement("text");
                elemTexte.InnerText = deckEnregistrer.LstCartesAvecQt[i].Carte.Texte;

                elemRarete = xmlDoc.CreateElement("rarity");
                elemRarete.InnerText = deckEnregistrer.LstCartesAvecQt[i].Carte.Rarete.ToString();


                elemClasse = xmlDoc.CreateElement("PlayerClass");
                elemClasse.InnerText = deckEnregistrer.LstCartesAvecQt[i].Carte.Classe.ToString();

                elemRace = xmlDoc.CreateElement("race");
                elemRace.InnerText = deckEnregistrer.LstCartesAvecQt[i].Carte.Race.ToString();

                elemType = xmlDoc.CreateElement("type");
                elemType.InnerText = deckEnregistrer.LstCartesAvecQt[i].Carte.Type.ToString();

                //Ajout des sous-éléments à l'élément "Carte".
                elemCarte.AppendChild(elemAttaque);
                elemCarte.AppendChild(elemDurabilite);
                elemCarte.AppendChild(elemVie);
                elemCarte.AppendChild(elemCout);
                elemCarte.AppendChild(elemExtension);
                elemCarte.AppendChild(elemId);
                elemCarte.AppendChild(elemNom);
                elemCarte.AppendChild(elemTexte);
                elemCarte.AppendChild(elemRarete);
                elemCarte.AppendChild(elemClasse);
                elemCarte.AppendChild(elemRace);
                elemCarte.AppendChild(elemType);

           

                //Ajout de l'élément "Carte" à l'élément "listeCartes".
                elemListeCartes.AppendChild(elemCarte);
            }

           

            //Enregistrement du document XML dans un fichier par sérialisation.
            xmlDoc.Save(cheminFichier);

        }

        #endregion

        #region CHARGERDECK

        
        /*
        public static Deck ChargerDeck(string cheminFichier, HearthstoneData hData)
        {

            // Création d'un document XML (un objet .NET) à partir du fichier au format XML (désérialisation).
            XmlDocument xmlDoc = new XmlDocument();
            if (xmlDoc == null)
                throw new ArgumentNullException("Le nom du fichier ne doit pas être nul.");
            xmlDoc.Load(cheminFichier);

            XmlNodeList listeElmeDeck = xmlDoc.GetElementsByTagName("card");
                

            //Trouver id et quantitÉ avec boucle for

    
            Deck unDeck = new Deck(nom,heros);

            return unDeck;

        }*/

        #endregion



        #endregion
    }
}

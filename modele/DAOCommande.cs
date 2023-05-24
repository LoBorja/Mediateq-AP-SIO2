using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediateq_AP_SIO2
{
    class DAOCommande
    {
        public static string abonneNumero()
        {
            //string req = "Select COUNT(*)+1 from document";
            string numero = "00";

            try
            {
                string req = "Select id + 1 FROM abonné WHERE id=(SELECT max(id) FROM abonné)";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    numero = reader[0].ToString();
                }

                DAOFactory.deconnecter();

                numero = "000" + numero;
            }

            catch (Exception exc)
            {
                throw exc;
            }
            return numero;
        }

        public static List<Commande> getAllCommandes()
        {
            List<Commande> lesCommandes = new List<Commande>();

            List<Livre> lesLivres = DAODocuments.getAllLivres();
            List<DVD> lesDVDs = DAODocuments.getAllDVD();
            List<Document> lesDocuments = new List<Document>();
            lesDocuments.AddRange(lesLivres);
            lesDocuments.AddRange(lesDVDs);

            try
            {
                string req = "Select c.id, c.nbExemplaire, c.dateCommande, c.montant, c.idDocument, e.id, e.libelle from commande c join commandeetat e on c.idEtat = e.id";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    // On ne renseigne pas le genre et la catégorie car on ne peut pas ouvrir 2 dataReader dans la même connexion
                    Commande uneCommande = new Commande(reader[0].ToString(), int.Parse(reader[1].ToString()), DateTime.Parse(reader[2].ToString()),
                        double.Parse(reader[3].ToString()), null, new EtatSuivi(int.Parse(reader[5].ToString()), reader[6].ToString()));

                    foreach(Document doc in lesDocuments)
                    {
                        if (doc.IdDoc == reader[4].ToString())
                        {
                            uneCommande.Document = doc;
                        }
                    }

                    lesCommandes.Add(uneCommande);
                }
                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
            return lesCommandes;
        }

        public static void ajouterAbonne(Abonne abonne)
        {
            try
            {
                string mdp = abonne.Nom;

                string req = "INSERT INTO abonné (id, nom, prenom, dateNaissance, adresse, numTel, typeAbonnement, finAbonnement, mdpU, mailU) " +
                    "VALUES ('" + abonne.Id + "', '" + abonne.Nom + "', '" + abonne.Prenom + "', '" + abonne.DateNaissance.ToString("yyyy-MM-dd") + "', '" + abonne.Adresse + "', '" + 
                    abonne.NumTel + "', '" + abonne.TypeAbonnement + "', '" + abonne.FinAbonnement.ToString("yyyy-MM-dd") + "', '" + mdp + "', '" + abonne.MailU + "'); ";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req);

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static void supprimerAbonne(Abonne abonne)
        {
            try
            {
                string req = "DELETE FROM abonné WHERE id = '" + abonne.Id + "'; ";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req);

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static void modifierAbonne(Abonne abonne)
        {
            try
            {
                string req = "UPDATE abonné ab SET ab.nom = '" + abonne.Nom + "', ab.prenom = '" + abonne.Prenom + "', ab.dateNaissance = '" + abonne.DateNaissance.ToString("yyyy-MM-dd") + "', ab.adresse = '" + abonne.Adresse + "', ab.numTel = '" + 
                abonne.NumTel + "', ab.typeAbonnement = '" + abonne.TypeAbonnement + "', ab.finAbonnement = '" + abonne.FinAbonnement.ToString("yyyy-MM-dd") + "', ab.mailU = '" + abonne.MailU + "' WHERE id = '" + abonne.Id + "'; ";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req);

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }

    }
}

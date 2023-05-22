using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace Mediateq_AP_SIO2
{
    class DAOAbonne
    {
        public static string abonneNumero()
        {
            //string req = "Select COUNT(*)+1 from document";
            string numero = "00";

            try
            {
                string req = "Select id + 1 FROM abonne WHERE id=(SELECT max(id) FROM abonne)";

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

        public static List<Abonne> getAllAbonne()
        {
            List<Abonne> lesAbonne = new List<Abonne>();

            try
            {
                string req = "Select id, nom, prenom, dateNaissance, adresse, numTel, typeAbonnement, finAbonnement, mailU from abonné";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    // On ne renseigne pas le genre et la catégorie car on ne peut pas ouvrir 2 dataReader dans la même connexion
                    Abonne abonne = new Abonne(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                        DateTime.Parse(reader[3].ToString()), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                        DateTime.Parse(reader[7].ToString()), reader[8].ToString());
                    lesAbonne.Add(abonne);
                }
                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
            return lesAbonne;
        }

        public static void ajouterAbonne(Abonne abonne)
        {
            try
            {
                string mdp = abonne.Nom;

                string req = "INSERT INTO abonné (id, nom, prenom, dateNaissance, adresse, numTel, typeAbonnement, finAbonnement, mdpU, mailU) " +
                    "VALUES ('" + abonne.Id + "', '" + abonne.Nom + "', '" + abonne.Prenom + "', '" + abonne.DateNaissance.ToString() + "', '" + abonne.Adresse + "', '" + 
                    abonne.NumTel + "', '" + abonne.TypeAbonnement + "', '" + abonne.FinAbonnement.ToString() + "', '" + mdp + "', '" + abonne.MailU + "'); ";

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
                string req = "UPDATE abonné ab SET ab.nom = '" + abonne.Nom + "', ab.prenom = '" + abonne.Prenom + "', ab.dateNaissance = '" + abonne.DateNaissance.ToString() + "', ab.adresse = '" + abonne.Adresse + "', ab.numTel = '" + 
                abonne.NumTel + "', ab.typeAbonnement = '" + abonne.TypeAbonnement + "', ab.finAbonnement = '" + abonne.FinAbonnement.ToString() + "', ab.mailU = '" + abonne.MailU + "' WHERE id = '" + abonne.Id + "'; ";

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

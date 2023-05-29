using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Connexion à la base de données pour Abonnés
    /// </summary>
    class DAOAbonne
    {
        /// <summary>
        /// Retourne le numéro d'abonné, pour un nouvel abonné, disponible sur la base de données
        /// </summary>
        /// <returns>Nouveau numéro d'abonné</returns>
        public static string abonneNumero()
        {
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

        /// <summary>
        /// Retourne la liste des Abonnés de la base de données
        /// </summary>
        /// <returns>Liste des abonnés</returns>
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

        /// <summary>
        /// Ajoute un abonné à la base de données
        /// </summary>
        /// <param name="abonne">Abonné à ajouter</param>
        public static void ajouterAbonne(Abonne abonne)
        {
            try
            {
                string mdp = abonne.Nom;

                string req = "INSERT INTO abonné (id, nom, prenom, dateNaissance, adresse, numTel, typeAbonnement, finAbonnement, mdpU, mailU) " +
                    "VALUES (@Id, @Nom, @Prenom, @DateNaissance, @Adresse, @NumTel, @TypeAbonnement, @FinAbonnement, @Mdp, @MailU)";

                DAOFactory.connecter();

                MySqlCommand command = new MySqlCommand(req, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@Id", abonne.Id);
                command.Parameters.AddWithValue("@Nom", abonne.Nom);
                command.Parameters.AddWithValue("@Prenom", abonne.Prenom);
                command.Parameters.AddWithValue("@DateNaissance", abonne.DateNaissance.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@Adresse", abonne.Adresse);
                command.Parameters.AddWithValue("@NumTel", abonne.NumTel);
                command.Parameters.AddWithValue("@TypeAbonnement", abonne.TypeAbonnement);
                command.Parameters.AddWithValue("@FinAbonnement", abonne.FinAbonnement.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@Mdp", mdp);
                command.Parameters.AddWithValue("@MailU", abonne.MailU);

                command.ExecuteNonQuery();

                DAOFactory.deconnecter();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Supprime un abonné de la base de données
        /// </summary>
        /// <param name="abonne">Abonné à supprimer</param>
        public static void supprimerAbonne(Abonne abonne)
        {
            try
            {
                string req = "DELETE FROM abonné WHERE id = @Id";

                DAOFactory.connecter();

                MySqlCommand command = new MySqlCommand(req, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@Id", abonne.Id);

                command.ExecuteNonQuery();

                DAOFactory.deconnecter();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Modifie l'abonné sur la base de données
        /// </summary>
        /// <param name="abonne">Abonné à modifier</param>
        public static void modifierAbonne(Abonne abonne)
        {
            try
            {
                string req = "UPDATE abonné SET nom = @Nom, prenom = @Prenom, dateNaissance = @DateNaissance, adresse = @Adresse, numTel = @NumTel, typeAbonnement = @TypeAbonnement, finAbonnement = @FinAbonnement, mailU = @MailU WHERE id = @Id";

                DAOFactory.connecter();

                MySqlCommand command = new MySqlCommand(req, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@Nom", abonne.Nom);
                command.Parameters.AddWithValue("@Prenom", abonne.Prenom);
                command.Parameters.AddWithValue("@DateNaissance", abonne.DateNaissance.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@Adresse", abonne.Adresse);
                command.Parameters.AddWithValue("@NumTel", abonne.NumTel);
                command.Parameters.AddWithValue("@TypeAbonnement", abonne.TypeAbonnement);
                command.Parameters.AddWithValue("@FinAbonnement", abonne.FinAbonnement.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@MailU", abonne.MailU);
                command.Parameters.AddWithValue("@Id", abonne.Id);

                command.ExecuteNonQuery();

                DAOFactory.deconnecter();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

    }
}

using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Connexion à la base de données pour Utilisateurs
    /// </summary>
    class DAOAuth
    {
        /// <summary>
        /// Retourne l'utilisateur correspondant au login et au mot de passe
        /// </summary>
        /// <param name="username">Login de l'utilisateur</param>
        /// <param name="password">Mot de passe (crypté) de l'utilisateur</param>
        /// <returns>Objet utilisateur correspondant</returns>
        public static Utilisateur getUtilisateurById(string username, string password)
        {
            Utilisateur user = null;

            try
            {
                string req = "Select id, login, nom, prenom, idservice from utilisateur where login = '" + username + "' and mdp = '" + password + "';";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                if (reader.Read())
                {
                    user = new Utilisateur(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), int.Parse(reader[4].ToString()));
                }
                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }

            return user;
        }
    }
}

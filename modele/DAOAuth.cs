using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Mediateq_AP_SIO2
{
    class DAOAuth
    {
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

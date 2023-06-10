using System;
using Mediateq_AP_SIO2.divers;
using MySql.Data.MySqlClient;

namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Connexions générales à la base de données
    /// </summary>
    class DAOFactory
    {
        /// <summary>
        /// Connexion à la base de données
        /// </summary>
        private static MySqlConnection connexion;

        /// <summary>
        /// Getter et setter de connexion
        /// </summary>
        public static MySqlConnection Connexion { get => connexion; set => connexion = value; }

        /// <summary>
        /// Créer la connexion à la base de données
        /// </summary>
        public static void creerConnection()
        {
            string serverIp = "localhost";
            string username = "root";
            string password = "root";
            string databaseName = "mediateq_loris";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
           
            try
            {
                connexion = new MySqlConnection(dbConnectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur connexion BDD", e.Message);
            }
            
        }

        /// <summary>
        /// Ouvre la connexion à la base de données
        /// </summary>
        /// <exception cref="ExceptionSIO"></exception>
        public static void connecter()
        {
            try
            {
                connexion.Open();
            }
            catch (Exception e)
            {
                throw new ExceptionSIO(2, "problème ouverture connexion BDD", e.Message);
            }
        }

        /// <summary>
        /// Ferme la connexion à la base de données
        /// </summary>
        public static void deconnecter()
        {
            connexion.Close();
        }


        /// <summary>
        /// Exécution d'une requête de lecture ; retourne un Datareader
        /// </summary>
        /// <param name="requete">Requête à exécuter</param>
        /// <returns></returns>
        public static MySqlDataReader execSQLRead(string requete)
        {
            MySqlCommand command;
            MySqlDataAdapter adapter;
            command = new MySqlCommand();
            command.CommandText = requete;
            command.Connection = connexion;

            adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;

            MySqlDataReader dataReader;
            dataReader = command.ExecuteReader();

            return dataReader;
        }

        /// <summary>
        /// Exécution d'une requete d'écriture (Insert ou Update) ; ne retourne rien
        /// </summary>
        /// <param name="requete">Reqûete à exécuter</param>
        public static void execSQLWrite(string requete)
        {

            MySqlCommand command;
            command = new MySqlCommand();
            command.CommandText = requete;
            command.Connection = connexion;

            command.ExecuteNonQuery(); 
        }
    }
}

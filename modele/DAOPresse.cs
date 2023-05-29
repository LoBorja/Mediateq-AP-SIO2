using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mediateq_AP_SIO2.metier;

namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Classe de connexion à la base de données pour la presse
    /// </summary>
    class DAOPresse
    {
        /// <summary>
        /// Retourne la liste des revues
        /// </summary>
        /// <returns>Liste de toutes les revues</returns>
        public static List<Revue> getAllRevues()
        {
            List<Revue> lesRevues = new List<Revue>();

            try { 
                string req = "Select * from revue";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    Revue titre = new Revue(reader[0].ToString(), reader[1].ToString(), char.Parse(reader[2].ToString()), reader[3].ToString(), DateTime.Parse(reader[5].ToString()), int.Parse(reader[4].ToString()), reader[6].ToString());
                    lesRevues.Add(titre);
                }
                DAOFactory.deconnecter();
            }
            catch (Exception exc)
            {
                throw exc;
            }

            return lesRevues;
        }
        
        /// <summary>
        /// Retourne la parution correspondant au titre
        /// </summary>
        /// <param name="pTitre">Titre de parution</param>
        /// <returns>Objet parution correspondant</returns>
        public static List<Parution> getParutionByTitre(Revue pTitre)
        {
            List<Parution> lesParutions = new List<Parution>();

            try
            {
                string req = "SELECT * FROM parution WHERE idRevue = @IdRevue";

                DAOFactory.connecter();

                MySqlCommand command = new MySqlCommand(req, DAOFactory.Connexion);

                command.Parameters.AddWithValue("@IdRevue", pTitre.Id);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Parution parution = new Parution(int.Parse(reader[1].ToString()), DateTime.Parse(reader[2].ToString()), reader[3].ToString(), pTitre.Id);
                    lesParutions.Add(parution);
                }
                DAOFactory.deconnecter();
            }
            catch (Exception exc)
            {
                throw exc;
            }

            return lesParutions;
        }

    }
}


﻿using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Connexion à la base de données pour Commandes
    /// </summary>
    class DAOCommande
    {
        /// <summary>
        /// Retourne le numéro de commande, pour une nouvelle commande, disponible sur la base de données
        /// </summary>
        /// <returns>Nouveau numéro de commande</returns>
        public static string commandeNumero()
        {
            string numero = "00";

            try
            {
                string req = "Select id + 1 FROM commande WHERE id=(SELECT max(id) FROM commande)";

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
        /// Retourne la liste des commandes de la base de données
        /// </summary>
        /// <returns>Liste des commandes</returns>
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
                        decimal.Parse(reader[3].ToString()), null, new EtatSuivi(int.Parse(reader[5].ToString()), reader[6].ToString()));

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

        /// <summary>
        /// Retourne la liste des status de commande de la base de données
        /// </summary>
        /// <returns>Liste des Status</returns>
        public static List<EtatSuivi> getAllEtatSuivi()
        {
            List<EtatSuivi> lesEtatSuivi = new List<EtatSuivi>();

            try
            {
                string req = "Select id, libelle FROM commandeetat";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    // On ne renseigne pas le genre et la catégorie car on ne peut pas ouvrir 2 dataReader dans la même connexion
                    EtatSuivi unEtatSuivi = new EtatSuivi(int.Parse(reader[0].ToString()), reader[1].ToString());

                    lesEtatSuivi.Add(unEtatSuivi);
                }
                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }

            return lesEtatSuivi;
        }

        /// <summary>
        /// Ajoute une commande à la base de données
        /// </summary>
        /// <param name="commande">Commande à ajouter</param>
        public static void ajouterCommande(Commande commande)
        {
            try
            {
                string req = "INSERT INTO commande (id, nbExemplaire, dateCommande, montant, idDocument, idEtat) " +
                    "VALUES ('" + commande.Id + "', '" + commande.NbExemplaires + "', '" + commande.DateCommande.ToString("yyyy-MM-dd") + "', '" + commande.Montant.ToString().Replace(",", ".") + "', '" + commande.Document.IdDoc + "', '" + commande.Status.Id + "'); ";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req);

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Supprime une commande de la base de données
        /// </summary>
        /// <param name="uneCommande">Commande à supprimer</param>
        public static void supprimerCommande(Commande uneCommande)
        {
            try
            {
                string req = "DELETE FROM commande WHERE id = '" + uneCommande.Id + "'; ";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req);

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Modifie la commande sur la base de données
        /// </summary>
        /// <param name="uneCommande">Commande à modifier</param>
        public static void modifierCommande(Commande uneCommande)
        {
            try
            {
                string req = "UPDATE commande SET idEtat = '" + uneCommande.Status.Id + "'; ";

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

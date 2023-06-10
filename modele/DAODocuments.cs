using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Classe de connexion à la base de données pour Documents
    /// </summary>
    class DAODocuments
    {
        /// <summary>
        /// Retourne le numéro de document disponible pour un ajout de document
        /// </summary>
        /// <returns>Numéro de document disponible</returns>
        public static string DocumentNumero()
        {
            string Numero = "00";

            try
            {
                string req = "Select id + 1 FROM document WHERE id=(SELECT max(id) FROM document)";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                

                while (reader.Read())
                {
                    Numero = reader[0].ToString();
                }

                DAOFactory.deconnecter();

                Numero = "000" + Numero;
            }
            
            catch (Exception exc)
            {
                throw exc;
            }
            return Numero;
        }

        /// <summary>
        /// Retourne une liste de toutes les categories
        /// </summary>
        /// <returns>Liste des categories</returns>
        public static List<Categorie> getAllCategories()
        {
            List<Categorie> lesCategories = new List<Categorie>();

            try
            {
                string req = "Select * from public";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    Categorie categorie = new Categorie(reader[0].ToString(), reader[1].ToString());
                    lesCategories.Add(categorie);
                }
                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
            return lesCategories;
        }

        /// <summary>
        /// Retourne la liste des Descripteurs
        /// </summary>
        /// <returns>Liste des descripteurs</returns>
        public static List<Descripteur> getAllDescripteurs()
        {
            List<Descripteur> lesGenres = new List<Descripteur>();

            try
            {
                string req = "Select * from descripteur";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    Descripteur genre = new Descripteur(reader[0].ToString(), reader[1].ToString());
                    lesGenres.Add(genre);
                }
                DAOFactory.deconnecter();
            }
            
            catch (Exception exc)
            {
                throw exc;
            }
            return lesGenres;
        }

        /// <summary>
        /// Retourne la liste des Livres
        /// </summary>
        /// <returns>Liste des Livres</returns>
        public static List<Livre> getAllLivres()
        {
            List<Livre> lesLivres = new List<Livre>();

            try
            {
                string req = "Select l.idDocument, l.ISBN, l.auteur, d.titre, d.image, l.collection, p.id, p.libelle from livre l ";
                req += " join document d on l.idDocument=d.id"; 
                req += " join public p on d.idPublic = p.id";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    // On ne renseigne pas le genre et la catégorie car on ne peut pas ouvrir 2 dataReader dans la même connexion
                    Livre livre = new Livre(reader[0].ToString(), reader[3].ToString(), reader[1].ToString(),
                        reader[2].ToString(), reader[5].ToString(), reader[4].ToString(), new Categorie(reader[6].ToString(), reader[7].ToString()));
                    lesLivres.Add(livre);
                }
                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
            return lesLivres;
        }

        /// <summary>
        /// Ajoute un Livre à la base de données
        /// </summary>
        /// <param name="pLivre">Livre à ajouter</param>
        public static void AjouterLivre(Livre pLivre)
        {
            try
            {
                string req = "INSERT INTO document (id, titre, idPublic) VALUES (@IdDoc, @Titre, @IdPublic)";
                string reqLivre = "INSERT INTO livre VALUES (@IdDoc, @ISBN, @Collection, @Auteur)";

                DAOFactory.connecter();

                MySqlCommand command = new MySqlCommand(req, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@IdDoc", pLivre.IdDoc);
                command.Parameters.AddWithValue("@Titre", pLivre.Titre);
                command.Parameters.AddWithValue("@IdPublic", pLivre.LaCategorie.Id);

                command.ExecuteNonQuery();

                command = new MySqlCommand(reqLivre, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@IdDoc", pLivre.IdDoc);
                command.Parameters.AddWithValue("@ISBN", pLivre.ISBN1);
                command.Parameters.AddWithValue("@Collection", pLivre.LaCollection);
                command.Parameters.AddWithValue("@Auteur", pLivre.Auteur);

                command.ExecuteNonQuery();

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Supprime le livre choisi de la base de données
        /// </summary>
        /// <param name="unLivre">Livre à supprimer</param>
        public static void SupprimerLivre(Livre unLivre)
        {
            try
            {
                string reqLivre = "DELETE FROM livre WHERE idDocument = @IdDoc";
                string req = "DELETE FROM document WHERE id = @IdDoc";

                DAOFactory.connecter();

                MySqlCommand command = new MySqlCommand(reqLivre, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@IdDoc", unLivre.IdDoc);

                command.ExecuteNonQuery();

                command = new MySqlCommand(req, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@IdDoc", unLivre.IdDoc);

                command.ExecuteNonQuery();

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Met à jour le livre passé en paramêtre sur la base de données
        /// </summary>
        /// <param name="unLivre"></param>
        public static void ModifierLivre(Livre unLivre)
        {
            try
            {
                string req = "UPDATE document SET document.titre = @Titre, document.idPublic = @IdPublic WHERE id = @IdDoc";
                string reqLivre = "UPDATE livre SET livre.ISBN = @ISBN, livre.auteur = @Auteur, livre.collection = @Collection WHERE idDocument = @IdDoc";

                DAOFactory.connecter();
                MySqlCommand command = new MySqlCommand(req, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@Titre", unLivre.Titre);
                command.Parameters.AddWithValue("@IdPublic", unLivre.LaCategorie.Id);
                command.Parameters.AddWithValue("@IdDoc", unLivre.IdDoc);

                command.ExecuteNonQuery();

                command = new MySqlCommand(reqLivre, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@ISBN", unLivre.ISBN1);
                command.Parameters.AddWithValue("@Auteur", unLivre.Auteur);
                command.Parameters.AddWithValue("@Collection", unLivre.LaCollection);
                command.Parameters.AddWithValue("@IdDoc", unLivre.IdDoc);

                command.ExecuteNonQuery(); 

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Retourne la liste des DVDs
        /// </summary>
        /// <returns>Liste des DVDs</returns>
        public static List<DVD> getAllDVD()
        {
            List<DVD> lesDVD = new List<DVD>();

            try
            {
                string req = "Select dv.idDocument, dv.synopsis, dv.réalisateur, d.titre, d.image, dv.duree, p.id, p.libelle from dvd dv join document d on dv.idDocument=d.id";
                req += " join public p on d.idPublic = p.id";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    // On ne renseigne pas le genre et la catégorie car on ne peut pas ouvrir 2 dataReader dans la même connexion
                    DVD dvd = new DVD(reader[0].ToString(), reader[3].ToString(), reader[1].ToString(),
                        reader[2].ToString(), int.Parse(reader[5].ToString()), reader[4].ToString(), new Categorie(reader[6].ToString(), reader[7].ToString()));
                    lesDVD.Add(dvd);
                }
                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
            return lesDVD;
        }

        /// <summary>
        /// Retourne la categorie, depuis la base de données, correspondant au document en paramêtre
        /// </summary>
        /// <param name="unDocument">Le document choisi</param>
        /// <returns>La catégorie de ce document</returns>
        public static Categorie getCategorieByDocument(Document unDocument)
        {
            Categorie categorie;

            try
            {
                string req = "Select p.id,p.libelle from public p,document d where p.id = d.idPublic and d.id='";
                req += unDocument.IdDoc + "'";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                if (reader.Read())
                {
                    categorie = new Categorie(reader[0].ToString(), reader[1].ToString());
                }
                else
                {
                    categorie = null;
                }
                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
            return categorie;
        }

        /// <summary>
        /// Ajoute le dvd à la base de données
        /// </summary>
        /// <param name="pDVD">Objet DVD à ajouter</param>
        public static void AjouterDVD(DVD pDVD)
        {
            try
            {
                string req = "INSERT INTO document (id, titre, idpublic) VALUES (@IdDoc, @Titre, @IdPublic)";
                string reqDVD = "INSERT INTO dvd VALUES (@IdDoc, @Synopsis, @Realisateur, @Duree)";

                DAOFactory.connecter();

                MySqlCommand command = new MySqlCommand(req, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@IdDoc", pDVD.IdDoc);
                command.Parameters.AddWithValue("@Titre", pDVD.Titre);
                command.Parameters.AddWithValue("@IdPublic", pDVD.LaCategorie.Id);

                command.ExecuteNonQuery();

                command = new MySqlCommand(reqDVD, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@IdDoc", pDVD.IdDoc);
                command.Parameters.AddWithValue("@Synopsis", pDVD.Synopsis);
                command.Parameters.AddWithValue("@Realisateur", pDVD.Realisateur);
                command.Parameters.AddWithValue("@Duree", pDVD.Duree);

                command.ExecuteNonQuery();

                DAOFactory.deconnecter();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Supprime le dvd choisi de la base de données
        /// </summary>
        /// <param name="unDVD">Le DVD choisi</param>
        public static void SupprimerDVD(DVD unDVD)
        {
            try
            {
                string reqDVD = "DELETE FROM dvd WHERE idDocument = @IdDoc";
                string req = "DELETE FROM document WHERE id = @IdDoc";

                DAOFactory.connecter();

                MySqlCommand command = new MySqlCommand(reqDVD, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@IdDoc", unDVD.IdDoc);

                command.ExecuteNonQuery();

                command = new MySqlCommand(req, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@IdDoc", unDVD.IdDoc);

                command.ExecuteNonQuery();

                DAOFactory.deconnecter();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Met à jour le dvd choisi sur la base de données
        /// </summary>
        /// <param name="unDVD">Le DVD choisi</param>
        public static void ModifierDVD(DVD unDVD)
        {
            try
            {
                string req = "UPDATE document SET document.titre = @Titre, document.idPublic = @IdPublic WHERE id = @IdDoc";
                string reqDVD = "UPDATE dvd SET dvd.Synopsis = @Synopsis, dvd.réalisateur = @Realisateur, dvd.duree = @Duree WHERE idDocument = @IdDoc";

                DAOFactory.connecter();

                MySqlCommand command = new MySqlCommand(req, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@Titre", unDVD.Titre);
                command.Parameters.AddWithValue("@IdPublic", unDVD.LaCategorie.Id);
                command.Parameters.AddWithValue("@IdDoc", unDVD.IdDoc);

                command.ExecuteNonQuery();

                command = new MySqlCommand(reqDVD, DAOFactory.Connexion);
                command.Parameters.AddWithValue("@Synopsis", unDVD.Synopsis);
                command.Parameters.AddWithValue("@Realisateur", unDVD.Realisateur);
                command.Parameters.AddWithValue("@Duree", unDVD.Duree);
                command.Parameters.AddWithValue("@IdDoc", unDVD.IdDoc);

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

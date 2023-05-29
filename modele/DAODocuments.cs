using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace Mediateq_AP_SIO2
{
    class DAODocuments
    {
        public static string DocumentNumero()
        {
            //string req = "Select COUNT(*)+1 from document";
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

        //
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

        public static void AjouterDVD(DVD pDVD)
        {
            try
            {
                string req = "INSERT INTO document (id ,titre, idpublic) VALUES ('" + pDVD.IdDoc + "' , '" + pDVD.Titre + "' , '" + pDVD.LaCategorie.Id + "' ); ";
                string reqDVD = "INSERT INTO dvd VALUES ('" + pDVD.IdDoc + "' , '" + pDVD.Synopsis + "' , '" + pDVD.Realisateur + "' , " + pDVD.Duree + " ); ";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req);

                DAOFactory.execSQLWrite(reqDVD);

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static void SupprimerDVD(DVD unDVD)
        {
            try
            {
                string reqDVD = "DELETE FROM dvd WHERE idDocument = '" + unDVD.IdDoc + "'; ";
                string req = "DELETE FROM document WHERE id = '" + unDVD.IdDoc + "'; ";


                DAOFactory.connecter();

                DAOFactory.execSQLWrite(reqDVD);

                DAOFactory.execSQLWrite(req);

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static void ModifierDVD(DVD unDVD)
        {
            try
            {
                string req = "UPDATE document SET document.titre = '" + unDVD.Titre + "', document.idPublic = '" + unDVD.LaCategorie.Id + "' WHERE id = '" + unDVD.IdDoc + "'; ";
                string reqDVD = "UPDATE dvd SET dvd.Synopsis = '" + unDVD.Synopsis + "' , dvd.réalisateur = '" + unDVD.Realisateur + "' , dvd.duree = '" + unDVD.Duree + "' WHERE idDocument = '" + unDVD.IdDoc + "' ; ";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req);

                DAOFactory.execSQLWrite(reqDVD);

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}

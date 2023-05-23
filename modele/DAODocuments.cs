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
                string req = "Select l.idDocument, l.ISBN, l.auteur, d.titre, d.image, l.collection from livre l join document d on l.idDocument=d.id";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    // On ne renseigne pas le genre et la catégorie car on ne peut pas ouvrir 2 dataReader dans la même connexion
                    Livre livre = new Livre(reader[0].ToString(), reader[3].ToString(), reader[1].ToString(),
                        reader[2].ToString(), reader[5].ToString(), reader[4].ToString());
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

        public static Categorie getCategorieByLivre(Livre pLivre)
        {
            Categorie categorie;

            try
            {
                string req = "Select p.id,p.libelle from public p,document d where p.id = d.idPublic and d.id='";
                req += pLivre.IdDoc + "'";

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

        /*public static void AjouterLivre(Livre pLivre)
        {
            try
            {
                string req = "INSERT INTO document (id ,titre, idpublic) VALUES ('" + pLivre.IdDoc + "' , '" + pLivre.Titre + "' , '" + pLivre.LaCategorie.Id + "' ); ";
                string reqLivre = "INSERT INTO livre VALUES ('" + pLivre.IdDoc + "' , '" + pLivre.ISBN1 + "' , '" + pLivre.LaCollection + "' , '" + pLivre.Auteur.Id + "' ); ";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req);

                DAOFactory.execSQLWrite(reqLivre);

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }*/

        public static void SupprimerLivre(Livre unLivre)
        {
            try
            {
                string reqLivre = "DELETE FROM livre WHERE id = '" + unLivre.IdDoc + "'; ";
                string req = "DELETE FROM document WHERE id = '" + unLivre.IdDoc + "'; ";


                DAOFactory.connecter();

                DAOFactory.execSQLWrite(reqLivre);

                DAOFactory.execSQLWrite(req);

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }

        /*public static void ModifierLivre(Livre unLivre, String uneCateg)
        {
            try
            {
                string req = "UPDATE document SET document.titre = '" + unLivre.Titre + "', document.idPublic = '" + uneCateg + "' WHERE id = '" + unLivre.IdDoc + "'; ";
                string reqLivre = "UPDATE livre SET livre.ISBN = '" + unLivre.ISBN1 + "' , livre.id_auteur = '" + unLivre.Auteur.Id + "' , livre.collection  = '" + unLivre.LaCollection + "' WHERE id = '" + unLivre.IdDoc + "' ; ";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req);

                DAOFactory.execSQLWrite(reqLivre);

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }*/

        //
        public static List<DVD> getAllDVD()
        {
            List<DVD> lesDVD = new List<DVD>();

            try
            {
                string req = "Select dv.idDocument, dv.synopsis, dv.réalisateur, d.titre, d.image, dv.duree from dvd dv join document d on dv.idDocument=d.id";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);

                while (reader.Read())
                {
                    // On ne renseigne pas le genre et la catégorie car on ne peut pas ouvrir 2 dataReader dans la même connexion
                    DVD dvd = new DVD(reader[0].ToString(), reader[3].ToString(), reader[1].ToString(),
                        reader[2].ToString(), int.Parse(reader[5].ToString()), reader[4].ToString());
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

        public static Categorie getCategorieByDVD(DVD pDVD)
        {
            Categorie categorie;

            try
            {
                string req = "Select p.id,p.libelle from public p,document d where p.id = d.idPublic and d.id='";
                req += pDVD.IdDoc + "'";

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

        public static void AjouterDVD(DVD pDVD, string choixPublic)
        {
            try
            {
                string req = "INSERT INTO document (id ,titre, idpublic) VALUES ('" + pDVD.IdDoc + "' , '" + pDVD.Titre + "' , '" + choixPublic + "' ); ";
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
                string reqLivre = "DELETE FROM dvd WHERE idDocument = '" + unDVD.IdDoc + "'; ";
                string req = "DELETE FROM document WHERE id = '" + unDVD.IdDoc + "'; ";


                DAOFactory.connecter();

                DAOFactory.execSQLWrite(reqLivre);

                DAOFactory.execSQLWrite(req);

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static void ModifierDVD(DVD unDVD, string uneCateg)
        {
            try
            {
                string req = "UPDATE document SET document.titre = '" + unDVD.Titre + "', document.idPublic = '" + uneCateg + "' WHERE id = '" + unDVD.IdDoc + "'; ";
                string reqLivre = "UPDATE dvd SET dvd.Synopsis = '" + unDVD.Synopsis + "' , dvd.réalisateur = '" + unDVD.Realisateur + "' , dvd.duree = '" + unDVD.Duree + "' WHERE id = '" + unDVD.IdDoc + "' ; ";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req);

                DAOFactory.execSQLWrite(reqLivre);

                DAOFactory.deconnecter();
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}

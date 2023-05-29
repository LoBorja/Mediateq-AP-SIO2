using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Objet Abonné
    /// </summary>
    public class Abonne
    {
        private string id;
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private string adresse;
        private string numTel;
        private string typeAbonnement;
        private DateTime finAbonnement;
        private string mailU;

        /// <summary>
        /// Constructeur Abonne
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="dateNaissance"></param>
        /// <param name="adresse"></param>
        /// <param name="numTel"></param>
        /// <param name="typeAbonnement"></param>
        /// <param name="finAbonnement"></param>
        /// <param name="mailU"></param>
        public Abonne(string id, string nom, string prenom, DateTime dateNaissance, string adresse, string numTel, string typeAbonnement, DateTime finAbonnement, string mailU)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaissance = dateNaissance;
            this.adresse = adresse;
            this.numTel = numTel;
            this.typeAbonnement = typeAbonnement;
            this.finAbonnement = finAbonnement;
            this.mailU = mailU;
        }

        /// <summary>
        /// getter setter Id
        /// </summary>
        public string Id { get => id; set => id = value; }

        /// <summary>
        /// getter setter Nom
        /// </summary>
        public string Nom { get => nom; set => nom = value; }

        /// <summary>
        /// getter setter Prenom
        /// </summary>
        public string Prenom { get => prenom; set => prenom = value; }

        /// <summary>
        /// getter setter Date de Naissance
        /// </summary>
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }

        /// <summary>
        /// getter setter Adresse
        /// </summary>
        public string Adresse { get => adresse; set => adresse = value; }

        /// <summary>
        /// getter setter Numéro de téléphone
        /// </summary>
        public string NumTel { get => numTel; set => numTel = value; }

        /// <summary>
        /// getter setter Type d'abonnement
        /// </summary>
        public string TypeAbonnement { get => typeAbonnement; set => typeAbonnement = value; }

        /// <summary>
        /// getter setter Date de fin d'abonnement
        /// </summary>
        public DateTime FinAbonnement { get => finAbonnement; set => finAbonnement = value; }

        /// <summary>
        /// getter setter Mail de l'abonné
        /// </summary>
        public string MailU { get => mailU; set => mailU = value; }
    }
}

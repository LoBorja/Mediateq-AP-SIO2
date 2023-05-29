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

        public string Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string NumTel { get => numTel; set => numTel = value; }
        public string TypeAbonnement { get => typeAbonnement; set => typeAbonnement = value; }
        public DateTime FinAbonnement { get => finAbonnement; set => finAbonnement = value; }
        public string MailU { get => mailU; set => mailU = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Objet Utilisateur, nécessaire à l'authentification sur l'application
    /// </summary>
    public class Utilisateur
    {
        private int id;
        private string login;
        private string nom;
        private string prenom;
        private int idService;

        public Utilisateur(int id, string login, string nom, string prenom, int idService)
        {
            this.id = id;
            this.login = login;
            this.nom = nom;
            this.prenom = prenom;
            this.idService = idService;
        }

        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public int IDService { get => idService; set => idService = value; }


    }
}

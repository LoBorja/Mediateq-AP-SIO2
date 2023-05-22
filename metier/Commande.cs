using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    class Commande
    {
        private string id;
        private int nbExemplaires;
        private DateTime dateCommande;
        private int montant;
        private Document document;
        private string status;

        public Commande(string id, int nbExemplaires, DateTime dateCommande, int montant, Document document, string status)
        {
            this.id = id;
            this.nbExemplaires = nbExemplaires;
            this.dateCommande = dateCommande;
            this.montant = montant;
            this.document = document;
            this.status = status;
        }

        public string Id { get => id; set => id = value; }
        public int NbExemplaires { get => nbExemplaires; set => nbExemplaires = value; }
        public DateTime DateCommande { get => dateCommande; set => dateCommande = value; }
        public int Montant { get => montant; set => montant = value; }
        public Document Document { get => document; set => document = value; }
        public string Status { get => status; set => status = value; }
        
    }
}



namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Objet Livre, hériter de Document
    /// </summary>
    class Livre : Document
    {
        private string ISBN;
        private string auteur;
        private string laCollection;

        public Livre(string unId, string unTitre, string unISBN, string  unAuteur, string uneCollection, string uneImage, Categorie uneCategorie) : base(unId, unTitre, uneImage, uneCategorie)
        {
            ISBN1 = unISBN;
            Auteur = unAuteur;
            LaCollection = uneCollection;
        }

        public string ISBN1 { get => ISBN; set => ISBN = value; }
        public string Auteur { get => auteur; set => auteur = value; }
        public string LaCollection { get => laCollection; set => laCollection = value; }
    }
}

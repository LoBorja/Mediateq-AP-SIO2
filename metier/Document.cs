using System.Collections.Generic;

namespace Mediateq_AP_SIO2.metier
{
    class Document
    {
        private string idDoc;
        private string titre;
        private string image;
        private Categorie laCategorie;
        private List<Descripteur> lesDescripteurs;

        public Document(string unId, string unTitre, string uneImage, Categorie uneCategorie)
        {
            idDoc = unId;
            titre = unTitre;
            image = uneImage;
            laCategorie = uneCategorie;
        }


        public string IdDoc { get => idDoc; set => idDoc = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Image { get => image; set => image = value; }
        public Categorie LaCategorie { get => laCategorie; set => laCategorie = value; }
    }


}

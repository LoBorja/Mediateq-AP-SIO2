using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Mediateq_AP_SIO2.divers;
using Mediateq_AP_SIO2.metier;


namespace Mediateq_AP_SIO2
{   
    /// <summary>
    /// Fenêtre principale de l'application
    /// </summary>
    public partial class FrmMediateq : Form
    {
        #region Variables globales
        /// <summary>
        /// Variables globales, listes d'objets
        /// </summary>
        static List<Categorie> lesCategories;
        static List<Descripteur> lesDescripteurs;
        static List<Revue> lesRevues;
        static List<Livre> lesLivres;
        static List<DVD> lesDVDs;
        static List<Abonne> lesAbonnes;
        static List<Commande> lesCommandes;
        static List<EtatSuivi> lesEtatSuivi;


        /// <summary>
        /// Objet Utilisateur correspondant à l'utilisateur connecté
        /// </summary>
        public Utilisateur user { get; set; }

        #endregion


        #region Procédures évènementielles

        /// <summary>
        /// Constructeur de la classe de l'application principale.
        /// </summary>
        /// <param name="utilisateur">Objet utilisateur envoyé depuis le formulaire de connexion</param>
        public FrmMediateq(Utilisateur utilisateur)
        {
            InitializeComponent();
            user = utilisateur;
        }

        /// <summary>
        /// Fermeture des pages selon le role utilisateur et récupération de certaines données.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMediateq_Load(object sender, EventArgs e)
        {
            if (user.IDService != 0)
            {
                tabOngletsApplication.TabPages.Remove(abonneGestion);
                tabOngletsApplication.TabPages.Remove(tabCommandes);
            }
            else
            {
                optionsLivre.Visible = true;
                optionsDVD.Visible = true;

                commanderLivre.Visible = true;
                commanderDVD.Visible = true;

                cbxDVDPublic.Visible = true;
                cbxLivrePublic.Visible = true;
                txtDVDPublic.Visible = false;
                txtLivrePublic.Visible = false;

                txtDVDDuree.Visible = false;
                numericUDDVD.Visible = true;

                dvdSupprimer.Visible = true;
                livreSupprimer.Visible = true;

                txtLivreISBN.ReadOnly = false;
                txtLivreCollection.ReadOnly = false;
                txtLivreAuteur.ReadOnly = false;
                txtLivrePublic.ReadOnly = false;
                txtLivreTitre.ReadOnly = false;

                txtDVDTitre.ReadOnly = false;
                txtDVDSynopsis.ReadOnly = false;
                txtDVDRealisateur.ReadOnly = false;
                txtDVDDuree.ReadOnly = false;
                txtDVDPublic.ReadOnly = false;
            }

            try
            {
                // Création de la connexion avec la base de données
                DAOFactory.creerConnection();

                // Chargement des objets en mémoire
                lesDescripteurs = DAODocuments.getAllDescripteurs();
                lesRevues = DAOPresse.getAllRevues();
                lesEtatSuivi = DAOCommande.getAllEtatSuivi();
            }
            catch (ExceptionSIO exc)
            {
                MessageBox.Show(exc.NiveauExc + " - " + exc.LibelleExc + " - " + exc.Message);
            }
        }

        #endregion


        #region Parutions
        //-----------------------------------------------------------
        // ONGLET "PARUTIONS"
        //------------------------------------------------------------
        /// <summary>
        /// Mise en places des données dans le combobox Titres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabParutions_Enter(object sender, EventArgs e)
        {
            cbxTitres.DataSource = lesRevues;
            cbxTitres.DisplayMember = "titre";
        }

        /// <summary>
        /// Changement de l'affichage lors de la selection d'un titre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTitres_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Parution> lesParutions;

            Revue titreSelectionne = (Revue)cbxTitres.SelectedItem;
            lesParutions = DAOPresse.getParutionByTitre(titreSelectionne);

            // ré-initialisation du dataGridView
            dgvParutions.Rows.Clear();

            // Parcours de la collection des titres et alimentation du datagridview
            foreach (Parution parution in lesParutions)
            {
                dgvParutions.Rows.Add(parution.Numero, parution.DateParution, parution.Photo);
            }

        }
        #endregion


        #region Revues
        //-----------------------------------------------------------
        // ONGLET "TITRES"
        //------------------------------------------------------------
        /// <summary>
        /// Mise en place des données dans le combobox Descripteurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabTitres_Enter(object sender, EventArgs e)
        {
            cbxDomaines.DataSource = lesDescripteurs;
            cbxDomaines.DisplayMember = "libelle";
        }

        /// <summary>
        /// Changements de l'affichage des revues lors de la selection d'un Descripteur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDomaines_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Objet Domaine sélectionné dans la comboBox
            Descripteur domaineSelectionne = (Descripteur)cbxDomaines.SelectedItem;

            // ré-initialisation du dataGridView
            dgvTitres.Rows.Clear();

            // Parcours de la collection des titres et alimentation du datagridview
            foreach (Revue revue in lesRevues)
            {
                if (revue.IdDescripteur == domaineSelectionne.Id)
                {
                    dgvTitres.Rows.Add(revue.Id, revue.Titre, revue.Empruntable, revue.DateFinAbonnement, revue.DelaiMiseADispo);
                }
            }
        }
        #endregion


        #region Livres
        //-----------------------------------------------------------
        // ONGLET "LIVRES"
        //-----------------------------------------------------------
        /// <summary>
        /// Récupérations des données Categories, Descripteurs et Livres de la BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabLivres_Enter(object sender, EventArgs e)
        {
            // Chargement des objets en mémoire
            lesCategories = DAODocuments.getAllCategories();
            lesDescripteurs = DAODocuments.getAllDescripteurs();
            lesLivres = DAODocuments.getAllLivres();

            livreRemplirDataGrid();

            cbxLivrePublic.DataSource = lesCategories;
            cbxLivrePublic.DisplayMember = "libelle";
            cbxLivrePublic.ValueMember = null;

            resetChampsLivre();
        }

        /// <summary>
        /// Changement de l'affichage lors de la recherche par numéro de Livre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLivreRecherche_Click(object sender, EventArgs e)
        {
            // On réinitialise les labels
            txtLivreNum.Text = "";
            txtLivreTitre.Text = "";
            txtLivreAuteur.Text = "";
            txtLivreCollection.Text = "";
            txtLivreISBN.Text = "";
            txtLivrePublic.Text = "";
            cbxLivrePublic.SelectedIndex = 0;

            // On recherche le livre correspondant au numéro de document saisi.
            // S'il n'existe pas: on affiche un popup message d'erreur
            bool trouve = false;
            foreach (Livre livre in lesLivres)
            {
                if (livre.IdDoc == txtLivreRechercheParNum.Text)
                {
                    txtLivreNum.Text = livre.IdDoc;
                    txtLivreTitre.Text = livre.Titre;
                    txtLivreAuteur.Text = livre.Auteur;
                    txtLivreCollection.Text = livre.LaCollection;
                    txtLivreISBN.Text = livre.ISBN1;
                    txtLivrePublic.Text = livre.LaCategorie.Libelle;
                    cbxLivrePublic.Text = livre.LaCategorie.Libelle;

                    trouve = true;

                    btnLivreUpdate.Enabled = true;
                    btnLivreNew.Enabled = false;
                }
            }
            if (!trouve)
                MessageBox.Show("Document non trouvé dans les livres");
        }

        /// <summary>
        /// Création d'un nouveau objet Livre selon les informations entrées dans les champs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLivreNew_Click(object sender, EventArgs e)
        {
            string numero = DAODocuments.DocumentNumero();
            string titre = txtLivreTitre.Text;
            string ISBN = txtLivreISBN.Text;
            string collection = txtLivreCollection.Text;
            string auteur  = txtLivreAuteur.Text;
            Categorie choixPublic = categorieParLibelle(cbxLivrePublic.Text);

            Livre newLivre = new Livre(numero, titre, ISBN, auteur, collection, "", choixPublic);

            DAODocuments.AjouterLivre(newLivre);

            lesLivres.Add(newLivre);

            livreRemplirDataGrid();

            resetChampsLivre();
        }

        /// <summary>
        /// Mise à jour du livre correspond au numéro séléctioné, selon les informations entrées dans les champs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLivreUpdate_Click(object sender, EventArgs e)
        {
            Livre livreModifie = rechercherLivreParId(txtLivreNum.Text);

            livreModifie.Titre = txtLivreTitre.Text;
            livreModifie.ISBN1 = txtLivreISBN.Text;
            livreModifie.Auteur = txtLivreAuteur.Text;
            livreModifie.LaCollection = txtLivreCollection.Text;
            livreModifie.LaCategorie = categorieParLibelle(cbxLivrePublic.Text);

            DAODocuments.ModifierLivre(livreModifie);

            livreRemplirDataGrid();

            resetChampsLivre();
        }

        /// <summary>
        /// Réinitialisation des champs de saisie et du numéro de Livre séléctioné lorsque l'utilisateur appuie sur le bouton de rénitialisation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLivreReset_Click(object sender, EventArgs e)
        {
            resetChampsLivre();
        }

        /// <summary>
        /// Changement de l'affichage lorsque l'utilisateur écrit un titre dans le champs de recherche par Titre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbTitre_TextChanged(object sender, EventArgs e)
        {
            dgvLivres.Rows.Clear();

            // On parcourt tous les livres. Si le titre matche avec la saisie, on l'affiche dans le datagrid.
            foreach (Livre livre in lesLivres)
            {
                // on passe le champ de saisie et le titre en minuscules car la méthode Contains
                // tient compte de la casse.
                string saisieMinuscules;
                saisieMinuscules = txtLivreRechercheParTitre.Text.ToLower();
                string titreMinuscules;
                titreMinuscules = livre.Titre.ToLower();

                //on teste si le titre du livre contient ce qui a été saisi
                if (titreMinuscules.Contains(saisieMinuscules))
                {
                    dgvLivres.Rows.Add(livre.IdDoc, livre.Titre, livre.Auteur, livre.ISBN1, livre.LaCollection);
                }
            }
        }

        /// <summary>
        /// Remet à zéro les champs de saisie, le numéro de Livre séléctionné et les permessions de boutons d'option
        /// </summary>
        private void resetChampsLivre()
        {
            txtLivreNum.Text = "Nouveau";
            txtLivreTitre.Text = "";
            txtLivreISBN.Text = "";
            txtLivreCollection.Text = "";
            txtLivreAuteur.Text = "";
            txtLivrePublic.Text = "";
            cbxLivrePublic.SelectedIndex = 0;

            btnLivreNew.Enabled = true;
            btnLivreUpdate.Enabled = false;
        }

        /// <summary>
        /// Fonction du bouton supprimer présent sur le tableau des Livres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvLivre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ligne = dgvLivres.Rows[e.RowIndex];

                Livre unLivre = rechercherLivreParId(ligne.Cells[0].Value.ToString());

                if (dgvLivres.Columns[e.ColumnIndex].Name == "livreSupprimer")
                {
                    if (MessageBox.Show("Voulez vous supprimer le livre numéro °" + unLivre.IdDoc + " " + unLivre.Titre + " ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DAODocuments.SupprimerLivre(unLivre);

                        dgvLivres.Rows.Remove(ligne);

                        lesLivres.Remove(unLivre);
                    }
                }
            }
        }
        
        /// <summary>
        /// Remplis le tableau des Livres présents sur la BDD
        /// </summary>
        private void livreRemplirDataGrid()
        {
            dgvLivres.Rows.Clear();

            foreach (Livre livre in lesLivres)
            {
                dgvLivres.Rows.Add(livre.IdDoc, livre.Titre, livre.Auteur, livre.ISBN1, livre.LaCollection);
            }
        }

        /// <summary>
        /// Activation du bouton de commande d'un Livre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLivreOrder_Click(object sender, EventArgs e)
        {
            int nombreExemplaires = Convert.ToInt32(livreCommandeNbSelect.Value);
            decimal prix = livreCommandePrixSelect.Value;

            Livre unLivre = rechercherLivreParId(txtLivreNum.Text);

            if (unLivre == null)
            {
                MessageBox.Show("Aucun livre n'est séléctionné");
                return;
            }
            else if (nombreExemplaires == 0)
            {
                MessageBox.Show("Une commande doit contenir aumoins un exemplaire");
                return;
            }

            decimal leMontant = nombreExemplaires * prix;

            if (MessageBox.Show("Voulez vous commander " + nombreExemplaires + " exemplaires du livre numéro °" + unLivre.IdDoc + " " + unLivre.Titre + " pour un montant total de " + leMontant + " ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string idCommande = DAOCommande.commandeNumero();

                Commande nouvelleCommande = new Commande(idCommande, nombreExemplaires, DateTime.Today, leMontant, unLivre, lesEtatSuivi[0]);

                DAOCommande.ajouterCommande(nouvelleCommande);
            }
        }

        /// <summary>
        /// Recherche un objet Livre avec un Id
        /// </summary>
        /// <param name="unId">Id du Livre</param>
        /// <returns>Objet Livre correspondant</returns>
        private Livre rechercherLivreParId(string unId)
        {
            Livre unLivre = null;
            foreach (Livre liv in lesLivres)
            {
                if (liv.IdDoc == unId)
                {
                    unLivre = liv;
                }
            }

            return unLivre;
        }

        #endregion


        #region DVD
        //-----------------------------------------------------------
        // ONGLET "DVD"
        //-----------------------------------------------------------
        /// <summary>
        /// Récupération des données Catégorie,Descripteurs et DVD et alimentation du tableau et des comboboxs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabDVD_Enter(object sender, EventArgs e)
        {
            // Chargement des objets en mémoire
            lesCategories = DAODocuments.getAllCategories();
            lesDescripteurs = DAODocuments.getAllDescripteurs();
            lesDVDs = DAODocuments.getAllDVD();

            dvdRemplirDataGrid();

            cbxDVDPublic.DataSource = lesCategories;
            cbxDVDPublic.DisplayMember = "libelle";
            cbxDVDPublic.ValueMember = null;

            resetChampsDVD();
        }

        /// <summary>
        /// Affichage du DVD recherché après utilisation du bouton Recherche par Numéro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDVDRecherche_Click(object sender, EventArgs e)
        {
            // On réinitialise les labels
            txtDVDNum.Text = "";
            txtDVDTitre.Text = "";
            txtDVDRealisateur.Text = "";
            txtDVDDuree.Text = "";
            txtDVDSynopsis.Text = "";
            txtDVDPublic.Text = "";
            cbxDVDPublic.SelectedIndex = 0;

            // On recherche le livre correspondant au numéro de document saisi.
            // S'il n'existe pas: on affiche un popup message d'erreur
            bool trouve = false;
            foreach (DVD dvd in lesDVDs)
            {
                if (dvd.IdDoc == txtDVDRechercheParNum.Text)
                {
                    txtDVDNum.Text = dvd.IdDoc;
                    txtDVDTitre.Text = dvd.Titre;
                    txtDVDRealisateur.Text = dvd.Realisateur;
                    txtDVDDuree.Text = dvd.Duree.ToString();
                    numericUDDVD.Value = dvd.Duree;
                    txtDVDSynopsis.Text = dvd.Synopsis;
                    txtDVDPublic.Text = dvd.LaCategorie.Libelle;
                    cbxDVDPublic.Text = dvd.LaCategorie.Libelle;
                    trouve = true;

                    btnDVDUpdate.Enabled = true;
                    btnDVDNew.Enabled = false;
                }
            }
            if (!trouve) 
                MessageBox.Show("Document non trouvé dans les dvds");
        }

        /// <summary>
        /// Affichage du tableau lorsque l'utilisateur écris sur la barre de recherche par Titre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDVDRechercheParTitre_TextChanged(object sender, EventArgs e)
        {
            dataGridDVD.Rows.Clear();

            // On parcourt tous les livres. Si le titre matche avec la saisie, on l'affiche dans le datagrid.
            foreach (DVD dvd in lesDVDs)
            {
                // on passe le champ de saisie et le titre en minuscules car la méthode Contains
                // tient compte de la casse.
                string saisieMinuscules;
                saisieMinuscules = txtDVDRechercheParTitre.Text.ToLower();
                string titreMinuscules;
                titreMinuscules = dvd.Titre.ToLower();

                //on teste si le titre du livre contient ce qui a été saisi
                if (titreMinuscules.Contains(saisieMinuscules))
                {
                    dataGridDVD.Rows.Add(dvd.IdDoc, dvd.Titre, dvd.Synopsis, dvd.Realisateur, dvd.Duree.ToString());
                }
            }
        }

        /// <summary>
        /// Création d'un nouveau DVD selon les champs d'information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDVDNew_Click(object sender, EventArgs e)
        {
            string numero = DAODocuments.DocumentNumero();
            string titre = txtDVDTitre.Text;
            string synopsis = txtDVDSynopsis.Text;
            string realisateur = txtDVDRealisateur.Text;
            int duree = Decimal.ToInt16(numericUDDVD.Value);
            Categorie choixPublic = categorieParLibelle(cbxDVDPublic.Text);

            DVD newDVD = new DVD(numero, titre, synopsis, realisateur, duree, "", choixPublic);

            DAODocuments.AjouterDVD(newDVD);

            lesDVDs.Add(newDVD);

            dvdRemplirDataGrid();

            resetChampsDVD();
        }

        /// <summary>
        /// Mise à jour d'un DVD selon les champs d'information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDVDUpdate_Click(object sender, EventArgs e)
        {
            DVD dvdModifie = rechercherDVDparId(txtDVDNum.Text);

            dvdModifie.Titre = txtDVDTitre.Text;
            dvdModifie.Synopsis = txtDVDSynopsis.Text;
            dvdModifie.Duree = Decimal.ToInt16(numericUDDVD.Value);
            dvdModifie.Realisateur = txtDVDRealisateur.Text;
            dvdModifie.LaCategorie = categorieParLibelle(cbxDVDPublic.Text);

            DAODocuments.ModifierDVD(dvdModifie);

            dvdRemplirDataGrid();

            resetChampsDVD();
        }

        /// <summary>
        /// Mise à jour des champs de saisie, et du numéro de DVD, par le bouton Rénitialiser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDVDReset_Click(object sender, EventArgs e)
        {
            resetChampsDVD();
        }

        /// <summary>
        /// Fonction des boutons de suppression du tableau de DVD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridDVD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ligne = dataGridDVD.Rows[e.RowIndex];

                DVD unDvd = rechercherDVDparId(ligne.Cells[0].Value.ToString());

                if (dataGridDVD.Columns[e.ColumnIndex].Name == "dvdSupprimer")
                {
                    if (MessageBox.Show("Voulez vous supprimer le dvd numéro °" + unDvd.IdDoc + " " + unDvd.Titre + " ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DAODocuments.SupprimerDVD(unDvd);

                        dataGridDVD.Rows.Remove(ligne);

                        lesDVDs.Remove(unDvd);
                    }
                }
            }
        }

        /// <summary>
        /// Remplissage du tableau de DVD
        /// </summary>
        private void dvdRemplirDataGrid()
        {
            dataGridDVD.Rows.Clear();

            foreach (DVD dvd in lesDVDs)
            {
                dataGridDVD.Rows.Add(dvd.IdDoc, dvd.Titre, dvd.Synopsis, dvd.Realisateur, dvd.Duree.ToString());
            }
        }

        /// <summary>
        /// Remise à zéro des champs de saisie, du numéro de DVD et des permissions de boutons
        /// </summary>
        private void resetChampsDVD()
        {
            txtDVDNum.Text = "Nouveau";
            txtDVDTitre.Text = "";
            txtDVDSynopsis.Text = "";
            txtDVDRealisateur.Text = "";
            txtDVDDuree.Text = "";
            txtDVDPublic.Text = "";
            cbxDVDPublic.SelectedIndex = 0;
            numericUDDVD.Value = 00;

            btnDVDNew.Enabled = true;
            btnDVDUpdate.Enabled = false;
        }

        /// <summary>
        /// Commande d'un DVD, selon le montant et le nombre d'exemplaires inscrits dans les champs de commande
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDVDOrder_Click(object sender, EventArgs e)
        {
            int nombreExemplaires = Convert.ToInt32(dvdCommandeNbSelect.Value);
            decimal prix = dvdCommandePrixSelect.Value;

            DVD unDVD = rechercherDVDparId(txtDVDNum.Text);

            if (unDVD == null)
            {
                MessageBox.Show("Aucun DVD n'est séléctionné");
                return;
            }
            else if (nombreExemplaires == 0)
            {
                MessageBox.Show("Une commande doit contenir aumoins un exemplaire");
                return;
            }

            decimal leMontant = nombreExemplaires * prix;

            if (MessageBox.Show("Voulez vous commander " + nombreExemplaires + " exemplaires du DVD numéro °" + unDVD.IdDoc + " " + unDVD.Titre + " pour un montant total de " + leMontant + " ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string idCommande = DAOCommande.commandeNumero();

                Commande nouvelleCommande = new Commande(idCommande, nombreExemplaires, DateTime.Today, leMontant, unDVD, lesEtatSuivi[0]);

                DAOCommande.ajouterCommande(nouvelleCommande);
            }
        }

        /// <summary>
        /// Recherche d'objet DVD par Id
        /// </summary>
        /// <param name="unId">Id de DVD</param>
        /// <returns>Objet DVD correspondant</returns>
        private DVD rechercherDVDparId(string unId)
        {
            DVD unDvd = null;
            foreach(DVD dvd in lesDVDs)
            {
                if(dvd.IdDoc == unId)
                {
                    unDvd = dvd;
                }
            }

            return unDvd;
        }

        #endregion


        #region Commande
        //-----------------------------------------------------------
        // ONGLET "Commande"
        //-----------------------------------------------------------
        /// <summary>
        /// Récupération des données des Commandes et des Status de suivi et remplissage des tableaux et comboboxs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabCommandes_Enter(object sender, EventArgs e)
        {
            lesCommandes = DAOCommande.getAllCommandes();

            cbxFiltreCommande.Items.Add("tout afficher");

            foreach (EtatSuivi status in lesEtatSuivi)
            {
                cbxFiltreCommande.Items.Add(status.Libelle);
            }

            commandeRemplirDataGrid();
        }

        /// <summary>
        /// Affichage de commande selon l'Id inscrit par l'utilisateur dans la barre de recherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommandeRecherche_Click(object sender, EventArgs e)
        {
            bool trouve = false;
            foreach (Commande commande in lesCommandes)
            {
                if (commande.Id == txtCommandeRecherche.Text)
                {
                    setInfosCommande(commande);

                    trouve = true;
                }
            }
            if (!trouve)
                MessageBox.Show("Aucune commande ne correspond à cet Id.");
        }

        /// <summary>
        /// Modification de l'affichage du tableau de commandes lors de la séléction de filtre 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxFiltreCommande_SelectedIndexChanged(object sender, EventArgs e)
        {
            commandeRemplirDataGrid(cbxFiltreCommande.Text);
        }

        /// <summary>
        /// Affichage de la commande séléctionné via le bouton Modifier correspondant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridCommandes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ligne = dataGridCommandes.Rows[e.RowIndex];

                Commande commande = rechercherCommandeParId(ligne.Cells[0].Value.ToString());

                if (dataGridCommandes.Columns[e.ColumnIndex].Name == "commandeModifier")
                {
                    setInfosCommande(commande);
                }
            }
        }

        /// <summary>
        /// Modification du status de commande selon le status choisi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifStatusCommande_Click(object sender, EventArgs e)
        {
            Commande uneCommande = rechercherCommandeParId(txtIdCommande.Text);
            string nouveauStatus = cbxStatusCommande.Text;

            if (uneCommande == null)
            {
                MessageBox.Show("Aucune Commande n'est séléctionée");
                return;
            }
            else if (nouveauStatus == "") 
            {
                MessageBox.Show("Veuillez choisir un nouveau status pour procéder");
                return;
            }

            if (nouveauStatus == "supprimer")
            {
                if (MessageBox.Show("Voulez vous supprimer la commande n°" + uneCommande.Id + " du " + uneCommande.DateCommande.ToShortDateString() + " ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAOCommande.supprimerCommande(uneCommande);

                    lesCommandes.Remove(uneCommande);

                    commandeInfoReinitialiserChamps();
                }
            }
            else
            {
                if (MessageBox.Show("Voulez vous passer la commande n°" + uneCommande.Id + " du " + uneCommande.DateCommande.ToShortDateString() + " au status " + nouveauStatus + " ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    uneCommande.Status = rechercherStatusParLibelle(nouveauStatus);

                    DAOCommande.modifierCommande(uneCommande);

                    commandeInfoReinitialiserChamps();
                }
            }
        }

        /// <summary>
        /// Remplissage du tableau de commande selon le critère choisi, ou affichage complet si aucun critère choisi
        /// </summary>
        /// <param name="unStatut">Filtre séléctionné</param>
        private void commandeRemplirDataGrid(string unStatut = "tout afficher")
        {
            dataGridCommandes.Rows.Clear();

            if (unStatut == "tout afficher" || unStatut == "")
            {
                foreach (Commande com in lesCommandes)
                {
                    dataGridCommandes.Rows.Add(com.Id, com.NbExemplaires, com.DateCommande.ToShortDateString(), com.Montant, com.Document.IdDoc, com.Document.Titre, com.Status.Libelle, "Modifier");
                }
            }
            else
            {
                foreach (Commande com in lesCommandes)
                {
                    if (com.Status.Libelle == unStatut)
                    {
                        dataGridCommandes.Rows.Add(com.Id, com.NbExemplaires, com.DateCommande.ToShortDateString(), com.Montant, com.Document.IdDoc, com.Document.Titre, com.Status.Libelle, "Modifier");
                    }
                }
            }
        }

        /// <summary>
        /// Affichage des informations et du status correspondant, et des status possibles pour la modification
        /// </summary>
        /// <param name="uneCommande"></param>
        private void setInfosCommande(Commande uneCommande)
        {
            string libEnCours = lesEtatSuivi[0].Libelle;
            string libLivree = lesEtatSuivi[1].Libelle;
            string libRelancee = lesEtatSuivi[2].Libelle;
            string libReglee = lesEtatSuivi[3].Libelle;
            string libCloturee = lesEtatSuivi[4].Libelle;
            string supprimer = "supprimer";

            txtIdCommande.Text = uneCommande.Id;
            txtNbExCommande.Text = uneCommande.NbExemplaires.ToString();
            txtDateCommande.Text = uneCommande.DateCommande.ToShortDateString();
            txtMontantCommande.Text = uneCommande.Montant.ToString();
            txtIdDocCommande.Text = uneCommande.Document.IdDoc;
            txtNomDocCommande.Text = uneCommande.Document.Titre;
            txtActuelStatusCommande.Text = uneCommande.Status.Libelle;

            cbxStatusCommande.Items.Clear();

            switch (uneCommande.Status.Id)
            {
                case 1: // En Cours
                    cbxStatusCommande.Items.Add(libLivree);
                    cbxStatusCommande.Items.Add(libRelancee);
                    cbxStatusCommande.Items.Add(supprimer);
                    break;
                case 2: // Livrée
                    cbxStatusCommande.Items.Add(libReglee);
                    break;
                case 3: // Relancée
                    cbxStatusCommande.Items.Add(libLivree);
                    cbxStatusCommande.Items.Add(supprimer);
                    break;
                case 4: // Reglée
                    cbxStatusCommande.Items.Add(libCloturee);
                    break;
                case 5: // Cloturée
                    break;
            }
        }

        /// <summary>
        /// Remise à zéro des champs d'information et de status de commande
        /// </summary>
        private void commandeInfoReinitialiserChamps()
        {
            commandeRemplirDataGrid();

            txtIdCommande.Text = "";
            txtNbExCommande.Text = "";
            txtDateCommande.Text = "";
            txtMontantCommande.Text = "";
            txtIdDocCommande.Text = "";
            txtNomDocCommande.Text = "";
            txtActuelStatusCommande.Text = "";

            cbxStatusCommande.Items.Clear();
        }

        /// <summary>
        /// Recherche commande par Id
        /// </summary>
        /// <param name="unId">Id de commande</param>
        /// <returns>Objet Commande correspondant</returns>
        private Commande rechercherCommandeParId(string unId)
        {
            Commande uneCommande = null;

            foreach (Commande commande in lesCommandes)
            {
                if (commande.Id == unId)
                {
                    uneCommande = commande;
                }
            }

            return uneCommande;
        }

        /// <summary>
        /// Recherche de status par libelle
        /// </summary>
        /// <param name="unLibelle">Libelle de status</param>
        /// <returns>Objet EtatSuivi correspondant</returns>
        private EtatSuivi rechercherStatusParLibelle(string unLibelle)
        {
            EtatSuivi status = null;

            foreach (EtatSuivi unStatus in lesEtatSuivi)
            {
                if (unStatus.Libelle == unLibelle)
                {
                    status = unStatus;
                }
            }

            return status;
        }

        #endregion


        #region Abonnee
        /// <summary>
        /// Récupération des objets abonnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabAbonne_Enter(object sender, EventArgs e)
        {
            // Chargement des objets en mémoire
            lesAbonnes = DAOAbonne.getAllAbonne();

            btnAbonneUpdate.Enabled = false;

            abonneRemplirDataGrid();
        }

        /// <summary>
        /// Modification de l'affichage du tableau d'abonnés lorsque l'utilisateur écrit sur la barre de recherche par Nom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbAbonne_TextChanged(object sender, EventArgs e)
        {
            dataGridAbonne.Rows.Clear();

            int i = 0;

            foreach (Abonne abonne in lesAbonnes)
            {
                string saisieMinuscules;
                saisieMinuscules = abonneTxtBox.Text.ToLower();
                string titreMinuscules;
                titreMinuscules = abonne.Nom.ToLower();

                if (titreMinuscules.Contains(saisieMinuscules))
                {
                    TimeSpan differenceTemps = abonne.FinAbonnement - DateTime.Today;

                    if (abonneExpireCheck.Checked == false || differenceTemps.TotalDays >= 30)
                    {
                        dataGridAbonne.Rows.Add(abonne.Id, abonne.Nom, abonne.Prenom, abonne.Adresse, abonne.NumTel, abonne.MailU, abonne.DateNaissance.ToShortDateString(), abonne.TypeAbonnement, abonne.FinAbonnement.ToShortDateString(),"Modifier", "Supprimer");

                        abonneColoriserFin(i,differenceTemps);

                        i++;
                    }
                }
            }
        }

        /// <summary>
        /// Fonction des boutons de supression et de mise à jour d'abonnés sur le tableau d'abonné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridAbonne_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ligne = dataGridAbonne.Rows[e.RowIndex];

                Abonne unAbonne = rechercherAbonneParId(ligne.Cells[0].Value.ToString());

                if (dataGridAbonne.Columns[e.ColumnIndex].Name == "abonneDGVSupprimer")
                {
                    if (MessageBox.Show("Voulez vous supprimer l'abboné id " + unAbonne.Id + " " + unAbonne.Nom + " " + unAbonne.Prenom + " ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DAOAbonne.supprimerAbonne(unAbonne);

                        dataGridAbonne.Rows.Remove(ligne);

                        lesAbonnes.Remove(unAbonne);
                    }
                }
                else if (dataGridAbonne.Columns[e.ColumnIndex].Name == "abonneModifier")
                {
                    txtAbonneId.Text = unAbonne.Id;
                    txtAbonneNom.Text = unAbonne.Nom;
                    txtAbonnePrenom.Text = unAbonne.Prenom;
                    dtpAbonneNaissance.Value = unAbonne.DateNaissance;
                    txtAbonneAdresse.Text = unAbonne.Adresse;
                    txtAbonneTel.Text = unAbonne.NumTel;
                    txtTypeAbonnement.Text = unAbonne.TypeAbonnement;
                    dtpFinAbonnement.Value = unAbonne.FinAbonnement;
                    txtAbonneMail.Text = unAbonne.MailU;

                    btnAbonneUpdate.Enabled = true;
                    btnAbonneNew.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Met à jour le datagrid lorsque le filtre pour séléctionner les abonnements fini ou proche de la fin est activé ou désactivé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abonneExpireCheck_CheckedChanged(object sender, EventArgs e)
        {
            abonneRemplirDataGrid();
        }

        /// <summary>
        /// Création d'un nouvel Abonné selon les informations entrées dans les champs de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbonneNew_Click(object sender, EventArgs e)
        {
            string id = DAOAbonne.abonneNumero();
            string nom = txtAbonneNom.Text;
            string prenom = txtAbonnePrenom.Text;
            DateTime naissance = dtpAbonneNaissance.Value;
            string adresse = txtAbonneAdresse.Text;
            string numTel = txtAbonneTel.Text;
            string typeAbonnement = txtTypeAbonnement.Text;
            DateTime finAbonnement = dtpFinAbonnement.Value;
            string mail = txtAbonneMail.Text;

            Abonne nouvelAbonne = new Abonne(id,nom,prenom,naissance,adresse,numTel,typeAbonnement,finAbonnement,mail);

            DAOAbonne.ajouterAbonne(nouvelAbonne);

            lesAbonnes.Add(nouvelAbonne);

            abonneRemplirDataGrid();

            abonneResetChamps();
        }

        /// <summary>
        /// Mise à jour de l'Abonné séléctionné selon les informations entrées dans les champs de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbonneUpdate_Click(object sender, EventArgs e)
        {
            Abonne abonneModifie = rechercherAbonneParId(txtAbonneId.Text);

            abonneModifie.Nom = txtAbonneNom.Text;
            abonneModifie.Prenom = txtAbonnePrenom.Text;
            abonneModifie.DateNaissance = dtpAbonneNaissance.Value;
            abonneModifie.Adresse = txtAbonneAdresse.Text;
            abonneModifie.NumTel = txtAbonneTel.Text;
            abonneModifie.TypeAbonnement = txtTypeAbonnement.Text;
            abonneModifie.FinAbonnement = dtpFinAbonnement.Value;
            abonneModifie.MailU = txtAbonneMail.Text;


            DAOAbonne.modifierAbonne(abonneModifie);

            abonneRemplirDataGrid();

            btnAbonneUpdate.Enabled = false;
            btnAbonneNew.Enabled = true;
            abonneResetChamps();
        }

        /// <summary>
        /// Remise à zéro des champs de saisie d'abonné et des permissions de boutons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbonneReset_Click(object sender, EventArgs e)
        {
            btnAbonneUpdate.Enabled = false;
            btnAbonneNew.Enabled = true;
            abonneResetChamps();
        }

        /// <summary>
        /// Affichage de l'abonné recherché selon l'Id inscrit dans le champs de recherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbonneParId_Click(object sender, EventArgs e)
        {
            Abonne unAbonne = rechercherAbonneParId(txtAbonneParId.Text);

            if(unAbonne == null)
            {
                MessageBox.Show("Saisie incorrecte pour le numéro d'abonné");
                return;
            }

            txtAbonneId.Text = unAbonne.Id;
            txtAbonneNom.Text = unAbonne.Nom;
            txtAbonnePrenom.Text = unAbonne.Prenom;
            dtpAbonneNaissance.Value = unAbonne.DateNaissance;
            txtAbonneAdresse.Text = unAbonne.Adresse;
            txtAbonneTel.Text = unAbonne.NumTel;
            txtTypeAbonnement.Text = unAbonne.TypeAbonnement;
            dtpFinAbonnement.Value = unAbonne.FinAbonnement;
            txtAbonneMail.Text = unAbonne.MailU;

            btnAbonneUpdate.Enabled = true;
            btnAbonneNew.Enabled = false;
        }

        /// <summary>
        /// Remise à zéro des champs de saisie
        /// </summary>
        private void abonneResetChamps()
        {
            txtAbonneId.Text = "Nouveau";
            txtAbonneNom.Text = "";
            txtAbonnePrenom.Text = "";
            dtpAbonneNaissance.Value = DateTime.Today;
            txtAbonneAdresse.Text = "";
            txtAbonneTel.Text = "";
            txtTypeAbonnement.Text = "";
            dtpFinAbonnement.Value = DateTime.Today;
            txtAbonneMail.Text = "";
        }

        /// <summary>
        /// Remplissage du tableau d'abonnés
        /// </summary>
        private void abonneRemplirDataGrid()
        {
            dataGridAbonne.Rows.Clear();

            int i = 0;

            foreach (Abonne abonne in lesAbonnes)
            {
                TimeSpan differenceTemps = abonne.FinAbonnement - DateTime.Today;

                if (abonneExpireCheck.Checked == false || differenceTemps.TotalDays <= 30)
                {
                    dataGridAbonne.Rows.Add(abonne.Id, abonne.Nom, abonne.Prenom, abonne.Adresse, abonne.NumTel, abonne.MailU, abonne.DateNaissance.ToShortDateString(), abonne.TypeAbonnement, abonne.FinAbonnement.ToShortDateString(),"Modifier", "Supprimer");
                    abonneColoriserFin(i, differenceTemps);

                    i++;
                }
            }
        }

        /// <summary>
        /// Colorise les case de date d'abonnement sur le tableau abonné selon le temps restant pour l'abonnement
        /// </summary>
        /// <param name="indice">Numéro de ligne sur le tableau</param>
        /// <param name="diffTemps">Différence de temps entre aujourd'hui et la fin d'abonnement</param>
        private void abonneColoriserFin(int indice, TimeSpan diffTemps)
        {
            if(diffTemps.TotalDays < 0)
            {
                dataGridAbonne.Rows[indice].Cells[8].Style.BackColor = System.Drawing.Color.Red;
            } 
            else if (diffTemps.TotalDays < 30)
            {
                dataGridAbonne.Rows[indice].Cells[8].Style.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                dataGridAbonne.Rows[indice].Cells[8].Style.BackColor = System.Drawing.Color.LightGreen;
            }
        }

        /// <summary>
        /// Recherche d'abonné par Id
        /// </summary>
        /// <param name="idAbonne">Id d'Abonné</param>
        /// <returns>Objet abonné correspondant</returns>
        private Abonne rechercherAbonneParId(string idAbonne)
        {
            Abonne unAbonne = null;

            foreach(Abonne a in lesAbonnes)
            {
                if (a.Id == idAbonne) unAbonne = a;
            }

            return unAbonne;
        }

        #endregion


        #region Fonctions Supplémentaires 
        /// <summary>
        /// Recherche de Catégorie par Nom
        /// </summary>
        /// <param name="uneNomDeCategorie">Nom de catégorie</param>
        /// <returns>Objet catégorie correspondant</returns>
        private Categorie categorieParLibelle(string uneNomDeCategorie)
        {
            Categorie resultatCategorie = lesCategories[0];

            foreach(Categorie categ in lesCategories)
            {
                if (categ.Libelle == uneNomDeCategorie)
                {
                    resultatCategorie = categ;
                }
            }

            return resultatCategorie;
        }

        /// <summary>
        /// Fermeture de l'application entière lorsque la fênêtre principale est fermée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMediateq_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        #endregion
    }
}

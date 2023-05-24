using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Mediateq_AP_SIO2.divers;
using Mediateq_AP_SIO2.metier;


namespace Mediateq_AP_SIO2
{
    public partial class FrmMediateq : Form
    {
        #region Variables globales

        static List<Categorie> lesCategories;
        static List<Descripteur> lesDescripteurs;
        static List<Revue> lesRevues;
        static List<Livre> lesLivres;
        static List<DVD> lesDVDs;
        static List<Abonne> lesAbonnes;
        static List<Commande> lesCommandes;

        public Utilisateur user { get; set; }

        #endregion


        #region Procédures évènementielles

        public FrmMediateq(Utilisateur utilisateur)
        {
            InitializeComponent();
            user = utilisateur;
        }

        private void FrmMediateq_Load(object sender, EventArgs e)
        {
            if (user.IDService != 0)
            {
                tabOngletsApplication.TabPages.Remove(abonneGestion);
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
        private void tabParutions_Enter(object sender, EventArgs e)
        {
            cbxTitres.DataSource = lesRevues;
            cbxTitres.DisplayMember = "titre";
        }

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
        private void tabTitres_Enter(object sender, EventArgs e)
        {
            cbxDomaines.DataSource = lesDescripteurs;
            cbxDomaines.DisplayMember = "libelle";
        }

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

            btnLivreUpdate.Enabled = false;
        }

        private void btnRechercher_Click(object sender, EventArgs e)
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
                if (livre.IdDoc == txbNumDoc.Text)
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

        private void btnLivreReset_Click(object sender, EventArgs e)
        {
            resetChampsLivre();
        }

        private void txbTitre_TextChanged(object sender, EventArgs e)
        {
            dgvLivres.Rows.Clear();

            // On parcourt tous les livres. Si le titre matche avec la saisie, on l'affiche dans le datagrid.
            foreach (Livre livre in lesLivres)
            {
                // on passe le champ de saisie et le titre en minuscules car la méthode Contains
                // tient compte de la casse.
                string saisieMinuscules;
                saisieMinuscules = txbTitre.Text.ToLower();
                string titreMinuscules;
                titreMinuscules = livre.Titre.ToLower();

                //on teste si le titre du livre contient ce qui a été saisi
                if (titreMinuscules.Contains(saisieMinuscules))
                {
                    dgvLivres.Rows.Add(livre.IdDoc, livre.Titre, livre.Auteur, livre.ISBN1, livre.LaCollection);
                }
            }
        }

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

        private void livreRemplirDataGrid()
        {
            dgvLivres.Rows.Clear();

            foreach (Livre livre in lesLivres)
            {
                dgvLivres.Rows.Add(livre.IdDoc, livre.Titre, livre.Auteur, livre.ISBN1, livre.LaCollection);
            }
        }

        private void btnLivreOrder_Click(object sender, EventArgs e)
        {
            int nombreExemplaires = Convert.ToInt32(livreCommandeNbSelect.Value);
            double prix = Convert.ToDouble(livreCommandePrixSelect.Value);

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

            double leMontant = nombreExemplaires * prix;

            Commande nouvelleCommande = new Commande();


        }

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

            btnDVDUpdate.Enabled = false;
        }

        private void DVD_NUM_BUTTON_Click(object sender, EventArgs e)
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
                if (dvd.IdDoc == TXT_Search_NUM_DVD.Text)
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

        private void TXT_Search_Titre_DVD_TextChanged(object sender, EventArgs e)
        {
            DGV_DVD.Rows.Clear();

            // On parcourt tous les livres. Si le titre matche avec la saisie, on l'affiche dans le datagrid.
            foreach (DVD dvd in lesDVDs)
            {
                // on passe le champ de saisie et le titre en minuscules car la méthode Contains
                // tient compte de la casse.
                string saisieMinuscules;
                saisieMinuscules = TXT_Search_Titre_DVD.Text.ToLower();
                string titreMinuscules;
                titreMinuscules = dvd.Titre.ToLower();

                //on teste si le titre du livre contient ce qui a été saisi
                if (titreMinuscules.Contains(saisieMinuscules))
                {
                    DGV_DVD.Rows.Add(dvd.IdDoc, dvd.Titre, dvd.Synopsis, dvd.Realisateur, dvd.Duree.ToString());
                }
            }
        }

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

        private void btnDVDReset_Click(object sender, EventArgs e)
        {
            resetChampsDVD();
        }

        private void DGV_DVD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ligne = DGV_DVD.Rows[e.RowIndex];

                DVD unDvd = rechercherDVDparId(ligne.Cells[0].Value.ToString());

                if (DGV_DVD.Columns[e.ColumnIndex].Name == "dvdSupprimer")
                {
                    if (MessageBox.Show("Voulez vous supprimer le dvd numéro °" + unDvd.IdDoc + " " + unDvd.Titre + " ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DAODocuments.SupprimerDVD(unDvd);

                        DGV_DVD.Rows.Remove(ligne);

                        lesDVDs.Remove(unDvd);
                    }
                }
            }
        }

        private void dvdRemplirDataGrid()
        {
            DGV_DVD.Rows.Clear();

            foreach (DVD dvd in lesDVDs)
            {
                DGV_DVD.Rows.Add(dvd.IdDoc, dvd.Titre, dvd.Synopsis, dvd.Realisateur, dvd.Duree.ToString());
            }
        }

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

        /*#region AJOUT_DVD
        //-----------------------------------------------------------
        // ONGLET "Ajout dvd"
        //-----------------------------------------------------------

        private void tabADD_DVD_Enter(object sender, EventArgs e)
        {
            // Chargement des objets en mémoire
            lesCategories = DAODocuments.getAllCategories();
            lesDescripteurs = DAODocuments.getAllDescripteurs();
            lesDVDs = DAODocuments.getAllDVD();
        }

        private void VALID_DVD_Click(object sender, EventArgs e)
        {
            String numero = DAODocuments.DocumentNumero();
            String titre = ADD_DVD_Titre.Text;
            String synopsis = ADD_DVD_Synop.Text;
            String realisateur = ADD_DVD_Reali.Text;
            int duree = int.Parse(ADD_DVD_Duree.Text);
            String choixPublic = ADD_PUBLIC.Text.Substring(0, 5);

            DVD newDVD = new DVD(numero, titre, synopsis, realisateur, duree, null);

            DAODocuments.AjouterDVD(newDVD, choixPublic);
            ADD_DVD_Titre.Text = "";
            ADD_DVD_Synop.Text = "";
            ADD_DVD_Reali.Text = "";
            ADD_DVD_Duree.Text = "";
        }

        #endregion*/

        #region Commande

        private void tabCommandes_Enter(object sender, EventArgs e)
        {
            lesCommandes = DAOCommande.getAllCommandes();

            commandeRemplirDataGrid();
        }

        private void commandeRemplirDataGrid()
        {
            dataGridCommandes.Rows.Clear();

            foreach (Commande com in lesCommandes)
            {

                    dataGridCommandes.Rows.Add(com.Id, com.NbExemplaires, com.DateCommande.ToShortDateString(), com.Montant, com.Document.IdDoc, com.Document.Titre, com.Status.Libelle, "Modifier");
            }
        }

        #endregion

        #region Abonnee

        private void tabAbonne_Enter(object sender, EventArgs e)
        {
            // Chargement des objets en mémoire
            lesAbonnes = DAOAbonne.getAllAbonne();

            btnAbonneUpdate.Enabled = false;

            abonneRemplirDataGrid();
        }

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

        private void abonneExpireCheck_CheckedChanged(object sender, EventArgs e)
        {
            abonneRemplirDataGrid();
        }

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

            resetChamps();
        }

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
            resetChamps();
        }

        private void btnAbonneReset_Click(object sender, EventArgs e)
        {
            btnAbonneUpdate.Enabled = false;
            btnAbonneNew.Enabled = true;
            resetChamps();
        }

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

        private void resetChamps()
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

        private void FrmMediateq_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}

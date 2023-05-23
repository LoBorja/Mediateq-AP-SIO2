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
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            // On réinitialise les labels
            lblNumero.Text = "";
            lblTitre.Text = "";
            lblAuteur.Text = "";
            lblCollection.Text = "";
            lblISBN.Text = "";
            lblImage.Text = "";

            // On recherche le livre correspondant au numéro de document saisi.
            // S'il n'existe pas: on affiche un popup message d'erreur
            bool trouve = false;
            foreach (Livre livre in lesLivres)
            {
                if (livre.IdDoc == txbNumDoc.Text)
                {
                    lblNumero.Text = livre.IdDoc;
                    lblTitre.Text = livre.Titre;
                    lblAuteur.Text = livre.Auteur;
                    lblCollection.Text = livre.LaCollection;
                    lblISBN.Text = livre.ISBN1;
                    lblImage.Text = livre.Image;
                    trouve = true;
                }
            }
            if (!trouve)
                MessageBox.Show("Document non trouvé dans les livres");
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
        }

        private void DVD_NUM_BUTTON_Click(object sender, EventArgs e)
        {
            // On réinitialise les labels
            NUM_DVD_LAB.Text = "";
            TITRE_DVD_LABEL.Text = "";
            REA_DVD_LAB.Text = "";
            TIME_DVD_LAB.Text = "";
            SYP_DVD_LAB.Text = "";
            IMG_DVD_LAB.Text = "";

            // On recherche le livre correspondant au numéro de document saisi.
            // S'il n'existe pas: on affiche un popup message d'erreur
            bool trouve = false;
            foreach (DVD dvd in lesDVDs)
            {
                if (dvd.IdDoc == TXT_Search_NUM_DVD.Text)
                {
                    NUM_DVD_LAB.Text = dvd.IdDoc;
                    TITRE_DVD_LABEL.Text = dvd.Titre;
                    REA_DVD_LAB.Text = dvd.Realisateur;
                    TIME_DVD_LAB.Text = dvd.Duree.ToString();
                    SYP_DVD_LAB.Text = dvd.Synopsis;
                    IMG_DVD_LAB.Text = dvd.Image;
                    trouve = true;
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

        #endregion

        #region AJOUT_DVD
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

        #endregion

        #region Commande



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

        private void FrmMediateq_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}

﻿
namespace Mediateq_AP_SIO2
{
    partial class FrmMediateq
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabOngletsApplication = new System.Windows.Forms.TabControl();
            this.tabParutions = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvParutions = new System.Windows.Forms.DataGridView();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateParution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTitres = new System.Windows.Forms.ComboBox();
            this.tabTitres = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvTitres = new System.Windows.Forms.DataGridView();
            this.idTitre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empruntable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodicite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDomaines = new System.Windows.Forms.ComboBox();
            this.tabLivres = new System.Windows.Forms.TabPage();
            this.grpRechercheTitre = new System.Windows.Forms.GroupBox();
            this.dgvLivres = new System.Windows.Forms.DataGridView();
            this.idDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auteur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isbn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lacollection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.txbTitre = new System.Windows.Forms.TextBox();
            this.grpRechercheCode = new System.Windows.Forms.GroupBox();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txbNumDoc = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblAuteur = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCollection = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabDVD = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.DGV_DVD = new System.Windows.Forms.DataGridView();
            this.NUMERODVD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TITREDVD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SYPNOSIS_DVD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REALISATEUR_DVD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DUREE_DVD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TXT_Search_Titre_DVD = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.TIME_DVD_LAB = new System.Windows.Forms.Label();
            this.REA_DVD_LAB = new System.Windows.Forms.Label();
            this.SYP_DVD_LAB = new System.Windows.Forms.Label();
            this.IMG_DVD_LAB = new System.Windows.Forms.Label();
            this.TITRE_DVD_LABEL = new System.Windows.Forms.Label();
            this.NUM_DVD_LAB = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.DVD_NUM_BUTTON = new System.Windows.Forms.Button();
            this.TXT_Search_NUM_DVD = new System.Windows.Forms.TextBox();
            this.ADD_DVD = new System.Windows.Forms.TabPage();
            this.ADD_PUBLIC = new System.Windows.Forms.ComboBox();
            this.VALID_DVD = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ADD_DVD_Duree = new System.Windows.Forms.TextBox();
            this.ADD_DVD_Reali = new System.Windows.Forms.TextBox();
            this.ADD_DVD_Synop = new System.Windows.Forms.TextBox();
            this.ADD_DVD_Titre = new System.Windows.Forms.TextBox();
            this.tabCommandes = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.commandeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandeNbEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandeMontant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandeDocumentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandeNomDocument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandeModifier = new System.Windows.Forms.DataGridViewButtonColumn();
            this.abonneGestion = new System.Windows.Forms.TabPage();
            this.abonneExpireCheck = new System.Windows.Forms.CheckBox();
            this.abonneLabelSearch = new System.Windows.Forms.Label();
            this.abonneTxtBox = new System.Windows.Forms.TextBox();
            this.dataGridAbonne = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAbonneId = new System.Windows.Forms.TextBox();
            this.txtAbonneNom = new System.Windows.Forms.TextBox();
            this.txtAbonnePrenom = new System.Windows.Forms.TextBox();
            this.txtAbonneAdresse = new System.Windows.Forms.TextBox();
            this.txtAbonneTel = new System.Windows.Forms.TextBox();
            this.txtAbonneMail = new System.Windows.Forms.TextBox();
            this.dtpAbonneNaissance = new System.Windows.Forms.DateTimePicker();
            this.dtpFinAbonnement = new System.Windows.Forms.DateTimePicker();
            this.txtTypeAbonnement = new System.Windows.Forms.TextBox();
            this.btnAbonneNew = new System.Windows.Forms.Button();
            this.btnAbonneUpdate = new System.Windows.Forms.Button();
            this.btnAbonneReset = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.abonneId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonneNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonnePrenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonneAdresse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonneTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonneMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonneNais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonneTypeAbo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonneFinAbo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonneModifier = new System.Windows.Forms.DataGridViewButtonColumn();
            this.abonneDGVSupprimer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabOngletsApplication.SuspendLayout();
            this.tabParutions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParutions)).BeginInit();
            this.tabTitres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitres)).BeginInit();
            this.tabLivres.SuspendLayout();
            this.grpRechercheTitre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivres)).BeginInit();
            this.grpRechercheCode.SuspendLayout();
            this.tabDVD.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DVD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.ADD_DVD.SuspendLayout();
            this.tabCommandes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.abonneGestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAbonne)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabOngletsApplication
            // 
            this.tabOngletsApplication.Controls.Add(this.tabParutions);
            this.tabOngletsApplication.Controls.Add(this.tabTitres);
            this.tabOngletsApplication.Controls.Add(this.tabLivres);
            this.tabOngletsApplication.Controls.Add(this.tabDVD);
            this.tabOngletsApplication.Controls.Add(this.ADD_DVD);
            this.tabOngletsApplication.Controls.Add(this.tabCommandes);
            this.tabOngletsApplication.Controls.Add(this.abonneGestion);
            this.tabOngletsApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOngletsApplication.Location = new System.Drawing.Point(0, 0);
            this.tabOngletsApplication.Margin = new System.Windows.Forms.Padding(4);
            this.tabOngletsApplication.Name = "tabOngletsApplication";
            this.tabOngletsApplication.SelectedIndex = 0;
            this.tabOngletsApplication.Size = new System.Drawing.Size(1067, 676);
            this.tabOngletsApplication.TabIndex = 0;
            // 
            // tabParutions
            // 
            this.tabParutions.Controls.Add(this.label3);
            this.tabParutions.Controls.Add(this.dgvParutions);
            this.tabParutions.Controls.Add(this.label1);
            this.tabParutions.Controls.Add(this.cbxTitres);
            this.tabParutions.Location = new System.Drawing.Point(4, 25);
            this.tabParutions.Margin = new System.Windows.Forms.Padding(4);
            this.tabParutions.Name = "tabParutions";
            this.tabParutions.Padding = new System.Windows.Forms.Padding(4);
            this.tabParutions.Size = new System.Drawing.Size(1059, 647);
            this.tabParutions.TabIndex = 0;
            this.tabParutions.Text = "Parutions";
            this.tabParutions.UseVisualStyleBackColor = true;
            this.tabParutions.Enter += new System.EventHandler(this.tabParutions_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(217, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(403, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Visualisation des numéros reçus par titre";
            // 
            // dgvParutions
            // 
            this.dgvParutions.AllowUserToAddRows = false;
            this.dgvParutions.AllowUserToDeleteRows = false;
            this.dgvParutions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParutions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero,
            this.dateParution,
            this.photo});
            this.dgvParutions.Location = new System.Drawing.Point(117, 166);
            this.dgvParutions.Margin = new System.Windows.Forms.Padding(4);
            this.dgvParutions.Name = "dgvParutions";
            this.dgvParutions.RowHeadersWidth = 51;
            this.dgvParutions.Size = new System.Drawing.Size(724, 289);
            this.dgvParutions.TabIndex = 2;
            // 
            // numero
            // 
            this.numero.HeaderText = "NUMERO";
            this.numero.MinimumWidth = 6;
            this.numero.Name = "numero";
            this.numero.Width = 60;
            // 
            // dateParution
            // 
            this.dateParution.HeaderText = "DATE DE PARUTION";
            this.dateParution.MinimumWidth = 6;
            this.dateParution.Name = "dateParution";
            this.dateParution.Width = 140;
            // 
            // photo
            // 
            this.photo.HeaderText = "EMPLACEMENT PHOTO";
            this.photo.MinimumWidth = 6;
            this.photo.Name = "photo";
            this.photo.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choisir un titre :";
            // 
            // cbxTitres
            // 
            this.cbxTitres.FormattingEnabled = true;
            this.cbxTitres.Location = new System.Drawing.Point(251, 91);
            this.cbxTitres.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTitres.Name = "cbxTitres";
            this.cbxTitres.Size = new System.Drawing.Size(193, 24);
            this.cbxTitres.TabIndex = 0;
            this.cbxTitres.SelectedIndexChanged += new System.EventHandler(this.cbxTitres_SelectedIndexChanged);
            // 
            // tabTitres
            // 
            this.tabTitres.Controls.Add(this.label4);
            this.tabTitres.Controls.Add(this.dgvTitres);
            this.tabTitres.Controls.Add(this.label2);
            this.tabTitres.Controls.Add(this.cbxDomaines);
            this.tabTitres.Location = new System.Drawing.Point(4, 25);
            this.tabTitres.Margin = new System.Windows.Forms.Padding(4);
            this.tabTitres.Name = "tabTitres";
            this.tabTitres.Padding = new System.Windows.Forms.Padding(4);
            this.tabTitres.Size = new System.Drawing.Size(1059, 647);
            this.tabTitres.TabIndex = 1;
            this.tabTitres.Text = "Titres";
            this.tabTitres.UseVisualStyleBackColor = true;
            this.tabTitres.Enter += new System.EventHandler(this.tabTitres_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(244, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(318, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Visualisation des titres abonnés";
            // 
            // dgvTitres
            // 
            this.dgvTitres.AllowUserToAddRows = false;
            this.dgvTitres.AllowUserToDeleteRows = false;
            this.dgvTitres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTitres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTitre,
            this.nom,
            this.empruntable,
            this.dateFin,
            this.periodicite});
            this.dgvTitres.Location = new System.Drawing.Point(96, 171);
            this.dgvTitres.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTitres.Name = "dgvTitres";
            this.dgvTitres.RowHeadersWidth = 51;
            this.dgvTitres.Size = new System.Drawing.Size(831, 137);
            this.dgvTitres.TabIndex = 2;
            // 
            // idTitre
            // 
            this.idTitre.HeaderText = "NUMERO";
            this.idTitre.MinimumWidth = 6;
            this.idTitre.Name = "idTitre";
            this.idTitre.Width = 60;
            // 
            // nom
            // 
            this.nom.HeaderText = "TITRE";
            this.nom.MinimumWidth = 6;
            this.nom.Name = "nom";
            this.nom.Width = 200;
            // 
            // empruntable
            // 
            this.empruntable.HeaderText = "EMPRUNTABLE";
            this.empruntable.MinimumWidth = 6;
            this.empruntable.Name = "empruntable";
            this.empruntable.Width = 125;
            // 
            // dateFin
            // 
            this.dateFin.HeaderText = "FIN D\'ABONNEMENT";
            this.dateFin.MinimumWidth = 6;
            this.dateFin.Name = "dateFin";
            this.dateFin.Width = 140;
            // 
            // periodicite
            // 
            this.periodicite.HeaderText = "PERIODICITE";
            this.periodicite.MinimumWidth = 6;
            this.periodicite.Name = "periodicite";
            this.periodicite.Width = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choisir un domaine :";
            // 
            // cbxDomaines
            // 
            this.cbxDomaines.FormattingEnabled = true;
            this.cbxDomaines.Location = new System.Drawing.Point(277, 95);
            this.cbxDomaines.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDomaines.Name = "cbxDomaines";
            this.cbxDomaines.Size = new System.Drawing.Size(300, 24);
            this.cbxDomaines.TabIndex = 0;
            this.cbxDomaines.SelectedIndexChanged += new System.EventHandler(this.cbxDomaines_SelectedIndexChanged);
            // 
            // tabLivres
            // 
            this.tabLivres.Controls.Add(this.grpRechercheTitre);
            this.tabLivres.Controls.Add(this.grpRechercheCode);
            this.tabLivres.Location = new System.Drawing.Point(4, 25);
            this.tabLivres.Margin = new System.Windows.Forms.Padding(4);
            this.tabLivres.Name = "tabLivres";
            this.tabLivres.Size = new System.Drawing.Size(1059, 647);
            this.tabLivres.TabIndex = 2;
            this.tabLivres.Text = "Livres";
            this.tabLivres.UseVisualStyleBackColor = true;
            this.tabLivres.Enter += new System.EventHandler(this.tabLivres_Enter);
            // 
            // grpRechercheTitre
            // 
            this.grpRechercheTitre.Controls.Add(this.dgvLivres);
            this.grpRechercheTitre.Controls.Add(this.label6);
            this.grpRechercheTitre.Controls.Add(this.txbTitre);
            this.grpRechercheTitre.Location = new System.Drawing.Point(40, 309);
            this.grpRechercheTitre.Margin = new System.Windows.Forms.Padding(4);
            this.grpRechercheTitre.Name = "grpRechercheTitre";
            this.grpRechercheTitre.Padding = new System.Windows.Forms.Padding(4);
            this.grpRechercheTitre.Size = new System.Drawing.Size(964, 325);
            this.grpRechercheTitre.TabIndex = 18;
            this.grpRechercheTitre.TabStop = false;
            this.grpRechercheTitre.Text = "RECHERCHE PAR TITRE";
            // 
            // dgvLivres
            // 
            this.dgvLivres.AllowUserToAddRows = false;
            this.dgvLivres.AllowUserToDeleteRows = false;
            this.dgvLivres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLivres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDoc,
            this.titre,
            this.auteur,
            this.isbn,
            this.lacollection});
            this.dgvLivres.Location = new System.Drawing.Point(24, 76);
            this.dgvLivres.Margin = new System.Windows.Forms.Padding(4);
            this.dgvLivres.Name = "dgvLivres";
            this.dgvLivres.RowHeadersWidth = 51;
            this.dgvLivres.Size = new System.Drawing.Size(919, 222);
            this.dgvLivres.TabIndex = 4;
            // 
            // idDoc
            // 
            this.idDoc.HeaderText = "NUMERO";
            this.idDoc.MinimumWidth = 6;
            this.idDoc.Name = "idDoc";
            this.idDoc.Width = 60;
            // 
            // titre
            // 
            this.titre.HeaderText = "TITRE DU LIVRE";
            this.titre.MinimumWidth = 6;
            this.titre.Name = "titre";
            this.titre.Width = 200;
            // 
            // auteur
            // 
            this.auteur.HeaderText = "AUTEUR(E)";
            this.auteur.MinimumWidth = 6;
            this.auteur.Name = "auteur";
            this.auteur.Width = 125;
            // 
            // isbn
            // 
            this.isbn.HeaderText = "Code ISBN";
            this.isbn.MinimumWidth = 6;
            this.isbn.Name = "isbn";
            this.isbn.Width = 90;
            // 
            // lacollection
            // 
            this.lacollection.HeaderText = "COLLECTION";
            this.lacollection.MinimumWidth = 6;
            this.lacollection.Name = "lacollection";
            this.lacollection.Width = 200;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Saisir le titre ou la partie d\'un titre :";
            // 
            // txbTitre
            // 
            this.txbTitre.Location = new System.Drawing.Point(315, 22);
            this.txbTitre.Margin = new System.Windows.Forms.Padding(4);
            this.txbTitre.Name = "txbTitre";
            this.txbTitre.Size = new System.Drawing.Size(231, 22);
            this.txbTitre.TabIndex = 3;
            this.txbTitre.TextChanged += new System.EventHandler(this.txbTitre_TextChanged);
            // 
            // grpRechercheCode
            // 
            this.grpRechercheCode.Controls.Add(this.btnRechercher);
            this.grpRechercheCode.Controls.Add(this.lblTitre);
            this.grpRechercheCode.Controls.Add(this.lblImage);
            this.grpRechercheCode.Controls.Add(this.label5);
            this.grpRechercheCode.Controls.Add(this.label10);
            this.grpRechercheCode.Controls.Add(this.txbNumDoc);
            this.grpRechercheCode.Controls.Add(this.lblNumero);
            this.grpRechercheCode.Controls.Add(this.lblAuteur);
            this.grpRechercheCode.Controls.Add(this.lblISBN);
            this.grpRechercheCode.Controls.Add(this.label7);
            this.grpRechercheCode.Controls.Add(this.label11);
            this.grpRechercheCode.Controls.Add(this.lblCollection);
            this.grpRechercheCode.Controls.Add(this.label8);
            this.grpRechercheCode.Controls.Add(this.label12);
            this.grpRechercheCode.Controls.Add(this.label9);
            this.grpRechercheCode.Location = new System.Drawing.Point(40, 23);
            this.grpRechercheCode.Margin = new System.Windows.Forms.Padding(4);
            this.grpRechercheCode.Name = "grpRechercheCode";
            this.grpRechercheCode.Padding = new System.Windows.Forms.Padding(4);
            this.grpRechercheCode.Size = new System.Drawing.Size(964, 254);
            this.grpRechercheCode.TabIndex = 17;
            this.grpRechercheCode.TabStop = false;
            this.grpRechercheCode.Text = "RECHERCHE PAR CODE DOCUMENT";
            // 
            // btnRechercher
            // 
            this.btnRechercher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechercher.Location = new System.Drawing.Point(397, 26);
            this.btnRechercher.Margin = new System.Windows.Forms.Padding(4);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(128, 25);
            this.btnRechercher.TabIndex = 4;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = true;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(373, 98);
            this.lblTitre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(36, 16);
            this.lblTitre.TabIndex = 12;
            this.lblTitre.Text = "(titre)";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(229, 142);
            this.lblImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(53, 16);
            this.lblImage.TabIndex = 16;
            this.lblImage.Text = "(image)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Saisir un numéro de document :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(311, 98);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "Titre :";
            // 
            // txbNumDoc
            // 
            this.txbNumDoc.Location = new System.Drawing.Point(276, 27);
            this.txbNumDoc.Margin = new System.Windows.Forms.Padding(4);
            this.txbNumDoc.Name = "txbNumDoc";
            this.txbNumDoc.Size = new System.Drawing.Size(88, 22);
            this.txbNumDoc.TabIndex = 0;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(208, 98);
            this.lblNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(60, 16);
            this.lblNumero.TabIndex = 11;
            this.lblNumero.Text = "(numéro)";
            // 
            // lblAuteur
            // 
            this.lblAuteur.AutoSize = true;
            this.lblAuteur.Location = new System.Drawing.Point(393, 180);
            this.lblAuteur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAuteur.Name = "lblAuteur";
            this.lblAuteur.Size = new System.Drawing.Size(52, 16);
            this.lblAuteur.TabIndex = 14;
            this.lblAuteur.Text = "(auteur)";
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(131, 180);
            this.lblISBN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(40, 16);
            this.lblISBN.TabIndex = 15;
            this.lblISBN.Text = "(isbn)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 98);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Numéro de document :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(311, 180);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 17);
            this.label11.TabIndex = 9;
            this.label11.Text = "Auteur(e) :";
            // 
            // lblCollection
            // 
            this.lblCollection.AutoSize = true;
            this.lblCollection.Location = new System.Drawing.Point(123, 220);
            this.lblCollection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCollection.Name = "lblCollection";
            this.lblCollection.Size = new System.Drawing.Size(72, 16);
            this.lblCollection.TabIndex = 13;
            this.lblCollection.Text = "(collection)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 142);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(193, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Emplacement de l\'image :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 220);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Collection :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 180);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Code ISBN :";
            // 
            // tabDVD
            // 
            this.tabDVD.Controls.Add(this.groupBox2);
            this.tabDVD.Controls.Add(this.groupBox1);
            this.tabDVD.Location = new System.Drawing.Point(4, 25);
            this.tabDVD.Margin = new System.Windows.Forms.Padding(4);
            this.tabDVD.Name = "tabDVD";
            this.tabDVD.Size = new System.Drawing.Size(1059, 647);
            this.tabDVD.TabIndex = 3;
            this.tabDVD.Text = "DVD";
            this.tabDVD.UseVisualStyleBackColor = true;
            this.tabDVD.Enter += new System.EventHandler(this.tabDVD_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.DGV_DVD);
            this.groupBox2.Controls.Add(this.TXT_Search_Titre_DVD);
            this.groupBox2.Location = new System.Drawing.Point(12, 309);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1033, 325);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RECHERCHE PAR TITRE";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(29, 54);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(220, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "Saisir titre ou partie du titre :";
            // 
            // DGV_DVD
            // 
            this.DGV_DVD.AllowUserToAddRows = false;
            this.DGV_DVD.AllowUserToDeleteRows = false;
            this.DGV_DVD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_DVD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NUMERODVD,
            this.TITREDVD,
            this.SYPNOSIS_DVD,
            this.REALISATEUR_DVD,
            this.DUREE_DVD});
            this.DGV_DVD.Location = new System.Drawing.Point(33, 95);
            this.DGV_DVD.Margin = new System.Windows.Forms.Padding(4);
            this.DGV_DVD.Name = "DGV_DVD";
            this.DGV_DVD.RowHeadersWidth = 51;
            this.DGV_DVD.Size = new System.Drawing.Size(970, 223);
            this.DGV_DVD.TabIndex = 1;
            // 
            // NUMERODVD
            // 
            this.NUMERODVD.HeaderText = "Numéro";
            this.NUMERODVD.MinimumWidth = 6;
            this.NUMERODVD.Name = "NUMERODVD";
            this.NUMERODVD.Width = 125;
            // 
            // TITREDVD
            // 
            this.TITREDVD.HeaderText = "Titre";
            this.TITREDVD.MinimumWidth = 6;
            this.TITREDVD.Name = "TITREDVD";
            this.TITREDVD.Width = 125;
            // 
            // SYPNOSIS_DVD
            // 
            this.SYPNOSIS_DVD.HeaderText = "Synopsis";
            this.SYPNOSIS_DVD.MinimumWidth = 6;
            this.SYPNOSIS_DVD.Name = "SYPNOSIS_DVD";
            this.SYPNOSIS_DVD.Width = 375;
            // 
            // REALISATEUR_DVD
            // 
            this.REALISATEUR_DVD.HeaderText = "Réalisateur";
            this.REALISATEUR_DVD.MinimumWidth = 6;
            this.REALISATEUR_DVD.Name = "REALISATEUR_DVD";
            this.REALISATEUR_DVD.Width = 125;
            // 
            // DUREE_DVD
            // 
            this.DUREE_DVD.HeaderText = "Durée";
            this.DUREE_DVD.MinimumWidth = 6;
            this.DUREE_DVD.Name = "DUREE_DVD";
            this.DUREE_DVD.Width = 125;
            // 
            // TXT_Search_Titre_DVD
            // 
            this.TXT_Search_Titre_DVD.Location = new System.Drawing.Point(264, 50);
            this.TXT_Search_Titre_DVD.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_Search_Titre_DVD.Name = "TXT_Search_Titre_DVD";
            this.TXT_Search_Titre_DVD.Size = new System.Drawing.Size(241, 22);
            this.TXT_Search_Titre_DVD.TabIndex = 0;
            this.TXT_Search_Titre_DVD.TextChanged += new System.EventHandler(this.TXT_Search_Titre_DVD_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.TIME_DVD_LAB);
            this.groupBox1.Controls.Add(this.REA_DVD_LAB);
            this.groupBox1.Controls.Add(this.SYP_DVD_LAB);
            this.groupBox1.Controls.Add(this.IMG_DVD_LAB);
            this.groupBox1.Controls.Add(this.TITRE_DVD_LABEL);
            this.groupBox1.Controls.Add(this.NUM_DVD_LAB);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.DVD_NUM_BUTTON);
            this.groupBox1.Controls.Add(this.TXT_Search_NUM_DVD);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1033, 276);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RECHERCHE PAR NUMERO DOCUMENT";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(378, 139);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(95, 16);
            this.label24.TabIndex = 14;
            this.label24.Text = "Réalisateur :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(378, 98);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 16);
            this.label23.TabIndex = 13;
            this.label23.Text = "Titre :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(12, 233);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 16);
            this.label22.TabIndex = 12;
            this.label22.Text = "Durée :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(12, 193);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 16);
            this.label21.TabIndex = 11;
            this.label21.Text = "Synopsis :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(12, 150);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(186, 16);
            this.label20.TabIndex = 10;
            this.label20.Text = "Emplacement de l\'image :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(12, 97);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(162, 16);
            this.label19.TabIndex = 9;
            this.label19.Text = "Numéro de document :";
            // 
            // TIME_DVD_LAB
            // 
            this.TIME_DVD_LAB.AutoSize = true;
            this.TIME_DVD_LAB.Location = new System.Drawing.Point(205, 233);
            this.TIME_DVD_LAB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TIME_DVD_LAB.Name = "TIME_DVD_LAB";
            this.TIME_DVD_LAB.Size = new System.Drawing.Size(50, 16);
            this.TIME_DVD_LAB.TabIndex = 8;
            this.TIME_DVD_LAB.Text = "(durée)";
            // 
            // REA_DVD_LAB
            // 
            this.REA_DVD_LAB.AutoSize = true;
            this.REA_DVD_LAB.Location = new System.Drawing.Point(480, 139);
            this.REA_DVD_LAB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.REA_DVD_LAB.Name = "REA_DVD_LAB";
            this.REA_DVD_LAB.Size = new System.Drawing.Size(78, 16);
            this.REA_DVD_LAB.TabIndex = 7;
            this.REA_DVD_LAB.Text = "(réalisateur)";
            // 
            // SYP_DVD_LAB
            // 
            this.SYP_DVD_LAB.AutoSize = true;
            this.SYP_DVD_LAB.Location = new System.Drawing.Point(205, 193);
            this.SYP_DVD_LAB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SYP_DVD_LAB.Name = "SYP_DVD_LAB";
            this.SYP_DVD_LAB.Size = new System.Drawing.Size(69, 16);
            this.SYP_DVD_LAB.TabIndex = 6;
            this.SYP_DVD_LAB.Text = "(synopsis)";
            // 
            // IMG_DVD_LAB
            // 
            this.IMG_DVD_LAB.AutoSize = true;
            this.IMG_DVD_LAB.Location = new System.Drawing.Point(205, 150);
            this.IMG_DVD_LAB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IMG_DVD_LAB.Name = "IMG_DVD_LAB";
            this.IMG_DVD_LAB.Size = new System.Drawing.Size(53, 16);
            this.IMG_DVD_LAB.TabIndex = 5;
            this.IMG_DVD_LAB.Text = "(image)";
            // 
            // TITRE_DVD_LABEL
            // 
            this.TITRE_DVD_LABEL.AutoSize = true;
            this.TITRE_DVD_LABEL.Location = new System.Drawing.Point(480, 98);
            this.TITRE_DVD_LABEL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TITRE_DVD_LABEL.Name = "TITRE_DVD_LABEL";
            this.TITRE_DVD_LABEL.Size = new System.Drawing.Size(36, 16);
            this.TITRE_DVD_LABEL.TabIndex = 4;
            this.TITRE_DVD_LABEL.Text = "(titre)";
            // 
            // NUM_DVD_LAB
            // 
            this.NUM_DVD_LAB.AutoSize = true;
            this.NUM_DVD_LAB.Location = new System.Drawing.Point(205, 98);
            this.NUM_DVD_LAB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NUM_DVD_LAB.Name = "NUM_DVD_LAB";
            this.NUM_DVD_LAB.Size = new System.Drawing.Size(60, 16);
            this.NUM_DVD_LAB.TabIndex = 3;
            this.NUM_DVD_LAB.Text = "(numéro)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(9, 38);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(239, 17);
            this.label14.TabIndex = 2;
            this.label14.Text = "Saisir un numéro de document :";
            // 
            // DVD_NUM_BUTTON
            // 
            this.DVD_NUM_BUTTON.Location = new System.Drawing.Point(381, 33);
            this.DVD_NUM_BUTTON.Margin = new System.Windows.Forms.Padding(4);
            this.DVD_NUM_BUTTON.Name = "DVD_NUM_BUTTON";
            this.DVD_NUM_BUTTON.Size = new System.Drawing.Size(125, 28);
            this.DVD_NUM_BUTTON.TabIndex = 1;
            this.DVD_NUM_BUTTON.Text = "Rechercher";
            this.DVD_NUM_BUTTON.UseVisualStyleBackColor = true;
            this.DVD_NUM_BUTTON.Click += new System.EventHandler(this.DVD_NUM_BUTTON_Click);
            // 
            // TXT_Search_NUM_DVD
            // 
            this.TXT_Search_NUM_DVD.Location = new System.Drawing.Point(265, 36);
            this.TXT_Search_NUM_DVD.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_Search_NUM_DVD.Name = "TXT_Search_NUM_DVD";
            this.TXT_Search_NUM_DVD.Size = new System.Drawing.Size(101, 22);
            this.TXT_Search_NUM_DVD.TabIndex = 0;
            // 
            // ADD_DVD
            // 
            this.ADD_DVD.Controls.Add(this.ADD_PUBLIC);
            this.ADD_DVD.Controls.Add(this.VALID_DVD);
            this.ADD_DVD.Controls.Add(this.label18);
            this.ADD_DVD.Controls.Add(this.label17);
            this.ADD_DVD.Controls.Add(this.label16);
            this.ADD_DVD.Controls.Add(this.label15);
            this.ADD_DVD.Controls.Add(this.ADD_DVD_Duree);
            this.ADD_DVD.Controls.Add(this.ADD_DVD_Reali);
            this.ADD_DVD.Controls.Add(this.ADD_DVD_Synop);
            this.ADD_DVD.Controls.Add(this.ADD_DVD_Titre);
            this.ADD_DVD.Location = new System.Drawing.Point(4, 25);
            this.ADD_DVD.Margin = new System.Windows.Forms.Padding(4);
            this.ADD_DVD.Name = "ADD_DVD";
            this.ADD_DVD.Size = new System.Drawing.Size(1059, 647);
            this.ADD_DVD.TabIndex = 4;
            this.ADD_DVD.Text = "Ajout DVD";
            this.ADD_DVD.UseVisualStyleBackColor = true;
            this.ADD_DVD.Enter += new System.EventHandler(this.tabADD_DVD_Enter);
            // 
            // ADD_PUBLIC
            // 
            this.ADD_PUBLIC.FormattingEnabled = true;
            this.ADD_PUBLIC.Items.AddRange(new object[] {
            "00001 Jeunesse",
            "00002 Adultes",
            "00003 Tous publics",
            "00004 Ados"});
            this.ADD_PUBLIC.Location = new System.Drawing.Point(484, 46);
            this.ADD_PUBLIC.Margin = new System.Windows.Forms.Padding(4);
            this.ADD_PUBLIC.Name = "ADD_PUBLIC";
            this.ADD_PUBLIC.Size = new System.Drawing.Size(160, 24);
            this.ADD_PUBLIC.TabIndex = 9;
            // 
            // VALID_DVD
            // 
            this.VALID_DVD.Location = new System.Drawing.Point(80, 245);
            this.VALID_DVD.Margin = new System.Windows.Forms.Padding(4);
            this.VALID_DVD.Name = "VALID_DVD";
            this.VALID_DVD.Size = new System.Drawing.Size(269, 28);
            this.VALID_DVD.TabIndex = 8;
            this.VALID_DVD.Text = "Ajouter DVD";
            this.VALID_DVD.UseVisualStyleBackColor = true;
            this.VALID_DVD.Click += new System.EventHandler(this.VALID_DVD_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(357, 199);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 16);
            this.label18.TabIndex = 7;
            this.label18.Text = "Durée";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(357, 145);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 16);
            this.label17.TabIndex = 6;
            this.label17.Text = "Réalisateur";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(357, 95);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 16);
            this.label16.TabIndex = 5;
            this.label16.Text = "Synopsis";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(357, 46);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 16);
            this.label15.TabIndex = 4;
            this.label15.Text = "Titre";
            // 
            // ADD_DVD_Duree
            // 
            this.ADD_DVD_Duree.Location = new System.Drawing.Point(80, 191);
            this.ADD_DVD_Duree.Margin = new System.Windows.Forms.Padding(4);
            this.ADD_DVD_Duree.Name = "ADD_DVD_Duree";
            this.ADD_DVD_Duree.Size = new System.Drawing.Size(268, 22);
            this.ADD_DVD_Duree.TabIndex = 3;
            // 
            // ADD_DVD_Reali
            // 
            this.ADD_DVD_Reali.Location = new System.Drawing.Point(80, 142);
            this.ADD_DVD_Reali.Margin = new System.Windows.Forms.Padding(4);
            this.ADD_DVD_Reali.Name = "ADD_DVD_Reali";
            this.ADD_DVD_Reali.Size = new System.Drawing.Size(268, 22);
            this.ADD_DVD_Reali.TabIndex = 2;
            // 
            // ADD_DVD_Synop
            // 
            this.ADD_DVD_Synop.Location = new System.Drawing.Point(80, 91);
            this.ADD_DVD_Synop.Margin = new System.Windows.Forms.Padding(4);
            this.ADD_DVD_Synop.Name = "ADD_DVD_Synop";
            this.ADD_DVD_Synop.Size = new System.Drawing.Size(268, 22);
            this.ADD_DVD_Synop.TabIndex = 1;
            // 
            // ADD_DVD_Titre
            // 
            this.ADD_DVD_Titre.Location = new System.Drawing.Point(80, 42);
            this.ADD_DVD_Titre.Margin = new System.Windows.Forms.Padding(4);
            this.ADD_DVD_Titre.Name = "ADD_DVD_Titre";
            this.ADD_DVD_Titre.Size = new System.Drawing.Size(268, 22);
            this.ADD_DVD_Titre.TabIndex = 0;
            // 
            // tabCommandes
            // 
            this.tabCommandes.Controls.Add(this.dataGridView1);
            this.tabCommandes.Location = new System.Drawing.Point(4, 25);
            this.tabCommandes.Name = "tabCommandes";
            this.tabCommandes.Size = new System.Drawing.Size(1059, 647);
            this.tabCommandes.TabIndex = 6;
            this.tabCommandes.Text = "Commandes";
            this.tabCommandes.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.commandeId,
            this.commandeNbEx,
            this.commandeDate,
            this.commandeMontant,
            this.commandeDocumentId,
            this.commandeNomDocument,
            this.commandeStatus,
            this.commandeModifier});
            this.dataGridView1.Location = new System.Drawing.Point(44, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(975, 525);
            this.dataGridView1.TabIndex = 0;
            // 
            // commandeId
            // 
            this.commandeId.HeaderText = "id";
            this.commandeId.MinimumWidth = 6;
            this.commandeId.Name = "commandeId";
            this.commandeId.Width = 50;
            // 
            // commandeNbEx
            // 
            this.commandeNbEx.HeaderText = "Nombre d\'exemplaires";
            this.commandeNbEx.MinimumWidth = 6;
            this.commandeNbEx.Name = "commandeNbEx";
            this.commandeNbEx.Width = 125;
            // 
            // commandeDate
            // 
            this.commandeDate.HeaderText = "Date";
            this.commandeDate.MinimumWidth = 6;
            this.commandeDate.Name = "commandeDate";
            this.commandeDate.Width = 125;
            // 
            // commandeMontant
            // 
            this.commandeMontant.HeaderText = "Montant";
            this.commandeMontant.MinimumWidth = 6;
            this.commandeMontant.Name = "commandeMontant";
            this.commandeMontant.Width = 125;
            // 
            // commandeDocumentId
            // 
            this.commandeDocumentId.HeaderText = "Id Document";
            this.commandeDocumentId.MinimumWidth = 6;
            this.commandeDocumentId.Name = "commandeDocumentId";
            this.commandeDocumentId.Width = 125;
            // 
            // commandeNomDocument
            // 
            this.commandeNomDocument.HeaderText = "Nom Document";
            this.commandeNomDocument.MinimumWidth = 6;
            this.commandeNomDocument.Name = "commandeNomDocument";
            this.commandeNomDocument.Width = 125;
            // 
            // commandeStatus
            // 
            this.commandeStatus.HeaderText = "Status";
            this.commandeStatus.MinimumWidth = 6;
            this.commandeStatus.Name = "commandeStatus";
            this.commandeStatus.Width = 125;
            // 
            // commandeModifier
            // 
            this.commandeModifier.HeaderText = "Modifier";
            this.commandeModifier.MinimumWidth = 6;
            this.commandeModifier.Name = "commandeModifier";
            this.commandeModifier.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.commandeModifier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.commandeModifier.Width = 125;
            // 
            // abonneGestion
            // 
            this.abonneGestion.Controls.Add(this.groupBox3);
            this.abonneGestion.Controls.Add(this.abonneExpireCheck);
            this.abonneGestion.Controls.Add(this.abonneLabelSearch);
            this.abonneGestion.Controls.Add(this.abonneTxtBox);
            this.abonneGestion.Controls.Add(this.dataGridAbonne);
            this.abonneGestion.Location = new System.Drawing.Point(4, 25);
            this.abonneGestion.Name = "abonneGestion";
            this.abonneGestion.Padding = new System.Windows.Forms.Padding(3);
            this.abonneGestion.Size = new System.Drawing.Size(1059, 647);
            this.abonneGestion.TabIndex = 5;
            this.abonneGestion.Text = "Abonnés";
            this.abonneGestion.UseVisualStyleBackColor = true;
            this.abonneGestion.Enter += new System.EventHandler(this.tabAbonne_Enter);
            // 
            // abonneExpireCheck
            // 
            this.abonneExpireCheck.AutoSize = true;
            this.abonneExpireCheck.Location = new System.Drawing.Point(597, 296);
            this.abonneExpireCheck.Name = "abonneExpireCheck";
            this.abonneExpireCheck.Size = new System.Drawing.Size(376, 20);
            this.abonneExpireCheck.TabIndex = 3;
            this.abonneExpireCheck.Text = "Montrer seulement les abonnements proche de l\'expiration";
            this.abonneExpireCheck.UseVisualStyleBackColor = true;
            this.abonneExpireCheck.CheckedChanged += new System.EventHandler(this.abonneExpireCheck_CheckedChanged);
            // 
            // abonneLabelSearch
            // 
            this.abonneLabelSearch.AutoSize = true;
            this.abonneLabelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abonneLabelSearch.Location = new System.Drawing.Point(46, 296);
            this.abonneLabelSearch.Name = "abonneLabelSearch";
            this.abonneLabelSearch.Size = new System.Drawing.Size(153, 16);
            this.abonneLabelSearch.TabIndex = 2;
            this.abonneLabelSearch.Text = "Recherche par Nom :";
            // 
            // abonneTxtBox
            // 
            this.abonneTxtBox.Location = new System.Drawing.Point(217, 293);
            this.abonneTxtBox.Name = "abonneTxtBox";
            this.abonneTxtBox.Size = new System.Drawing.Size(278, 22);
            this.abonneTxtBox.TabIndex = 1;
            this.abonneTxtBox.TextChanged += new System.EventHandler(this.txbAbonne_TextChanged);
            // 
            // dataGridAbonne
            // 
            this.dataGridAbonne.AllowUserToAddRows = false;
            this.dataGridAbonne.AllowUserToDeleteRows = false;
            this.dataGridAbonne.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridAbonne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAbonne.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.abonneId,
            this.abonneNom,
            this.abonnePrenom,
            this.abonneAdresse,
            this.abonneTel,
            this.abonneMail,
            this.abonneNais,
            this.abonneTypeAbo,
            this.abonneFinAbo,
            this.abonneModifier,
            this.abonneDGVSupprimer});
            this.dataGridAbonne.Location = new System.Drawing.Point(22, 340);
            this.dataGridAbonne.Name = "dataGridAbonne";
            this.dataGridAbonne.ReadOnly = true;
            this.dataGridAbonne.RowHeadersWidth = 51;
            this.dataGridAbonne.RowTemplate.Height = 24;
            this.dataGridAbonne.Size = new System.Drawing.Size(1029, 254);
            this.dataGridAbonne.TabIndex = 0;
            this.dataGridAbonne.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAbonne_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.btnAbonneReset);
            this.groupBox3.Controls.Add(this.btnAbonneUpdate);
            this.groupBox3.Controls.Add(this.btnAbonneNew);
            this.groupBox3.Controls.Add(this.txtTypeAbonnement);
            this.groupBox3.Controls.Add(this.dtpFinAbonnement);
            this.groupBox3.Controls.Add(this.dtpAbonneNaissance);
            this.groupBox3.Controls.Add(this.txtAbonneMail);
            this.groupBox3.Controls.Add(this.txtAbonneTel);
            this.groupBox3.Controls.Add(this.txtAbonneAdresse);
            this.groupBox3.Controls.Add(this.txtAbonnePrenom);
            this.groupBox3.Controls.Add(this.txtAbonneNom);
            this.groupBox3.Controls.Add(this.txtAbonneId);
            this.groupBox3.Location = new System.Drawing.Point(38, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(981, 248);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Abonné ";
            // 
            // txtAbonneId
            // 
            this.txtAbonneId.Location = new System.Drawing.Point(89, 37);
            this.txtAbonneId.Name = "txtAbonneId";
            this.txtAbonneId.ReadOnly = true;
            this.txtAbonneId.Size = new System.Drawing.Size(100, 22);
            this.txtAbonneId.TabIndex = 0;
            this.txtAbonneId.Text = "Nouveau";
            // 
            // txtAbonneNom
            // 
            this.txtAbonneNom.Location = new System.Drawing.Point(89, 78);
            this.txtAbonneNom.Name = "txtAbonneNom";
            this.txtAbonneNom.Size = new System.Drawing.Size(100, 22);
            this.txtAbonneNom.TabIndex = 1;
            // 
            // txtAbonnePrenom
            // 
            this.txtAbonnePrenom.Location = new System.Drawing.Point(89, 120);
            this.txtAbonnePrenom.Name = "txtAbonnePrenom";
            this.txtAbonnePrenom.Size = new System.Drawing.Size(100, 22);
            this.txtAbonnePrenom.TabIndex = 2;
            // 
            // txtAbonneAdresse
            // 
            this.txtAbonneAdresse.Location = new System.Drawing.Point(89, 164);
            this.txtAbonneAdresse.Name = "txtAbonneAdresse";
            this.txtAbonneAdresse.Size = new System.Drawing.Size(186, 22);
            this.txtAbonneAdresse.TabIndex = 3;
            // 
            // txtAbonneTel
            // 
            this.txtAbonneTel.Location = new System.Drawing.Point(470, 34);
            this.txtAbonneTel.Name = "txtAbonneTel";
            this.txtAbonneTel.Size = new System.Drawing.Size(124, 22);
            this.txtAbonneTel.TabIndex = 4;
            // 
            // txtAbonneMail
            // 
            this.txtAbonneMail.Location = new System.Drawing.Point(470, 78);
            this.txtAbonneMail.Name = "txtAbonneMail";
            this.txtAbonneMail.Size = new System.Drawing.Size(124, 22);
            this.txtAbonneMail.TabIndex = 5;
            // 
            // dtpAbonneNaissance
            // 
            this.dtpAbonneNaissance.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAbonneNaissance.Location = new System.Drawing.Point(470, 117);
            this.dtpAbonneNaissance.Name = "dtpAbonneNaissance";
            this.dtpAbonneNaissance.Size = new System.Drawing.Size(124, 22);
            this.dtpAbonneNaissance.TabIndex = 7;
            this.dtpAbonneNaissance.Value = new System.DateTime(2023, 5, 23, 0, 0, 0, 0);
            // 
            // dtpFinAbonnement
            // 
            this.dtpFinAbonnement.Location = new System.Drawing.Point(470, 201);
            this.dtpFinAbonnement.Name = "dtpFinAbonnement";
            this.dtpFinAbonnement.Size = new System.Drawing.Size(200, 22);
            this.dtpFinAbonnement.TabIndex = 8;
            // 
            // txtTypeAbonnement
            // 
            this.txtTypeAbonnement.Location = new System.Drawing.Point(470, 161);
            this.txtTypeAbonnement.Name = "txtTypeAbonnement";
            this.txtTypeAbonnement.Size = new System.Drawing.Size(100, 22);
            this.txtTypeAbonnement.TabIndex = 9;
            // 
            // btnAbonneNew
            // 
            this.btnAbonneNew.Location = new System.Drawing.Point(750, 25);
            this.btnAbonneNew.Name = "btnAbonneNew";
            this.btnAbonneNew.Size = new System.Drawing.Size(115, 46);
            this.btnAbonneNew.TabIndex = 10;
            this.btnAbonneNew.Text = "Insérer Nouveau Abonné";
            this.btnAbonneNew.UseVisualStyleBackColor = true;
            this.btnAbonneNew.Click += new System.EventHandler(this.btnAbonneNew_Click);
            // 
            // btnAbonneUpdate
            // 
            this.btnAbonneUpdate.Location = new System.Drawing.Point(750, 94);
            this.btnAbonneUpdate.Name = "btnAbonneUpdate";
            this.btnAbonneUpdate.Size = new System.Drawing.Size(115, 48);
            this.btnAbonneUpdate.TabIndex = 11;
            this.btnAbonneUpdate.Text = "Mettre à Jour Abonné";
            this.btnAbonneUpdate.UseVisualStyleBackColor = true;
            this.btnAbonneUpdate.Click += new System.EventHandler(this.btnAbonneUpdate_Click);
            // 
            // btnAbonneReset
            // 
            this.btnAbonneReset.Location = new System.Drawing.Point(750, 164);
            this.btnAbonneReset.Name = "btnAbonneReset";
            this.btnAbonneReset.Size = new System.Drawing.Size(115, 49);
            this.btnAbonneReset.TabIndex = 12;
            this.btnAbonneReset.Text = "Rénitialiser";
            this.btnAbonneReset.UseVisualStyleBackColor = true;
            this.btnAbonneReset.Click += new System.EventHandler(this.btnAbonneReset_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(18, 37);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(20, 16);
            this.label25.TabIndex = 13;
            this.label25.Text = "Id";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(18, 78);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(39, 16);
            this.label26.TabIndex = 14;
            this.label26.Text = "Nom";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(18, 123);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(60, 16);
            this.label27.TabIndex = 15;
            this.label27.Text = "Prenom";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(18, 164);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(65, 16);
            this.label28.TabIndex = 16;
            this.label28.Text = "Adresse";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(307, 37);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(124, 16);
            this.label29.TabIndex = 17;
            this.label29.Text = "N° de Téléphone";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(307, 81);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(98, 16);
            this.label30.TabIndex = 18;
            this.label30.Text = "Adresse Mail";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(307, 122);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(140, 16);
            this.label31.TabIndex = 19;
            this.label31.Text = "Date de Naissance";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(307, 164);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(146, 16);
            this.label32.TabIndex = 20;
            this.label32.Text = "Type d\'Abonnement";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(307, 201);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(131, 16);
            this.label33.TabIndex = 21;
            this.label33.Text = "Fin d\'Abonnement";
            // 
            // abonneId
            // 
            this.abonneId.HeaderText = "Id";
            this.abonneId.MinimumWidth = 6;
            this.abonneId.Name = "abonneId";
            this.abonneId.ReadOnly = true;
            this.abonneId.Width = 47;
            // 
            // abonneNom
            // 
            this.abonneNom.HeaderText = "Nom";
            this.abonneNom.MinimumWidth = 6;
            this.abonneNom.Name = "abonneNom";
            this.abonneNom.ReadOnly = true;
            this.abonneNom.Width = 65;
            // 
            // abonnePrenom
            // 
            this.abonnePrenom.HeaderText = "Prenom";
            this.abonnePrenom.MinimumWidth = 6;
            this.abonnePrenom.Name = "abonnePrenom";
            this.abonnePrenom.ReadOnly = true;
            this.abonnePrenom.Width = 83;
            // 
            // abonneAdresse
            // 
            this.abonneAdresse.HeaderText = "Adresse";
            this.abonneAdresse.MinimumWidth = 6;
            this.abonneAdresse.Name = "abonneAdresse";
            this.abonneAdresse.ReadOnly = true;
            this.abonneAdresse.Width = 87;
            // 
            // abonneTel
            // 
            this.abonneTel.HeaderText = "Téléphone";
            this.abonneTel.MinimumWidth = 6;
            this.abonneTel.Name = "abonneTel";
            this.abonneTel.ReadOnly = true;
            this.abonneTel.Width = 102;
            // 
            // abonneMail
            // 
            this.abonneMail.HeaderText = "Adresse Mail";
            this.abonneMail.MinimumWidth = 6;
            this.abonneMail.Name = "abonneMail";
            this.abonneMail.ReadOnly = true;
            this.abonneMail.Width = 115;
            // 
            // abonneNais
            // 
            this.abonneNais.HeaderText = "Naissance";
            this.abonneNais.MinimumWidth = 6;
            this.abonneNais.Name = "abonneNais";
            this.abonneNais.ReadOnly = true;
            this.abonneNais.Width = 101;
            // 
            // abonneTypeAbo
            // 
            this.abonneTypeAbo.HeaderText = "Type d\'Abonnement";
            this.abonneTypeAbo.MinimumWidth = 6;
            this.abonneTypeAbo.Name = "abonneTypeAbo";
            this.abonneTypeAbo.ReadOnly = true;
            this.abonneTypeAbo.Width = 145;
            // 
            // abonneFinAbo
            // 
            this.abonneFinAbo.HeaderText = "Fin d\'Abonnement";
            this.abonneFinAbo.MinimumWidth = 6;
            this.abonneFinAbo.Name = "abonneFinAbo";
            this.abonneFinAbo.ReadOnly = true;
            this.abonneFinAbo.Width = 132;
            // 
            // abonneModifier
            // 
            this.abonneModifier.HeaderText = "Modifier";
            this.abonneModifier.MinimumWidth = 6;
            this.abonneModifier.Name = "abonneModifier";
            this.abonneModifier.ReadOnly = true;
            this.abonneModifier.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.abonneModifier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.abonneModifier.Text = "Modifier";
            this.abonneModifier.Width = 84;
            // 
            // abonneDGVSupprimer
            // 
            this.abonneDGVSupprimer.HeaderText = "Supprimer";
            this.abonneDGVSupprimer.MinimumWidth = 6;
            this.abonneDGVSupprimer.Name = "abonneDGVSupprimer";
            this.abonneDGVSupprimer.ReadOnly = true;
            this.abonneDGVSupprimer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.abonneDGVSupprimer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.abonneDGVSupprimer.Text = "Supprimer";
            this.abonneDGVSupprimer.Width = 98;
            // 
            // FrmMediateq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 676);
            this.Controls.Add(this.tabOngletsApplication);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMediateq";
            this.Text = "Gestion Médiathèque";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMediateq_FormClosed);
            this.Load += new System.EventHandler(this.FrmMediateq_Load);
            this.tabOngletsApplication.ResumeLayout(false);
            this.tabParutions.ResumeLayout(false);
            this.tabParutions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParutions)).EndInit();
            this.tabTitres.ResumeLayout(false);
            this.tabTitres.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitres)).EndInit();
            this.tabLivres.ResumeLayout(false);
            this.grpRechercheTitre.ResumeLayout(false);
            this.grpRechercheTitre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivres)).EndInit();
            this.grpRechercheCode.ResumeLayout(false);
            this.grpRechercheCode.PerformLayout();
            this.tabDVD.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DVD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ADD_DVD.ResumeLayout(false);
            this.ADD_DVD.PerformLayout();
            this.tabCommandes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.abonneGestion.ResumeLayout(false);
            this.abonneGestion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAbonne)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabOngletsApplication;
        private System.Windows.Forms.TabPage tabParutions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTitres;
        private System.Windows.Forms.TabPage tabTitres;
        private System.Windows.Forms.ComboBox cbxDomaines;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTitres;
        private System.Windows.Forms.DataGridView dgvParutions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateParution;
        private System.Windows.Forms.DataGridViewTextBoxColumn photo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTitre;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn empruntable;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodicite;
        private System.Windows.Forms.TabPage tabLivres;
        private System.Windows.Forms.TabPage tabDVD;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.TextBox txbTitre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbNumDoc;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Label lblAuteur;
        private System.Windows.Forms.Label lblCollection;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpRechercheTitre;
        private System.Windows.Forms.GroupBox grpRechercheCode;
        private System.Windows.Forms.DataGridView dgvLivres;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn titre;
        private System.Windows.Forms.DataGridViewTextBoxColumn auteur;
        private System.Windows.Forms.DataGridViewTextBoxColumn isbn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lacollection;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TXT_Search_Titre_DVD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGV_DVD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button DVD_NUM_BUTTON;
        private System.Windows.Forms.TextBox TXT_Search_NUM_DVD;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label TIME_DVD_LAB;
        private System.Windows.Forms.Label REA_DVD_LAB;
        private System.Windows.Forms.Label SYP_DVD_LAB;
        private System.Windows.Forms.Label IMG_DVD_LAB;
        private System.Windows.Forms.Label TITRE_DVD_LABEL;
        private System.Windows.Forms.Label NUM_DVD_LAB;
        private System.Windows.Forms.TabPage ADD_DVD;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox ADD_DVD_Duree;
        private System.Windows.Forms.TextBox ADD_DVD_Reali;
        private System.Windows.Forms.TextBox ADD_DVD_Synop;
        private System.Windows.Forms.TextBox ADD_DVD_Titre;
        private System.Windows.Forms.Button VALID_DVD;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox ADD_PUBLIC;
        private System.Windows.Forms.TabPage abonneGestion;
        private System.Windows.Forms.TextBox abonneTxtBox;
        private System.Windows.Forms.DataGridView dataGridAbonne;
        private System.Windows.Forms.Label abonneLabelSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERODVD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TITREDVD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SYPNOSIS_DVD;
        private System.Windows.Forms.DataGridViewTextBoxColumn REALISATEUR_DVD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DUREE_DVD;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox abonneExpireCheck;
        private System.Windows.Forms.TabPage tabCommandes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandeNbEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandeMontant;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandeDocumentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandeNomDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandeStatus;
        private System.Windows.Forms.DataGridViewButtonColumn commandeModifier;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAbonneReset;
        private System.Windows.Forms.Button btnAbonneUpdate;
        private System.Windows.Forms.Button btnAbonneNew;
        private System.Windows.Forms.TextBox txtTypeAbonnement;
        private System.Windows.Forms.DateTimePicker dtpFinAbonnement;
        private System.Windows.Forms.DateTimePicker dtpAbonneNaissance;
        private System.Windows.Forms.TextBox txtAbonneMail;
        private System.Windows.Forms.TextBox txtAbonneTel;
        private System.Windows.Forms.TextBox txtAbonneAdresse;
        private System.Windows.Forms.TextBox txtAbonnePrenom;
        private System.Windows.Forms.TextBox txtAbonneNom;
        private System.Windows.Forms.TextBox txtAbonneId;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonneId;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonneNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonnePrenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonneAdresse;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonneTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonneMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonneNais;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonneTypeAbo;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonneFinAbo;
        private System.Windows.Forms.DataGridViewButtonColumn abonneModifier;
        private System.Windows.Forms.DataGridViewButtonColumn abonneDGVSupprimer;
    }
}


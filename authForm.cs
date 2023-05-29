using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Mediateq_AP_SIO2.divers;
using Mediateq_AP_SIO2.metier;

namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Fenêtre de la page de connexion
    /// </summary>
    public partial class authForm : Form
    {   
        /// <summary>
        /// Initialise les composants du formulaire de connexion
        /// </summary>
        public authForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lors de l'ouverture du formulaire, créée une connection à la base de données.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void authForm_Load(object sender, EventArgs e)
        {
            DAOFactory.creerConnection();
        }

        /// <summary>
        /// Bouton de connexion, prend en compte le login et mot de passe entrés et les verifiés avec une requête à la BDD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginButton_Click(object sender, EventArgs e)
        {
            string login = usernameTxtBox.Text;
            string mdp = BitConverter.ToString(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(passwordTxtBox.Text))).Replace("-", "");

            Utilisateur user = DAOAuth.getUtilisateurById(login, mdp);

            if (user != null)
            {
                new FrmMediateq(user).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Identifiants de connexion invalides");
            }
        }
    }
}

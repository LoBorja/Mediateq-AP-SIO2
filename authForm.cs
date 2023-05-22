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
    public partial class authForm : Form
    {
        public authForm()
        {
            InitializeComponent();
        }

        private void authForm_Load(object sender, EventArgs e)
        {
            DAOFactory.creerConnection();
        }

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

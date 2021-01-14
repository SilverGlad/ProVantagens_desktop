using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProVantagensApp.forms
{
    public partial class frmMudarSenha : Form
    {
        public frmMudarSenha()
        {
            InitializeComponent();
        }

        void mudarSenha()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyA0hQhaFdSKMTQfpSltAmDdqdMvDDG-aR4"));
            authProvider.ChangeUserPassword(User.Token, txtSenha.Text);
        }

        private void btnSalvar_Click(Object sender, EventArgs e)
        {
            if (txtSenha.Text != txtConfirmSenha.Text)
            {
                MessageBox.Show("As senhas não coincidem");
            }
            else
            {
                if(txtSenha.Text.Length < 6)
                {
                    MessageBox.Show("Senha muito curta");
                }
                else
                {
                    try
                    {
                        mudarSenha();
                        MessageBox.Show("Senha alterada com sucesso!");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao alterar senha!");
                    }
                }
               
            }
        }
    }
}

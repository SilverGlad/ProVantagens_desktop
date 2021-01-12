using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using Firebase.Auth;
using System.Net;
using HtmlAgilityPack;

namespace ProVantagensApp
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }


        async private void btnLogar_Click(object sender, EventArgs e)
        {
            btnLogar.Enabled = false;
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyA0hQhaFdSKMTQfpSltAmDdqdMvDDG-aR4"));
            
            try
            {
                var auth = authProvider.SignInWithEmailAndPasswordAsync(txtEmail.Text, txtSenha.Text).Result;
                User.ID = auth.User.LocalId;
                await getUser(User.ID);
                if (User.ID == null)
                {

                }
                else
                {
                    MessageBox.Show("Logado com sucesso!");
                    this.Hide();
                    FrmGeral frmGeral = new FrmGeral();
                    frmGeral.Show();
                }

            }
            catch
            {
                MessageBox.Show("Usuário ou senha incorretos");
                btnLogar.Enabled = true;
            }
            

        }

        async private Task getUser(String id)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("pro-vantagens");

            DocumentReference documentReference = db.Collection("users").Document(User.ID);
            DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();

            User.Name = documentSnapshot.GetValue<String>("name");


        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool mouseClicked;
        Point clickedAt;

        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseClicked)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }

        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            mouseClicked = true;
            clickedAt = e.Location;
        }

        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClicked = false;
        }
    }
}

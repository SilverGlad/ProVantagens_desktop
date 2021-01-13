using Google.Cloud.Firestore;
using ProVantagensApp.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProVantagensApp
{
    public partial class FrmGeral : Form
    {
        public FrmGeral()
        {
            InitializeComponent();
        }


        //Menu inicial

        private void btnHome_Click(object sender, EventArgs e)
        {
            ctrlHome frm = new ctrlHome();
            pnPage.Controls.Clear();
            pnPage.Controls.Add(frm);
            frm.Show();
            frm.Dock = DockStyle.Fill;
            frm.AutoSize = true;
            btnClients.ForeColor = Color.Black;
            btnBeneficios.ForeColor = Color.Black;
            btnHome.ForeColor = Color.White;
            btnPartners.ForeColor = Color.Black;
            btnPlans.ForeColor = Color.Black;
            btnDashboard.ForeColor = Color.Black;
            btnFaturas.ForeColor = Color.Black;
            btnPagamentos.ForeColor = Color.Black;
            btnRelatorios.ForeColor = Color.Black;
        }

        private void btnPartners_Click(object sender, EventArgs e)
        {
            ctrlPartners frm = new ctrlPartners();
            pnPage.Controls.Clear();
            pnPage.Controls.Add(frm);
            frm.Show();
            btnClients.ForeColor = Color.Black;
            btnBeneficios.ForeColor = Color.Black;
            btnHome.ForeColor = Color.Black;
            btnPartners.ForeColor = Color.White;
            btnPlans.ForeColor = Color.Black;
            btnDashboard.ForeColor = Color.Black;
            btnFaturas.ForeColor = Color.Black;
            btnPagamentos.ForeColor = Color.Black;
            btnRelatorios.ForeColor = Color.Black;
        }

        private void btnBeneficios_Click(object sender, EventArgs e)
        {
            ctrlBenefits frm = new ctrlBenefits();
            pnPage.Controls.Clear();
            pnPage.Controls.Add(frm);
            frm.Show();
            btnClients.ForeColor = Color.Black;
            btnBeneficios.ForeColor = Color.White;
            btnHome.ForeColor = Color.Black;
            btnPartners.ForeColor = Color.Black;
            btnPlans.ForeColor = Color.Black;
            btnDashboard.ForeColor = Color.Black;
            btnFaturas.ForeColor = Color.Black;
            btnPagamentos.ForeColor = Color.Black;
            btnRelatorios.ForeColor = Color.Black;
        }
        private void btnClients_Click(object sender, EventArgs e)
        {
            ctrlClients frm = new ctrlClients();
            pnPage.Controls.Clear();
            pnPage.Controls.Add(frm);
            frm.Show();
            btnClients.ForeColor = Color.White;
            btnBeneficios.ForeColor = Color.Black;
            btnHome.ForeColor = Color.Black;
            btnPartners.ForeColor = Color.Black;
            btnPlans.ForeColor = Color.Black;
            btnDashboard.ForeColor = Color.Black;
            btnFaturas.ForeColor = Color.Black;
            btnPagamentos.ForeColor = Color.Black;
            btnRelatorios.ForeColor = Color.Black;
        }

        private void btnPlans_Click(object sender, EventArgs e)
        {
            ctrlPlans frm = new ctrlPlans();
            pnPage.Controls.Clear();
            pnPage.Controls.Add(frm);
            frm.Show();
            btnClients.ForeColor = Color.Black;
            btnBeneficios.ForeColor = Color.Black;
            btnHome.ForeColor = Color.Black;
            btnPartners.ForeColor = Color.Black;
            btnPlans.ForeColor = Color.White;
            btnDashboard.ForeColor = Color.Black;
            btnFaturas.ForeColor = Color.Black;
            btnPagamentos.ForeColor = Color.Black;
            btnRelatorios.ForeColor = Color.Black;

        }

        private void FrmGeral_Load(object sender, EventArgs e)
        {
            string path =  AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            FirestoreDb db = FirestoreDb.Create("pro-vantagens");
            lbUserName.Text = User.Name;

            ctrlHome frm = new ctrlHome();
            pnPage.Controls.Clear();
            pnPage.Controls.Add(frm);
            frm.Show();
            frm.Dock = DockStyle.Fill;
            frm.AutoSize = true;
            btnClients.ForeColor = Color.Black;
            btnBeneficios.ForeColor = Color.Black;
            btnHome.ForeColor = Color.White;
            btnPartners.ForeColor = Color.Black;
            btnPlans.ForeColor = Color.Black;
            btnDashboard.ForeColor = Color.Black;
            btnFaturas.ForeColor = Color.Black;
            btnPagamentos.ForeColor = Color.Black;
            btnRelatorios.ForeColor = Color.Black;
        }

        private void FrmGeral_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnFaturas_Click(Object sender, EventArgs e)
        {
            ctrlFaturas frm = new ctrlFaturas();
            pnPage.Controls.Clear();
            pnPage.Controls.Add(frm);
            frm.Show();
            btnClients.ForeColor = Color.Black;
            btnBeneficios.ForeColor = Color.Black;
            btnHome.ForeColor = Color.Black;
            btnPartners.ForeColor = Color.Black;
            btnPlans.ForeColor = Color.Black;
            btnDashboard.ForeColor = Color.Black;
            btnFaturas.ForeColor = Color.White;
            btnPagamentos.ForeColor = Color.Black;
            btnRelatorios.ForeColor = Color.Black;
        }

        private void btnPagamentos_Click(Object sender, EventArgs e)
        {
            ctrlPagamentos frm = new ctrlPagamentos();
            pnPage.Controls.Clear();
            pnPage.Controls.Add(frm);
            frm.Show();
            btnClients.ForeColor = Color.Black;
            btnBeneficios.ForeColor = Color.Black;
            btnHome.ForeColor = Color.Black;
            btnPartners.ForeColor = Color.Black;
            btnPlans.ForeColor = Color.Black;
            btnDashboard.ForeColor = Color.Black;
            btnFaturas.ForeColor = Color.Black;
            btnPagamentos.ForeColor = Color.White;
            btnRelatorios.ForeColor = Color.Black;
        }

        private void btnDashboard_Click(Object sender, EventArgs e)
        {
            ctrlDashboard frm = new ctrlDashboard();
            pnPage.Controls.Clear();
            pnPage.Controls.Add(frm);
            frm.Show();
            btnClients.ForeColor = Color.Black;
            btnBeneficios.ForeColor = Color.Black;
            btnHome.ForeColor = Color.Black;
            btnPartners.ForeColor = Color.Black;
            btnPlans.ForeColor = Color.Black;
            btnDashboard.ForeColor = Color.White;
            btnFaturas.ForeColor = Color.Black;
            btnPagamentos.ForeColor = Color.Black;
            btnRelatorios.ForeColor = Color.Black;
        }
    }
}

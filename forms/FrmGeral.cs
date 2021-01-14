using Google.Cloud.Firestore;
using ProVantagensApp.controls;
using ProVantagensApp.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProVantagensApp
{
    public partial class FrmGeral : Form
    {
        private String monthNow;
        List<Dependents> dependentsList = new List<Dependents>();

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

        private async void FrmGeral_Load(object sender, EventArgs e)
        {
            monthNow = DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString();
            if (DateTime.Now.Month < 10)
            {
                monthNow = "0" + monthNow;
            }
            string path =  AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            FirestoreDb db = FirestoreDb.Create("pro-vantagens");
            lbUserName.Text = User.Name;

            Query Query = db.Collection("users");
            QuerySnapshot snapshots = await Query.GetSnapshotAsync();
            foreach (DocumentSnapshot documentSnapshot in snapshots)
            {
                Clients users = documentSnapshot.ConvertTo<Clients>();

                if(users.plan != "")
                {
                    if(users.plan != null)
                    {

                        DocumentReference invoiceReference = db.Collection("users").Document(documentSnapshot.Id).Collection("invoices").Document(monthNow);
                        DocumentSnapshot invoiceSnap = await invoiceReference.GetSnapshotAsync();

                        if (invoiceSnap.Exists)
                        {

                        }
                        else
                        {
                            int dependents = 0;
                            for (int i = 0; i < users.dependents.Count; i++)
                            {
                               if(users.dependents[i].aditional == true){
                                    dependents = dependents + 1;
                                }
                            }

                            double dpvalue = dependents * 9.90;
                            double totalValue = (double.Parse(users.planvalue.Replace("R$ ", "")) + dpvalue);

                            Dictionary<string, object> invoiceData = new Dictionary<string, object>()
                            {
                            {"aditional", dpvalue},
                            {"dueDate", users.dueDate},
                            {"holder", users.name},
                            {"month", DateTime.Now.Month.ToString()},
                            {"paymentMethod", users.paymentMethod},
                            {"planName", users.plan},
                            {"status", "Pendente"},
                            {"totalValue", totalValue},
                            {"value", users.planvalue},
                            };
                            await invoiceReference.SetAsync(invoiceData);
                        }
                    }
                }


            }
            if (User.AccessLevel > 1)
                {
                    gbFinances.Visible = true;
                }

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

        private void button1_Click(Object sender, EventArgs e)
        {
            frmAddClientAutomatico frm = new frmAddClientAutomatico();
            frm.Show();
        }

        private void btnMudarSenha_Click(Object sender, EventArgs e)
        {
            frmMudarSenha frm = new frmMudarSenha();
            frm.Show();
        }
    }
}

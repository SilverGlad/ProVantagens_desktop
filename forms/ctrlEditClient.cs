using Google.Cloud.Firestore;
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
    public partial class ctrlEditClient : Form
    {
        string userID, invoiceID, planID;
        Invoices invoices = new Invoices();
        Plans plans = new Plans();
        DocumentReference documentReference;
        DocumentSnapshot documentSnapshot;
        FirestoreDb db;
        public ctrlEditClient(string userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private async void btnOk_Click(Object sender, EventArgs e)
        {
            if (btnPlan.Checked)
            {
                frmContractPlan frm = new frmContractPlan(userID);
                this.Close();
                frm.ShowDialog();
            }
            if (btnFatura.Checked)
            {
                try
                {
                    if (invoiceID == "")
                    {
                        MessageBox.Show("Você deve selecionar ao menos uma fatura!");
                    }
                    else
                    {
                        documentReference = db.Collection("users").Document(userID).Collection("invoices").Document(invoiceID);
                        documentSnapshot = await documentReference.GetSnapshotAsync();
                        invoices = documentSnapshot.ConvertTo<Invoices>();
                        Query Query = db.Collection("plans");
                        QuerySnapshot snapshots = await Query.GetSnapshotAsync();

                        foreach (DocumentSnapshot documentSnapshot in snapshots)
                        {
                            plans = documentSnapshot.ConvertTo<Plans>();
                            if(invoices.planName.Contains(plans.name) && invoices.planName.Contains(plans.type))
                            {
                                planID = documentSnapshot.Id;
                            }
                        }
                        frmFinalizeClient frm = new frmFinalizeClient(userID, planID);
                        this.Close();
                        frm.ShowDialog();
                    }
                }
                catch
                {

                }



            }
            if (btnClient.Checked)
            {
                frmEditClient frm = new frmEditClient(userID);
                this.Close();
                frm.ShowDialog();
            }
        }

        private void btnFatura_CheckedChanged(Object sender, EventArgs e)
        {
            if (btnFatura.Checked)
            {
                lbFatura.Visible = true;
                cboFatura.Visible = true;
            }
            else
            {
                lbFatura.Visible = false;
                cboFatura.Visible = false;
            }
        }

        private void cboFatura_SelectedIndexChanged(Object sender, EventArgs e)
        {
            invoiceID = cboFatura.Text;
        }

        private async void ctrlEditClient_Load(Object sender, EventArgs e)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            db = FirestoreDb.Create("pro-vantagens");


            Query Query = db.Collection("users").Document(userID).Collection("invoices");
            QuerySnapshot snapshots = await Query.GetSnapshotAsync();

            foreach (DocumentSnapshot documentSnapshot in snapshots)
            {
                cboFatura.Items.Add(documentSnapshot.Id);
            }
        }
    }
}

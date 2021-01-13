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

namespace ProVantagensApp
{
    public partial class ctrlBenefits : UserControl
    {
        public String benefitID;

        public ctrlBenefits()
        {
            InitializeComponent();
        }

        private async void ctrlBenefits_LoadAsync(Object sender, EventArgs e)
        {
            cboSearch.Items.Add("ID");
            cboSearch.Items.Add("Nome");
            cboSearch.Items.Add("Plano");

            try
            {
                await loadBenefitsAsync();

            }
            catch
            {
                MessageBox.Show("Nenhum documento encontrado no banco de dados");
            }
        }

        public async Task loadBenefitsAsync()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("pro-vantagens");

            Query query = db.Collection("benefits");
            QuerySnapshot snapshots = await query.GetSnapshotAsync();

            dataGrid.Rows.Clear();

            foreach (DocumentSnapshot documentSnapshot in snapshots)
            {
                Benefits benefits = documentSnapshot.ConvertTo<Benefits>();
                if (cboSearch.Text == "")
                {
                    if (documentSnapshot.Exists)
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, benefits.name, benefits.description, benefits.card, benefits.value);
                    }
                }
                if (cboSearch.Text == "ID")
                {
                    if (documentSnapshot.Id.Contains(txtSearch.Text))
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, benefits.name, benefits.description, benefits.card, benefits.value);
                    }
                }
                if (cboSearch.Text == "Nome")
                {
                    if (benefits.name.Contains(txtSearch.Text))
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, benefits.name, benefits.description, benefits.card, benefits.value);
                    }
                }
                if (cboSearch.Text == "Plano")
                {
                    if (benefits.card.Contains(txtSearch.Text))
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, benefits.name, benefits.description, benefits.card, benefits.value);
                    }
                }
            }

            benefitID = dataGrid.Rows[0].Cells[0].Value.ToString();

        }

        private async void removerToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir o parceiro?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

                FirestoreDb db = FirestoreDb.Create("pro-vantagens");
                DocumentReference documentReference = db.Collection("benefits").Document(benefitID);

                await documentReference.DeleteAsync();
                try
                {
                    await loadBenefitsAsync();

                }
                catch
                {
                }
            }
            else
            {

            }
        }

        private void dataGrid_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            benefitID = dataGrid.CurrentRow.Cells[0].Value.ToString();
        }

        private async void editarToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (benefitID == null)
            {
                MessageBox.Show("Selecione um parceiro");
            }
            else
            {
                frmEditBenefit frm = new frmEditBenefit(benefitID);
                frm.ShowDialog();
                try
                {
                    await loadBenefitsAsync();
                }
                catch
                {
                }
            }

        }

        private async void adicionarToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            frmAddBenefit frm = new frmAddBenefit();
            frm.ShowDialog();
            await loadBenefitsAsync();
        }

        private async void btnSearch_Click(Object sender, EventArgs e)
        {
            try
            {
                await loadBenefitsAsync();

            }
            catch
            {
                MessageBox.Show("Nenhum documento encontrado no banco de dados");
            }
        }

        private async void btnShowAll_Click(Object sender, EventArgs e)
        {
            cboSearch.Text = "";
            try
            {
                await loadBenefitsAsync();

            }
            catch
            {
                MessageBox.Show("Nenhum documento encontrado no banco de dados");
            }
        }
    }
}

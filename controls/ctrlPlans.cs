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
    public partial class ctrlPlans : UserControl
    {
        public String plansID;

        public ctrlPlans()
        {
            InitializeComponent();
        }
        private async void ctrlPlans_LoadAsync(object sender, EventArgs e)
        {
            cboSearch.Items.Add("ID");
            cboSearch.Items.Add("Nome");
            cboSearch.Items.Add("Tipo");
            cboSearch.Items.Add("Valor");

            try
            {
                await loadPlansAsync();
            }
            catch
            {
                MessageBox.Show("Nenhum documento encontrado no banco de dados!");
            }
        }
        public async Task loadPlansAsync()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("pro-vantagens");

            Query plansQuery = db.Collection("plans");
            QuerySnapshot snapshots = await plansQuery.GetSnapshotAsync();

            dataGrid.Rows.Clear();


            foreach (DocumentSnapshot documentSnapshot in snapshots)
            {
                Plans plans = documentSnapshot.ConvertTo<Plans>();
                if (cboSearch.Text == "")
                {
                    if (documentSnapshot.Exists)
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, plans.name, plans.description, plans.type, plans.value);
                    }
                }
                if (cboSearch.Text == "Id")
                {
                    if (documentSnapshot.Id.Contains(txtSearch.Text))
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, plans.name, plans.description, plans.type, plans.value);
                    }
                }
                if (cboSearch.Text == "Nome")
                {
                    if (plans.name.Contains(txtSearch.Text))
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, plans.name, plans.description, plans.type, plans.value);
                    }
                }
                if (cboSearch.Text == "Tipo")
                {
                    if (plans.type.Contains(txtSearch.Text))
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, plans.name, plans.description, plans.type, plans.value);
                    }
                }
                if (cboSearch.Text == "Valor")
                {
                    if (plans.value.Contains(txtSearch.Text))
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, plans.name, plans.description, plans.type, plans.value);
                    }
                }
            }

            plansID = dataGrid.Rows[0].Cells[0].Value.ToString();

        }

        private async void removerToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir o parceiro?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

                FirestoreDb db = FirestoreDb.Create("pro-vantagens");
                DocumentReference documentReference = db.Collection("plans").Document(plansID);

                await documentReference.DeleteAsync();
                try
                {
                    await loadPlansAsync();
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
            plansID = dataGrid.CurrentRow.Cells[0].Value.ToString();
        }

        private async void editarToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (plansID == null)
            {
                MessageBox.Show("Selecione um parceiro");
            }
            else
            {
                frmEditPlan frm = new frmEditPlan(plansID);
                frm.ShowDialog();
                try
                {
                    await loadPlansAsync();
                }
                catch
                {
                }
            }

        }

        private async void adicionarToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            frmAddPlan frm = new frmAddPlan();
            frm.ShowDialog();
            try
            {
                await loadPlansAsync();
            }
            catch
            {
            }
        }

        private async void btnSearch_Click(Object sender, EventArgs e)
        {
            try
            {
                await loadPlansAsync();
            }
            catch
            {
                MessageBox.Show("Nenhum documento encontrado no banco de dados!");
            }
        }

        private async void btnShowAll_Click(Object sender, EventArgs e)
        {
            cboSearch.Text = "";
            try
            {
                await loadPlansAsync();
            }
            catch
            {
                MessageBox.Show("Nenhum documento encontrado no banco de dados!");
            }
        }

    }
}

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
    public partial class ctrlPagamentos : UserControl
    {
        public String invoiceID;
        public ctrlPagamentos()
        {
            InitializeComponent();
        }

        private async void ctrlPagamentos_Load(Object sender, EventArgs e)
        {
            cboSearch.Items.Add("Data da fatura");
            cboSearch.Items.Add("Nome");
            cboSearch.Items.Add("Tipo");
            cboSearch.Items.Add("Plano");
            cboSearch.Items.Add("Valor total");

            try
            {
                await loadInvoicesAsync();
            }
            catch
            {
                MessageBox.Show("Nenhum documento encontrado no banco de dados!");
            }
        }

        public async Task loadInvoicesAsync()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("pro-vantagens");

            Query queryUser = db.Collection("users");
            QuerySnapshot usersSnapshots = await queryUser.GetSnapshotAsync();


            dataGrid.Rows.Clear();

            foreach (DocumentSnapshot userDocument in usersSnapshots)
            {
                Clients clients = userDocument.ConvertTo<Clients>();

                Query Query = db.Collection("users").Document(userDocument.Id).Collection("payments");
                QuerySnapshot snapshots = await Query.GetSnapshotAsync();

                foreach (DocumentSnapshot documentSnapshot in snapshots)
                {
                    Payments payments= documentSnapshot.ConvertTo<Payments>();
                    if (btnPagos.Checked)
                    {
                        if (payments.status == "Ok")
                        {
                            if (cboSearch.Text == "")
                            {
                                if (documentSnapshot.Exists)
                                {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                                }
                            }
                            if (cboSearch.Text.Contains("Data da fatura"))
                            {
                                if (documentSnapshot.Id.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                                }
                            }
                            if (cboSearch.Text == "Tipo")
                            {
                                if (payments.cardType.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                                }
                            }
                            if (cboSearch.Text == "Plano")
                            {
                                if (payments.planName.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                                }
                            }
                            if (cboSearch.Text == "Valor total")
                            {
                                if (payments.value.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                                }
                            }
                        }
                    }
                    if (btnEstornado.Checked)
                    {
                        if (payments.status == "Vencido")
                        {
                            if (cboSearch.Text == "")
                            {
                                if (documentSnapshot.Exists)
                                {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                                }
                            }
                            if (cboSearch.Text.Contains("Data da fatura"))
                            {
                                if (documentSnapshot.Id.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                                }
                            }
                            if (cboSearch.Text == "Tipo")
                            {
                                if (payments.cardType.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                                }
                            }
                            if (cboSearch.Text == "Plano")
                            {
                                if (payments.planName.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                                }
                            }
                            if (cboSearch.Text == "Valor total")
                            {
                                if (payments.value.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                                }
                            }

                        }
                    }
                    if (btnAll.Checked)
                    {
                        if (cboSearch.Text == "")
                        {
                            if (documentSnapshot.Exists)
                            {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                            }
                        }
                        if (cboSearch.Text.Contains( "Data da fatura"))
                        {
                            if (documentSnapshot.Id.Contains(txtSearch.Text))
                            {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                            }
                        }
                        if (cboSearch.Text == "Tipo")
                        {
                            if (payments.cardType.Contains(txtSearch.Text))
                            {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                            }
                        }
                        if (cboSearch.Text == "Plano")
                        {
                            if (payments.planName.Contains(txtSearch.Text))
                            {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                            }
                        }
                        if (cboSearch.Text == "Valor total")
                        {
                            if (payments.value.Contains(txtSearch.Text))
                            {
                                    dataGrid.Rows.Add(documentSnapshot.Id, clients.name, payments.status, payments.planName, payments.cardType, payments.value);
                            }
                        }
                    }
                }

            };





            invoiceID = dataGrid.Rows[0].Cells[0].Value.ToString();

        }
        private async void removerToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir o parceiro?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

                FirestoreDb db = FirestoreDb.Create("pro-vantagens");
                DocumentReference documentReference = db.Collection("benefits").Document(invoiceID);

                await documentReference.DeleteAsync();
                try
                {
                    await loadInvoicesAsync();
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
            invoiceID = dataGrid.CurrentRow.Cells[0].Value.ToString();
        }

        private async void editarToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (invoiceID == null)
            {
                MessageBox.Show("Selecione uma fatura");
            }
            else
            {
                frmContractPlan frm = new frmContractPlan();
                frm.ShowDialog();
                try
                {
                    await loadInvoicesAsync();
                }
                catch
                {
                }
            }

        }

        private async void adicionarToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("Criar cliente");
            frmAddClient frm = new frmAddClient();
            frm.ShowDialog();
            try
            {
                await loadInvoicesAsync();
            }
            catch
            {
            }
        }

        private async void btnSearch_Click(Object sender, EventArgs e)
        {
            try
            {
                await loadInvoicesAsync();
            }
            catch
            {
                MessageBox.Show("Nenhum documento encontrado no banco de dados!");
            }
        }

        private async void btnShowAll_Click(Object sender, EventArgs e)
        {
            cboSearch.Text = "";
            btnEstornado.Checked = false;
            btnPagos.Checked = false;
            btnAll.Checked = true;
            try
            {
                await loadInvoicesAsync();
            }
            catch
            {
                MessageBox.Show("Nenhum documento encontrado no banco de dados!");
            }
        }

        private void btnEstornado_CheckedChanged(Object sender, EventArgs e)
        {
            if (btnEstornado.Checked == true)
            {
                btnPagos.Checked = false;
                btnAll.Checked = false;
            }
        }

        private void btnPagos_CheckedChanged(Object sender, EventArgs e)
        {
            if (btnPagos.Checked == true)
            {
                btnEstornado.Checked = false;
                btnAll.Checked = false;
            }
        }

        private void btnAll_CheckedChanged(Object sender, EventArgs e)
        {
            if (btnAll.Checked == true)
            {
                btnPagos.Checked = false;
                btnEstornado.Checked = false;
            }
        }

        private void editarToolStripMenuItem_Click_1(Object sender, EventArgs e)
        {

        }

        private void removerToolStripMenuItem_Click_1(Object sender, EventArgs e)
        {

        }
    }
}

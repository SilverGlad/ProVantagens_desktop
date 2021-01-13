using Google.Cloud.Firestore;
using ProVantagensApp.forms;
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
    public partial class ctrlFaturas : UserControl
    {
        public String userID, invoiceID;
        public ctrlFaturas()
        {
            InitializeComponent();
        }

        private async void ctrlFaturas_Load(Object sender, EventArgs e)
        {
            cboSearch.Items.Add("Data da fatura");
            cboSearch.Items.Add("Nome");
            cboSearch.Items.Add("Vencimento");
            cboSearch.Items.Add("Plano");
            cboSearch.Items.Add("Método de pegamento");
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

                Query Query = db.Collection("users").Document(userDocument.Id).Collection("invoices");
                QuerySnapshot snapshots = await Query.GetSnapshotAsync();

                foreach (DocumentSnapshot documentSnapshot in snapshots)
                {
                    Invoices invoices = documentSnapshot.ConvertTo<Invoices>();
                    if (btnPagos.Checked)
                    {
                        if (invoices.status == "Ok")
                        {
                            if (cboSearch.Text == "")
                            {
                                if (documentSnapshot.Exists)
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                        if (cboSearch.Text == "Data da fatura")
                            {
                                if (documentSnapshot.Id.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Nome")
                            {
                                if (invoices.holder.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Plano")
                            {
                                if (invoices.planName.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Vencimento")
                            {
                                if (invoices.dueDate.ToString() == txtSearch.Text)
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Método de pagamento")
                            {
                                if (invoices.paymentMethod.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Valor total")
                            {
                                if (invoices.totalValue.ToString().Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                        }

                    }
                    if (btnPendentes.Checked)
                    {
                        if (invoices.status == "Pendente")
                        {
                            if (cboSearch.Text == "")
                            {
                                if (documentSnapshot.Exists)
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                        if (cboSearch.Text == "Data da fatura")
                            {
                                if (documentSnapshot.Id.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Nome")
                            {
                                if (invoices.holder.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Plano")
                            {
                                if (invoices.planName.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Vencimento")
                            {
                                if (invoices.dueDate.ToString() == txtSearch.Text)
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Método de pagamento")
                            {
                                if (invoices.paymentMethod.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Valor total")
                            {
                                if (invoices.totalValue.ToString().Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                        }
                    }
                    if (btnVencidos.Checked)
                    {
                        if (invoices.status == "Vencido")
                        {
                            if (cboSearch.Text == "")
                            {
                                if (documentSnapshot.Exists)
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                        if (cboSearch.Text == "Data da fatura")
                            {
                                if (documentSnapshot.Id.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Nome")
                            {
                                if (invoices.holder.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Plano")
                            {
                                if (invoices.planName.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Vencimento")
                            {
                                if (invoices.dueDate.ToString() == txtSearch.Text)
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Método de pagamento")
                            {
                                if (invoices.paymentMethod.Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                                }
                            }
                            if (cboSearch.Text == "Valor total")
                            {
                                if (invoices.totalValue.ToString().Contains(txtSearch.Text))
                                {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
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
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                            }
                        }
                        if (cboSearch.Text == "Data da fatura")
                        {
                            if (documentSnapshot.Id.Contains(txtSearch.Text))
                            {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                            }
                        }
                        if (cboSearch.Text == "Nome")
                        {
                            if (invoices.holder.Contains(txtSearch.Text))
                            {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                            }
                        }
                        if (cboSearch.Text == "Plano")
                        {
                            if (invoices.planName.Contains(txtSearch.Text))
                            {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                            }
                        }
                        if (cboSearch.Text == "Vencimento")
                        {
                            if (invoices.dueDate.ToString() == txtSearch.Text)
                            {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                            }
                        }
                        if (cboSearch.Text == "Método de pagamento")
                        {
                            if (invoices.paymentMethod.Contains(txtSearch.Text))
                            {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                            }
                        }
                        if (cboSearch.Text == "Valor total")
                        {
                            if (invoices.totalValue.ToString().Contains(txtSearch.Text))
                            {
                                    dataGrid.Rows.Add(userDocument.Id, documentSnapshot.Id, invoices.holder, invoices.status, invoices.planName, invoices.paymentMethod, invoices.dueDate, invoices.totalValue);
                            }
                        }
                    }
                }

            };





            userID = dataGrid.Rows[0].Cells[0].Value.ToString();
            invoiceID = dataGrid.Rows[0].Cells[1].Value.ToString();

        }
        private async void removerToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir o parceiro?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

                FirestoreDb db = FirestoreDb.Create("pro-vantagens");
                DocumentReference documentReference = db.Collection("users").Document(userID).Collection("invoices").Document(invoiceID);

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
            userID = dataGrid.CurrentRow.Cells[0].Value.ToString();
            invoiceID = dataGrid.CurrentRow.Cells[1].Value.ToString();
        }

        private async void editarToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (invoiceID == null)
            {
                MessageBox.Show("Selecione uma fatura");
            }
            else
            {
                frmEditInvoice frm = new frmEditInvoice(userID, invoiceID);
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
            btnVencidos.Checked = false;
            btnPagos.Checked = false;
            btnPendentes.Checked = false;
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

        private void btnVencidos_CheckedChanged(Object sender, EventArgs e)
        {
            if (btnVencidos.Checked == true)
            {
                btnPagos.Checked = false;
                btnPendentes.Checked = false;
                btnAll.Checked = false;
            }
        }

        private void btnPagos_CheckedChanged(Object sender, EventArgs e)
        {
            if (btnPagos.Checked == true)
            {
                btnVencidos.Checked = false;
                btnPendentes.Checked = false;
                btnAll.Checked = false;
            }
        }

        private void btnAll_CheckedChanged(Object sender, EventArgs e)
        {
            if (btnAll.Checked == true)
            {
                btnVencidos.Checked = false;
                btnPagos.Checked = false;
                btnPendentes.Checked = false;
            }
        }

        private void btnPendentes_CheckedChanged(Object sender, EventArgs e)
        {
            if (btnPendentes.Checked == true)
            {
                btnVencidos.Checked = false;
                btnPagos.Checked = false;
                btnAll.Checked = false;
            }
        }
    }
}

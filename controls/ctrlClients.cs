using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
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
    public partial class ctrlClients : UserControl
    {
        public String userID;

        public ctrlClients()
        {
            InitializeComponent();
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.GetApplicationDefault(),
            });
        }

        private async void ctrlClients_LoadAsync(Object sender, EventArgs e)
        {
            cboSearch.Items.Add("ID");
            cboSearch.Items.Add("Nome");
            cboSearch.Items.Add("Plano");
            cboSearch.Items.Add("CPF");

            try
            {
                await loadUsersAsync();
            }
            catch
            {
                MessageBox.Show("Nenhum documento encontrado no banco de dados!");
            }
        }
        public async Task loadUsersAsync()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("pro-vantagens");

            Query Query = db.Collection("users");
            QuerySnapshot snapshots = await Query.GetSnapshotAsync();

            dataGrid.Rows.Clear();


            foreach (DocumentSnapshot documentSnapshot in snapshots)
            {
                Clients users = documentSnapshot.ConvertTo<Clients>();
                if (btnClientes.Checked)
                {
                    if(users.accessLevel < 1)
                    {
                        if (cboSearch.Text == "")
                        {
                            if (documentSnapshot.Exists)
                            {
                                dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
                            }
                        }
                        if (cboSearch.Text == "Id")
                        {
                            if (documentSnapshot.Id.Contains(txtSearch.Text))
                            {
                                dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
                            }
                        }
                        if (cboSearch.Text == "Nome")
                        {
                            if (users.name.Contains(txtSearch.Text))
                            {
                                dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
                            }
                        }
                        if (cboSearch.Text == "Plano")
                        {
                            if (users.plan.Contains(txtSearch.Text))
                            {
                                dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
                            }
                        }
                        if (cboSearch.Text == "CPF")
                        {
                            if (users.cpf.Contains(txtSearch.Text))
                            {
                                dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
                            }
                        }
                    }

                }
                if (btnFunc.Checked)
                {
                    if(users.accessLevel > 0)
                    {
                        if (cboSearch.Text == "")
                        {
                            if (documentSnapshot.Exists)
                            {
                                dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
                            }
                        }
                        if (cboSearch.Text == "Id")
                        {
                            if (documentSnapshot.Id.Contains(txtSearch.Text))
                            {
                                dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
                            }
                        }
                        if (cboSearch.Text == "Nome")
                        {
                            if (users.name.Contains(txtSearch.Text))
                            {
                                dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
                            }
                        }
                        if (cboSearch.Text == "Plano")
                        {
                            if (users.plan.Contains(txtSearch.Text))
                            {
                                dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
                            }
                        }
                        if (cboSearch.Text == "CPF")
                        {
                            if (users.cpf.Contains(txtSearch.Text))
                            {
                                dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
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
                            dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
                        }
                    }
                    if (cboSearch.Text == "Id")
                    {
                        if (documentSnapshot.Id.Contains(txtSearch.Text))
                        {
                            dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
                        }
                    }
                    if (cboSearch.Text == "Nome")
                    {
                        if (users.name.Contains(txtSearch.Text))
                        {
                            dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
                        }
                    }
                    if (cboSearch.Text == "Plano")
                    {
                        if (users.plan.Contains(txtSearch.Text))
                        {
                            dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
                        }
                    }
                    if (cboSearch.Text == "CPF")
                    {
                        if (users.cpf.Contains(txtSearch.Text))
                        {
                            dataGrid.Rows.Add(documentSnapshot.Id, users.name, users.dtn, users.email, users.tel1, users.cpf, users.estadocivil, users.plan);
                        }
                    }
                }        
            }

            userID = dataGrid.Rows[0].Cells[0].Value.ToString();

        }

        private async void removerToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir o parceiro?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

                FirestoreDb db = FirestoreDb.Create("pro-vantagens");
                DocumentReference documentReference = db.Collection("users").Document(userID);
                removerToolStripMenuItem.Enabled = false;
                await FirebaseAuth.DefaultInstance.DeleteUserAsync(userID);                
                await documentReference.DeleteAsync();
                removerToolStripMenuItem.Enabled = true;
                try
                {
                    await loadUsersAsync();
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
        }

        private async void editarToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (userID == null)
            {
                MessageBox.Show("Selecione um parceiro");
            }
            else
            {
                ctrlEditClient frm = new ctrlEditClient(userID);
                frm.ShowDialog();
                try
                {
                    await loadUsersAsync();
                }
                catch
                {
                }
            }

        }

        private async void adicionarToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            frmAddClient frm = new frmAddClient();
            frm.ShowDialog();
            try
            {
                await loadUsersAsync();
            }
            catch
            {
            }
        }

        private async void btnSearch_Click(Object sender, EventArgs e)
        {
            try
            {
                await loadUsersAsync();
            }
            catch
            {
                MessageBox.Show("Nenhum documento encontrado no banco de dados!");
            }
        }

        private async void btnShowAll_Click(Object sender, EventArgs e)
        {
            cboSearch.Text = "";
            txtSearch.Text = "";
            btnAll.Checked = true;
            btnClientes.Checked = false;
            btnFunc.Checked = false;
            try
            {
                await loadUsersAsync();
            }
            catch
            {
                MessageBox.Show("Nenhum documento encontrado no banco de dados!");
            }
        }

        private void btnFunc_CheckedChanged(Object sender, EventArgs e)
        {
            if (btnFunc.Checked == true)
            {
                btnClientes.Checked = false;
                btnAll.Checked = false;
            }
        }

        private void btnClientes_CheckedChanged(Object sender, EventArgs e)
        {
            if (btnClientes.Checked == true)
            {
                btnFunc.Checked = false;
                btnAll.Checked = false;
            }
        }

        private void btnAll_CheckedChanged(Object sender, EventArgs e)
        {
            if(btnAll.Checked == true)
            {
                btnFunc.Checked = false;
                btnClientes.Checked = false;
            }
        }
    }
}

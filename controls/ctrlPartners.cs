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
    public partial class ctrlPartners : UserControl
    {
        public String partnerID;
        public ctrlPartners()
        {
            InitializeComponent();
        }

        private async void ctrlPartners_LoadAsync(Object sender, EventArgs e)
        {
            cboSearch.Items.Add("ID");
            cboSearch.Items.Add("Nome");
            cboSearch.Items.Add("Estado");
            cboSearch.Items.Add("Cidade");
            cboSearch.Items.Add("Bairro");
            cboSearch.Items.Add("Rua");
            cboSearch.Items.Add("Tipo");

            try
            {
                await loadPartnersAsync();

            }
            catch
            {
                MessageBox.Show("Nenhum documento encontrado no banco de dados");
            }
        }

        private async void btnSearch_Click(Object sender, EventArgs e)
        {
            try
            {
                await loadPartnersAsync();

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
                await loadPartnersAsync();

            }
            catch
            {
                MessageBox.Show("Nenhum documento encontrado no banco de dados");
            }
        }

        public async Task loadPartnersAsync()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("pro-vantagens");

            Query partnersQuery = db.Collection("partners");
            QuerySnapshot snapshots = await partnersQuery.GetSnapshotAsync();

            dataGrid.Rows.Clear();

            foreach (DocumentSnapshot documentSnapshot in snapshots)
            {

                Partners partners = documentSnapshot.ConvertTo<Partners>();
                if (cboSearch.Text == "")
                {
                    if (documentSnapshot.Exists)
                    {
                            dataGrid.Rows.Add(documentSnapshot.Id, partners.name, partners.type, partners.address.state, partners.address.city, partners.address.district, partners.address.street);
                    }
                }
                if (cboSearch.Text == "ID")
                {
                     if (documentSnapshot.Id.Contains(txtSearch.Text))
                     {
                            dataGrid.Rows.Add(documentSnapshot.Id, partners.name, partners.type, partners.address.state, partners.address.city, partners.address.district, partners.address.street);
                     }
                  
                }
                if (cboSearch.Text == "Nome")
                {
                    if (partners.name.Contains(txtSearch.Text))
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, partners.name, partners.type, partners.address.state, partners.address.city, partners.address.district, partners.address.street);
                    }
                }
                if (cboSearch.Text == "Cidade")
                {
                    if (partners.address.city.Contains(txtSearch.Text))
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, partners.name, partners.type, partners.address.state, partners.address.city, partners.address.district, partners.address.street);
                    }
                }
                if (cboSearch.Text == "Rua")
                {
                    if (partners.address.street.Contains(txtSearch.Text))
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, partners.name, partners.type, partners.address.state, partners.address.city, partners.address.district, partners.address.street);
                    }
                }
                if (cboSearch.Text == "Bairro")
                {
                    if (partners.address.district.Contains(txtSearch.Text))
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, partners.name, partners.type, partners.address.state, partners.address.city, partners.address.district, partners.address.street);
                    }
                }
                if (cboSearch.Text == "Estado")
                {
                    if (partners.address.state.Contains(txtSearch.Text))
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, partners.name, partners.type, partners.address.state, partners.address.city, partners.address.district, partners.address.street);
                    }
                }
                if (cboSearch.Text == "Tipo")
                {
                    if (partners.type.Contains(txtSearch.Text))
                    {
                        dataGrid.Rows.Add(documentSnapshot.Id, partners.name, partners.type, partners.address.state, partners.address.city, partners.address.district, partners.address.street);
                    }
                }

            }

            partnerID = dataGrid.Rows[0].Cells[0].Value.ToString();

        }

        private void dataGrid_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            partnerID = dataGrid.CurrentRow.Cells[0].Value.ToString();
        }

        private async void editarToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if(partnerID == null)
            {
                MessageBox.Show("Selecione um parceiro");
            }
            else
            {
                frmEditPartner frm = new frmEditPartner(partnerID);
                frm.ShowDialog();
                cboSearch.Text = "";
                try
                {
                    await loadPartnersAsync();

                }
                catch
                {
                }
            }
            
        }

        private async void adicionarToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            frmAddPartner frm = new frmAddPartner();
            frm.ShowDialog();
            cboSearch.Text = "";
            try
            {
                await loadPartnersAsync();

            }
            catch
            {
            }

        }

        private async void removerToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir o parceiro?" , "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

                FirestoreDb db = FirestoreDb.Create("pro-vantagens");
                DocumentReference documentReference = db.Collection("partners").Document(partnerID);

                await documentReference.DeleteAsync();

                cboSearch.Text = "";
                try
                {
                    await loadPartnersAsync();

                }
                catch
                {
                }
            }
            else
            {
                
            }
        }
    }
}

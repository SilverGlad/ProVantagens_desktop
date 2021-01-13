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
    public partial class frmFinalizeClient : Form
    {
        string clientID, planID;
        Clients clients = new Clients();
        Dependents dependents = new Dependents();
        Invoices invoices = new Invoices();
        Plans plans = new Plans();
        int groupNum = 1;
        int i;
        private DocumentReference userReference, planReference;
        private DocumentSnapshot userSnap, planSnap;
        List<String> relations = new List<string>()
        {
          "Cônjuge",
          "Pai/Mãe",
          "Filho(a)",
        };

        private async void frmFinalizeClient_Load(Object sender, EventArgs e)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("pro-vantagens");

            userReference = db.Collection("users").Document(clientID);
            planReference = db.Collection("plans").Document(planID);
            planSnap = await planReference.GetSnapshotAsync();
            userSnap = await userReference.GetSnapshotAsync();

            Plans plans = planSnap.ConvertTo<Plans>();
            Clients clients = userSnap.ConvertTo<Clients>();

            txtHolder.Text = clients.name;
            txtPlanName.Text = plans.name;
            txtPlanValue.Text = plans.value;

        }

        string stringPlanValue, stringAditionalValue, stringTotalValue;
        private void txtPlanValue_TextChanged(Object sender, EventArgs e)
        {
            try
            {
                stringPlanValue = txtPlanValue.Text.Replace("R$", "");
                txtPlanValue.Text = string.Format("{0:C}", Convert.ToDouble(stringPlanValue));
            }
            catch
            {

            }
        }

        private void txtAditional_TextChanged(Object sender, EventArgs e)
        {
            try
            {
                stringAditionalValue = txtAditional.Text.Replace("R$", "");
                txtAditional.Text = string.Format("{0:C}", Convert.ToDouble(stringAditionalValue));
            }
            catch
            {

            }
        }

        private async void btnSalvar_Click(Object sender, EventArgs e)
        {


            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"dueDate", txtDueDate.Text},
                {"dependents", dependents},
            };

            await userReference.UpdateAsync(data);
            this.Close();
            frmFinalizeClient frm = new frmFinalizeClient();
            frm.Show();
        }

        private void btnAddDependent_Click(Object sender, EventArgs e)
        {
            GroupBox box = new GroupBox();
            Label lbNameDependent = new Label();
            Label lbDtnDependent = new Label();
            Label lbRelationDependent = new Label();
            TextBox txtNameDependent = new TextBox();
            MaskedTextBox txtDtnDependent = new MaskedTextBox();
            ComboBox cboRelationDependent = new ComboBox();

            pnDependents.Controls.Add(box);
            box.Name = "dependent" + groupNum.ToString();
            box.Text = "Dependente " + groupNum.ToString();
            box.Width = 498;
            box.Height = 100;
            box.Location = new Point(18, i + 44);

            box.Controls.Add(lbNameDependent);
            lbNameDependent.Name = "lbNameDependent" + groupNum.ToString();
            lbNameDependent.Text = "";
            lbNameDependent.Font = new Font("Lucida Sans Unicode", 12, FontStyle.Bold);
            lbNameDependent.Location = new Point(6, 22);

            box.Controls.Add(lbDtnDependent);
            lbDtnDependent.Name = "lbDtnDependent" + groupNum.ToString();
            lbDtnDependent.Text = "";
            lbDtnDependent.Font = new Font("Lucida Sans Unicode", 12, FontStyle.Bold);
            lbDtnDependent.Location = new Point(4, 66);

            box.Controls.Add(lbRelationDependent);
            lbRelationDependent.Name = "lbRelationDependent" + groupNum.ToString();
            lbRelationDependent.Text = "";
            lbRelationDependent.Font = new Font("Lucida Sans Unicode", 12, FontStyle.Bold);
            lbRelationDependent.Location = new Point(223, 66);

            box.Controls.Add(txtNameDependent);
            txtNameDependent.Name = "txtNameDependent" + groupNum.ToString();
            txtNameDependent.Text = "";
            txtNameDependent.Font = new Font("Lucida Sans Unicode", 10, FontStyle.Regular);
            txtNameDependent.Location = new Point(81, 19);
            txtNameDependent.Size = new Size(390, 28);

            box.Controls.Add(txtDtnDependent);
            txtDtnDependent.Name = "txtDtnDependent" + groupNum.ToString();
            txtDtnDependent.Text = "";
            txtDtnDependent.Mask = "00/00/0000";
            txtDtnDependent.Font = new Font("Lucida Sans Unicode", 10, FontStyle.Regular);
            txtDtnDependent.Location = new Point(129, 62);
            txtDtnDependent.Size = new Size(88, 28);


            box.Controls.Add(cboRelationDependent);
            cboRelationDependent.Name = "cboRelationDependent" + groupNum.ToString();
            cboRelationDependent.Font = new Font("Lucida Sans Unicode", 10, FontStyle.Regular);
            cboRelationDependent.Location = new Point(312, 62);
            cboRelationDependent.Size = new Size(159, 24);
            cboRelationDependent.DataSource = relations;

            if (plans.type == "Familia")
            {
                if (groupNum > 5)
                {
                    txtAditional.Text = ((groupNum - 5) * 9.90).ToString();
                }
            }
            else
            {
                txtAditional.Text = ((groupNum) * 9.90).ToString();
            }

            i = i + 106;
            groupNum = groupNum + 1;


        }

        public frmFinalizeClient()
        {
            InitializeComponent();
        }



    }
}

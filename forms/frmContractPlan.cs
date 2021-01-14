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
    public partial class frmContractPlan : Form
    {
        string userID;
        int groupNum = 1;
        int i;
        private DocumentReference documentReference;

        public frmContractPlan(string userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private async void frmContractPlan_Load(Object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("pro-vantagens");

            Query plansQuery = db.Collection("plans");
            QuerySnapshot snapshots = await plansQuery.GetSnapshotAsync();

            foreach (DocumentSnapshot plansSnapshot in snapshots)
            {
                Plans plans = plansSnapshot.ConvertTo<Plans>();

                GroupBox box = new GroupBox();
                Label lbName = new Label();
                Label lbType = new Label();
                Label lbDescription = new Label();
                Label lbValue = new Label();
                Label txtName = new Label();
                Label txtType = new Label();
                Label txtValue = new Label();
                TextBox txtDescription = new TextBox();
                Button buttonNext = new Button();


                pnPlans.Controls.Add(box);
                box.Name = "Op" + groupNum.ToString();
                box.Text = "Opção " + groupNum.ToString();
                box.Width = 579;
                box.Height = 199;
                box.Location = new Point(12, i + 12);
                box.BackColor = Color.Transparent;

                box.Controls.Add(txtName);
                txtName.Name = "txtName" + groupNum.ToString();
                txtName.Text = plans.name;
                txtName.Font = new Font("Lucida Sans Unicode", 12, FontStyle.Regular);
                txtName.Location = new Point(161, 16);
                txtName.BackColor = Color.Transparent;

                box.Controls.Add(txtType);
                txtType.Name = "txtType" + groupNum.ToString();
                txtType.Text = plans.type;
                txtType.Font = new Font("Lucida Sans Unicode", 12, FontStyle.Regular);
                txtType.Location = new Point(161, 51);
                txtType.BackColor = Color.Transparent;

                box.Controls.Add(txtDescription);
                txtDescription.Name = "txtDescription" + groupNum.ToString();
                txtDescription.Text = plans.description;
                txtDescription.Font = new Font("Lucida Sans Unicode", 12, FontStyle.Regular);
                txtDescription.Location = new Point(161, 80);
                txtDescription.ReadOnly = true;
                txtDescription.Multiline = true;
                txtDescription.Size = new Size(412, 83);


                box.Controls.Add(txtValue);
                txtValue.Name = "txtValue" + groupNum.ToString();
                txtValue.Text = plans.value;
                txtValue.Font = new Font("Lucida Sans Unicode", 12, FontStyle.Regular);
                txtValue.Location = new Point(494, 16);
                txtValue.BackColor = Color.Transparent;

                box.Controls.Add(lbName);
                lbName.Name = "lbName" + groupNum.ToString();
                lbName.Text = "Nome do plano:";
                lbName.Font = new Font("Lucida Sans Unicode", 10, FontStyle.Bold);
                lbName.Location = new Point(6, 16);
                lbName.BackColor = Color.Transparent;
                lbName.AutoSize = true;

                box.Controls.Add(lbType);
                lbType.Name = "lbType" + groupNum.ToString();
                lbType.Text = "Tipo de plano:";
                lbType.Font = new Font("Lucida Sans Unicode", 10, FontStyle.Bold);
                lbType.Location = new Point(6, 51);
                lbType.BackColor = Color.Transparent;
                lbType.AutoSize = true;

                box.Controls.Add(lbDescription);
                lbDescription.Name = "lbDescription" + groupNum.ToString();
                lbDescription.Text = "Descrição:";
                lbDescription.Font = new Font("Lucida Sans Unicode", 10, FontStyle.Bold);
                lbDescription.Location = new Point(54, 80);
                lbDescription.BackColor = Color.Transparent;
                lbDescription.AutoSize = true;

                box.Controls.Add(lbValue);
                lbValue.Name = "lbValue" + groupNum.ToString();
                lbValue.Text = "Valor do plano:";
                lbValue.Font = new Font("Lucida Sans Unicode", 10, FontStyle.Bold);
                lbValue.Location = new Point(344, 16);
                lbValue.BackColor = Color.Transparent;
                lbValue.AutoSize = true;

                box.Controls.Add(buttonNext);
                buttonNext.Name = plansSnapshot.Id;
                buttonNext.Text = "Avançar";
                buttonNext.Font = new Font("Lucida Sans Unicode", 10, FontStyle.Regular);
                buttonNext.Location = new Point(498, 166);
                buttonNext.Size = new Size(75,30);
                buttonNext.Click += delegate(object send, EventArgs ex)
                {
                    callContract(send, ex, plansSnapshot.Id, plans.type, plans.name, plans.value);
                };

                i = i + 208;
                groupNum = groupNum + 1;

            }




        }

        private async void savePlan(string planName, string planValue, string planID)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            FirestoreDb db = FirestoreDb.Create("pro-vantagens");
            documentReference = db.Collection("users").Document(userID);


            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"plan", planName},
                {"planvalue", planValue},
            };

            await documentReference.UpdateAsync(data);
            this.Close();
            frmFinalizeClient frm = new frmFinalizeClient(userID, planID);
            frm.ShowDialog();

        }

        private void callContract(Object sender, EventArgs e, string planID, string planType, string planName, string planValue)
        {
            Button button = (Button)sender;
            try
            {
                savePlan(planName, planValue, planID);
            }
            catch
            {
                MessageBox.Show("Erro ao selecionar e salvar plano");
            }
        }
    }
}

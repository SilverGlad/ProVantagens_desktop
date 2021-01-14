using Google.Cloud.Firestore;
using System;
using System.Collections;
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
        List<Dependents> dependentsList = new List<Dependents>();
        int groupNum = 0;
        int i;
        string monthNow;
        private DocumentReference userReference, planReference, invoiceReference;
        private DocumentSnapshot userSnap, planSnap, invoiceSnap;
        List<TextBox> textBoxes = new List<TextBox>();
        List<ComboBox> comboBoxes = new List<ComboBox>();
        List<MaskedTextBox> maskedTextBoxes = new List<MaskedTextBox>();


        private async void frmFinalizeClient_Load(Object sender, EventArgs e)
        {
            monthNow = DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString();
            if(DateTime.Now.Month < 10)
            {
                monthNow = "0" + monthNow;
            }
            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("pro-vantagens");

            userReference = db.Collection("users").Document(clientID);
            planReference = db.Collection("plans").Document(planID);
            planSnap = await planReference.GetSnapshotAsync();
            userSnap = await userReference.GetSnapshotAsync();
            invoiceReference = db.Collection("users").Document(clientID).Collection("invoices").Document(monthNow);
            invoiceSnap = await invoiceReference.GetSnapshotAsync();


            plans = planSnap.ConvertTo<Plans>();
            clients = userSnap.ConvertTo<Clients>();

            if (invoiceSnap.Exists)
            {
                invoices = invoiceSnap.ConvertTo<Invoices>();
                txtHolder.Text = clients.name;
                txtPlanName.Text = invoices.planName;
                txtPlanValue.Text = invoices.value;
                txtAditional.Text = invoices.aditional.ToString();
                cboPaymentMethod.Text = invoices.paymentMethod;
                txtDueDate.Text = invoices.dueDate.ToString();
                if(clients.dependents.Count > 0)
                {
                    dependentsList = clients.dependents;
                    for (int x = 0; x < dependentsList.Count; x++)
                    {
                        addDependent();
                    }
                }


            }
            else
            {
                txtHolder.Text = clients.name;
                txtPlanName.Text = plans.name + " (" + plans.type + ")";
                txtPlanValue.Text = plans.value;
                txtAditional.Text = "0";
            }

            cboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        string stringPlanValue, stringAditionalValue, stringTotalValue;

        private void txtTotalValue_TextChanged(Object sender, EventArgs e)
        {
            try
            {
                stringTotalValue = txtTotalValue.Text.Replace("R$", "");
                txtTotalValue.Text = string.Format("{0:C}", Convert.ToDouble(stringTotalValue));
            }
            catch
            {

            }
        }

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
                double valorTotal = double.Parse(txtAditional.Text.Replace("R$ ", "")) + double.Parse(txtPlanValue.Text.Replace("R$ ", ""));
                txtTotalValue.Text = valorTotal.ToString();
            }
            catch
            {

            }
        }

        async void setData()
        {
            dependentsList.Clear();
                for (int i = 0; i < groupNum; i++)
                {
                dependents = new Dependents();
                if (plans.type == "Familia")
                    {
                        if (i > 5)
                        {
                            dependents.aditional = true;

                        }
                        else
                        {
                            dependents.aditional = false;

                        }
                    }
                    else
                    {
                        dependents.aditional = true;

                    }

                    dependents.name = textBoxes[i].Text;
                    dependents.dtn = maskedTextBoxes[i].Text;
                    dependents.relation = comboBoxes[i].Text;
                    dependentsList.Add(dependents);
            }           


            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"dependents", dependentsList},
                {"dueDate", int.Parse(txtDueDate.Text)},
                {"paymentMethod", cboPaymentMethod.Text}
            };


            Dictionary<string, object> invoiceData = new Dictionary<string, object>()
            {
                {"aditional", double.Parse(txtAditional.Text.Replace("R$ ", ""))},
                {"dueDate", int.Parse(txtDueDate.Text)},
                {"holder", txtHolder.Text},
                {"month", DateTime.Now.Month.ToString()},
                {"paymentMethod", cboPaymentMethod.Text},
                {"planName", txtPlanName.Text},
                {"status", "Pendente"},
                {"totalValue", double.Parse(txtTotalValue.Text.Replace("R$ ", ""))},
                {"value", txtPlanValue.Text},
            };

            await userReference.UpdateAsync(data);
                await invoiceReference.SetAsync(invoiceData);
        }

        private void btnSalvar_Click(Object sender, EventArgs e)
        {
            try
            {
                setData();
                MessageBox.Show("Dados salvos com sucesso");
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void addDependent() {
            GroupBox box = new GroupBox();
            Label lbNameDependent = new Label();
            Label lbDtnDependent = new Label();
            Label lbRelationDependent = new Label();
            TextBox txtNameDependent = new TextBox();
            MaskedTextBox txtDtnDependent = new MaskedTextBox();
            ComboBox cboRelationDependent = new ComboBox();
            Button btnDelete = new Button();

            pnDependents.Controls.Add(box);
            box.Name = "dependent" + groupNum.ToString();
            box.Text = "Dependente " + groupNum.ToString();
            box.Width = 498;
            box.Height = 100;
            box.Location = new Point(18, i + 44);
            box.Dock = DockStyle.Top;
            box.BringToFront();

            box.Controls.Add(lbNameDependent);
            lbNameDependent.Name = "lbNameDependent" + groupNum.ToString();
            lbNameDependent.Text = "Nome:";
            lbNameDependent.Font = new Font("Lucida Sans Unicode", 12, FontStyle.Bold);
            lbNameDependent.Location = new Point(6, 22);
            lbNameDependent.AutoSize = true;

            box.Controls.Add(lbDtnDependent);
            lbDtnDependent.Name = "lbDtnDependent" + groupNum.ToString();
            lbDtnDependent.Text = "Nascimento:";
            lbDtnDependent.Font = new Font("Lucida Sans Unicode", 12, FontStyle.Bold);
            lbDtnDependent.Location = new Point(4, 66);
            lbDtnDependent.AutoSize = true;

            box.Controls.Add(lbRelationDependent);
            lbRelationDependent.Name = "lbRelationDependent" + groupNum.ToString();
            lbRelationDependent.Text = "Relação";
            lbRelationDependent.Font = new Font("Lucida Sans Unicode", 12, FontStyle.Bold);
            lbRelationDependent.Location = new Point(223, 66);
            lbRelationDependent.AutoSize = true;

            box.Controls.Add(txtNameDependent);
            txtNameDependent.Name = "txtNameDependent" + groupNum.ToString();
            txtNameDependent.Text = "";
            txtNameDependent.Font = new Font("Lucida Sans Unicode", 10, FontStyle.Regular);
            txtNameDependent.Location = new Point(81, 19);
            txtNameDependent.Size = new Size(370, 28);
            textBoxes.Add(txtNameDependent);

            box.Controls.Add(txtDtnDependent);
            txtDtnDependent.Name = "txtDtnDependent" + groupNum.ToString();
            txtDtnDependent.Text = "";
            txtDtnDependent.Mask = "00/00/0000";
            txtDtnDependent.Font = new Font("Lucida Sans Unicode", 10, FontStyle.Regular);
            txtDtnDependent.Location = new Point(129, 62);
            txtDtnDependent.Size = new Size(88, 28);
            maskedTextBoxes.Add(txtDtnDependent);


            box.Controls.Add(cboRelationDependent);
            cboRelationDependent.Name = "cboRelationDependent" + groupNum.ToString();
            cboRelationDependent.Font = new Font("Lucida Sans Unicode", 10, FontStyle.Regular);
            cboRelationDependent.Location = new Point(312, 62);
            cboRelationDependent.Size = new Size(139, 24);
            cboRelationDependent.Items.Add("Cônjuge");
            cboRelationDependent.Items.Add("Pai / Mãe");
            cboRelationDependent.Items.Add("Filho(a)");
            comboBoxes.Add(cboRelationDependent);

            box.Controls.Add(btnDelete);
            btnDelete.Name = "btnDelete" + groupNum.ToString();
            btnDelete.Location = new Point(460, 10);
            btnDelete.Size = new Size(34, 23);
            btnDelete.BackgroundImage = Properties.Resources.iconMenos;
            btnDelete.BackgroundImageLayout = ImageLayout.Stretch;
            btnDelete.BackColor = Color.Transparent;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += delegate (object send, EventArgs ex)
            {
                deleteBox(send, ex, box.Name);
            };

            if(dependentsList.Count > 0 && groupNum < dependentsList.Count)
            {
                txtNameDependent.Text = dependentsList[groupNum].name;
                txtDtnDependent.Text = dependentsList[groupNum].dtn;
                cboRelationDependent.Text = dependentsList[groupNum].relation;

            }


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


        private void btnAddDependent_Click(Object sender, EventArgs e)
        {
            addDependent();            
        }
        private void deleteBox(Object sender, EventArgs e, String group)
        {
            Button button = (Button)sender;
            try
            {
                if (groupNum > 1)
                {

                    foreach (Control item in pnDependents.Controls.OfType<Control>())
                    {
                        if (item.Name == group)
                        {
                            pnDependents.Controls.Remove(item);
                            i = i - 106;
                            if (plans.type == "Familia")
                            {
                                if ((groupNum - 1) > 5)
                                {
                                    txtAditional.Text = ((groupNum - 6) * 9.90).ToString();
                                }
                                else
                                {
                                    txtAditional.Text = "0";
                                }
                            }
                            else
                            {
                                txtAditional.Text = (((groupNum - 1) * 9.90)).ToString();
                            }
                        }
                        else
                        {

                        }
                        break;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public frmFinalizeClient(string clientID, string planID)
        {
            InitializeComponent();
            this.planID = planID;
            this.clientID = clientID;
        }



    }
}

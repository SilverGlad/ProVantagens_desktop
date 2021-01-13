using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProVantagensApp.forms
{
    public partial class frmEditInvoice : Form
    {
        private String invoiceID, userID;
        private Invoices invoices = new Invoices();
        private int _width;
        string checkboxes = "";
        private bool check;
        private DocumentReference documentReference;
        private DocumentSnapshot documentSnapshot;
        private String imgFile;
        public frmEditInvoice(String userID, String invoiceID)
        {
            InitializeComponent();
            this.invoiceID = invoiceID;
            this.userID = userID;
        }

        private async void frmEditInvoice_Load(Object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("pro-vantagens");
            documentReference = db.Collection("users").Document(userID).Collection("invoices").Document(invoiceID);
            documentSnapshot = await documentReference.GetSnapshotAsync();

            invoices = documentSnapshot.ConvertTo<Invoices>();

            txtHolder.Text = invoices.holder;
            txtPlanName.Text = invoices.planName;
            cboPaymentMethod.Text = invoices.paymentMethod;
            cboStatus.Text = invoices.status;
            txtPlanValue.Text = (double.Parse(invoices.value, CultureInfo.InvariantCulture)).ToString();
            txtAditional.Text = invoices.aditional.ToString();
            txtTotalValue.Text = invoices.totalValue.ToString();
            txtDueDate.Text = invoices.dueDate.ToString();
        }



        string stringValorPlano;
        string stringValorAditional;
        string stringValorTotal;
        double valorPlano, valorAditional, valorTotal;

        //Valor adicional
        private void txt_valor_adicional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txtAditional.Text.Contains(","));
                }
                else
                    e.Handled = true;
            }
        }
        private void txt_valor_adicional_Leave(object sender, EventArgs e)
        {
            try
            {
                stringValorAditional = txtAditional.Text.Replace("R$", "");
                txtAditional.Text = string.Format("{0:C}", Convert.ToDouble(stringValorAditional));
            }
            catch
            {

            }

        }

        private void txt_valor_adicional_KeyUp(object sender, KeyEventArgs e)
        {
            stringValorAditional = txtAditional.Text.Replace("R$", "").Replace(",", "").Replace(" ", "").Replace("00,", "");
            if (stringValorAditional.Length == 0)
            {
                txtAditional.Text = "0,00" + stringValorAditional;
            }
            if (stringValorAditional.Length == 1)
            {
                txtAditional.Text = "0,0" + stringValorAditional;
            }
            if (stringValorAditional.Length == 2)
            {
                txtAditional.Text = "0," + stringValorAditional;
            }
            else if (stringValorAditional.Length >= 3)
            {
                if (txtAditional.Text.StartsWith("0,"))
                {
                    txtAditional.Text = stringValorAditional.Insert(stringValorAditional.Length - 2, ",").Replace("0,", "");
                }
                else if (txtAditional.Text.Contains("00,"))
                {
                    txtAditional.Text = stringValorAditional.Insert(stringValorAditional.Length - 2, ",").Replace("00,", "");
                }
                else
                {
                    txtAditional.Text = stringValorAditional.Insert(stringValorAditional.Length - 2, ",");
                }
            }
            stringValorAditional = txtAditional.Text;
            txtAditional.Text = string.Format("{0:C}", Convert.ToDouble(stringValorAditional));
            txtAditional.Select(txtAditional.Text.Length, 0);
        }


        //valor total

        private void txt_stringValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txtTotalValue.Text.Contains(","));
                }
                else
                    e.Handled = true;
            }
        }

        private void txt_stringValorTotal_Leave(object sender, EventArgs e)
        {
            try
            {
                stringValorTotal = txtTotalValue.Text.Replace("R$", "");
                txtTotalValue.Text = string.Format("{0:C}", Convert.ToDouble(stringValorTotal));
            }
            catch
            {

            }

        }

        private void txt_stringValorTotal_KeyUp(object sender, KeyEventArgs e)
        {
            stringValorTotal = txtTotalValue.Text.Replace("R$", "").Replace(",", "").Replace(" ", "").Replace("00,", "");
            if (stringValorTotal.Length == 0)
            {
                txtTotalValue.Text = "0,00" + stringValorTotal;
            }
            if (stringValorTotal.Length == 1)
            {
                txtTotalValue.Text = "0,0" + stringValorTotal;
            }
            if (stringValorTotal.Length == 2)
            {
                txtTotalValue.Text = "0," + stringValorTotal;
            }
            else if (stringValorTotal.Length >= 3)
            {
                if (txtTotalValue.Text.StartsWith("0,"))
                {
                    txtTotalValue.Text = stringValorTotal.Insert(stringValorTotal.Length - 2, ",").Replace("0,", "");
                }
                else if (txtTotalValue.Text.Contains("00,"))
                {
                    txtTotalValue.Text = stringValorTotal.Insert(stringValorTotal.Length - 2, ",").Replace("00,", "");
                }
                else
                {
                    txtTotalValue.Text = stringValorTotal.Insert(stringValorTotal.Length - 2, ",");
                }
            }
            stringValorTotal = txtTotalValue.Text;
            txtTotalValue.Text = string.Format("{0:C}", Convert.ToDouble(stringValorTotal));
            txtTotalValue.Select(txtTotalValue.Text.Length, 0);
        }

        async void updateData()
        {


            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"aditional", double.Parse(txtAditional.Text.Replace("R$ ", ""))},
                {"dueDate", int.Parse(txtDueDate.Text)},
                {"paymentMethod", cboPaymentMethod.Text},
                {"status", cboStatus.Text},
                {"totalValue", double.Parse(txtTotalValue.Text.Replace("R$ ", "")) }


            };

            if (documentSnapshot.Exists)
            {
                await documentReference.UpdateAsync(data);
            }
        }


        private void btnSalvar_Click(Object sender, EventArgs e)
        {
            try
            {
                btnSalvar.Enabled = false;
                updateData();
                MessageBox.Show("Dados atualizados com sucesso!");

            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao tentar atualizar os dados.");
                btnSalvar.Enabled = true;
            }
            this.Close();



        }

        private void txtAditional_TextChanged(Object sender, EventArgs e)
        {


            try
            {
                valorTotal = double.Parse(txtAditional.Text.Replace("R$ ", "")) + double.Parse(txtPlanValue.Text.Replace("R$ ", ""));
                txtTotalValue.Text = valorTotal.ToString();
            }
            catch
            {

            }
        }

        private void btnCancelar_Click(Object sender, EventArgs e)
        {
            this.Close();
        }

        //Valor plano

        private void txt_stringValorPlano_Leave(object sender, EventArgs e)
        {
            stringValorPlano = txtPlanValue.Text.Replace("R$", "");
            txtPlanValue.Text = string.Format("{0:C}", Convert.ToDouble(stringValorPlano));
        }



    }
}

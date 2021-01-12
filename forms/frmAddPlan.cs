using Firebase.Storage;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProVantagensApp
{
    public partial class frmAddPlan : Form
    {
        private String planID;
        private Plans plans;
        private int _width;
        string checkboxes = "";
        private bool check;
        private DocumentReference documentReference;
        private DocumentSnapshot documentSnapshot;
        private String imgFile, pdfFile;
        public frmAddPlan()
        {
            InitializeComponent();
        }

        private void imgPlans_Click(Object sender, EventArgs e)
        {

        }

        private async void frmAddPlan_Load(Object sender, EventArgs e)
        {
            _width = this.Width;

            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("pro-vantagens");

        }

        async void setData()
        {


            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"name", txtName.Text},
                {"description", txtDescription.Text},
                {"value", txtValue.Text},
                {"type", cboType.Text},
                {"image", plans.image},
                {"contract", plans.contract}
            };

            if (documentSnapshot.Exists)
            {
                await documentReference.SetAsync(data);
            }
        }


        private void btnAddImg_Click(Object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                imgPlans.Image = new Bitmap(open.FileName);
                // image file path  
                imgFile = open.FileName;
            }

        }


        //Save Image in Storage


        async Task UploadImageAsync()
        {
            // Get any Stream - it can be FileStream, MemoryStream or any other type of Stream
            var stream = File.OpenRead(imgFile);

            // Construct FirebaseStorage, path to where you want to upload the file and Put it there
            var task = new FirebaseStorage("pro-vantagens.appspot.com")
                .Child("plans")
                .Child(planID)
                .Child("imagePartner")
                .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // await the task to wait until upload completes and get the download url
            var downloadUrl = await task;
            plans.image = downloadUrl;
        }

        async Task UploadPDFAsync()
        {
            // Get any Stream - it can be FileStream, MemoryStream or any other type of Stream
            var stream = File.OpenRead(pdfFile);

            // Construct FirebaseStorage, path to where you want to upload the file and Put it there
            var task = new FirebaseStorage("pro-vantagens.appspot.com")
                .Child("plans")
                .Child(planID)
                .Child("pdfPlan")
                .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // await the task to wait until upload completes and get the download url
            var downloadUrl = await task;
            plans.contract = downloadUrl;
        }

        private async void btnSalvar_Click(Object sender, EventArgs e)
        {
            try
            {
                btnSalvar.Enabled = false;
                if (imgFile != null)
                {
                    await UploadImageAsync();
                }
                if(pdfFile != null)
                {
                    await UploadPDFAsync();
                }
                setData();
                ctrlPlans ctrl = new ctrlPlans();
                await ctrl.loadPlansAsync();
                MessageBox.Show("Dados atualizados com sucesso!");

            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao tentar atualizar os dados.");
                btnSalvar.Enabled = true;
            }
            this.Close();


        }

        private void btnCancelar_Click(Object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtPhone_KeyPress(Object sender, KeyPressEventArgs e)
        {

        }

        //Crie um textbox com o name txt_valor e atribua os eventos KeyPress,KeyUp e 
        // Leave e uma string valor;
        string valor;
        private void txt_valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txtValue.Text.Contains(","));
                }
                else
                    e.Handled = true;
            }
        }

        private void txt_valor_Leave(object sender, EventArgs e)
        {
            valor = txtValue.Text.Replace("R$", "");
            txtValue.Text = string.Format("{0:C}", Convert.ToDouble(valor));
        }

        private void txt_valor_KeyUp(object sender, KeyEventArgs e)
        {
            valor = txtValue.Text.Replace("R$", "").Replace(",", "").Replace(" ", "").Replace("00,", "");
            if (valor.Length == 0)
            {
                txtValue.Text = "0,00" + valor;
            }
            if (valor.Length == 1)
            {
                txtValue.Text = "0,0" + valor;
            }
            if (valor.Length == 2)
            {
                txtValue.Text = "0," + valor;
            }
            else if (valor.Length >= 3)
            {
                if (txtValue.Text.StartsWith("0,"))
                {
                    txtValue.Text = valor.Insert(valor.Length - 2, ",").Replace("0,", "");
                }
                else if (txtValue.Text.Contains("00,"))
                {
                    txtValue.Text = valor.Insert(valor.Length - 2, ",").Replace("00,", "");
                }
                else
                {
                    txtValue.Text = valor.Insert(valor.Length - 2, ",");
                }
            }
            valor = txtValue.Text;
            txtValue.Text = string.Format("{0:C}", Convert.ToDouble(valor));
            txtValue.Select(txtValue.Text.Length, 0);
        }

        private void btnAddPDF_Click(Object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Text files | *.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                // PDF file path  
                pdfFile = open.FileName;
                txtPDF.Text = pdfFile;
            }
        }

    }
}

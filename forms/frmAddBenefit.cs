using Firebase.Storage;
using Google.Cloud.Firestore;
using ProVantagensApp.models;
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
    public partial class frmAddBenefit : Form
    {
        private String benefitID;
        private Benefits benefits = new Benefits();
        private List<Modify> listModfies = new List<Modify>();
        private Modify modify = new Modify();
        private modifyManager modifyManager = new modifyManager();
        private int _width;
        string checkboxes = "";
        private bool check;
        private DocumentReference documentReference, modifyReference;
        private DocumentSnapshot documentSnapshot, modifySnap;
        private String imgFile;
        public frmAddBenefit()
        {
            InitializeComponent();
        }

        private string alfanumericoAleatorio(int tamanho)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            benefitID = new String(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return benefitID;
        }

        private async void frmAddBenefit_Load(Object sender, EventArgs e)
        {
            alfanumericoAleatorio(20);
            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("pro-vantagens");
            documentReference = db.Collection("benefits").Document(benefitID);
            modifyReference = db.Collection("modifies").Document("benefits");
            modifySnap = await modifyReference.GetSnapshotAsync();

            if (modifySnap.Exists)
            {
                modifyManager = modifySnap.ConvertTo<modifyManager>();
                if (modifyManager.Modifies.Count > 0)
                {
                    listModfies = modifyManager.Modifies;

                }
            }

            Query plansQuery = db.Collection("plans");
            QuerySnapshot snapshots = await plansQuery.GetSnapshotAsync();

            foreach (DocumentSnapshot plansSnapshot in snapshots)
            {
                Plans plans = plansSnapshot.ConvertTo<Plans>();
                check = false;
                checkList.Items.Add(plans.name, check);

            }

        }
        async void setData()
        {

            modify.userName = User.ID;
            modify.screen = "Adicionar beneficios";
            modify.modifyHour = DateTime.Now.ToString();
            modify.documentID = benefitID;
            listModfies.Add(modify);

            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"name", txtName.Text},
                {"description", txtDescription.Text},
                {"value", txtValue.Text},
                {"card", checkboxes},
                {"image", benefits.image}

            };

            Dictionary<string, object> dataModify = new Dictionary<string, object>()
            {
                {"Modifies", listModfies},
            };

            await documentReference.SetAsync(data);
            await modifyReference.UpdateAsync(dataModify);
        }

        private void btnAddImg_Click(Object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                imgBenefits.Image = new Bitmap(open.FileName);
                imgBenefits.SizeMode = PictureBoxSizeMode.StretchImage;
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
                .Child("benefits")
                .Child(benefitID)
                .Child("imageBenefit")
                .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // await the task to wait until upload completes and get the download url
            var downloadUrl = await task;
            benefits.image = downloadUrl;
        }

        private async void btnSalvar_Click(Object sender, EventArgs e)
        {
            if (checkList.CheckedItems.Count != 0)
            {
                //looped through all checked items and show results.
                for (int x = 0; x < checkList.CheckedItems.Count; x++)
                {
                    checkboxes = checkboxes + checkList.CheckedItems[x].ToString() + "/";
                }
            }

            try
            {
                btnSalvar.Enabled = false;
                if (imgFile != null)
                {
                    await UploadImageAsync();
                }
                setData();
                MessageBox.Show("Dados atualizados com sucesso!");

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar atualizar os dados.  " + ex);
                btnSalvar.Enabled = true;
            }
            this.Close();


        }

        private void btnCancelar_Click(Object sender, EventArgs e)
        {
            this.Close();
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
            try
            {
                valor = txtValue.Text.Replace("R$", "");
                txtValue.Text = string.Format("{0:C}", Convert.ToDouble(valor));
            }
            catch
            {

            }

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
    }
}

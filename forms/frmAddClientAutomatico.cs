using Firebase.Auth;
using Google.Cloud.Firestore;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProVantagensApp.forms
{
    public partial class frmAddClientAutomatico : Form
    {
        private String clientID;
        private Clients clients = new Clients();
        private Address address = new Address();
        private int _width;
        private DocumentReference documentReference;
        public frmAddClientAutomatico()
        {
            InitializeComponent();
        }

        private void frmAddClientAutomatico_Load(Object sender, EventArgs e)
        {
            try
            {
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='D:\\clients.xlsx';Extended Properties=Excel 8.0;");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
                MyCommand.TableMappings.Add("Table", "TestTable");
                DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);
                dataGridView1.DataSource = DtSet.Tables[0];
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(Object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                btnBuscaCEP_Click(i);
                setData(i);
            }
        }
        private void btnBuscaCEP_Click(int row)
        {
            string url = "https://www.mapacep.com.br//busca-cep.php?busca-cep=" + dataGridView1.Rows[row].Cells[15].Value.ToString();

            HtmlWeb page = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = page.Load(url);
            page.Get(url, "/");
            document.Save("out.html");

            var cepAddress = document.DocumentNode.Descendants("title").FirstOrDefault().InnerText.Split(',');
            try
            {
                address.state = cepAddress[3].Split(' ')[2].Trim();
                address.city = cepAddress[2].Split(' ')[2].Trim();
                address.district = cepAddress[1].Trim();
                address.street= cepAddress[0].Split('-')[0].Trim();
                address.lat = double.Parse(cepAddress[6].Split(' ')[2]);
                address.longitude = double.Parse(cepAddress[7].Split(' ')[2]);
            }
            catch
            {
            }


        }

        async void setData(int row)
        {

            address.number = dataGridView1.Rows[row].Cells[15].Value.ToString();

            string estadoCivil = dataGridView1.Rows[row].Cells[9].Value.ToString();
            if(estadoCivil == "VIUVO" || estadoCivil == "VIUVA")
            {
                estadoCivil = "Viuvo(a)";
            }
            if (estadoCivil == "SOLTEIRO" || estadoCivil == "SOLTEIRA")
            {
                estadoCivil = "Solteiro(a)";
            }
            if (estadoCivil == "CASADO" || estadoCivil == "CASADA")
            {
                estadoCivil = "Casado(a)";
            }
            if (estadoCivil == "SEPARADO" || estadoCivil == "SEPARADA")
            {
                estadoCivil = "Separado(a)";
            }
            if (estadoCivil == "DIVORCIADO" || estadoCivil == "DIVORCIADA")
            {
                estadoCivil = "Divorciado(a)";
            }
            string email = dataGridView1.Rows[row].Cells[21].Value.ToString();
            if (email == "")
            {
                email = dataGridView1.Rows[row].Cells[19].Value.ToString() + "@provantagens.com";
            };

            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"accessLevel", 0},
                {"name", dataGridView1.Rows[row].Cells[1].Value.ToString()},
                {"address", address},
                {"cpf", dataGridView1.Rows[row].Cells[2].Value.ToString() },
                {"dtn", dataGridView1.Rows[row].Cells[5].Value.ToString()},
                {"email", email},
                {"estadoCivil", estadoCivil},
                {"expedicao", dataGridView1.Rows[row].Cells[8].Value.ToString()},
                {"nomeconjuge", dataGridView1.Rows[row].Cells[10].Value.ToString()},
                {"nomemae", dataGridView1.Rows[row].Cells[12].Value.ToString()},
                {"nomepai", dataGridView1.Rows[row].Cells[12].Value.ToString()},
                {"orgaoemissor", dataGridView1.Rows[row].Cells[7].Value.ToString()},
                {"rg", dataGridView1.Rows[row].Cells[6].Value.ToString()},
                {"tel1", dataGridView1.Rows[row].Cells[19].Value.ToString()},
                {"tel2", dataGridView1.Rows[row].Cells[20].Value.ToString()},
            };

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyA0hQhaFdSKMTQfpSltAmDdqdMvDDG-aR4"));
            try
            {
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, "123456");
                clientID = auth.User.LocalId;
                string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                FirestoreDb db = FirestoreDb.Create("pro-vantagens");
                documentReference = db.Collection("users").Document(clientID);
                await documentReference.SetAsync(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


    }

}

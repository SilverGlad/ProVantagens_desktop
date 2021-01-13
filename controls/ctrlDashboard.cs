using Google.Cloud.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProVantagensApp.controls
{
    public partial class ctrlDashboard : UserControl
    {
        string[] months = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
        string[] clients = { "Ativos", "Inativos" };
        int invoiceOk, invoicePendente, invoiceVencida, invoiceVencidaOld, paymentOk, paymentEstornado, clientsTotal, clientsOn;
        string dataAtual;
        double recebidoMes, janNow, fevNow, marNow, abrNow, maiNow, junNow, julNow, agoNow, setNow, outNow, novNow, dezNow;
        double janOld, fevOld, marOld, abrOld, maiOld, junOld, julOld, agoOld, setOld, outOld, novOld, dezOld;
        public ctrlDashboard()
        {
            InitializeComponent();
        }

        private async void ctrlDashboard_Load(Object sender, EventArgs e)
        {
            if(DateTime.Now.Month < 10)
            {
                dataAtual = "0" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
            }
            else
            {
                dataAtual = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
            }
            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("pro-vantagens");

            Query queryUser = db.Collection("users");
            QuerySnapshot usersSnapshots = await queryUser.GetSnapshotAsync();

            foreach (DocumentSnapshot userDocument in usersSnapshots)
            {
                Clients clients = userDocument.ConvertTo<Clients>();
                if (userDocument.Exists)
                {
                    clientsTotal = clientsTotal + 1;
                    if(clients.plan != null)
                    {
                        clientsOn = clientsOn + 1;
                    }
                }

                Query Query = db.Collection("users").Document(userDocument.Id).Collection("invoices");
                QuerySnapshot snapshots = await Query.GetSnapshotAsync();

                foreach (DocumentSnapshot documentSnapshot in snapshots)
                {
                    Invoices invoices = documentSnapshot.ConvertTo<Invoices>();
                   if(documentSnapshot.Id == dataAtual)
                    {
                        if (invoices.status == "Ok")
                        {
                            invoiceOk = invoiceOk + 1;
                        }
                        if (invoices.status == "Pendente")
                        {
                            invoicePendente = invoicePendente + 1;
                        }
                        if (invoices.status == "Vencido")
                        {
                            invoiceVencida = invoiceVencida + 1;
                        }
                    }
                    else
                    {
                        if (invoices.status == "Vencido")
                        {
                            invoiceVencidaOld = invoiceVencidaOld + 1;
                        }
                    }
                    
                }

                Query queryPay = db.Collection("users").Document(userDocument.Id).Collection("payments");
                QuerySnapshot paySnap = await queryPay.GetSnapshotAsync();
                String documentName;

                foreach (DocumentSnapshot paySnapshot in paySnap)
                {
                    Payments payments = paySnapshot.ConvertTo<Payments>();

                    if (payments.status == "Ok")
                    {

                        documentName = (paySnapshot.Id.Split('-')[1] + "-" + paySnapshot.Id.Split('-')[2]);
                        if(documentName == dataAtual)
                        {
                            recebidoMes = recebidoMes + Convert.ToDouble(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if(documentName == "01-" + DateTime.Now.Year.ToString())
                        {
                            janNow = janNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "02-" + DateTime.Now.Year.ToString())
                        {
                            fevNow = fevNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "03-" + DateTime.Now.Year.ToString())
                        {
                            marNow= marNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "04-" + DateTime.Now.Year.ToString())
                        {
                            abrNow = abrNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "05-" + DateTime.Now.Year.ToString())
                        {
                            maiNow = maiNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "06-" + DateTime.Now.Year.ToString())
                        {
                            junNow = junNow+ double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "07-" + DateTime.Now.Year.ToString())
                        {
                            julNow = julNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "08-" + DateTime.Now.Year.ToString())
                        {
                            agoNow = agoNow+ double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "09-" + DateTime.Now.Year.ToString())
                        {
                            setNow = setNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "10-" + DateTime.Now.Year.ToString())
                        {
                            outNow = outNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "11-" + DateTime.Now.Year.ToString())
                        {
                            novNow = novNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "12-" + DateTime.Now.Year.ToString())
                        {
                            dezNow = dezNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if(documentName == "01-" + DateTime.Now.Year.ToString())
                        {
                            janNow = janNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "02-" + DateTime.Now.Year.ToString())
                        {
                            fevNow = fevNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "03-" + DateTime.Now.Year.ToString())
                        {
                            marNow= marNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "04-" + DateTime.Now.Year.ToString())
                        {
                            abrNow = abrNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "05-" + DateTime.Now.Year.ToString())
                        {
                            maiNow = maiNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "06-" + DateTime.Now.Year.ToString())
                        {
                            junNow = junNow+ double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "07-" + DateTime.Now.Year.ToString())
                        {
                            julNow = julNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "08-" + DateTime.Now.Year.ToString())
                        {
                            agoNow = agoNow+ double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "09-" + DateTime.Now.Year.ToString())
                        {
                            setNow = setNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "10-" + DateTime.Now.Year.ToString())
                        {
                            outNow = outNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "11-" + DateTime.Now.Year.ToString())
                        {
                            novNow = novNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "12-" + DateTime.Now.Year.ToString())
                        {
                            dezNow = dezNow + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }

                        //Ano anterior

                        if (documentName == "01-" + (DateTime.Now.Year - 1).ToString())
                        {
                            janOld = janOld + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "02-" + (DateTime.Now.Year - 1).ToString())
                        {
                            fevOld = fevOld + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "03-" + (DateTime.Now.Year - 1).ToString())
                        {
                            marOld = marOld + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "04-" + (DateTime.Now.Year - 1).ToString())
                        {
                            abrOld = abrOld + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "05-" + (DateTime.Now.Year - 1).ToString())
                        {
                            maiOld = maiOld + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "06-" + (DateTime.Now.Year - 1).ToString())
                        {
                            junOld = junOld + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "07-" + (DateTime.Now.Year - 1).ToString())
                        {
                            julOld = julOld + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "08-" + (DateTime.Now.Year - 1).ToString())
                        {
                            agoOld = agoOld + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "09-" + (DateTime.Now.Year - 1).ToString())
                        {
                            setOld = setOld + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "10-" + (DateTime.Now.Year - 1).ToString())
                        {
                            outOld = outOld + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "11-" + (DateTime.Now.Year - 1).ToString())
                        {
                            novOld = novOld + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }
                        if (documentName == "12-" + (DateTime.Now.Year - 1).ToString())
                        {
                            dezOld = dezOld + double.Parse(payments.value.Replace("R$: ", ""), CultureInfo.InvariantCulture);
                        }

                    }
                    if (payments.status == "Estornado")
                    {
                    }
                }
            }



            ///////////////////////////////////////Adicionar dados a tela\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            //Assinaturas
            lbClientsTotal.Text = clientsTotal.ToString();
            lbClientsOn.Text = clientsOn.ToString();

            //Cobrança
            lbPayOk.Text = invoiceOk.ToString();
            lbNoPrazo.Text = invoicePendente.ToString();
            lbVencidas.Text = invoiceVencida.ToString();
            lbVencidasOld.Text = invoiceVencidaOld.ToString();

            //Valor recebido no mês
            lbRecebidoMes.Text = "R$ " + recebidoMes.ToString();
            //Grafico ano atual
            this.graficPaymentsNow.Palette = ChartColorPalette.SeaGreen;
            graficPaymentsNow.Series.Clear();
            Series series = this.graficPaymentsNow.Series.Add("Ano atual");
            series.ChartType = SeriesChartType.RangeColumn;
            series.IsXValueIndexed = true;
            for (int i = 0; i < months.Length; i++)
            {
                if(months[i] == "Janeiro")
                {
                    series.Points.AddXY(months[i],janNow);
                }
                if (months[i] == "Fevereiro")
                {
                    series.Points.AddXY(months[i],fevNow);
                }
                if (months[i] == "Março")
                {
                    series.Points.AddXY(months[i],marNow);
                }
                if (months[i] == "Abril")
                {
                    series.Points.AddXY(months[i],abrNow);
                }
                if (months[i] == "Maio")
                {
                    series.Points.AddXY(months[i],maiNow);
                }
                if (months[i] == "Junho")
                {
                    series.Points.AddXY(months[i],junNow);
                }
                if (months[i] == "Julho")
                {
                    series.Points.AddXY(months[i],julNow);
                }
                if (months[i] == "Agosto")
                {
                    series.Points.AddXY(months[i],agoNow);
                }
                if (months[i] == "Setembro")
                {
                    series.Points.AddXY(months[i],setNow);
                }
                if (months[i] == "Outubro")
                {
                    series.Points.AddXY(months[i],outNow);
                }
                if (months[i] == "Novembro")
                {
                    series.Points.AddXY(months[i],novNow);
                }
                if (months[i] == "Dezembro")
                {
                    series.Points.AddXY(months[i],dezNow);
                }
            }

            MessageBox.Show("Ativos:" + clientsOn.ToString());
            MessageBox.Show("Inativos:" + clientsTotal.ToString());
            MessageBox.Show("Old:" + janOld.ToString());

            //Grafico ano anterior
            this.graficPaymentsOld.Palette = ChartColorPalette.SeaGreen;
            graficPaymentsOld.Series.Clear();
            Series paymentOldSerie = this.graficPaymentsOld.Series.Add("Ano anterior");
            paymentOldSerie.ChartType = SeriesChartType.RangeColumn;
            paymentOldSerie.IsXValueIndexed = true;

            for (int i = 0; i < months.Length; i++)
            {
                if (months[i] == "Janeiro")
                {
                    paymentOldSerie.Points.AddXY(months[i],janOld);
                }
                if (months[i] == "Fevereiro")
                {
                    paymentOldSerie.Points.AddXY(months[i],fevOld);
                }
                if (months[i] == "Março")
                {
                    paymentOldSerie.Points.AddXY(months[i],marOld);
                }
                if (months[i] == "Abril")
                {
                    paymentOldSerie.Points.AddXY(months[i],abrOld);
                }
                if (months[i] == "Maio")
                {
                    paymentOldSerie.Points.AddXY(months[i],maiOld);
                }
                if (months[i] == "Junho")
                {
                    paymentOldSerie.Points.AddXY(months[i],junOld);
                }
                if (months[i] == "Julho")
                {
                    paymentOldSerie.Points.AddXY(months[i],julOld);
                }
                if (months[i] == "Agosto")
                {
                    paymentOldSerie.Points.AddXY(months[i],agoOld);
                }
                if (months[i] == "Setembro")
                {
                    paymentOldSerie.Points.AddXY(months[i],setOld);
                }
                if (months[i] == "Outubro")
                {
                    paymentOldSerie.Points.AddXY(months[i],outOld);
                }
                if (months[i] == "Novembro")
                {
                    paymentOldSerie.Points.AddXY(months[i],novOld);
                }
                if (months[i] == "Dezembro")
                {
                    paymentOldSerie.Points.AddXY(months[i],dezOld);
                }
            }

            //Grafico assinaturas
            this.graficClients.Palette = ChartColorPalette.SeaGreen;
            graficClients.Series.Clear();
            Series clientSerie = this.graficClients.Series.Add("Clientes");
            clientSerie.ChartType = SeriesChartType.Pie;
            clientSerie.IsXValueIndexed = true;

            for (int i = 0; i < clients.Length; i++)
            {
                if (clients[i] == "Ativos")
                {

                    clientSerie.Points.AddXY("Ativos", clientsOn);
                    
                }
                if (clients[i] == "Inativos")
                {
                    clientSerie.Points.AddXY("Inativos",clientsTotal-clientsOn);
                }
            }

        }
    }
}

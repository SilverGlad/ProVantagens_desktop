using Firebase.Storage;
using Google.Cloud.Firestore;
using HtmlAgilityPack;
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
    public partial class ctrlHome : UserControl
    {
        private List<String> listImage;
        private int imgNow;
        private int imgLimit;
        private String imgFile, imgID;
        private DocumentReference documentReference;
        private DocumentSnapshot documentSnapshot;

        public ctrlHome()
        {
            InitializeComponent();

        }

        async private void ctrlHome_Load(object sender, EventArgs e)

        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"pro-vantagens-firebase-adminsdk-5cf5q-82ec44750b.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("pro-vantagens");

            documentReference = db.Collection("home").Document("drlmPXCpRvfPmsEx2r0p");
            documentSnapshot = await documentReference.GetSnapshotAsync();

            listImage = documentSnapshot.GetValue<List<String>>("images");

            imgNow = 0;
            imgLimit = listImage.Count;
            imgHome.Load(listImage[imgNow]);

            lbRight.Parent = imgHome;
            lbRight.BackColor = Color.Transparent;
            lbLeft.Parent = imgHome;
            lbLeft.BackColor = Color.Transparent;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(imgNow < imgLimit)
            {
                imgNow++;
            }
            if(imgNow == imgLimit)
            {
                imgNow = 0;
            }
            imgHome.Load(listImage[imgNow]);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (imgNow < 1)
            {
                imgNow = imgLimit-1;
            }
            else
            {
                imgNow--;
            }
            Console.WriteLine(imgNow);
            imgHome.Load(listImage[imgNow]);
        }

        async void updateData()
        {


            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"images", listImage},
            };

            if (documentSnapshot.Exists)
            {
                await documentReference.UpdateAsync(data);
            }
        }

        async private void removerToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            string imgRemove = listImage[imgNow];
            string imgStorageDelete = imgRemove.Replace("https://firebasestorage.googleapis.com/v0/b/pro-vantagens.appspot.com/o/home%2FdrlmPXCpRvfPmsEx2r0p%2F", "").Split('?')[0];
            listImage.RemoveAt(imgNow);
            var task = new FirebaseStorage("pro-vantagens.appspot.com").Child("home").Child("drlmPXCpRvfPmsEx2r0p").Child(imgStorageDelete).DeleteAsync();
            updateData();
            try
            {
                imgHome.Load(listImage[listImage.Count-1]);
                imgNow = listImage.Count - 1;
                imgLimit = listImage.Count;
            }
            catch
            {
                imgHome.Image = null;
            }
        }

        private async void adicionarToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                imgHome.Load(listImage[listImage.Count-1]);
                imgNow = listImage.Count - 1;
                imgLimit = listImage.Count;
                // image file path  
                imgFile = open.FileName;
                await UploadImageAsync();
                updateData();
            }
        }

        async Task UploadImageAsync()
        {
            // Get any Stream - it can be FileStream, MemoryStream or any other type of Stream
            var stream = File.OpenRead(imgFile);
            alfanumericoAleatorio(36);

            // Construct FirebaseStorage, path to where you want to upload the file and Put it there
            var task = new FirebaseStorage("pro-vantagens.appspot.com")
                .Child("home")
                .Child("drlmPXCpRvfPmsEx2r0p")
                .Child(imgID)
                .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // await the task to wait until upload completes and get the download url
            var downloadUrl = await task;
            listImage.Add(downloadUrl);
        }

        private string alfanumericoAleatorio(int tamanho)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            imgID = new String(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return imgID;
        }
    }
}

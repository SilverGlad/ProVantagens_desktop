using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProVantagensApp
{
    [FirestoreData]
    public class Invoices
    {
        [FirestoreProperty]
        public String holder { get; set; }

        [FirestoreProperty]
        public String month { get; set; }

        [FirestoreProperty]
        public String paymentMethod { get; set; }

        [FirestoreProperty]
        public String planName{ get; set; }

        [FirestoreProperty]
        public String status{ get; set; }

        [FirestoreProperty]
        public Double totalValue{ get; set; }

        [FirestoreProperty]
        public String value{ get; set; }

        [FirestoreProperty]
        public int dueDate{ get; set; }

        [FirestoreProperty]
        public int aditional{ get; set; }

   
    }
}

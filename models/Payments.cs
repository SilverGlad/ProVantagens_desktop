using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProVantagensApp
{
    [FirestoreData]
    public class Payments
    {
        [FirestoreProperty]
        public String planName { get; set; }

        [FirestoreProperty]
        public String cardHolder { get; set; }

        [FirestoreProperty]
        public String cardNum { get; set; }

        [FirestoreProperty]
        public int cardType { get; set; }

        [FirestoreProperty]
        public String cpfHolder { get; set; }

        [FirestoreProperty]
        public String payId { get; set; }

        [FirestoreProperty]
        public String value { get; set; }

        [FirestoreProperty]
        public String status { get; set; }
    }
}

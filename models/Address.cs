using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProVantagensApp
{
    [FirestoreData]
    public class Address
    {
        
        [FirestoreProperty]
        public String city { get; set; }

        [FirestoreProperty]
        public String complement { get; set; }

        [FirestoreProperty]
        public String district { get; set; }

        [FirestoreProperty]
        public Double lat { get; set; }

        [FirestoreProperty]
        public Double longitude { get; set; }

        [FirestoreProperty]
        public String number { get; set; }

        [FirestoreProperty]
        public String state { get; set; }

        [FirestoreProperty]
        public String street { get; set; }

        [FirestoreProperty]
        public String zipCode { get; set; }
    }
}

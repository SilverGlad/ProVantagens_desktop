using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProVantagensApp
{
    [FirestoreData]
    public class Partners
    {
        [FirestoreProperty]
        public String name { get; set; }

        [FirestoreProperty]
        public String type { get; set; }

        [FirestoreProperty]
        public String image { get; set; }

        [FirestoreProperty]
        public Address address { get; set; }

        [FirestoreProperty]
        public Opening opening { get; set; }

        [FirestoreProperty]
        public String phone { get; set; }


    }
}

using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProVantagensApp
{
    [FirestoreData]
    public class Plans
    {
        [FirestoreProperty]
        public String name { get; set; }

        [FirestoreProperty]
        public String description { get; set; }

        [FirestoreProperty]
        public String image { get; set; }

        [FirestoreProperty]
        public String type { get; set; }

        [FirestoreProperty]
        public String contract { get; set; }

        [FirestoreProperty]
        public String value { get; set; }

    }
}

using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProVantagensApp
{
    [FirestoreData]
    public class Benefits
    {
        [FirestoreProperty]
        public String name { get; set; }

        [FirestoreProperty]
        public String description { get; set; }

        [FirestoreProperty]
        public String image { get; set; }

        [FirestoreProperty]
        public String card { get; set; }

        [FirestoreProperty]
        public String value { get; set; }

    }
}

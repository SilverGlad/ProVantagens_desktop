using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProVantagensApp
{
    [FirestoreData]
    public class Opening
    {

        [FirestoreProperty]
        public String friday { get; set; }

        [FirestoreProperty]
        public String monday { get; set; }

        [FirestoreProperty]
        public String saturday { get; set; }

        [FirestoreProperty]
        public String sunday { get; set; }

        [FirestoreProperty]
        public String thursday { get; set; }

        [FirestoreProperty]
        public String tuesday { get; set; }

        [FirestoreProperty]
        public String wednesday { get; set; }
    }
}

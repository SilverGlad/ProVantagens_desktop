using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProVantagensApp.models
{
    class Modify
    {
        [FirestoreProperty]
        public String userName { get; set; }

        [FirestoreProperty]
        public String screen { get; set; }

        [FirestoreProperty]
        public String documentID { get; set; }

        [FirestoreProperty]
        public String modifyHour { get; set; }

    }
}

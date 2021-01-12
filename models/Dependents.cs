using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProVantagensApp
{
    [FirestoreData]
    public class Dependents
    {
        [FirestoreProperty]
        public String name { get; set; }

        [FirestoreProperty]
        public bool aditional { get; set; }

        [FirestoreProperty]
        public String relation { get; set; }

        [FirestoreProperty]
        public String dtn { get; set; }

    }
}

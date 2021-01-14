using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProVantagensApp.models
{
    class modifyManager
    {
        [FirestoreProperty]
        public List<Modify> Modifies { get; set; }
    }
}

using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProVantagensApp
{
    [FirestoreData]
    public class Clients
    {
        [FirestoreProperty]
        public String name { get; set; }

        [FirestoreProperty]
        public Address address { get; set; }

        [FirestoreProperty]
        public String cpf { get; set; }

        [FirestoreProperty]
        public String dtn { get; set; }

        [FirestoreProperty]
        public int dueDate { get; set; }

        [FirestoreProperty]
        public String email { get; set; }

        [FirestoreProperty]
        public String estadocivil { get; set; }

        [FirestoreProperty]
        public String expedicao { get; set; }

        [FirestoreProperty]
        public String nomeconjugue { get; set; }

        [FirestoreProperty]
        public String nomemae { get; set; }

        [FirestoreProperty]
        public String nomepai { get; set; }

        [FirestoreProperty]
        public String orgaoemissor { get; set; }

        [FirestoreProperty]
        public String paymentMethod { get; set; }

        [FirestoreProperty]
        public String plan { get; set; }

        [FirestoreProperty]
        public String planvalue { get; set; }

        [FirestoreProperty]
        public String rg { get; set; }

        [FirestoreProperty]
        public String tel1 { get; set; }

        [FirestoreProperty]
        public String tel2 { get; set; }

        [FirestoreProperty]
        public int accessLevel { get; set; }

    }
}

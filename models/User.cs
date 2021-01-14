using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace ProVantagensApp
{
    public static class User
    {
        private static string _id = "";
        public static string ID
        {
            get { return _id;}
            set { _id = value;}
        }
        private static int _accessLevel = 0;
        public static int AccessLevel
        {
            get { return _accessLevel; }
            set { _accessLevel = value; }
        }
        private static string _name = "";
        public static string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private static string _token = "";
        public static string Token
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}

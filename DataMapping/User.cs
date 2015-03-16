using System;
using System.Collections.Generic;
using System.Text;

namespace FBV.DataMapping
{
    [Serializable]
    public class User
    {
        public int UserID;
        public string UserFullname;
        public string Username;
        public string UserPassword;
        public int UDerpartmentID;
        public int UAccessLevel;
        public bool? UEvaluation;

    }
}

using System;
using System.Collections.Generic;
using System.Web;

namespace Sbyt.Balance_Po_TP
{
    public class OplatiDetails
    {

        public OplatiDetails(string n1, string n2, string kodtp, string kodsektp)
        {
            N1 = n1;
            N2 = n2;
            KODTP = kodtp;
            KODSEKTP = kodsektp;


        }


        

        private string _n1;
        public string N1
        {
            get { return _n1; }
            set { _n1= value; }
    
        }

        private string _n2;
        public string N2
        {
            get { return _n2; }
            set { _n2 = value; }

        }

        private string _kodtp;
        public string KODTP
        {
            get { return _kodtp; }
            set { _kodtp = value; }

        }

        private string _kodsektp;
        public string KODSEKTP
        {
            get { return _kodsektp; }
            set { _kodsektp = value; }

        }





    }
}
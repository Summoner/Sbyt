using System;
using System.Collections.Generic;
using System.Web;

namespace Sbyt.Balance_Po_VL
{
    public class VLDetails
    {

         public VLDetails()
        {
		
        }

        public VLDetails(string doc_code, string doc_name_vl10)
        {
            DOC_CODE = doc_code;
            DOC_NAME_VL10 = doc_name_vl10;
            
       
        }


        public VLDetails(string doc_code, string doc_name_vl10, string beg_name)
        {
            DOC_CODE = doc_code;
            DOC_NAME_VL10 = doc_name_vl10;
            BEG_NAME = beg_name;


        }


        private string _doc_code = string.Empty;
        public string DOC_CODE
        {
            get { return _doc_code; }
            set { _doc_code = value; }
    
        }

        private string _doc_name_vl10 = string.Empty;
        public string DOC_NAME_VL10
        {
            get { return _doc_name_vl10; }
            set { _doc_name_vl10 = value; }

        }

        private string _beg_name;
        public string BEG_NAME
        {
            get { return _beg_name; }
            set { _beg_name = value; }

        }


    }
}
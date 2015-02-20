namespace Sbyt.Balance_Po_TP
{
    /// <summary>
    /// Сводное описание для EmployeeDetails
    /// </summary>
    public class TpDetails
    {
        public TpDetails()
        {
		
        }

        public TpDetails(string doc_code, string doc_name)
        {
            DOC_CODE = doc_code;
            DOC_NAME = doc_name;
            
       
        }


        public TpDetails(string doc_code, string doc_name, string template_code)
        {
            DOC_CODE = doc_code;
            DOC_NAME = doc_name;
            TEMPLATE_CODE = template_code;


        }


        private string _doc_code;
        public string DOC_CODE
        {
            get { return _doc_code; }
            set { _doc_code = value; }
    
        }

        private string _doc_name;
        public string DOC_NAME
        {
            get { return _doc_name; }
            set { _doc_name = value; }

        }

        private string _template_code;
        public string TEMPLATE_CODE
        {
            get { return _template_code; }
            set { _template_code = value; }

        }


    
    }
}
using System;
using System.Collections.Generic;
using System.Web;

namespace Sbyt.Balance_Po_TP
{
    public class StolbBLLTPs
    {


         public StolbBLLTPs()
        {
		
        }

    
        public StolbBLLTPs(string doc_code, string doc_name)
        {
            DOC_CODE = doc_code;
            DOC_NAME = doc_name;

        }

        public StolbBLLTPs(string doc_code, string doc_name, string template_code)
        {
            DOC_CODE = doc_code;
            DOC_NAME = doc_name;
            TEMPLATE_CODE = template_code;


        }

        public StolbBLLTPs(string n1, string n2, string kodtp, string kodsektp)
        {
            N1 = n1;
            N2 = n2;
            KODTP = kodtp;
            KODSEKTP = kodsektp;


        }



        private string _doc_code = string.Empty;
        public string DOC_CODE
        {
            get {return _doc_code; }
            set { _doc_code = value; }
    
        }

        private string _doc_name = string.Empty;
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


        private string _n1 = string.Empty;
        public string N1
        {
            get { return _n1; }
            set { _n1 = value; }

        }

        private string _n2 = string.Empty;
        public string N2
        {
            get { return _n2; }
            set { _n2 = value; }

        }

        private string _kodtp = string.Empty;
        public string KODTP
        {
            get { return _kodtp; }
            set { _kodtp = value; }

        }

        private string _kodsektp = string.Empty;
        public string KODSEKTP
        {
            get { return _kodsektp; }
            set { _kodsektp = value; }

        }


      
    
        //Упаковка обьекта из DAL слоя в обьект BLL слоя
        private static StolbBLLTPs GetTpFromDaltPs(TpDetails record)
        {
            if (record == null)
        
                return null;
            StolbBLLTPs BLLTP =
                new StolbBLLTPs(record.DOC_CODE, record.DOC_NAME);
       
            return BLLTP;
    
        }
        //Получение списка BLL обьектов
        private static List<StolbBLLTPs> GetListTPsFromDalEmployees(List<TpDetails> recordset)
        {


            if (recordset == null)
                return null;
            else
            {
                List<StolbBLLTPs> TPsArr = new List<StolbBLLTPs>();
                foreach (TpDetails record in recordset)
                {
                    TPsArr.Add(GetTpFromDaltPs(record));

                }
                return TPsArr;
            }
        }

        
        //Метод для ObjectDataSource
        public static List<StolbBLLTPs> GetTPs
            (int startRowIndex, int maximumRows, String TPsSort)

        {
          //  maximumRows = 15;
            List<StolbBLLTPs> ListTPs = null;
            List<TpDetails> recordset =
                StolbOracleTpProvider.Instance.GetTPs(GetPageIndex(startRowIndex, maximumRows), maximumRows, TPsSort);
            ListTPs = GetListTPsFromDalEmployees(recordset);
            return ListTPs;
    
        }

        public static List<StolbBLLTPs> GetTPbyName(string DOC_NAME)
        {
            //  maximumRows = 15;
            List<StolbBLLTPs> ListTPs = null;
            List<TpDetails> recordset =
                StolbOracleTpProvider.Instance.GetTPbyName(DOC_NAME);
            ListTPs = GetListTPsFromDalEmployees(recordset);
            return ListTPs;

        }


        //Метод для ObjectDataSource
        public static Int32 GetTPsCount()
        {
            Int32 TPsCount = 0;
            TPsCount = StolbOracleTpProvider.Instance.GetTPsCount();
            return TPsCount;
    
        }

        //Расчет индекса страницы для пейджинга
        protected static int GetPageIndex(int startRowIndex, int maximumRows)
        {
            if (maximumRows <= 0)
                return 0;
            else
                return (int)Math.Floor((double)startRowIndex / (double)maximumRows);
        }


        //**********************Детали для запроса по оплатам*************



        //Метод для ObjectDataSource
        public static StolbBLLTPs GetOplatiDetails(String kodtp, String tableName)
        {
            
           
             OplatiDetails recordset =
                StolbOracleTpProvider.Instance.GetOplatiDetails(kodtp, tableName);

             StolbBLLTPs BLLOplati = GetOplatiDetailsFromDalOplatys(recordset);

            return BLLOplati;

        }

        //Упаковка обьекта из DAL слоя в обьект BLL слоя
        private static StolbBLLTPs GetOplatiDetailsFromDalOplatys(OplatiDetails record)
        {
            if (record == null)

                return null;
            StolbBLLTPs BLLOplati =
                new StolbBLLTPs(record.N1, record.N2, record.KODTP, record.KODSEKTP);

            return BLLOplati;

        }

        //**********************************************************************************

    }
}
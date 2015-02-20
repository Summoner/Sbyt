using System;
using System.Collections.Generic;

namespace Sbyt.Balance_Po_TP
{
    /// <summary>
    /// Сводное описание для BLLEmployees
    /// </summary>
    public class KleckBLLTPs
    {
        public KleckBLLTPs()
        {
		
        }

    
        public KleckBLLTPs(string doc_code, string doc_name)
        {
            DOC_CODE = doc_code;
            DOC_NAME = doc_name;

        }
        

        public KleckBLLTPs (string doc_code, string doc_name, string template_code)
        {
            DOC_CODE = doc_code;
            DOC_NAME = doc_name;
            TEMPLATE_CODE = template_code;


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


      
    
        //Упаковка обьекта из DAL слоя в обьект BLL слоя
        private static KleckBLLTPs GetTpFromDaltPs(TpDetails record)
        {
            if (record == null)
        
                return null;
            KleckBLLTPs BLLTP =
                new KleckBLLTPs(record.DOC_CODE,record.DOC_NAME);
       
            return BLLTP;
    
        }
        //Получение списка BLL обьектов
        private static List<KleckBLLTPs> GetListTPsFromDalEmployees(List<TpDetails> recordset)
        {


            if (recordset == null)
                return null;
            else
            {
                List<KleckBLLTPs> TPsArr = new List<KleckBLLTPs>();
                foreach (TpDetails record in recordset)
                {
                    TPsArr.Add(GetTpFromDaltPs(record));

                }
                return TPsArr;
            }
        }

        
        //Метод для ObjectDataSource
        public static List<KleckBLLTPs> GetTPs
            (int startRowIndex, int maximumRows, String TPsSort)

        {
          //  maximumRows = 15;
            List<KleckBLLTPs> ListTPs = null;
            List<TpDetails> recordset = 
                KleckOracleTpProvider.Instance.GetTPs(GetPageIndex(startRowIndex,maximumRows),maximumRows,TPsSort);
            ListTPs = GetListTPsFromDalEmployees(recordset);
            return ListTPs;
    
        }

        public static List<KleckBLLTPs> GetTPbyName(string DOC_NAME)
        {
            //  maximumRows = 15;
            List<KleckBLLTPs> ListTPs = null;
            List<TpDetails> recordset =
                KleckOracleTpProvider.Instance.GetTPbyName(DOC_NAME);
            ListTPs = GetListTPsFromDalEmployees(recordset);
            return ListTPs;

        }


        //Метод для ObjectDataSource
        public static Int32 GetTPsCount()
        {
            Int32 TPsCount = 0;
            TPsCount= KleckOracleTpProvider.Instance.GetTPsCount();
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


        //**********************Детали для запроса по ТП*************



        //Метод для ObjectDataSource
        public static KleckBLLTPs GetTpDetails (String doc_name)
        {
            
           
             TpDetails recordset =
                KleckOracleTpProvider.Instance.GetTpDetails(doc_name);

            KleckBLLTPs BLLTp = GetTpDetailsFromDalTPs(recordset);

            return BLLTp;

        }

        //Упаковка обьекта из DAL слоя в обьект BLL слоя
        private static KleckBLLTPs GetTpDetailsFromDalTPs(TpDetails record)
        {
            if (record == null)

                return null;
            KleckBLLTPs BLLTP =
                new KleckBLLTPs(record.DOC_CODE, record.DOC_NAME,record.TEMPLATE_CODE);

            return BLLTP;

        }

        //**********************************************************************************

       


        
    
    }
}
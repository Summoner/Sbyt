using System;
using System.Collections.Generic;

namespace Sbyt.Balance_Po_TP
{
    /// <summary>
    /// Сводное описание для BLLEmployees
    /// </summary>
    public class BLLTPs
    {
        public BLLTPs()
        {
		
        }

    
        public BLLTPs(string doc_code, string doc_name)
        {
            DOC_CODE = doc_code;
            DOC_NAME = doc_name;


        }
        

        public BLLTPs (string doc_code, string doc_name, string template_code)
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
        private static BLLTPs GetTpFromDaltPs(TpDetails record)
        {
            if (record == null)
        
                return null;
            BLLTPs BLLTP =
                new BLLTPs(record.DOC_CODE,record.DOC_NAME);
       
            return BLLTP;
    
        }
        //Получение списка BLL обьектов
        private static List<BLLTPs> GetListTPsFromDalEmployees(List<TpDetails> recordset)
        {


            if (recordset == null)
                return null;
            else
            {
                List<BLLTPs> TPsArr = new List<BLLTPs>();
                foreach (TpDetails record in recordset)
                {
                    TPsArr.Add(GetTpFromDaltPs(record));

                }
                return TPsArr;
            }
        }


    



    
        //Метод для ObjectDataSource
        public static List<BLLTPs> GetTPs
            (int startRowIndex, int maximumRows, String TPsSort)

        {
          //  maximumRows = 15;
            List<BLLTPs> ListTPs = null;
            List<TpDetails> recordset = 
                KleckOracleTpProvider.Instance.GetTPs(GetPageIndex(startRowIndex,maximumRows),maximumRows,TPsSort);
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


        //*************************************************



        //Метод для ObjectDataSource
        public static BLLTPs GetTpDetails (String doc_name)
        {
            
           
            TpDetails recordset =
                KleckOracleTpProvider.Instance.GetTpDetails(doc_name);

            BLLTPs BLLTp = GetTpDetailsFromDalTPs(recordset);

            return BLLTp;

        }

        //Упаковка обьекта из DAL слоя в обьект BLL слоя
        private static BLLTPs GetTpDetailsFromDalTPs(TpDetails record)
        {
            if (record == null)

                return null;
            BLLTPs BLLTP =
                new BLLTPs(record.DOC_CODE, record.DOC_NAME,record.TEMPLATE_CODE);

            return BLLTP;

        }
    

    
    }
}
using System;
using System.Collections.Generic;
using System.Web;


namespace Sbyt.Balance_Po_VL
{
    public class StolbBLLVLs
    {
        
         public StolbBLLVLs()
        {
		
        }

    
        public StolbBLLVLs(string doc_code, string doc_name_vl10)
        {
            DOC_CODE = doc_code;
            DOC_NAME_VL10 = doc_name_vl10;

        }

        public StolbBLLVLs(string doc_code, string doc_name_vl10, string beg_name)
        {
            DOC_CODE = doc_code;
            DOC_NAME_VL10 = doc_name_vl10;
            BEG_NAME = beg_name;


        }
        
        private string _doc_code = string.Empty;
        public string DOC_CODE
        {
            get {return _doc_code; }
            set { _doc_code = value; }
    
        }

        private string _doc_name_vl10 = string.Empty;
        public string DOC_NAME_VL10
        {
            get { return _doc_name_vl10; }
            set { _doc_name_vl10 = value; }

        }

        private string _beg_name = string.Empty;
        public string BEG_NAME
        {
            get { return _beg_name; }
            set { _beg_name = value; }

        }
               
      
    
        //Упаковка обьекта из DAL слоя в обьект BLL слоя
        private static StolbBLLVLs GetVLFromDalVLs(VLDetails record)
        {
            if (record == null)
        
                return null;
            StolbBLLVLs BLLVL =
                new StolbBLLVLs(record.DOC_CODE, record.DOC_NAME_VL10, record.BEG_NAME);

            return BLLVL;
    
        }
        //Получение списка BLL обьектов
        private static List<StolbBLLVLs> GetListVLsFromDalEmployees(List<VLDetails> recordset)
        {


            if (recordset == null)
                return null;
            else
            {
                List<StolbBLLVLs> VLsArr = new List<StolbBLLVLs>();
                foreach (VLDetails record in recordset)
                {
                    VLsArr.Add(GetVLFromDalVLs(record));

                }
                return VLsArr;
            }
        }

        
        //Метод для ObjectDataSource
        public static List<StolbBLLVLs> GetVLs
            (int startRowIndex, int maximumRows, String VLsSort)

        {
          //  maximumRows = 15;
            List<StolbBLLVLs> ListVLs = null;
            List<VLDetails> recordset =
                StolbOracleVLProvider.Instance.GetVLs(GetPageIndex(startRowIndex, maximumRows), maximumRows, VLsSort);
            ListVLs = GetListVLsFromDalEmployees(recordset);
            return ListVLs;
    
        }

        public static List<StolbBLLVLs> GetVLbyName(string DOC_NAME)
        {
            //  maximumRows = 15;
            List<StolbBLLVLs> ListVLs = null;
            List<VLDetails> recordset =
                StolbOracleVLProvider.Instance.GetVLbyName(DOC_NAME);
            ListVLs = GetListVLsFromDalEmployees(recordset);
            return ListVLs;

        }
        //Метод для ObjectDataSource
        public static Int32 GetVLsCount()
        {
            Int32 VLsCount = 0;
            VLsCount = StolbOracleVLProvider.Instance.GetVLsCount();
            return VLsCount;
    
        }

        //Расчет индекса страницы для пейджинга
        protected static int GetPageIndex(int startRowIndex, int maximumRows)
        {
            if (maximumRows <= 0)
                return 0;
            else
                return (int)Math.Floor((double)startRowIndex / (double)maximumRows);
        }


       

    }
}
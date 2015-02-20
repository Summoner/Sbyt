using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using Sbyt.App_Service;

namespace Sbyt.Balance_Po_VL
{
    public class DergOracleVLProvider : BaseDal
    {
         //Описание инстанса. Он нужен для доступа к методам DAL слоя из BLL слоя
      

        #region Instance
        private DergOracleVLProvider() { }

        [ThreadStatic]
        private static DergOracleVLProvider _instance;

        public static DergOracleVLProvider Instance
        {
            get { return _instance ?? (_instance = new DergOracleVLProvider()); }
        }
        #endregion


        //Упаковка записи полученной из БД, в обьект
        protected  VLDetails GetVLFromReader(IDataReader reader)
        {

            VLDetails tp = new VLDetails(

                Convert.ToString(reader["DOC_CODE"]),
                Convert.ToString(reader["DOC_NAME_VL10"]),
                Convert.ToString(reader["BEG_NAME"])
                );
                

            return tp;
        
        }

        

        //создание списка обьектов
        protected List<VLDetails> GetVLListFromReader(IDataReader reader)
        {

            List<VLDetails> tpArr = new List<VLDetails>();

            do
            {
                tpArr.Add(this.GetVLFromReader(reader));
            }

            while(reader.Read());
       
            return tpArr;
    
    
        }

    
        //Получение записей из бд
        public List<VLDetails> GetVLs(int pageIndex, int pageSize, String VLsSort)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationHelper.DergPassportConnectionString))
            {
                if (VLsSort == "")
                {
                    VLsSort = "DOC_NAME_VL10";
                }

                OracleCommand cmd =
                    new OracleCommand("Select DOC_CODE, DOC_NAME_VL10, BEG_NAME FROM (SELECT a.*, ROWNUM r FROM (SELECT DOC_CODE, DOC_NAME_CL10 as DOC_NAME_VL10, BEG_NAME FROM view_doc_code_cl10_main UNION SELECT DOC_CODE, TO_CHAR(DOC_NAME_VL10), BEG_NAME FROM VIEW_DOC_CODE_VL10 ORDER BY DOC_NAME_VL10)a where rownum <= :HigerBound) where r >= :LowerBound order by " + VLsSort, connection);
                cmd.CommandType = CommandType.Text;
                int LowerBound = pageIndex * pageSize + 1;
                int HigerBound = (pageIndex + 1) * pageSize;
           
                cmd.Parameters.Add(new OracleParameter("HigerBound", HigerBound));
                cmd.Parameters.Add(new OracleParameter("LowerBound", LowerBound));
                //  cmd.Parameters.Add(new OracleParameter("pEmplSort", EmployeesSort));

                connection.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    return GetVLListFromReader(reader);
                }
                else
                    return null;


            }
        }

        public List<VLDetails> GetVLbyName(String DOC_NAME)
        {
            if (DOC_NAME == string.Empty)
            {
                DOC_NAME = "1";
            }
            using (OracleConnection connection = new OracleConnection(ConfigurationHelper.DergPassportConnectionString))
            {


                OracleCommand cmd =
                         new OracleCommand("Select DOC_CODE, DOC_NAME_VL10, BEG_NAME FROM (SELECT DOC_CODE, DOC_NAME_CL10 as DOC_NAME_VL10, BEG_NAME FROM view_doc_code_cl10_main UNION SELECT DOC_CODE, TO_CHAR(DOC_NAME_VL10), BEG_NAME FROM VIEW_DOC_CODE_VL10 ORDER BY DOC_NAME_VL10) where DOC_NAME_VL10 = " + DOC_NAME, connection);
                cmd.CommandType = CommandType.Text;


                connection.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    return GetVLListFromReader(reader);
                }
                else
                    return null;


            }
        }

     
        //Получение количества записей из БД
        public  int GetVLsCount()
        {
            using (OracleConnection connect = new OracleConnection(ConfigurationHelper.DergPassportConnectionString))
            {
                OracleCommand command = new OracleCommand("SELECT COUNT(*) FROM (SELECT DOC_CODE from VIEW_DOC_CODE_VL10 union select doc_code FROM view_doc_code_cl10_main)", connect);
                command.CommandType = CommandType.Text;
                connect.Open();
                return Convert.ToInt32(ExecuteScalar(command));
            }
        }




    }
}
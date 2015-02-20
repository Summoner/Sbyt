using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using Sbyt.App_Service;

namespace Sbyt.Balance_Po_TP
{
    /// <summary>
    /// Сводное описание для KleckOracleTPProvider
    /// </summary>
    public class KleckOracleTpProvider:BaseDal
    {
	
        //Описание инстанса. Он нужен для доступа к методам DAL слоя из BLL слоя
      

        #region Instance
        private KleckOracleTpProvider() { }

        [ThreadStatic]
        private static KleckOracleTpProvider _instance;

        public static KleckOracleTpProvider Instance
        {
            get { return _instance ?? (_instance = new KleckOracleTpProvider()); }
        }
        #endregion


        //Упаковка записи полученной из БД, в обьект
        protected  TpDetails GetTpFromReader(IDataReader reader)
        {

             TpDetails tp = new  TpDetails(

                Convert.ToString(reader["DOC_CODE"]),
                Convert.ToString(reader["DOC_NAME"])
                );
                

            return tp;
        
        }

        

        //создание списка обьектов
        protected List<TpDetails> GetTpListFromReader(IDataReader reader)
        {
       
            List<TpDetails> tpArr = new List<TpDetails>();

            do
            {
                tpArr.Add(this.GetTpFromReader(reader));
            }

            while(reader.Read());
       
            return tpArr;
    
    
        }

    
        //Получение записей из бд
        public  List<TpDetails> GetTPs(int pageIndex, int pageSize, String TPsSort)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationHelper.KleckPassportConnectionString))
            {
                if (TPsSort == "")
                {
                    TPsSort = "DOC_NAME";
                }
            
                OracleCommand cmd =
                    new OracleCommand("Select DOC_CODE, DOC_NAME FROM (SELECT a.*, ROWNUM r FROM (SELECT DOC_CODE, DOC_NAME FROM PDOCS WHERE TEMPLATE_CODE IN ('RP','TP') ORDER BY DOC_NAME)a where rownum <= :HigerBound) where r >= :LowerBound order by " + TPsSort, connection);
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
                    return GetTpListFromReader(reader);
                }
                else
                    return null;


            }
        }

        public List<TpDetails> GetTPbyName(String DOC_NAME)
        {
            if (DOC_NAME == string.Empty)
            {
                DOC_NAME = "1";
            }
            using (OracleConnection connection = new OracleConnection(ConfigurationHelper.KleckPassportConnectionString))
            {


                OracleCommand cmd =
                    new OracleCommand("SELECT DOC_CODE, DOC_NAME FROM PDOCS WHERE TEMPLATE_CODE IN ('RP','TP') AND DOC_NAME = " + DOC_NAME, connection);
                cmd.CommandType = CommandType.Text;


                connection.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    return GetTpListFromReader(reader);
                }
                else
                    return null;


            }
        }
        //Получение количества записей из БД
        public  int GetTPsCount()
        {
            using (OracleConnection connect = new OracleConnection(ConfigurationHelper.KleckPassportConnectionString))
            {
                OracleCommand command = new OracleCommand("SELECT COUNT(*) FROM PDOCS WHERE TEMPLATE_CODE IN ('RP','TP')", connect);
                command.CommandType = CommandType.Text;
                connect.Open();
                return Convert.ToInt32(ExecuteScalar(command));
            }
        }



        //****************************************

        protected  TpDetails GetTpDetailsFromReader(IDataReader reader)
        {

             TpDetails tp = new  TpDetails(

                Convert.ToString(reader["DOC_CODE"]),
                Convert.ToString(reader["DOC_NAME"]),
                Convert.ToString(reader["TEMPLATE_CODE"])
                );


            return tp;

        }

        public  TpDetails GetTpDetails(string doc_name)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationHelper.KleckPassportConnectionString))
            {
                
                OracleCommand cmd =
                    new OracleCommand("Select DOC_CODE, TEMPLATE_CODE, DOC_NAME FROM PDOCS WHERE DOC_NAME = :DOC_NAME" , connection);
                cmd.CommandType = CommandType.Text;
                

                cmd.Parameters.Add(new OracleParameter("DOC_NAME", doc_name));
                
                connection.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    return GetTpDetailsFromReader(reader);
                }
                else
                    return null;


            }
        }
    
    

   

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Web;
using Sbyt.App_Service;

namespace Sbyt.Balance_Po_TP
{
    public class UzdaOracleTpProvider:BaseDal
    {
        //Описание инстанса. Он нужен для доступа к методам DAL слоя из BLL слоя
      

        #region Instance
        private UzdaOracleTpProvider() { }

        [ThreadStatic]
        private static UzdaOracleTpProvider _instance;

        public static UzdaOracleTpProvider Instance
        {
            get { return _instance ?? (_instance = new UzdaOracleTpProvider()); }
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
            using (OracleConnection connection = new OracleConnection(ConfigurationHelper.UzdaPassportConnectionString))
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
            using (OracleConnection connection = new OracleConnection(ConfigurationHelper.UzdaPassportConnectionString))
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
            using (OracleConnection connect = new OracleConnection(ConfigurationHelper.UzdaPassportConnectionString))
            {
                OracleCommand command = new OracleCommand("SELECT COUNT(*) FROM PDOCS WHERE TEMPLATE_CODE IN ('RP','TP')", connect);
                command.CommandType = CommandType.Text;
                connect.Open();
                return Convert.ToInt32(ExecuteScalar(command));
            }
        }



        //****************************************

        protected  OplatiDetails GetOplatiDetailsFromReader(IDataReader reader)
        {

             OplatiDetails oplata = new  OplatiDetails(

                Convert.ToString(reader["N1"]),
                Convert.ToString(reader["N2"]),
                Convert.ToString(reader["KODTP"]),
                Convert.ToString(reader["KODSEKTP"])

                );


            return oplata;

        }

        public OplatiDetails GetOplatiDetails(string kodtp, string tableName)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
            {
                
                OracleCommand cmd =
                    new OracleCommand("Select N1, N2, KODTP, KODSEKTP,KODLINI,OTPUSK FROM :TABLENAME WHERE KODTP = :KODTP" , connection);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new OracleParameter("TABLENAME", tableName));
                cmd.Parameters.Add(new OracleParameter("KODTP", kodtp));
                
                connection.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    return GetOplatiDetailsFromReader(reader);
                }
                else
                    return null;


            }
        }
    
    }
}
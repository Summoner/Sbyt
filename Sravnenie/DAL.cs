using System;
using System.Data.OracleClient;
using System.Data.Odbc;
using System.Data;
using Sbyt.App_Service;
using Sbyt.Balance_Po_TP;
using Sbyt.LogsManagement;

namespace Sbyt.Sravnenie
{
    public class DAL
     {
        
        
        private static String OraConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;
       
        private static String ODBCConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ODBCConnectionString"].ConnectionString;
      
         //Описание инстанса. Он нужен для доступа к методам DAL слоя из BLL слоя
      

        #region Instance
        private DAL() { }

        [ThreadStatic]
        private static DAL _instance;

        public static DAL Instance
        {
            get { return _instance ?? (_instance = new DAL()); }
        }
        #endregion



        public DataTable ConnectToODBC(String odbcFileName)
        {

            String odbcConnectionString = ODBCConnectionString;

          //  String OdbcConnectionString = @"Provider=Поставщик данных .NET Framework для ODBC;Dsn=Файлы dBASE;dbq=E:\temp;defaultdir=E:\temp;driverid=533;maxbuffersize=2048;pagetimeout=5;Provider=OleDb";
            OdbcConnection connect = new OdbcConnection(odbcConnectionString);

            OdbcCommand testcommand = connect.CreateCommand();
            testcommand.CommandText = "SELECT * FROM " + odbcFileName;
            OdbcDataAdapter oledbDA = new OdbcDataAdapter(testcommand);
            DataTable dbfTable = new DataTable();
            try
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Получение данных из DBF файла '{0}'", odbcFileName)));
                oledbDA.Fill(dbfTable);
                
                
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex.ToString())));
            
            }
            return dbfTable;




        }
        
        public void CreateOracleTable(String oraCommand, String tableName)
        {
            String connectionstring = OraConnectionString;
          //  String connectionstring = "Data Source=oik;Persist Security Info=True;User ID=sbyt;Password=1;Unicode=True";
            OracleConnection connect = new OracleConnection(connectionstring);

            OracleCommand command = connect.CreateCommand();
            command.CommandText = oraCommand;

            
            connect.Open();
            try
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Команда ORACLE на создание таблицы '{0}'", tableName)));
                command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex)));
            }
            finally
            {
                connect.Close();
            }
        }

        //Создание таблиц запроса сравнения привязки бытовых в Оракле и получение результата
        public DataTable CreateOraTablesGetDataForCompare(string shortResName)
        {

            //1. Запрос для сбытовиков
            DropOraTable(shortResName + "sbytoviki");
            String connectionstring = OraConnectionString;
            OracleConnection connect = new OracleConnection(connectionstring);
            string oraCommand = SQL.GetSbytovikiSqlCommand(shortResName);
            OracleCommand command = connect.CreateCommand();
            command.CommandText = oraCommand;


            connect.Open();
            try
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Команда ORACLE на создание таблицы '{0}'", shortResName+"Sbytoviki")));
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex)));
            }
            finally
            {
                connect.Close();
            }


            //2. Запрос для паспортов
            DropOraTable(shortResName + "pasporta");
            oraCommand = SQL.GetPasportaSqlCommand(shortResName);
            command = connect.CreateCommand();
            command.CommandText = oraCommand;


            connect.Open();
            try
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Команда ORACLE на создание таблицы '{0}'", shortResName + "Pasporta")));
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex)));
            }
            finally
            {
                connect.Close();
            }

            //3. Запрос для имя Рэс + result
            DropOraTable(shortResName + "result");
            oraCommand = SQL.GetResResultSqlCommand(shortResName);
            command = connect.CreateCommand();
            command.CommandText = oraCommand;


            connect.Open();
            try
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Команда ORACLE на создание таблицы '{0}'", shortResName + "Result")));
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex)));
            }
            finally
            {
                connect.Close();
            }

            //4. Финальный запрос с улицами
           
            oraCommand = SQL.GetResResultSqlCommandForStreets(shortResName);
            command = connect.CreateCommand();
            command.CommandText = oraCommand;
            DataTable resultDataTable = new DataTable();
            OracleDataAdapter oraDa = new OracleDataAdapter(command.CommandText, connect);

            try
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Формирование результата запроса для {0} из ORACLE ", shortResName + "Result")));
                oraDa.Fill(resultDataTable);
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Формирование результата запроса для {0} из ORACLE завершено", shortResName + "Result")));

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex)));
            }


            return resultDataTable;

        }

        public void FillOraTable(DataTable inpTable, String destTableName)
        {
            foreach (DataRow rowtemp in inpTable.Rows)
            {
                rowtemp.SetAdded();
            }
           // String connectionstring = DAL.OraConnectionString;
           // String connectionstring = "Data Source=oik;Persist Security Info=True;User ID=sbyt;Password=1;Unicode=True";
            OracleTransaction trans = null;
            try
            {
                OracleConnection connect = new OracleConnection(OraConnectionString);
                connect.Open();
                OracleCommand command = new OracleCommand("select * from " + destTableName, connect);
                OracleDataAdapter oraDa = new OracleDataAdapter(command);
                OracleCommandBuilder builder = new OracleCommandBuilder(oraDa);

                trans = connect.BeginTransaction();
                command.Transaction = trans;

                oraDa.InsertCommand = builder.GetInsertCommand();
                oraDa.Update(inpTable);

                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Заполнение таблицы ORACLE '{0}' данными {1}", destTableName, inpTable.TableName)));
                trans.Commit();
                connect.Close();
                
            }

            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex)));
               
            }


        }
               
        public void DropOraTable(String tableName)
        {
            String connectionstring = OraConnectionString;
            try
            {

                if (ConvertTablesToOra.Instance.IsTableExistInOra(tableName, connectionstring))
                {
                    // String connectionstring = "Data Source=oik;Persist Security Info=True;User ID=sbyt;Password=1;Unicode=True";
                    OracleConnection connect = new OracleConnection(connectionstring);

                    OracleCommand command = connect.CreateCommand();
                    command.CommandText = "Drop table " + tableName;

                   
                    Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm,
                                                   (string.Format("Удаление таблицы {0} из ORACLE", tableName)));
                    connect.Open();
                    command.ExecuteNonQuery();
                    connect.Close();
                }

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex)));
                
            }

               
        }

        public DataTable ResultReport(String command, String tableName)
        {
            // String connectionstring = "Data Source=oik;Persist Security Info=True;User ID=sbyt;Password=1;Unicode=True";
                String connectionstring = OraConnectionString;
                OracleConnection connect = new OracleConnection(connectionstring);
                DataTable resultDataTable = new DataTable();
               
                OracleCommand reportCommand = new OracleCommand();
                reportCommand.CommandText = command;
                reportCommand.CommandType = CommandType.Text;
                OracleDataAdapter oraDa = new OracleDataAdapter(reportCommand.CommandText,connect);
                
                try
                {
                    Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Формирование результата запроса для {0} из ORACLE ", tableName)));
                    oraDa.Fill(resultDataTable);
                    Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Формирование результата запроса для {0} из ORACLE завершено", tableName)));
                    
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex)));
                }
                                    

                return resultDataTable;
        
        }

        public DataTable GetOraTableByCommand(String command)

        {
            OracleConnection connect = new OracleConnection(OraConnectionString);
            DataTable resultDataTable = new DataTable();

            OracleCommand reportcommand = new OracleCommand();
            reportcommand.CommandText = command;
            reportcommand.CommandType = CommandType.Text;
            OracleDataAdapter oraDa = new OracleDataAdapter(reportcommand.CommandText, connect);
           
            try
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Получение данных из ORACLE по запросу: {0}", command)));
                oraDa.Fill(resultDataTable);
                
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex)));
            }

            return resultDataTable;
        
        
        
        }

        

        


        


    }
}
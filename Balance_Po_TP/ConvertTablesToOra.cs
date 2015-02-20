using System;
using System.Data;
using System.Data.Odbc;
using System.Data.OracleClient;
using Sbyt.App_Service;
using Sbyt.LogsManagement;

namespace Sbyt.Balance_Po_TP
{
    public class ConvertTablesToOra
    {
      
        //Описание инстанса. Он нужен для доступа к методам DAL слоя из BLL слоя
      

        #region Instance
        private ConvertTablesToOra() { }

        [ThreadStatic]
        private static ConvertTablesToOra _instance;

        public static ConvertTablesToOra Instance
        {
            get { return _instance ?? (_instance = new ConvertTablesToOra()); }
        }
        #endregion

        public void DropOraTable(string tableName, string connectionString)
        {
            try
            {
                if (IsTableExistInOra(tableName, connectionString))
                {
                    OracleConnection connect = new OracleConnection(connectionString);
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

        public DataTable ConnectToODBC(String odbcFileName, String odbcConnectionString)
        {
            
            OdbcConnection connect = new OdbcConnection(odbcConnectionString);

            OdbcCommand testcommand = connect.CreateCommand();
            testcommand.CommandText = "SELECT * FROM " + odbcFileName;
            OdbcDataAdapter oledbDA = new OdbcDataAdapter(testcommand);
            DataTable DBFTable = new DataTable();
            try
            {
                
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Получение данных из DBF файла '{0}'", odbcFileName)));
            oledbDA.Fill(DBFTable);

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex)));

            }
            return DBFTable;




        }
        
        public bool  IsTableExistInOra(string tableName, string connectionString)
        {
            Int32 count = 0;
            OracleConnection connect = new OracleConnection(connectionString);

            OracleCommand command = connect.CreateCommand();

            command.CommandText = "SELECT COUNT(*) FROM user_tables where table_name = :ptableName";
            command.Parameters.Add(new OracleParameter("ptableName", tableName.ToUpper()));
            try
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Проверка наличия таблицы '{0}'", tableName)));
                connect.Open();
                count =  Convert.ToInt32(command.ExecuteScalar());
                connect.Close();

            }

            catch(Exception e)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", e)));
                connect.Close();
            }


            if (count == 0)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' отсутствует в Oracle", tableName)));
                return false;
            }
            else
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' присутствует в Oracle", tableName)));
                return true;
            }


        }

        public void CreateOracleTable(string oraCommand, string tableName, string connectionString, string resName)
        {
          
            OracleConnection connect = new OracleConnection(connectionString);

            OracleCommand command = connect.CreateCommand();
            command.CommandText = oraCommand;

           
            connect.Open();
            try
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Команда ORACLE на создание таблицы '{0} для {1}'", tableName,resName)));
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

        public void FillOraTable(DataTable inpTable, string destTableName, string connectionString)
        {
            foreach (DataRow Rowtemp in inpTable.Rows)
            {
                Rowtemp.SetAdded();
            }
            
            OracleTransaction trans = null;
           
            try
            {
                OracleConnection connect = new OracleConnection(connectionString);
                connect.Open();
                OracleCommand command = new OracleCommand("select * from " + destTableName, connect);
                OracleDataAdapter oraDa = new OracleDataAdapter(command);
                OracleCommandBuilder builder = new OracleCommandBuilder(oraDa);

                trans = connect.BeginTransaction();
                command.Transaction = trans;

                oraDa.InsertCommand = builder.GetInsertCommand();
                oraDa.Update(inpTable);

                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Заполнение таблицы ORACLE '{0}' данными {1}", destTableName, inpTable.TableName)));
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, "*******************************************************************");
                trans.Commit();
                connect.Close();

            }

            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex.ToString())));

            }


        }

        public string CreateOraTableCommand(DataTable inpDataTable, string tableName)
        {

           
                //  String CommandText;
                String text = String.Empty;
                for (int i = 0; i < inpDataTable.Columns.Count; i++)
                {

                    if (i != inpDataTable.Columns.Count - 1)
                    {
                        text += inpDataTable.Columns[i].ColumnName + " Varchar(300), ";
                    }
                    else
                    {
                        text += inpDataTable.Columns[i].ColumnName + " Varchar(300)) ";
                    }
                }



               string commandText = "Create table " + tableName + "(" + text;

            return commandText;








        }
                   
        public  void ConvertToOraForBalancePoTp(string resName,string tableName,string odbcFileName)
        {
            DataTable tableFromOdbc = new DataTable();
            

            switch (resName)
            {
                case "Kleck":
                    {
                        tableFromOdbc = ConnectToODBC(odbcFileName, ConfigurationHelper.OdbcConnectionStringKleck);

                        if (tableFromOdbc.Columns.Count == 0)
                        {
                            Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, ("Данные ODBC для Клецкого РЭС не получены, таблица ORACLE не создается."));
                        }
                        else
                        {
                            DropOraTable(tableName, ConfigurationHelper.KleckOraConnectionStringBalPoTP);
                            CreateOracleTable(CreateOraTableCommand(tableFromOdbc, tableName),
                                                      tableName, ConfigurationHelper.KleckOraConnectionStringBalPoTP,"Клецкого РЭС");

                            FillOraTable(tableFromOdbc, tableName, ConfigurationHelper.KleckOraConnectionStringBalPoTP);
                            
                        }

                    }
                    break;

                case "Uzda":
                    {
                        tableFromOdbc = ConnectToODBC(odbcFileName, ConfigurationHelper.OdbcConnectionStringUzda);

                        if (tableFromOdbc.Columns.Count == 0)
                        {
                            Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, ("Данные ODBC для Узденского РЭС не получены, таблица ORACLE не создается."));
                        }
                        else
                        {
                            DropOraTable(tableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP);
                            CreateOracleTable(CreateOraTableCommand(tableFromOdbc, tableName),
                                                      tableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP,"Узденского РЭС");

                            FillOraTable(tableFromOdbc, tableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP);
                        }

                    }
                    break;

                case "Stolb":
                    {
                        tableFromOdbc = ConnectToODBC(odbcFileName, ConfigurationHelper.OdbcConnectionStringStolb);

                        if (tableFromOdbc.Columns.Count == 0)
                        {
                            Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, ("Данные ODBC для Столбцовского РЭС не получены, таблица ORACLE не создается."));
                        }
                        else
                        {
                            DropOraTable(tableName, ConfigurationHelper.StolbOraConnectionStringBalPoTP);
                            CreateOracleTable(CreateOraTableCommand(tableFromOdbc, tableName),
                                                      tableName, ConfigurationHelper.StolbOraConnectionStringBalPoTP,"Столбцовского РЭС");

                            FillOraTable(tableFromOdbc, tableName, ConfigurationHelper.StolbOraConnectionStringBalPoTP);
                            
                        }

                    }
                    break;

                case "Derg":
                    {
                        tableFromOdbc = ConnectToODBC(odbcFileName, ConfigurationHelper.OdbcConnectionStringDerg);

                        if (tableFromOdbc.Columns.Count == 0)
                        {
                            Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, ("Данные ODBC для Дзержинского РЭС не получены, таблица ORACLE не создается."));
                        }
                        else
                        {
                            DropOraTable(tableName, ConfigurationHelper.DergOraConnectionStringBalPoTP);
                            CreateOracleTable(CreateOraTableCommand(tableFromOdbc, tableName),
                                                      tableName, ConfigurationHelper.DergOraConnectionStringBalPoTP,"Дзержинского РЭС");

                            FillOraTable(tableFromOdbc, tableName, ConfigurationHelper.DergOraConnectionStringBalPoTP);
                            
                        }

                    }
                    break;

                case "Nesv":
                    {
                        tableFromOdbc = ConnectToODBC(odbcFileName, ConfigurationHelper.OdbcConnectionStringNesv);

                        if (tableFromOdbc.Columns.Count == 0)
                        {
                            Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, ("Данные ODBC для Несвижского РЭС не получены, таблица ORACLE не создается."));
                        }
                        else
                        {
                            DropOraTable(tableName, ConfigurationHelper.NesvOraConnectionStringBalPoTP);
                            CreateOracleTable(CreateOraTableCommand(tableFromOdbc, tableName),
                                                      tableName, ConfigurationHelper.NesvOraConnectionStringBalPoTP,"Несвижского РЭС");

                            FillOraTable(tableFromOdbc, tableName, ConfigurationHelper.NesvOraConnectionStringBalPoTP);
                            
                        }

                    }
                    break;




            }


        }

        public void ConvertToOraForBalancePoTpStreet(string resName, string tableName, string odbcFileName)
        {
            DataTable tableFromOdbc = new DataTable();


            switch (resName)
            {
                case "Kleck":
                    {
                        tableFromOdbc = ConnectToODBC(odbcFileName, ConfigurationHelper.OdbcConnectionStringKleck);

                        if (tableFromOdbc.Columns.Count == 0)
                        {
                            Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, ("Данные ODBC для Клецкого РЭС не получены, таблица ORACLE не создается."));
                        }
                        else
                        {
                            DropOraTable(tableName, ConfigurationHelper.KleckOraConnectionStringBalPoTP);
                            CreateOracleTable(CreateOraTableCommand(tableFromOdbc, tableName),
                                                      tableName, ConfigurationHelper.KleckOraConnectionStringBalPoTP, "Клецкого РЭС");

                            FillOraTable(tableFromOdbc, tableName, ConfigurationHelper.KleckOraConnectionStringBalPoTP);

                           
                        }

                    }
                    break;

                case "Uzda":
                    {
                        tableFromOdbc = ConnectToODBC(odbcFileName, ConfigurationHelper.OdbcConnectionStringUzda);

                        if (tableFromOdbc.Columns.Count == 0)
                        {
                            Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, ("Данные ODBC для Узденского РЭС не получены, таблица ORACLE не создается."));
                        }
                        else
                        {
                            DropOraTable(tableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP);
                            CreateOracleTable(CreateOraTableCommand(tableFromOdbc, tableName),
                                                      tableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP, "Узденского РЭС");

                            FillOraTable(tableFromOdbc, tableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP);
                            
                        }

                    }
                    break;

                case "Stolb":
                    {
                        tableFromOdbc = ConnectToODBC(odbcFileName, ConfigurationHelper.OdbcConnectionStringStolb);

                        if (tableFromOdbc.Columns.Count == 0)
                        {
                            Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, ("Данные ODBC для Столбцовского РЭС не получены, таблица ORACLE не создается."));
                        }
                        else
                        {
                            DropOraTable(tableName, ConfigurationHelper.StolbOraConnectionStringBalPoTP);
                            CreateOracleTable(CreateOraTableCommand(tableFromOdbc, tableName),
                                                      tableName, ConfigurationHelper.StolbOraConnectionStringBalPoTP, "Столбцовского РЭС");

                            FillOraTable(tableFromOdbc, tableName, ConfigurationHelper.StolbOraConnectionStringBalPoTP);
                           
                        }

                    }
                    break;

                case "Derg":
                    {
                        tableFromOdbc = ConnectToODBC(odbcFileName, ConfigurationHelper.OdbcConnectionStringDerg);

                        if (tableFromOdbc.Columns.Count == 0)
                        {
                            Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, ("Данные ODBC для Дзержинского РЭС не получены, таблица ORACLE не создается."));
                        }
                        else
                        {
                            DropOraTable(tableName, ConfigurationHelper.DergOraConnectionStringBalPoTP);
                            CreateOracleTable(CreateOraTableCommand(tableFromOdbc, tableName),
                                                      tableName, ConfigurationHelper.DergOraConnectionStringBalPoTP, "Дзержинского РЭС");

                            FillOraTable(tableFromOdbc, tableName, ConfigurationHelper.DergOraConnectionStringBalPoTP);
                           
                        }

                    }
                    break;

                case "Nesv":
                    {
                        tableFromOdbc = ConnectToODBC(odbcFileName, ConfigurationHelper.OdbcConnectionStringNesv);

                        if (tableFromOdbc.Columns.Count == 0)
                        {
                            Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, ("Данные ODBC для Несвижского РЭС не получены, таблица ORACLE не создается."));
                        }
                        else
                        {
                            DropOraTable(tableName, ConfigurationHelper.NesvOraConnectionStringBalPoTP);
                            CreateOracleTable(CreateOraTableCommand(tableFromOdbc, tableName),
                                                      tableName, ConfigurationHelper.NesvOraConnectionStringBalPoTP, "Несвижского РЭС");

                            FillOraTable(tableFromOdbc, tableName, ConfigurationHelper.NesvOraConnectionStringBalPoTP);
                            
                        }

                    }
                    break;




            }


        }
        
    }

    
}
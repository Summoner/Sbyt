using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using Sbyt.LogsManagement;

namespace Sbyt.App_Service
{
    public class ChekODBCColumns
    {
        //проверяем наличие необходимых колонок в DBF

         #region Instance
        private ChekODBCColumns() { }

        [ThreadStatic]
        private static ChekODBCColumns _instance;

        public static ChekODBCColumns Instance
        {
            get { return _instance ?? (_instance = new ChekODBCColumns()); }
        }
        #endregion

        private static String ODBCConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ODBCConnectionString"].ConnectionString;

        //----------------Для сравнения оплат потребителей ----------------------------


        private DataTable ConnectToODBC(String odbcFileName, String connectionString)
        {

            String odbcConnectionString = connectionString;

            //  String OdbcConnectionString = @"Provider=Поставщик данных .NET Framework для ODBC;Dsn=Файлы dBASE;dbq=E:\temp;defaultdir=E:\temp;driverid=533;maxbuffersize=2048;pagetimeout=5;Provider=OleDb";
            OdbcConnection connect = new OdbcConnection(odbcConnectionString);

            OdbcCommand testcommand = connect.CreateCommand();
            testcommand.CommandText = "SELECT * FROM " + odbcFileName;
            OdbcDataAdapter oledbDa = new OdbcDataAdapter(testcommand);
            DataTable dbfTable = new DataTable();
            try
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Получение данных из '{0}' для проверки имен столбцов DBF файла ", odbcFileName)));
                oledbDa.Fill(dbfTable);


            }
            catch (Exception ex)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex)));

            }
            return dbfTable;




        }

        //дЛЯ БЫТОВЫХ - оплаты
        private string CheckColumnsNamesByt(DataTable odbCtable)
        {
            List<string> columnNames = new List<string>();
            List<string> columnNamesNotExist = new List<string>();

            String text = string.Empty;

            for (int i = 0; i < odbCtable.Columns.Count; i++)
            {
                columnNames.Add(odbCtable.Columns[i].ColumnName);
               
            }

            if (!columnNames.Contains("AB_N"))
            {
                columnNamesNotExist.Add("AB_N");
            }
            if (!columnNames.Contains("FIO"))
            {
                columnNamesNotExist.Add("FIO");
            }
            if (!columnNames.Contains("STREET"))
            {
                columnNamesNotExist.Add("STREET");
            }
            if (!columnNames.Contains("DOM"))
            {
                columnNamesNotExist.Add("DOM");
            }
            if (!columnNames.Contains("KORP"))
            {
                columnNamesNotExist.Add("KORP");
            }
            if (!columnNames.Contains("KVAR"))
            {
                columnNamesNotExist.Add("KVAR");
            }
            if (!columnNames.Contains("KVT"))
            {
                columnNamesNotExist.Add("KVT");
            }
            if (!columnNames.Contains("PRPLOM"))
            {
                columnNamesNotExist.Add("PRPLOM");
            }
            if (!columnNames.Contains("TIP"))
            {
                columnNamesNotExist.Add("TIP");
            }
            if (!columnNames.Contains("NOMER"))
            {
                columnNamesNotExist.Add("NOMER");
            }
            if (!columnNames.Contains("OPOKAZ"))
            {
                columnNamesNotExist.Add("OPOKAZ");
            }


            if (columnNamesNotExist.Count != 0)
            {

                text = "Колонки с наименованиями: ";

                foreach (string str in columnNamesNotExist)
                {
                    text += str;
                    text += " , ";
                }
                text += " отсутствуют в файле DBF. Конвертацию не производим.";
            
            }

            

            return text;
        
        }

        //для промышленников оплаты
        private string CheckColumnsNamesProm(DataTable odbCtable)
        {
            List<string> columnNames = new List<string>();
            List<string> columnNamesNotExist = new List<string>();

            String text = string.Empty;
          

            for (int i = 0; i < odbCtable.Columns.Count; i++)
            {
                columnNames.Add(odbCtable.Columns[i].ColumnName);

            }

            if (!columnNames.Contains("N1"))
            {
                columnNamesNotExist.Add("N1");
            }
            if (!columnNames.Contains("N2"))
            {
                columnNamesNotExist.Add("N2");
            }
            if (!columnNames.Contains("N3"))
            {
                columnNamesNotExist.Add("N3");
            }
            if (!columnNames.Contains("OTPUSK"))
            {
                columnNamesNotExist.Add("OTPUSK");
            }
            if (!columnNames.Contains("POTERI"))
            {
                columnNamesNotExist.Add("POTERI");
            }
            if (!columnNames.Contains("KP"))
            {
                columnNamesNotExist.Add("KP");
            }
            if (!columnNames.Contains("NAB"))
            {
                columnNamesNotExist.Add("NAB");
            }
            if (!columnNames.Contains("KTU"))
            {
                columnNamesNotExist.Add("KTU");
            }
            if (!columnNames.Contains("KODTP"))
            {
                columnNamesNotExist.Add("KODTP");
            }
            if (!columnNames.Contains("TP"))
            {
                columnNamesNotExist.Add("TP");
            }
            if (!columnNames.Contains("NST"))
            {
                columnNamesNotExist.Add("NST");
            }
            if (!columnNames.Contains("TIPSCH"))
            {
                columnNamesNotExist.Add("TIPSCH");
            }
            if (!columnNames.Contains("TPOK"))
            {
                columnNamesNotExist.Add("TPOK");
            }
            if (!columnNames.Contains("KTT"))
            {
                columnNamesNotExist.Add("KTT");
            }

            if (columnNamesNotExist.Count != 0)
            {

                text = "Колонки с наименованиями: ";

                foreach (string str in columnNamesNotExist)
                {
                    text += str;
                    text += " , ";
                }

                text += " отсутствуют в файле DBF. Конвертацию не производим.";
            }

            if (columnNames.Contains("POTERI"))
            {
                if(odbCtable.Rows[1]["POTERI"].ToString() == string.Empty)
                {
                    text += "Значения в столбце POTERI отсутствуют. Конвертацию не производим";
                }
            }

           
            return text;

        }

        //ДЛЯ улиц оплаты
        private string CheckColumnsNamesStreet(DataTable odbCtable)
        {
            List<string> columnNames = new List<string>();
            List<string> columnNamesNotExist = new List<string>();

            String text = string.Empty;


            for (int i = 0; i < odbCtable.Columns.Count; i++)
            {
                columnNames.Add(odbCtable.Columns[i].ColumnName);

            }

            if (!columnNames.Contains("NOM"))
            {
                columnNamesNotExist.Add("NOM");
            }
            if (!columnNames.Contains("NAIM"))
            {
                columnNamesNotExist.Add("NAIM");
            }
            

            if (columnNamesNotExist.Count != 0)
            {

                text = "Колонки с наименованиями: ";

                foreach (string str in columnNamesNotExist)
                {
                    text += str;
                    text += " , ";
                }
                text += " отсутствуют в файле DBF. Конвертацию не производим.";

            }



            return text;

        }

                
        public string CheckColumns(String odbcFileName, String connectionString, String promOrByt)
        {
            String res = string.Empty;

            DataTable table = ConnectToODBC(odbcFileName, connectionString);

            switch (promOrByt)
            {
                case "PROM":
                    {
                        res = CheckColumnsNamesProm(table);
                        break;
                    }

                case "BYT":
                    {
                        res = CheckColumnsNamesByt(table);
                        break;
                    }


            }

            return res;
        
        }


        public string CheckColumnsStreetOplati(String odbcFileName, String connectionString)
        {
            DataTable table = ConnectToODBC(odbcFileName, connectionString);

            string res = CheckColumnsNamesStreet(table);

            return res;

        }


        //----------------Для сравнения привязки бытовых потребителей----------------------------


        private string CheckColumnsNamesSbyt(DataTable odbCtable)
        {
            List<string> columnNames = new List<string>();
            List<string> columnNamesNotExist = new List<string>();

            String text = string.Empty;

            for (int i = 0; i < odbCtable.Columns.Count; i++)
            {
                columnNames.Add(odbCtable.Columns[i].ColumnName);

            }

            if (!columnNames.Contains("AB_N"))
            {
                columnNamesNotExist.Add("AB_N");
            }
            if (!columnNames.Contains("FIO"))
            {
                columnNamesNotExist.Add("FIO");
            }
            if (!columnNames.Contains("STREET"))
            {
                columnNamesNotExist.Add("STREET");
            }
            if (!columnNames.Contains("DOM"))
            {
                columnNamesNotExist.Add("DOM");
            }
            if (!columnNames.Contains("PRPLOM"))
            {
                columnNamesNotExist.Add("PRPLOM");
            }
            if (!columnNames.Contains("FIDER"))
            {
                columnNamesNotExist.Add("FIDER");
            }



            if (columnNamesNotExist.Count != 0)
            {

                text = "Колонки с наименованиями: ";

                foreach (string str in columnNamesNotExist)
                {
                    text += str;
                    text += " , ";
                }
                text += " отсутствуют в файле DBF. Конвертацию не производим.";

            }



            return text;

        }
        public string CheckColumnNamesSbyt(String odbcFileName)
        {
            string connectionString = ODBCConnectionString;
            DataTable table = ConnectToODBC(odbcFileName, connectionString);
            string res = CheckColumnsNamesSbyt(table);
            return res;

        }


        private string CheckColumnsNamesPasport(DataTable odbCtable)
        {
            List<string> columnNames = new List<string>();
            List<string> columnNamesNotExist = new List<string>();

            String text = string.Empty;

            for (int i = 0; i < odbCtable.Columns.Count; i++)
            {
                columnNames.Add(odbCtable.Columns[i].ColumnName);

            }

            if (!columnNames.Contains("AB_N"))
            {
                columnNamesNotExist.Add("AB_N");
            }
            if (!columnNames.Contains("FIO"))
            {
                columnNamesNotExist.Add("FIO");
            }
            if (!columnNames.Contains("STREET"))
            {
                columnNamesNotExist.Add("STREET");
            }
            if (!columnNames.Contains("DOM"))
            {
                columnNamesNotExist.Add("DOM");
            }
            if (!columnNames.Contains("N_TP"))
            {
                columnNamesNotExist.Add("N_TP");
            }
            if (!columnNames.Contains("N_VL"))
            {
                columnNamesNotExist.Add("N_VL");
            }



            if (columnNamesNotExist.Count != 0)
            {

                text = "Колонки с наименованиями: ";

                foreach (string str in columnNamesNotExist)
                {
                    text += str;
                    text += " , ";
                }
                text += " отсутствуют в файле DBF. Конвертацию не производим.";

            }



            return text;

        }
        public string CheckColumnsNamesPasport(String odbcFileName)
        {
            string connectionString = ODBCConnectionString;
            DataTable table = ConnectToODBC(odbcFileName, connectionString);

            string res = CheckColumnsNamesPasport(table);

            return res;

        }
        

        private string CheckColumnsNamesDerul(DataTable odbCtable)
        {
            List<string> columnNames = new List<string>();
            List<string> columnNamesNotExist = new List<string>();

            String text = string.Empty;


            for (int i = 0; i < odbCtable.Columns.Count; i++)
            {
                columnNames.Add(odbCtable.Columns[i].ColumnName);

            }

            if (!columnNames.Contains("NOM"))
            {
                columnNamesNotExist.Add("NOM");
            }
            if (!columnNames.Contains("NAIM"))
            {
                columnNamesNotExist.Add("NAIM");
            }


            if (columnNamesNotExist.Count != 0)
            {

                text = "Колонки с наименованиями: ";

                foreach (string str in columnNamesNotExist)
                {
                    text += str;
                    text += " , ";
                }
                text += " отсутствуют в файле DBF. Конвертацию не производим.";

            }



            return text;

        }
        public string CheckColumnsNamesDerul(String odbcFileName)
        {
            string connectionString = ODBCConnectionString;
            DataTable table = ConnectToODBC(odbcFileName, connectionString);
            string res = CheckColumnsNamesDerul(table);
            return res;

        }

    }
}
using System;
using System.IO;
using System.Data;

namespace Sbyt
{
    public class ReadFromLog
    {

         //Описание инстанса. Он нужен для доступа к методам DAL слоя из BLL слоя
    
        #region Instance
        private ReadFromLog() { }

        [ThreadStatic]
        private static ReadFromLog _instance;

        public static ReadFromLog Instance
        {
            get { return _instance ?? (_instance = new ReadFromLog()); }
        }
        #endregion




        public  DataTable ReadFromLogFunk(string logPath)
        {
           
             DataTable logTable = new DataTable();
             logTable.Columns.Add(new DataColumn("События"));
             


            if (File.Exists(logPath))
            {


                using (StreamReader sr = new StreamReader(logPath))
                {
                    string line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        
                        logTable.Rows.Add(line);
                    }
                }

            }

            else
            {
                string line = "Данного лог-файла не существует.";
                
                logTable.Rows.Add(line);
            }

           
            return logTable;


        }





    }
}
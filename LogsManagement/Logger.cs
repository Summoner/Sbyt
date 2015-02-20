using System;
using System.IO;
using System.Web;

namespace Sbyt.LogsManagement
{
   public class Logger
    {

      
      

        #region Instance
       private Logger() { }

        [ThreadStatic]
       private static Logger _instance;

        public static Logger Instance
        {
            get { return _instance ?? (_instance = new Logger()); }
        }
        #endregion

       public void WriteToLogFile(String path, String errorText)
       {
           lock(this)
           {
               using (StreamWriter file = new StreamWriter(path, true))
               {
                   file.WriteLine(String.Format("{0} {1} {2}", DateTime.Now,
                                                HttpContext.Current.Request.UserHostAddress, errorText));
               }
           }


       }


    }
}

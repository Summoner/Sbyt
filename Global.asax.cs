using System;
using System.Web;
using Sbyt.App_Service;
using Sbyt.LogsManagement;


namespace Sbyt
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

       HttpContext context = HttpContext.Current;
        Exception ex = context.Server.GetLastError();
      string errorSource =  ((HttpApplication)sender).Context.Request.Url.ToString();
        
      
        if (ex != null)
        {
          String message = ex.ToString();
          // message = StringConvert.Instance.RemoveSymbols(message);
           Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, ("****************************************************************"));
           Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Описание ошибки программы: {0} ", message)));
           Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Источник ошибки: {0} ", errorSource)));
           Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, ("****************************************************************"));
                
       }
           Server.Transfer("Error.aspx");
       }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
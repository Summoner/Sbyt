using System;
using Sbyt.App_Service;

namespace Sbyt
{
    public partial class LogViewProgramm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            logRead.DataSource = ReadFromLog.Instance.ReadFromLogFunk(ConfigurationHelper.ErrorLogProgramm);
            logRead.DataBind();

        }
    }
}
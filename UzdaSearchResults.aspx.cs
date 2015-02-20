using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sbyt.App_Service;
using Sbyt.Balance_Po_TP;
using System.Data;
using Sbyt.LogsManagement;

namespace Sbyt
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> PromTableNames = new List<string>();
            List<string> BytTableNames = new List<string>();
           
            string searchExpression = Session["searchExpression"].ToString();


            if ((Session["Year"] != null) && (Session["Month"] != null))
            {
                string PromTableName = "PROM_" + Session["Month"].ToString() + "_" + Session["Year"].ToString();
                string BytTableName = "BYT_" + Session["Month"].ToString() + "_" + Session["Year"].ToString();



                if (ConvertTablesToOra.Instance.IsTableExistInOra(PromTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                {
                    PromTableNames.Add(PromTableName);
                }
                else
                {
                    Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", PromTableName)));
                }

                if (ConvertTablesToOra.Instance.IsTableExistInOra(BytTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                {
                    BytTableNames.Add(BytTableName);
                }
                else
                {
                    Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", BytTableName)));
                }


            }

            if ((Session["Year1"] != null) && (Session["Month1"] != null))
            {
                string PromTableName = "PROM_" + Session["Month1"].ToString() + "_" + Session["Year1"].ToString();
                string BytTableName = "BYT_" + Session["Month1"].ToString() + "_" + Session["Year1"].ToString();

                if (!PromTableNames.Contains(PromTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(PromTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        PromTableNames.Add(PromTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", PromTableName)));
                    }


                }

                if (!BytTableNames.Contains(BytTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(BytTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        BytTableNames.Add(BytTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", BytTableName)));
                    }


                }






            }

            if ((Session["Year2"] != null) && (Session["Month2"] != null))
            {
                string PromTableName = "PROM_" + Session["Month2"].ToString() + "_" + Session["Year2"].ToString();
                string BytTableName = "BYT_" + Session["Month2"].ToString() + "_" + Session["Year2"].ToString();

                if (!PromTableNames.Contains(PromTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(PromTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        PromTableNames.Add(PromTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", PromTableName)));
                    }


                }

                if (!BytTableNames.Contains(BytTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(BytTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        BytTableNames.Add(BytTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", BytTableName)));
                    }


                }
            }

            if ((Session["Year3"] != null) && (Session["Month3"] != null))
            {
                string PromTableName = "PROM_" + Session["Month3"].ToString() + "_" + Session["Year3"].ToString();
                string BytTableName = "BYT_" + Session["Month3"].ToString() + "_" + Session["Year3"].ToString();

                if (!PromTableNames.Contains(PromTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(PromTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        PromTableNames.Add(PromTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", PromTableName)));
                    }


                }

                if (!BytTableNames.Contains(BytTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(BytTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        BytTableNames.Add(BytTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", BytTableName)));
                    }


                }
            }

            if ((Session["Year4"] != null) && (Session["Month4"] != null))
            {
                string PromTableName = "PROM_" + Session["Month4"].ToString() + "_" + Session["Year4"].ToString();
                string BytTableName = "BYT_" + Session["Month4"].ToString() + "_" + Session["Year4"].ToString();

                if (!PromTableNames.Contains(PromTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(PromTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        PromTableNames.Add(PromTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", PromTableName)));
                    }


                }

                if (!BytTableNames.Contains(BytTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(BytTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        BytTableNames.Add(BytTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", BytTableName)));
                    }


                }
            }

            if ((Session["Year5"] != null) && (Session["Month5"] != null))
            {
                string PromTableName = "PROM_" + Session["Month5"].ToString() + "_" + Session["Year5"].ToString();
                string BytTableName = "BYT_" + Session["Month5"].ToString() + "_" + Session["Year5"].ToString();

                if (!PromTableNames.Contains(PromTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(PromTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        PromTableNames.Add(PromTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", PromTableName)));
                    }


                }

                if (!BytTableNames.Contains(BytTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(BytTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        BytTableNames.Add(BytTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", BytTableName)));
                    }


                }
            }


            if ((Session["Year6"] != null) && (Session["Month6"] != null))
            {
                string PromTableName = "PROM_" + Session["Month6"].ToString() + "_" + Session["Year6"].ToString();
                string BytTableName = "BYT_" + Session["Month6"].ToString() + "_" + Session["Year6"].ToString();

                if (!PromTableNames.Contains(PromTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(PromTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        PromTableNames.Add(PromTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", PromTableName)));
                    }


                }

                if (!BytTableNames.Contains(BytTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(BytTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        BytTableNames.Add(BytTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", BytTableName)));
                    }


                }

            }

            if ((Session["Year7"] != null) && (Session["Month7"] != null))
            {
                string PromTableName = "PROM_" + Session["Month7"].ToString() + "_" + Session["Year7"].ToString();
                string BytTableName = "BYT_" + Session["Month7"].ToString() + "_" + Session["Year7"].ToString();

                if (!PromTableNames.Contains(PromTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(PromTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        PromTableNames.Add(PromTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", PromTableName)));
                    }


                }

                if (!BytTableNames.Contains(BytTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(BytTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        BytTableNames.Add(BytTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", BytTableName)));
                    }


                }

            }


            if ((Session["Year8"] != null) && (Session["Month8"] != null))
            {
                string PromTableName = "PROM_" + Session["Month8"].ToString() + "_" + Session["Year8"].ToString();
                string BytTableName = "BYT_" + Session["Month8"].ToString() + "_" + Session["Year8"].ToString();

                if (!PromTableNames.Contains(PromTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(PromTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        PromTableNames.Add(PromTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", PromTableName)));
                    }


                }

                if (!BytTableNames.Contains(BytTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(BytTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        BytTableNames.Add(BytTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", BytTableName)));
                    }


                }

            }

            if ((Session["Year9"] != null) && (Session["Month9"] != null))
            {
                string PromTableName = "PROM_" + Session["Month9"].ToString() + "_" + Session["Year9"].ToString();
                string BytTableName = "BYT_" + Session["Month9"].ToString() + "_" + Session["Year9"].ToString();

                if (!PromTableNames.Contains(PromTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(PromTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        PromTableNames.Add(PromTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", PromTableName)));
                    }


                }

                if (!BytTableNames.Contains(BytTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(BytTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        BytTableNames.Add(BytTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", BytTableName)));
                    }


                }

            }

            if ((Session["Year10"] != null) && (Session["Month10"] != null))
            {
                string PromTableName = "PROM_" + Session["Month10"].ToString() + "_" + Session["Year10"].ToString();
                string BytTableName = "BYT_" + Session["Month10"].ToString() + "_" + Session["Year10"].ToString();

                if (!PromTableNames.Contains(PromTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(PromTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        PromTableNames.Add(PromTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", PromTableName)));
                    }


                }

                if (!BytTableNames.Contains(BytTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(BytTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        BytTableNames.Add(BytTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", BytTableName)));
                    }


                }

            }


            if ((Session["Year11"] != null) && (Session["Month11"] != null))
            {
                string PromTableName = "PROM_" + Session["Month11"].ToString() + "_" + Session["Year11"].ToString();
                string BytTableName = "BYT_" + Session["Month11"].ToString() + "_" + Session["Year11"].ToString();

                if (!PromTableNames.Contains(PromTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(PromTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        PromTableNames.Add(PromTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", PromTableName)));
                    }


                }

                if (!BytTableNames.Contains(BytTableName))
                {


                    if (ConvertTablesToOra.Instance.IsTableExistInOra(BytTableName, ConfigurationHelper.UzdaOraConnectionStringBalPoTP))
                    {
                        BytTableNames.Add(BytTableName);
                    }
                    else
                    {
                        Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Таблица '{0}' в ORACLE не существует", BytTableName)));
                    }


                }

            }




            if (PromTableNames.Count != 0)
            {


                 

                   // promTable = Balance_Po_VL.OracleOplati.Instance.PromGetOraTable(Promsql, ConfigurationHelper.UzdaOraConnectionStringBalPoTP, "Узденский РЭС");
                    promTable = App_Service.SearchOra.Instance.PromGetOraTable(PromTableNames,searchExpression,ConfigurationHelper.UzdaOraConnectionStringBalPoTP,"Узденский РЭС");
                    PromGridView.DataSource = promTable;
                    PromGridView.DataBind();
                    Session["PromTable"] = promTable;
             }



          

            PromTableNames.Clear();


            if (BytTableNames.Count != 0)
            {
               

                 //   bytTable = Balance_Po_VL.OracleOplati.Instance.BytGetOraTable(Bytsql, ConfigurationHelper.UzdaOraConnectionStringBalPoTP, "Узденский РЭС");
                bytTable = App_Service.SearchOra.Instance.BytGetOraTable(BytTableNames,searchExpression,ConfigurationHelper.UzdaOraConnectionStringBalPoTP,"Узденский РЭС");
                    BytGridView.DataSource = bytTable;
                    BytGridView.DataBind();
                    Session["BytTable"] = bytTable;

                }

           

            BytTableNames.Clear();

        }

        DataTable promTable = new DataTable();
        DataTable bytTable = new DataTable();


        private decimal Sum0;
        private decimal Sum1;
        private decimal Sum2;
        private decimal Sum3;
        private decimal Sum4;
        private decimal Sum5;
        private decimal Sum6;
        private decimal Sum7;
        private decimal Sum8;
        private decimal Sum9;
        private decimal Sum10;
        private decimal Sum11;

        protected void PromGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            Int32 columns = promTable.Columns.Count;


            if (columns == 5)
            {
                return;
            }

            else if (columns == 6)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption));
                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[5].Text = Sum0.ToString();

                }
            }

            else if (columns == 7)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption));
                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[5].Text = Sum0.ToString();
                    e.Row.Cells[6].Text = Sum1.ToString();

                }
            }


            else if (columns == 8)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption));
                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[5].Text = Sum0.ToString();
                    e.Row.Cells[6].Text = Sum1.ToString();
                    e.Row.Cells[7].Text = Sum2.ToString();

                }
            }


            else if (columns == 9)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[5].Text = Sum0.ToString();
                    e.Row.Cells[6].Text = Sum1.ToString();
                    e.Row.Cells[7].Text = Sum2.ToString();
                    e.Row.Cells[8].Text = Sum3.ToString();

                }
            }


            else if (columns == 10)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[5].Text = Sum0.ToString();
                    e.Row.Cells[6].Text = Sum1.ToString();
                    e.Row.Cells[7].Text = Sum2.ToString();
                    e.Row.Cells[8].Text = Sum3.ToString();
                    e.Row.Cells[9].Text = Sum4.ToString();

                }
            }

            else if (columns == 11)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[5].Text = Sum0.ToString();
                    e.Row.Cells[6].Text = Sum1.ToString();
                    e.Row.Cells[7].Text = Sum2.ToString();
                    e.Row.Cells[8].Text = Sum3.ToString();
                    e.Row.Cells[9].Text = Sum4.ToString();
                    e.Row.Cells[10].Text = Sum5.ToString();

                }
            }


            else if (columns == 12)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value)
                    {
                        Sum6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[5].Text = Sum0.ToString();
                    e.Row.Cells[6].Text = Sum1.ToString();
                    e.Row.Cells[7].Text = Sum2.ToString();
                    e.Row.Cells[8].Text = Sum3.ToString();
                    e.Row.Cells[9].Text = Sum4.ToString();
                    e.Row.Cells[10].Text = Sum5.ToString();
                    e.Row.Cells[11].Text = Sum6.ToString();

                }
            }

            else if (columns == 13)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value)
                    {
                        Sum6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption) != DBNull.Value)
                    {
                        Sum7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption));
                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[5].Text = Sum0.ToString();
                    e.Row.Cells[6].Text = Sum1.ToString();
                    e.Row.Cells[7].Text = Sum2.ToString();
                    e.Row.Cells[8].Text = Sum3.ToString();
                    e.Row.Cells[9].Text = Sum4.ToString();
                    e.Row.Cells[10].Text = Sum5.ToString();
                    e.Row.Cells[11].Text = Sum6.ToString();
                    e.Row.Cells[12].Text = Sum7.ToString();

                }
            }

            else if (columns == 14)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value)
                    {
                        Sum6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption) != DBNull.Value)
                    {
                        Sum7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption) != DBNull.Value)
                    {
                        Sum8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption));
                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[5].Text = Sum0.ToString();
                    e.Row.Cells[6].Text = Sum1.ToString();
                    e.Row.Cells[7].Text = Sum2.ToString();
                    e.Row.Cells[8].Text = Sum3.ToString();
                    e.Row.Cells[9].Text = Sum4.ToString();
                    e.Row.Cells[10].Text = Sum5.ToString();
                    e.Row.Cells[11].Text = Sum6.ToString();
                    e.Row.Cells[12].Text = Sum7.ToString();
                    e.Row.Cells[13].Text = Sum8.ToString();

                }
            }

            else if (columns == 15)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value)
                    {
                        Sum6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption) != DBNull.Value)
                    {
                        Sum7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption) != DBNull.Value)
                    {
                        Sum8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption) != DBNull.Value)
                    {
                        Sum9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption));
                    }

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[5].Text = Sum0.ToString();
                    e.Row.Cells[6].Text = Sum1.ToString();
                    e.Row.Cells[7].Text = Sum2.ToString();
                    e.Row.Cells[8].Text = Sum3.ToString();
                    e.Row.Cells[9].Text = Sum4.ToString();
                    e.Row.Cells[10].Text = Sum5.ToString();
                    e.Row.Cells[11].Text = Sum6.ToString();
                    e.Row.Cells[12].Text = Sum7.ToString();
                    e.Row.Cells[13].Text = Sum8.ToString();
                    e.Row.Cells[14].Text = Sum9.ToString();

                }
            }

            else if (columns == 16)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value)
                    {
                        Sum6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption) != DBNull.Value)
                    {
                        Sum7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption) != DBNull.Value)
                    {
                        Sum8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption) != DBNull.Value)
                    {
                        Sum9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption) != DBNull.Value)
                    {
                        Sum10 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption));
                    }

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[5].Text = Sum0.ToString();
                    e.Row.Cells[6].Text = Sum1.ToString();
                    e.Row.Cells[7].Text = Sum2.ToString();
                    e.Row.Cells[8].Text = Sum3.ToString();
                    e.Row.Cells[9].Text = Sum4.ToString();
                    e.Row.Cells[10].Text = Sum5.ToString();
                    e.Row.Cells[11].Text = Sum6.ToString();
                    e.Row.Cells[12].Text = Sum7.ToString();
                    e.Row.Cells[13].Text = Sum8.ToString();
                    e.Row.Cells[14].Text = Sum9.ToString();
                    e.Row.Cells[15].Text = Sum10.ToString();

                }
            }


            else if (columns == 17)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[5].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[6].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value)
                    {
                        Sum6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption) != DBNull.Value)
                    {
                        Sum7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption) != DBNull.Value)
                    {
                        Sum8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption) != DBNull.Value)
                    {
                        Sum9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption) != DBNull.Value)
                    {
                        Sum10 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[16].Caption) != DBNull.Value)
                    {
                        Sum11 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[16].Caption));
                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[5].Text = Sum0.ToString();
                    e.Row.Cells[6].Text = Sum1.ToString();
                    e.Row.Cells[7].Text = Sum2.ToString();
                    e.Row.Cells[8].Text = Sum3.ToString();
                    e.Row.Cells[9].Text = Sum4.ToString();
                    e.Row.Cells[10].Text = Sum5.ToString();
                    e.Row.Cells[11].Text = Sum6.ToString();
                    e.Row.Cells[12].Text = Sum7.ToString();
                    e.Row.Cells[13].Text = Sum8.ToString();
                    e.Row.Cells[14].Text = Sum9.ToString();
                    e.Row.Cells[15].Text = Sum10.ToString();
                    e.Row.Cells[16].Text = Sum11.ToString();

                }
            }






































        }
        protected void BytGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            Int32 columns = bytTable.Columns.Count;


            if (columns == 6)
            {
                return;
            }

            else if (columns == 7)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption));
                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[6].Text = Sum0.ToString();

                }
            }

            else if (columns == 8)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption) != DBNull.Value)
                    {

                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption));
                    }



                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[6].Text = Sum0.ToString();
                    e.Row.Cells[7].Text = Sum1.ToString();

                }
            }


            else if (columns == 9)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption) != DBNull.Value)
                    {

                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption));

                    }

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[6].Text = Sum0.ToString();
                    e.Row.Cells[7].Text = Sum1.ToString();
                    e.Row.Cells[8].Text = Sum2.ToString();

                }
            }


            else if (columns == 10)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption) != DBNull.Value)
                    {

                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));

                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[6].Text = Sum0.ToString();
                    e.Row.Cells[7].Text = Sum1.ToString();
                    e.Row.Cells[8].Text = Sum2.ToString();
                    e.Row.Cells[9].Text = Sum3.ToString();

                }
            }


            else if (columns == 11)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption) != DBNull.Value)
                    {

                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));

                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[6].Text = Sum0.ToString();
                    e.Row.Cells[7].Text = Sum1.ToString();
                    e.Row.Cells[8].Text = Sum2.ToString();
                    e.Row.Cells[9].Text = Sum3.ToString();
                    e.Row.Cells[10].Text = Sum4.ToString();

                }
            }

            else if (columns == 12)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption) != DBNull.Value)
                    {

                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value)
                    {
                        Sum5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[6].Text = Sum0.ToString();
                    e.Row.Cells[7].Text = Sum1.ToString();
                    e.Row.Cells[8].Text = Sum2.ToString();
                    e.Row.Cells[9].Text = Sum3.ToString();
                    e.Row.Cells[10].Text = Sum4.ToString();
                    e.Row.Cells[11].Text = Sum5.ToString();

                }
            }


            else if (columns == 13)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption) != DBNull.Value)
                    {

                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value)
                    {
                        Sum5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value)
                    {
                        Sum6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[6].Text = Sum0.ToString();
                    e.Row.Cells[7].Text = Sum1.ToString();
                    e.Row.Cells[8].Text = Sum2.ToString();
                    e.Row.Cells[9].Text = Sum3.ToString();
                    e.Row.Cells[10].Text = Sum4.ToString();
                    e.Row.Cells[11].Text = Sum5.ToString();
                    e.Row.Cells[12].Text = Sum6.ToString();

                }
            }

            else if (columns == 14)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption) != DBNull.Value)
                    {

                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value)
                    {
                        Sum5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value)
                    {
                        Sum6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                    }

                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption) != DBNull.Value)
                    {
                        Sum7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption));

                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[6].Text = Sum0.ToString();
                    e.Row.Cells[7].Text = Sum1.ToString();
                    e.Row.Cells[8].Text = Sum2.ToString();
                    e.Row.Cells[9].Text = Sum3.ToString();
                    e.Row.Cells[10].Text = Sum4.ToString();
                    e.Row.Cells[11].Text = Sum5.ToString();
                    e.Row.Cells[12].Text = Sum6.ToString();
                    e.Row.Cells[13].Text = Sum7.ToString();

                }
            }

            else if (columns == 15)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption) != DBNull.Value)
                    {

                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value)
                    {
                        Sum5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value)
                    {
                        Sum6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                    }

                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption) != DBNull.Value)
                    {
                        Sum7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption) != DBNull.Value)
                    {
                        Sum8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption));

                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[6].Text = Sum0.ToString();
                    e.Row.Cells[7].Text = Sum1.ToString();
                    e.Row.Cells[8].Text = Sum2.ToString();
                    e.Row.Cells[9].Text = Sum3.ToString();
                    e.Row.Cells[10].Text = Sum4.ToString();
                    e.Row.Cells[11].Text = Sum5.ToString();
                    e.Row.Cells[12].Text = Sum6.ToString();
                    e.Row.Cells[13].Text = Sum7.ToString();
                    e.Row.Cells[14].Text = Sum8.ToString();

                }
            }

            else if (columns == 16)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption) != DBNull.Value)
                    {

                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value)
                    {
                        Sum5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value)
                    {
                        Sum6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                    }

                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption) != DBNull.Value)
                    {
                        Sum7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption) != DBNull.Value)
                    {
                        Sum8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption) != DBNull.Value)
                    {
                        Sum9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption));

                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[6].Text = Sum0.ToString();
                    e.Row.Cells[7].Text = Sum1.ToString();
                    e.Row.Cells[8].Text = Sum2.ToString();
                    e.Row.Cells[9].Text = Sum3.ToString();
                    e.Row.Cells[10].Text = Sum4.ToString();
                    e.Row.Cells[11].Text = Sum5.ToString();
                    e.Row.Cells[12].Text = Sum6.ToString();
                    e.Row.Cells[13].Text = Sum7.ToString();
                    e.Row.Cells[14].Text = Sum8.ToString();
                    e.Row.Cells[15].Text = Sum9.ToString();

                }
            }

            else if (columns == 17)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption) != DBNull.Value)
                    {

                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value)
                    {
                        Sum5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value)
                    {
                        Sum6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                    }

                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption) != DBNull.Value)
                    {
                        Sum7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption) != DBNull.Value)
                    {
                        Sum8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption) != DBNull.Value)
                    {
                        Sum9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption));

                    }

                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption) != DBNull.Value)
                    {
                        Sum10 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption));

                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[6].Text = Sum0.ToString();
                    e.Row.Cells[7].Text = Sum1.ToString();
                    e.Row.Cells[8].Text = Sum2.ToString();
                    e.Row.Cells[9].Text = Sum3.ToString();
                    e.Row.Cells[10].Text = Sum4.ToString();
                    e.Row.Cells[11].Text = Sum5.ToString();
                    e.Row.Cells[12].Text = Sum6.ToString();
                    e.Row.Cells[13].Text = Sum7.ToString();
                    e.Row.Cells[14].Text = Sum8.ToString();
                    e.Row.Cells[15].Text = Sum9.ToString();
                    e.Row.Cells[16].Text = Sum10.ToString();

                }
            }


            else if (columns == 18)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    Sum0 = 0;
                    Sum1 = 0;
                    Sum2 = 0;
                    Sum3 = 0;
                    Sum4 = 0;
                    Sum5 = 0;
                    Sum6 = 0;
                    Sum7 = 0;
                    Sum8 = 0;
                    Sum9 = 0;
                    Sum10 = 0;
                    Sum11 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption) != DBNull.Value)
                    {
                        Sum0 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[6].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption) != DBNull.Value)
                    {

                        Sum1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[7].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption) != DBNull.Value)
                    {
                        Sum2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[8].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value)
                    {
                        Sum3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value)
                    {
                        Sum4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value)
                    {
                        Sum5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value)
                    {
                        Sum6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                    }

                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption) != DBNull.Value)
                    {
                        Sum7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption) != DBNull.Value)
                    {
                        Sum8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption));

                    }
                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption) != DBNull.Value)
                    {
                        Sum9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption));

                    }

                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption) != DBNull.Value)
                    {
                        Sum10 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption));

                    }

                    if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[17].Caption) != DBNull.Value)
                    {
                        Sum11 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[17].Caption));

                    }
                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[6].Text = Sum0.ToString();
                    e.Row.Cells[7].Text = Sum1.ToString();
                    e.Row.Cells[8].Text = Sum2.ToString();
                    e.Row.Cells[9].Text = Sum3.ToString();
                    e.Row.Cells[10].Text = Sum4.ToString();
                    e.Row.Cells[11].Text = Sum5.ToString();
                    e.Row.Cells[12].Text = Sum6.ToString();
                    e.Row.Cells[13].Text = Sum7.ToString();
                    e.Row.Cells[14].Text = Sum8.ToString();
                    e.Row.Cells[15].Text = Sum9.ToString();
                    e.Row.Cells[16].Text = Sum10.ToString();
                    e.Row.Cells[17].Text = Sum11.ToString();

                }
            }

        }


        protected void PromGridView_OnSorting(object sender, GridViewSortEventArgs e)
        {



            //Retrieve the table from the session object.
            DataTable dt = Session["PromTable"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                PromGridView.DataSource = Session["PromTable"];
                PromGridView.DataBind();
            }



        }
        protected void BytGridView_OnSorting(object sender, GridViewSortEventArgs e)
        {



            //Retrieve the table from the session object.
            DataTable dt = Session["BytTable"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                BytGridView.DataSource = Session["BytTable"];
                BytGridView.DataBind();
            }



        }
        private string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }
    }
}
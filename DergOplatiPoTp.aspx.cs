using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sbyt.App_Service;
using Sbyt.Balance_Po_TP;
using Sbyt.LogsManagement;


namespace Sbyt
{
    public partial class DergOplatiPoTP : Page
    {

        #region declaring_variables

        private DataTable promTable = new DataTable();
        private DataTable bytTable = new DataTable();

        private bool promTablesExists = false;
        private bool bytTablesExists = false;

        private decimal itogSumColumn1;
        private decimal itogSumColumn2;
        private decimal itogSumColumn3;
        private decimal itogSumColumn4;
        private decimal itogSumColumn5;
        private decimal itogSumColumn6;
        private decimal itogSumColumn7;
        private decimal itogSumColumn8;
        private decimal itogSumColumn9;
        private decimal itogSumColumn10;
        private decimal itogSumColumn11;
        private decimal itogSumColumn12;

        #endregion

        


        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> promTableNames = new List<string>();
            List<string> bytTableNames = new List<string>();
          

            Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, "***********************************************************************************");
            Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Инициируется отчет по оплатам для '{0}'", Constants.DergResLongName)));

            MyLabel.Visible = false;
           


            #region interval
            //*****************Получение списка таблиц интервалом********************************
            if ((Session["FromMonth"] != null) && (Session["FromYear"] != null) && (Session["ToMonth"] != null) && (Session["ToYear"] != null))
            {
                string fromMonth = Session["FromMonth"].ToString();
                string fromYear = Session["FromYear"].ToString();
                string toMonth = Session["ToMonth"].ToString();
                string toYear = Session["ToYear"].ToString();

                //получаем список таблиц

                List<string> promTableNamesInterval = TimePeriod.Instance.GetListPromTables(fromMonth, fromYear, toMonth, toYear);



                //Проверили наличие в БД
                foreach (string tableName in promTableNamesInterval)
                {

                    if (ConvertTablesToOra.Instance.IsTableExistInOra(tableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        promTableNames.Add(tableName);
                    }

                }



                List<string> bytTableNamesInterval = TimePeriod.Instance.GetListBytTables(fromMonth, fromYear, toMonth, toYear);

                foreach (string tableName in bytTableNamesInterval)
                {

                    if (ConvertTablesToOra.Instance.IsTableExistInOra(tableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        bytTableNames.Add(tableName);
                    }

                }




            }

                //*************************************************
            #endregion


            else if ((Session["Year1"] != null) && (Session["Month1"] != null))
            {
                string promTableName = "PROM_" + Session["Month1"] + "_" + Session["Year1"];
                string bytTableName = "BYT_" + Session["Month1"] + "_" + Session["Year1"];

                if (ConvertTablesToOra.Instance.IsTableExistInOra(promTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                {
                    promTableNames.Add(promTableName);
                }
                
                if (ConvertTablesToOra.Instance.IsTableExistInOra(bytTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                {
                    bytTableNames.Add(bytTableName);
                }
                
            }

            if ((Session["Year2"] != null) && (Session["Month2"] != null))
            {
                string promTableName = "PROM_" + Session["Month2"] + "_" + Session["Year2"];
                string bytTableName = "BYT_" + Session["Month2"] + "_" + Session["Year2"];

                if (!promTableNames.Contains(promTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(promTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        promTableNames.Add(promTableName);
                    }
                   
                }

                if (!bytTableNames.Contains(bytTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(bytTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        bytTableNames.Add(bytTableName);
                    }
                   
                }

            }

            if ((Session["Year3"] != null) && (Session["Month3"] != null))
            {
                string promTableName = "PROM_" + Session["Month3"] + "_" + Session["Year3"];
                string bytTableName = "BYT_" + Session["Month3"] + "_" + Session["Year3"];

                if (!promTableNames.Contains(promTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(promTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        promTableNames.Add(promTableName);
                    }
                    
                }

                if (!bytTableNames.Contains(bytTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(bytTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        bytTableNames.Add(bytTableName);
                    }
                    
                }
            }

            if ((Session["Year4"] != null) && (Session["Month4"] != null))
            {
                string promTableName = "PROM_" + Session["Month4"] + "_" + Session["Year4"];
                string bytTableName = "BYT_" + Session["Month4"] + "_" + Session["Year4"];

                if (!promTableNames.Contains(promTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(promTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        promTableNames.Add(promTableName);
                    }
                   
                }

                if (!bytTableNames.Contains(bytTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(bytTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        bytTableNames.Add(bytTableName);
                    }
                    
                }
            }

            if ((Session["Year5"] != null) && (Session["Month5"] != null))
            {
                string promTableName = "PROM_" + Session["Month5"] + "_" + Session["Year5"];
                string bytTableName = "BYT_" + Session["Month5"] + "_" + Session["Year5"];

                if (!promTableNames.Contains(promTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(promTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        promTableNames.Add(promTableName);
                    }
                 }

                if (!bytTableNames.Contains(bytTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(bytTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        bytTableNames.Add(bytTableName);
                    }
                    
                }
            }

            if ((Session["Year6"] != null) && (Session["Month6"] != null))
            {
                string promTableName = "PROM_" + Session["Month6"] + "_" + Session["Year6"];
                string bytTableName = "BYT_" + Session["Month6"] + "_" + Session["Year6"];

                if (!promTableNames.Contains(promTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(promTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        promTableNames.Add(promTableName);
                    }
                    
                }

                if (!bytTableNames.Contains(bytTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(bytTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        bytTableNames.Add(bytTableName);
                    }
                }
            }


            if ((Session["Year7"] != null) && (Session["Month7"] != null))
            {
                string promTableName = "PROM_" + Session["Month7"] + "_" + Session["Year7"];
                string bytTableName = "BYT_" + Session["Month7"] + "_" + Session["Year7"];

                if (!promTableNames.Contains(promTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(promTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        promTableNames.Add(promTableName);
                    }
                   
                }

                if (!bytTableNames.Contains(bytTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(bytTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        bytTableNames.Add(bytTableName);
                    }
                   
                }

            }

            if ((Session["Year8"] != null) && (Session["Month8"] != null))
            {
                string promTableName = "PROM_" + Session["Month8"] + "_" + Session["Year8"];
                string bytTableName = "BYT_" + Session["Month8"] + "_" + Session["Year8"];

                if (!promTableNames.Contains(promTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(promTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        promTableNames.Add(promTableName);
                    }
                }

                if (!bytTableNames.Contains(bytTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(bytTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        bytTableNames.Add(bytTableName);
                    }
                 }

            }


            if ((Session["Year9"] != null) && (Session["Month9"] != null))
            {
                string promTableName = "PROM_" + Session["Month9"] + "_" + Session["Year9"];
                string bytTableName = "BYT_" + Session["Month9"] + "_" + Session["Year9"];

                if (!promTableNames.Contains(promTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(promTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        promTableNames.Add(promTableName);
                    }
                }

                if (!bytTableNames.Contains(bytTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(bytTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        bytTableNames.Add(bytTableName);
                    }
                 }

            }

            if ((Session["Year10"] != null) && (Session["Month10"] != null))
            {
                string promTableName = "PROM_" + Session["Month10"] + "_" + Session["Year10"];
                string bytTableName = "BYT_" + Session["Month10"] + "_" + Session["Year10"];

                if (!promTableNames.Contains(promTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(promTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        promTableNames.Add(promTableName);
                    }
                }

                if (!bytTableNames.Contains(bytTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(bytTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        bytTableNames.Add(bytTableName);
                    }
                }

            }

            if ((Session["Year11"] != null) && (Session["Month11"] != null))
            {
                string promTableName = "PROM_" + Session["Month11"] + "_" + Session["Year11"];
                string bytTableName = "BYT_" + Session["Month11"] + "_" + Session["Year11"];

                if (!promTableNames.Contains(promTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(promTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        promTableNames.Add(promTableName);
                    }
                 }

                if (!bytTableNames.Contains(bytTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(bytTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        bytTableNames.Add(bytTableName);
                    }
                 }

            }


            if ((Session["Year12"] != null) && (Session["Month12"] != null))
            {
                string promTableName = "PROM_" + Session["Month12"] + "_" + Session["Year12"];
                string bytTableName = "BYT_" + Session["Month12"] + "_" + Session["Year12"];

                if (!promTableNames.Contains(promTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(promTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        promTableNames.Add(promTableName);
                    }
                 }

                if (!bytTableNames.Contains(bytTableName))
                {
                    if (ConvertTablesToOra.Instance.IsTableExistInOra(bytTableName, ConfigurationHelper.DergOraConnectionStringBalPoTP))
                    {
                        bytTableNames.Add(bytTableName);
                    }
                }

            }


            PromMonthYearLbl.Text = "Оплаты по ТП-" + Request.QueryString["DOC_NAME"] + " промышленных потребителей";
            BytMonthYearLbl.Text = "Оплаты по ТП-" + Request.QueryString["DOC_NAME"] + " бытовых потребителей";

            if ((promTableNames.Count > 0) && (promTableNames.Count <= Constants.PromBytTablesCount))
            {
                promTablesExists = true;
                //Формируем колонки  GridView для промышленных потребителей
                PromGridView.Columns.Clear();

                BoundField kp = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("KP", "№ дог.");
                PromGridView.Columns.Add(kp);

                BoundField n1 = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("N1", "Плательщик");
                PromGridView.Columns.Add(n1);

                BoundField n2 = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("N2", "Абонент");
                PromGridView.Columns.Add(n2);

                BoundField n3 = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("N3", "Точка учета");
                PromGridView.Columns.Add(n3);

                BoundField nst = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("NST", "№ сч-ка");
                PromGridView.Columns.Add(nst);

                BoundField tipsch = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("TIPSCH", "Тип сч-ка");
                PromGridView.Columns.Add(tipsch);

                BoundField tpok = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("TPOK", "Тек. пок-я");
                PromGridView.Columns.Add(tpok);

                BoundField ktt = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("KTT", "Коэфф. тр-ра тока");
                PromGridView.Columns.Add(ktt);


                for (int i = 0; i < promTableNames.Count; i++)
                {
                    BoundField monthYear = CreatingWebControlsParts.Instance.CreateOplatiGridViewColumn("Month" + (i + 1) + "Oplata", promTableNames[i]);
                    PromGridView.Columns.Add(monthYear);
                }

                promTable = OracleOplati.Instance.GetOplatiTablePromTP(promTableNames, ConfigurationHelper.DergOraConnectionStringBalPoTP, Request.QueryString["DOC_CODE"]);

              //  promTable =
             // OracleOplati.Instance.PromGetOraTable(OracleOplati.Instance.FormSqlProm(promTableNames, Request.QueryString["DOC_CODE"]), ConfigurationHelper.DergOraConnectionStringBalPoTP, Constants.DergResLongName);
                PromGridView.DataSource = promTable;
                PromGridView.DataBind();
           //    Session[promGuid] = promTable;

            }
           

            promTableNames.Clear();


            if ((bytTableNames.Count > 0) && (bytTableNames.Count <= Constants.PromBytTablesCount))
            {
                bytTablesExists = true;
                //Формируем колонки  GridView для бытовиков
                BytGridView.Columns.Clear();
                
                BoundField abn = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("ABN", "Абон. №");
                BytGridView.Columns.Add(abn);
               

                BoundField fio = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("FIO", "Фамилия");
                BytGridView.Columns.Add(fio);

                BoundField street = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("STREET", "Улица");
                BytGridView.Columns.Add(street);

                BoundField dom = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("DOM", "Дом");
                BytGridView.Columns.Add(dom);

                BoundField korp = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("KORP", "Корпус");
                BytGridView.Columns.Add(korp);

                BoundField kvar = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("KVAR", "Квартира");
                BytGridView.Columns.Add(kvar);

                BoundField tip = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("TIP", "Тип сч-ка");
                BytGridView.Columns.Add(tip);

                BoundField nomer = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("NOMER", "№ сч-ка");
                BytGridView.Columns.Add(nomer);

                BoundField opokaz = CreatingWebControlsParts.Instance.CreateEtalontGridViewColumn("OPOKAZ", "Посл. показ.");
                BytGridView.Columns.Add(opokaz);


                for (int i = 0; i < bytTableNames.Count; i++)
                {
                    BoundField monthYear = CreatingWebControlsParts.Instance.CreateOplatiGridViewColumn("Month" + (i +1) + "Oplata", bytTableNames[i]);
                    BytGridView.Columns.Add(monthYear);
                }

                 
                bytTable = OracleOplati.Instance.GetOplatiTableBytTP(bytTableNames, ConfigurationHelper.DergOraConnectionStringBalPoTP, Request.QueryString["DOC_NAME"]);

              //  bytTable =
              // OracleOplati.Instance.BytGetOraTable(OracleOplati.Instance.FormSqlByt(bytTableNames, Request.QueryString["DOC_NAME"]), ConfigurationHelper.DergOraConnectionStringBalPoTP, Constants.DergResLongName);
                BytGridView.DataSource = bytTable;
                BytGridView.DataBind();
              //  Session[bytGuid] = bytTable;
               
            }

            bytTableNames.Clear();
            if (bytTablesExists == false && promTablesExists == false)
            {
                MyLabel.Visible = true;
                MyLabel.Text = "Выберите не менее 1-го и не более 12-ти месяцев!!!";
            }
            Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Формирование отчета по оплатам для '{0}' закончено", Constants.DergResLongName)));
            Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, "***********************************************************************************");



        }


        protected void PromGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            Int32 columns = promTable.Columns.Count;


            if (columns == 9)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    itogSumColumn1 = 0;
                    itogSumColumn2 = 0;
                    itogSumColumn3 = 0;
                    itogSumColumn4 = 0;
                    itogSumColumn5 = 0;
                    itogSumColumn6 = 0;
                    itogSumColumn7 = 0;
                    itogSumColumn8 = 0;
                    itogSumColumn9 = 0;
                    itogSumColumn10 = 0;
                    itogSumColumn11 = 0;
                    itogSumColumn12 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[8].Text = itogSumColumn1.ToString();


                }
            }


            else if (columns == 10)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    itogSumColumn1 = 0;
                    itogSumColumn2 = 0;
                    itogSumColumn3 = 0;
                    itogSumColumn4 = 0;
                    itogSumColumn5 = 0;
                    itogSumColumn6 = 0;
                    itogSumColumn7 = 0;
                    itogSumColumn8 = 0;
                    itogSumColumn9 = 0;
                    itogSumColumn10 = 0;
                    itogSumColumn11 = 0;
                    itogSumColumn12 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[8].Text = itogSumColumn1.ToString();
                    e.Row.Cells[9].Text = itogSumColumn2.ToString();

                }
            }


            else if (columns == 11)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    itogSumColumn1 = 0;
                    itogSumColumn2 = 0;
                    itogSumColumn3 = 0;
                    itogSumColumn4 = 0;
                    itogSumColumn5 = 0;
                    itogSumColumn6 = 0;
                    itogSumColumn7 = 0;
                    itogSumColumn8 = 0;
                    itogSumColumn9 = 0;
                    itogSumColumn10 = 0;
                    itogSumColumn11 = 0;
                    itogSumColumn12 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[8].Text = itogSumColumn1.ToString();
                    e.Row.Cells[9].Text = itogSumColumn2.ToString();
                    e.Row.Cells[10].Text = itogSumColumn3.ToString();

                }
            }


            else if (columns == 12)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    itogSumColumn1 = 0;
                    itogSumColumn2 = 0;
                    itogSumColumn3 = 0;
                    itogSumColumn4 = 0;
                    itogSumColumn5 = 0;
                    itogSumColumn6 = 0;
                    itogSumColumn7 = 0;
                    itogSumColumn8 = 0;
                    itogSumColumn9 = 0;
                    itogSumColumn10 = 0;
                    itogSumColumn11 = 0;
                    itogSumColumn12 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[8].Text = itogSumColumn1.ToString();
                    e.Row.Cells[9].Text = itogSumColumn2.ToString();
                    e.Row.Cells[10].Text = itogSumColumn3.ToString();
                    e.Row.Cells[11].Text = itogSumColumn4.ToString();

                }
            }

            else if (columns == 13)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    itogSumColumn1 = 0;
                    itogSumColumn2 = 0;
                    itogSumColumn3 = 0;
                    itogSumColumn4 = 0;
                    itogSumColumn5 = 0;
                    itogSumColumn6 = 0;
                    itogSumColumn7 = 0;
                    itogSumColumn8 = 0;
                    itogSumColumn9 = 0;
                    itogSumColumn10 = 0;
                    itogSumColumn11 = 0;
                    itogSumColumn12 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption));
                    }

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[8].Text = itogSumColumn1.ToString();
                    e.Row.Cells[9].Text = itogSumColumn2.ToString();
                    e.Row.Cells[10].Text = itogSumColumn3.ToString();
                    e.Row.Cells[11].Text = itogSumColumn4.ToString();
                    e.Row.Cells[12].Text = itogSumColumn5.ToString();

                }
            }


            else if (columns == 14)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    itogSumColumn1 = 0;
                    itogSumColumn2 = 0;
                    itogSumColumn3 = 0;
                    itogSumColumn4 = 0;
                    itogSumColumn5 = 0;
                    itogSumColumn6 = 0;
                    itogSumColumn7 = 0;
                    itogSumColumn8 = 0;
                    itogSumColumn9 = 0;
                    itogSumColumn10 = 0;
                    itogSumColumn11 = 0;
                    itogSumColumn12 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption));
                    }

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";

                    e.Row.Cells[8].Text = itogSumColumn1.ToString();
                    e.Row.Cells[9].Text = itogSumColumn2.ToString();
                    e.Row.Cells[10].Text = itogSumColumn3.ToString();
                    e.Row.Cells[11].Text = itogSumColumn4.ToString();
                    e.Row.Cells[12].Text = itogSumColumn5.ToString();
                    e.Row.Cells[13].Text = itogSumColumn6.ToString();

                }
            }

            else if (columns == 15)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    itogSumColumn1 = 0;
                    itogSumColumn2 = 0;
                    itogSumColumn3 = 0;
                    itogSumColumn4 = 0;
                    itogSumColumn5 = 0;
                    itogSumColumn6 = 0;
                    itogSumColumn7 = 0;
                    itogSumColumn8 = 0;
                    itogSumColumn9 = 0;
                    itogSumColumn10 = 0;
                    itogSumColumn11 = 0;
                    itogSumColumn12 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption));
                    }

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";

                    e.Row.Cells[8].Text = itogSumColumn1.ToString();
                    e.Row.Cells[9].Text = itogSumColumn2.ToString();
                    e.Row.Cells[10].Text = itogSumColumn3.ToString();
                    e.Row.Cells[11].Text = itogSumColumn4.ToString();
                    e.Row.Cells[12].Text = itogSumColumn5.ToString();
                    e.Row.Cells[13].Text = itogSumColumn6.ToString();
                    e.Row.Cells[14].Text = itogSumColumn7.ToString();

                }
            }

            else if (columns == 16)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    itogSumColumn1 = 0;
                    itogSumColumn2 = 0;
                    itogSumColumn3 = 0;
                    itogSumColumn4 = 0;
                    itogSumColumn5 = 0;
                    itogSumColumn6 = 0;
                    itogSumColumn7 = 0;
                    itogSumColumn8 = 0;
                    itogSumColumn9 = 0;
                    itogSumColumn10 = 0;
                    itogSumColumn11 = 0;
                    itogSumColumn12 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption));
                    }

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";
                    e.Row.Cells[8].Text = itogSumColumn1.ToString();
                    e.Row.Cells[9].Text = itogSumColumn2.ToString();
                    e.Row.Cells[10].Text = itogSumColumn3.ToString();
                    e.Row.Cells[11].Text = itogSumColumn4.ToString();
                    e.Row.Cells[12].Text = itogSumColumn5.ToString();
                    e.Row.Cells[13].Text = itogSumColumn6.ToString();
                    e.Row.Cells[14].Text = itogSumColumn7.ToString();
                    e.Row.Cells[15].Text = itogSumColumn8.ToString();

                }
            }

            else if (columns == 17)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    itogSumColumn1 = 0;
                    itogSumColumn2 = 0;
                    itogSumColumn3 = 0;
                    itogSumColumn4 = 0;
                    itogSumColumn5 = 0;
                    itogSumColumn6 = 0;
                    itogSumColumn7 = 0;
                    itogSumColumn8 = 0;
                    itogSumColumn9 = 0;
                    itogSumColumn10 = 0;
                    itogSumColumn11 = 0;
                    itogSumColumn12 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[16].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[16].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[16].Caption));
                    }


                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";

                    e.Row.Cells[8].Text = itogSumColumn1.ToString();
                    e.Row.Cells[9].Text = itogSumColumn2.ToString();
                    e.Row.Cells[10].Text = itogSumColumn3.ToString();
                    e.Row.Cells[11].Text = itogSumColumn4.ToString();
                    e.Row.Cells[12].Text = itogSumColumn5.ToString();
                    e.Row.Cells[13].Text = itogSumColumn6.ToString();
                    e.Row.Cells[14].Text = itogSumColumn7.ToString();
                    e.Row.Cells[15].Text = itogSumColumn8.ToString();
                    e.Row.Cells[16].Text = itogSumColumn9.ToString();

                }
            }

            else if (columns == 18)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    itogSumColumn1 = 0;
                    itogSumColumn2 = 0;
                    itogSumColumn3 = 0;
                    itogSumColumn4 = 0;
                    itogSumColumn5 = 0;
                    itogSumColumn6 = 0;
                    itogSumColumn7 = 0;
                    itogSumColumn8 = 0;
                    itogSumColumn9 = 0;
                    itogSumColumn10 = 0;
                    itogSumColumn11 = 0;
                    itogSumColumn12 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[16].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[16].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[16].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[17].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[17].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn10 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[17].Caption));
                    }


                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";

                    e.Row.Cells[8].Text = itogSumColumn1.ToString();
                    e.Row.Cells[9].Text = itogSumColumn2.ToString();
                    e.Row.Cells[10].Text = itogSumColumn3.ToString();
                    e.Row.Cells[11].Text = itogSumColumn4.ToString();
                    e.Row.Cells[12].Text = itogSumColumn5.ToString();
                    e.Row.Cells[13].Text = itogSumColumn6.ToString();
                    e.Row.Cells[14].Text = itogSumColumn7.ToString();
                    e.Row.Cells[15].Text = itogSumColumn8.ToString();
                    e.Row.Cells[16].Text = itogSumColumn9.ToString();
                    e.Row.Cells[17].Text = itogSumColumn10.ToString();

                }
            }


            else if (columns == 19)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    itogSumColumn1 = 0;
                    itogSumColumn2 = 0;
                    itogSumColumn3 = 0;
                    itogSumColumn4 = 0;
                    itogSumColumn5 = 0;
                    itogSumColumn6 = 0;
                    itogSumColumn7 = 0;
                    itogSumColumn8 = 0;
                    itogSumColumn9 = 0;
                    itogSumColumn10 = 0;
                    itogSumColumn11 = 0;
                    itogSumColumn12 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[16].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[16].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[16].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[17].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[17].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn10 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[17].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[18].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[18].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn11 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[18].Caption));
                    }

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";

                    e.Row.Cells[8].Text = itogSumColumn1.ToString();
                    e.Row.Cells[9].Text = itogSumColumn2.ToString();
                    e.Row.Cells[10].Text = itogSumColumn3.ToString();
                    e.Row.Cells[11].Text = itogSumColumn4.ToString();
                    e.Row.Cells[12].Text = itogSumColumn5.ToString();
                    e.Row.Cells[13].Text = itogSumColumn6.ToString();
                    e.Row.Cells[14].Text = itogSumColumn7.ToString();
                    e.Row.Cells[15].Text = itogSumColumn8.ToString();
                    e.Row.Cells[16].Text = itogSumColumn9.ToString();
                    e.Row.Cells[17].Text = itogSumColumn10.ToString();
                    e.Row.Cells[18].Text = itogSumColumn11.ToString();



                }
            }

            else if (columns == 20)
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {

                    itogSumColumn1 = 0;
                    itogSumColumn2 = 0;
                    itogSumColumn3 = 0;
                    itogSumColumn4 = 0;
                    itogSumColumn5 = 0;
                    itogSumColumn6 = 0;
                    itogSumColumn7 = 0;
                    itogSumColumn8 = 0;
                    itogSumColumn9 = 0;
                    itogSumColumn10 = 0;
                    itogSumColumn11 = 0;
                    itogSumColumn12 = 0;
                }

                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[8].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[9].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[10].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[11].Caption));
                    }

                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[12].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[13].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[14].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[15].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[16].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[16].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[16].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[17].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[17].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn10 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[17].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[18].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[18].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn11 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[18].Caption));
                    }
                    if (DataBinder.Eval(e.Row.DataItem, promTable.Columns[19].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, promTable.Columns[19].Caption).ToString() != string.Empty)
                    {
                        itogSumColumn12 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, promTable.Columns[19].Caption));
                    }

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Итого: ";

                    e.Row.Cells[8].Text = itogSumColumn1.ToString();
                    e.Row.Cells[9].Text = itogSumColumn2.ToString();
                    e.Row.Cells[10].Text = itogSumColumn3.ToString();
                    e.Row.Cells[11].Text = itogSumColumn4.ToString();
                    e.Row.Cells[12].Text = itogSumColumn5.ToString();
                    e.Row.Cells[13].Text = itogSumColumn6.ToString();
                    e.Row.Cells[14].Text = itogSumColumn7.ToString();
                    e.Row.Cells[15].Text = itogSumColumn8.ToString();
                    e.Row.Cells[16].Text = itogSumColumn9.ToString();
                    e.Row.Cells[17].Text = itogSumColumn10.ToString();
                    e.Row.Cells[18].Text = itogSumColumn11.ToString();
                    e.Row.Cells[19].Text = itogSumColumn12.ToString();



                }
            }
        }
        protected void BytGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Int32 columns = bytTable.Columns.Count;


            switch (columns)
            {
                case 10:
                    if (e.Row.RowType == DataControlRowType.Header)
                    {

                        itogSumColumn1 = 0;
                        itogSumColumn2 = 0;
                        itogSumColumn3 = 0;
                        itogSumColumn4 = 0;
                        itogSumColumn5 = 0;
                        itogSumColumn6 = 0;
                        itogSumColumn7 = 0;
                        itogSumColumn8 = 0;
                        itogSumColumn9 = 0;
                        itogSumColumn10 = 0;
                        itogSumColumn11 = 0;
                        itogSumColumn12 = 0;
                    }

                    else
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));
                            }
                        }

                        else if (e.Row.RowType == DataControlRowType.Footer)
                        {
                            e.Row.Cells[0].Text = "Итого: ";
                            e.Row.Cells[9].Text = itogSumColumn1.ToString();

                        }
                    break;
                case 11:
                    if (e.Row.RowType == DataControlRowType.Header)
                    {

                        itogSumColumn1 = 0;
                        itogSumColumn2 = 0;
                        itogSumColumn3 = 0;
                        itogSumColumn4 = 0;
                        itogSumColumn5 = 0;
                        itogSumColumn6 = 0;
                        itogSumColumn7 = 0;
                        itogSumColumn8 = 0;
                        itogSumColumn9 = 0;
                        itogSumColumn10 = 0;
                        itogSumColumn11 = 0;
                        itogSumColumn12 = 0;
                    }

                    else
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));
                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption).ToString() != String.Empty)
                            {

                                itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));
                            }



                        }

                        else if (e.Row.RowType == DataControlRowType.Footer)
                        {
                            e.Row.Cells[0].Text = "Итого: ";
                            e.Row.Cells[9].Text = itogSumColumn1.ToString();
                            e.Row.Cells[10].Text = itogSumColumn2.ToString();

                        }
                    break;
                case 12:
                    if (e.Row.RowType == DataControlRowType.Header)
                    {

                        itogSumColumn1 = 0;
                        itogSumColumn2 = 0;
                        itogSumColumn3 = 0;
                        itogSumColumn4 = 0;
                        itogSumColumn5 = 0;
                        itogSumColumn6 = 0;
                        itogSumColumn7 = 0;
                        itogSumColumn8 = 0;
                        itogSumColumn9 = 0;
                        itogSumColumn10 = 0;
                        itogSumColumn11 = 0;
                        itogSumColumn12 = 0;
                    }

                    else
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));
                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption).ToString() != String.Empty)
                            {

                                itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));
                            }

                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                            }

                        }

                        else if (e.Row.RowType == DataControlRowType.Footer)
                        {
                            e.Row.Cells[0].Text = "Итого: ";
                            e.Row.Cells[9].Text = itogSumColumn1.ToString();
                            e.Row.Cells[10].Text = itogSumColumn2.ToString();
                            e.Row.Cells[11].Text = itogSumColumn3.ToString();

                        }
                    break;
                case 13:
                    if (e.Row.RowType == DataControlRowType.Header)
                    {

                        itogSumColumn1 = 0;
                        itogSumColumn2 = 0;
                        itogSumColumn3 = 0;
                        itogSumColumn4 = 0;
                        itogSumColumn5 = 0;
                        itogSumColumn6 = 0;
                        itogSumColumn7 = 0;
                        itogSumColumn8 = 0;
                        itogSumColumn9 = 0;
                        itogSumColumn10 = 0;
                        itogSumColumn11 = 0;
                        itogSumColumn12 = 0;
                    }

                    else
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));
                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption).ToString() != String.Empty)
                            {

                                itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));
                            }

                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                            }
                        }

                        else if (e.Row.RowType == DataControlRowType.Footer)
                        {
                            e.Row.Cells[0].Text = "Итого: ";
                            e.Row.Cells[9].Text = itogSumColumn1.ToString();
                            e.Row.Cells[10].Text = itogSumColumn2.ToString();
                            e.Row.Cells[11].Text = itogSumColumn3.ToString();
                            e.Row.Cells[12].Text = itogSumColumn4.ToString();

                        }
                    break;
                case 14:
                    if (e.Row.RowType == DataControlRowType.Header)
                    {

                        itogSumColumn1 = 0;
                        itogSumColumn2 = 0;
                        itogSumColumn3 = 0;
                        itogSumColumn4 = 0;
                        itogSumColumn5 = 0;
                        itogSumColumn6 = 0;
                        itogSumColumn7 = 0;
                        itogSumColumn8 = 0;
                        itogSumColumn9 = 0;
                        itogSumColumn10 = 0;
                        itogSumColumn11 = 0;
                        itogSumColumn12 = 0;
                    }

                    else
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));
                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption).ToString() != String.Empty)
                            {

                                itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));
                            }

                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption));

                            }
                        }

                        else if (e.Row.RowType == DataControlRowType.Footer)
                        {
                            e.Row.Cells[0].Text = "Итого: ";
                            e.Row.Cells[9].Text = itogSumColumn1.ToString();
                            e.Row.Cells[10].Text = itogSumColumn2.ToString();
                            e.Row.Cells[11].Text = itogSumColumn3.ToString();
                            e.Row.Cells[12].Text = itogSumColumn4.ToString();
                            e.Row.Cells[13].Text = itogSumColumn5.ToString();

                        }
                    break;
                case 15:
                    if (e.Row.RowType == DataControlRowType.Header)
                    {

                        itogSumColumn1 = 0;
                        itogSumColumn2 = 0;
                        itogSumColumn3 = 0;
                        itogSumColumn4 = 0;
                        itogSumColumn5 = 0;
                        itogSumColumn6 = 0;
                        itogSumColumn7 = 0;
                        itogSumColumn8 = 0;
                        itogSumColumn9 = 0;
                        itogSumColumn10 = 0;
                        itogSumColumn11 = 0;
                        itogSumColumn12 = 0;
                    }

                    else
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));
                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption).ToString() != String.Empty)
                            {

                                itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));
                            }

                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption));

                            }
                        }

                        else if (e.Row.RowType == DataControlRowType.Footer)
                        {
                            e.Row.Cells[0].Text = "Итого: ";
                            e.Row.Cells[9].Text = itogSumColumn1.ToString();
                            e.Row.Cells[10].Text = itogSumColumn2.ToString();
                            e.Row.Cells[11].Text = itogSumColumn3.ToString();
                            e.Row.Cells[12].Text = itogSumColumn4.ToString();
                            e.Row.Cells[13].Text = itogSumColumn5.ToString();
                            e.Row.Cells[14].Text = itogSumColumn6.ToString();

                        }
                    break;
                case 16:
                    if (e.Row.RowType == DataControlRowType.Header)
                    {

                        itogSumColumn1 = 0;
                        itogSumColumn2 = 0;
                        itogSumColumn3 = 0;
                        itogSumColumn4 = 0;
                        itogSumColumn5 = 0;
                        itogSumColumn6 = 0;
                        itogSumColumn7 = 0;
                        itogSumColumn8 = 0;
                        itogSumColumn9 = 0;
                        itogSumColumn10 = 0;
                        itogSumColumn11 = 0;
                        itogSumColumn12 = 0;
                    }

                    else
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));
                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption).ToString() != String.Empty)
                            {

                                itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));
                            }

                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption));

                            }
                        }

                        else if (e.Row.RowType == DataControlRowType.Footer)
                        {
                            e.Row.Cells[0].Text = "Итого: ";
                            e.Row.Cells[9].Text = itogSumColumn1.ToString();
                            e.Row.Cells[10].Text = itogSumColumn2.ToString();
                            e.Row.Cells[11].Text = itogSumColumn3.ToString();
                            e.Row.Cells[12].Text = itogSumColumn4.ToString();
                            e.Row.Cells[13].Text = itogSumColumn5.ToString();
                            e.Row.Cells[14].Text = itogSumColumn6.ToString();
                            e.Row.Cells[15].Text = itogSumColumn7.ToString();
                        }
                    break;
                case 17:
                    if (e.Row.RowType == DataControlRowType.Header)
                    {

                        itogSumColumn1 = 0;
                        itogSumColumn2 = 0;
                        itogSumColumn3 = 0;
                        itogSumColumn4 = 0;
                        itogSumColumn5 = 0;
                        itogSumColumn6 = 0;
                        itogSumColumn7 = 0;
                        itogSumColumn8 = 0;
                        itogSumColumn9 = 0;
                        itogSumColumn10 = 0;
                        itogSumColumn11 = 0;
                        itogSumColumn12 = 0;
                    }

                    else
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));
                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption).ToString() != String.Empty)
                            {

                                itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));
                            }

                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption));

                            }
                        }

                        else if (e.Row.RowType == DataControlRowType.Footer)
                        {
                            e.Row.Cells[0].Text = "Итого: ";
                            e.Row.Cells[9].Text = itogSumColumn1.ToString();
                            e.Row.Cells[10].Text = itogSumColumn2.ToString();
                            e.Row.Cells[11].Text = itogSumColumn3.ToString();
                            e.Row.Cells[12].Text = itogSumColumn4.ToString();
                            e.Row.Cells[13].Text = itogSumColumn5.ToString();
                            e.Row.Cells[14].Text = itogSumColumn6.ToString();
                            e.Row.Cells[15].Text = itogSumColumn7.ToString();
                            e.Row.Cells[16].Text = itogSumColumn8.ToString();

                        }
                    break;
                case 18:
                    if (e.Row.RowType == DataControlRowType.Header)
                    {

                        itogSumColumn1 = 0;
                        itogSumColumn2 = 0;
                        itogSumColumn3 = 0;
                        itogSumColumn4 = 0;
                        itogSumColumn5 = 0;
                        itogSumColumn6 = 0;
                        itogSumColumn7 = 0;
                        itogSumColumn8 = 0;
                        itogSumColumn9 = 0;
                        itogSumColumn10 = 0;
                        itogSumColumn11 = 0;
                        itogSumColumn12 = 0;
                    }

                    else
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));
                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption).ToString() != String.Empty)
                            {

                                itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));
                            }

                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[17].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[17].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[17].Caption));
                            }
                        }

                        else if (e.Row.RowType == DataControlRowType.Footer)
                        {
                            e.Row.Cells[0].Text = "Итого: ";
                            e.Row.Cells[9].Text = itogSumColumn1.ToString();
                            e.Row.Cells[10].Text = itogSumColumn2.ToString();
                            e.Row.Cells[11].Text = itogSumColumn3.ToString();
                            e.Row.Cells[12].Text = itogSumColumn4.ToString();
                            e.Row.Cells[13].Text = itogSumColumn5.ToString();
                            e.Row.Cells[14].Text = itogSumColumn6.ToString();
                            e.Row.Cells[15].Text = itogSumColumn7.ToString();
                            e.Row.Cells[16].Text = itogSumColumn8.ToString();
                            e.Row.Cells[17].Text = itogSumColumn9.ToString();

                        }
                    break;
                case 19:
                    if (e.Row.RowType == DataControlRowType.Header)
                    {

                        itogSumColumn1 = 0;
                        itogSumColumn2 = 0;
                        itogSumColumn3 = 0;
                        itogSumColumn4 = 0;
                        itogSumColumn5 = 0;
                        itogSumColumn6 = 0;
                        itogSumColumn7 = 0;
                        itogSumColumn8 = 0;
                        itogSumColumn9 = 0;
                        itogSumColumn10 = 0;
                        itogSumColumn11 = 0;
                        itogSumColumn12 = 0;
                    }

                    else
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));
                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption).ToString() != String.Empty)
                            {

                                itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));
                            }

                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[17].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[17].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[17].Caption));
                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[18].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[18].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn10 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[18].Caption));

                            }
                        }

                        else if (e.Row.RowType == DataControlRowType.Footer)
                        {
                            e.Row.Cells[0].Text = "Итого: ";
                            e.Row.Cells[9].Text = itogSumColumn1.ToString();
                            e.Row.Cells[10].Text = itogSumColumn2.ToString();
                            e.Row.Cells[11].Text = itogSumColumn3.ToString();
                            e.Row.Cells[12].Text = itogSumColumn4.ToString();
                            e.Row.Cells[13].Text = itogSumColumn5.ToString();
                            e.Row.Cells[14].Text = itogSumColumn6.ToString();
                            e.Row.Cells[15].Text = itogSumColumn7.ToString();
                            e.Row.Cells[16].Text = itogSumColumn8.ToString();
                            e.Row.Cells[17].Text = itogSumColumn9.ToString();
                            e.Row.Cells[18].Text = itogSumColumn10.ToString();

                        }
                    break;
                case 20:
                    if (e.Row.RowType == DataControlRowType.Header)
                    {

                        itogSumColumn1 = 0;
                        itogSumColumn2 = 0;
                        itogSumColumn3 = 0;
                        itogSumColumn4 = 0;
                        itogSumColumn5 = 0;
                        itogSumColumn6 = 0;
                        itogSumColumn7 = 0;
                        itogSumColumn8 = 0;
                        itogSumColumn9 = 0;
                        itogSumColumn10 = 0;
                        itogSumColumn11 = 0;
                        itogSumColumn12 = 0;
                    }

                    else
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));
                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption).ToString() != String.Empty)
                            {

                                itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));
                            }

                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[17].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[17].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[17].Caption));
                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[18].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[18].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn10 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[18].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[19].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[19].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn11 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[19].Caption));
                            }
                        }

                        else if (e.Row.RowType == DataControlRowType.Footer)
                        {
                            e.Row.Cells[0].Text = "Итого: ";
                            e.Row.Cells[9].Text = itogSumColumn1.ToString();
                            e.Row.Cells[10].Text = itogSumColumn2.ToString();
                            e.Row.Cells[11].Text = itogSumColumn3.ToString();
                            e.Row.Cells[12].Text = itogSumColumn4.ToString();
                            e.Row.Cells[13].Text = itogSumColumn5.ToString();
                            e.Row.Cells[14].Text = itogSumColumn6.ToString();
                            e.Row.Cells[15].Text = itogSumColumn7.ToString();
                            e.Row.Cells[16].Text = itogSumColumn8.ToString();
                            e.Row.Cells[17].Text = itogSumColumn9.ToString();
                            e.Row.Cells[18].Text = itogSumColumn10.ToString();
                            e.Row.Cells[19].Text = itogSumColumn11.ToString();
                        }
                    break;
                case 21:
                    if (e.Row.RowType == DataControlRowType.Header)
                    {

                        itogSumColumn1 = 0;
                        itogSumColumn2 = 0;
                        itogSumColumn3 = 0;
                        itogSumColumn4 = 0;
                        itogSumColumn5 = 0;
                        itogSumColumn6 = 0;
                        itogSumColumn7 = 0;
                        itogSumColumn8 = 0;
                        itogSumColumn9 = 0;
                        itogSumColumn10 = 0;
                        itogSumColumn11 = 0;
                        itogSumColumn12 = 0;
                    }

                    else
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[9].Caption));
                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption).ToString() != String.Empty)
                            {

                                itogSumColumn2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[10].Caption));
                            }

                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[11].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[12].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn5 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[13].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn6 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[14].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn7 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[15].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn8 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[16].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[17].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[17].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn9 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[17].Caption));
                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[18].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[18].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn10 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[18].Caption));

                            }
                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[19].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[19].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn11 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[19].Caption));
                            }

                            if (DataBinder.Eval(e.Row.DataItem, bytTable.Columns[20].Caption) != DBNull.Value && DataBinder.Eval(e.Row.DataItem, bytTable.Columns[20].Caption).ToString() != String.Empty)
                            {
                                itogSumColumn12 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, bytTable.Columns[20].Caption));

                            }
                        }

                        else if (e.Row.RowType == DataControlRowType.Footer)
                        {
                            e.Row.Cells[0].Text = "Итого: ";
                            e.Row.Cells[9].Text = itogSumColumn1.ToString();
                            e.Row.Cells[10].Text = itogSumColumn2.ToString();
                            e.Row.Cells[11].Text = itogSumColumn3.ToString();
                            e.Row.Cells[12].Text = itogSumColumn4.ToString();
                            e.Row.Cells[13].Text = itogSumColumn5.ToString();
                            e.Row.Cells[14].Text = itogSumColumn6.ToString();
                            e.Row.Cells[15].Text = itogSumColumn7.ToString();
                            e.Row.Cells[16].Text = itogSumColumn8.ToString();
                            e.Row.Cells[17].Text = itogSumColumn9.ToString();
                            e.Row.Cells[18].Text = itogSumColumn10.ToString();
                            e.Row.Cells[19].Text = itogSumColumn11.ToString();
                            e.Row.Cells[20].Text = itogSumColumn12.ToString();

                        }
                    break;
            }
        }

        protected void PromGridView_OnSorting(object sender, GridViewSortEventArgs e)
        {



            //Retrieve the table from the session object.
            DataTable dt = promTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                PromGridView.DataSource = dt;
                PromGridView.DataBind();
            }



        }
        protected void BytGridView_OnSorting(object sender, GridViewSortEventArgs e)
        {



            //Retrieve the table from the session object.
            DataTable dt = bytTable;

            if (dt != null)
            {

                //Sort the data.
                
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                BytGridView.DataSource = dt;
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

        protected void PromHyper(object sender, EventArgs e)
        {
           StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);
 
            PromGridView.AllowSorting = PromGridView.AllowPaging = false;
            PromGridView.AutoGenerateSelectButton = false;
            PromGridView.DataBind();
            PromGridView.RenderControl(tw);
            PromGridView.AllowSorting = PromGridView.AllowPaging = true;
            PromGridView.AutoGenerateSelectButton = true;
 
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename="+ "dergProm" + Request.QueryString["DOC_NAME"]+ ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
 
            {
 
                return;
 
                }
        protected void BytHyper(object sender, EventArgs e)
        {
       

            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

         
            BytGridView.AllowSorting = PromGridView.AllowPaging = false;
            BytGridView.AutoGenerateSelectButton = false;
            BytGridView.DataBind();
            BytGridView.RenderControl(tw);
            BytGridView.AllowSorting = PromGridView.AllowPaging = true;
            BytGridView.AutoGenerateSelectButton = true;

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "dergByt" + Request.QueryString["DOC_NAME"] + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();


        }
        
       
    }
}
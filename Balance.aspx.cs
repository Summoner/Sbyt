using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using Sbyt.App_Service;
using Sbyt.LogsManagement;
using Sbyt.Sravnenie;
using System.Text.RegularExpressions;


namespace Sbyt
{
    public partial class Balance : System.Web.UI.Page
    {
        Int32 _kolvoTp;
       
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                ResList.SelectedIndex = 0;
                MyLabel.Visible = false;
                KleckPromResResultLinkButton.Visible = false;
                DergPromResResultLinkButton.Visible = false;
                UzdaPromResResultLinkButton.Visible = false;
                NesvPromResResultLinkButton.Visible = false;
                StolbPromResResultLinkButton.Visible = false;
                               

            }
            else
            {
                MyLabel.Visible = true;



                if (BLL.Instance.IsDigit(TPTextBox.Text))
                {

                    _kolvoTp = Convert.ToInt32(TPTextBox.Text);
                
                    Int32 count = 1;

                  

                    for (Int32 i = 0; i < _kolvoTp; i++)
                    {
                        TextBox txtInput = new TextBox();
                        txtInput.Width = 56;
                        txtInput.ID = count.ToString();

                        Label txtLabel = new Label();
                        txtLabel.Text = "ТП " + count.ToString() + ": ";
                        txtLabel.ForeColor = Color.Blue;
                        txtLabel.Font.Size = 16;

                        Literal literal = new Literal();
                        literal.Text = "<br />";
                        Literal literal1 = new Literal();
                        literal1.Text = "<p>&nbsp;</p>";


                        PlaceHolder1.Controls.Add(literal);
                        PlaceHolder1.Controls.Add(literal1);

                        PlaceHolder1.Controls.Add(txtLabel);
                        PlaceHolder1.Controls.Add(txtInput);

                        PlaceHolder1.Controls.Add(literal);
                        PlaceHolder1.Controls.Add(literal1);
                        count += 1;
                    }

                


                }
                else
                {
                    MyLabel.Text = "Введите количество ТП для линии!!!";
                }

               

            }


        }

        protected void PromResButton_Click(object sender, EventArgs e)
        {
            if (PromResFileUpload1.HasFile)
            {

                String tablename = PromResFileUpload1.FileName;
                
                /*
               switch(ResList.SelectedValue)
               {
                   case Constants.StolbResShortName:
                    tablename = Constants.StolbPromResTable;
                    break;

                   case Constants.UzdaResShortName:
                    tablename = Constants.UzdaPromResTable;
                    break;

                   case Constants.DergResShortName:
                    tablename = Constants.DergPromResTable;
                    break;

                   case Constants.NesvResShortName:
                    tablename = Constants.NesvPromResTable;
                    break;

                   case Constants.KleckResShortName:
                    tablename = Constants.KleckPromResTable;
                    break;

               }
                */
                String fileName = PromResFileUpload1.FileName;
                String savePath = Constants.SavePathForFilesConvert;
               
                savePath += fileName;
                PromResFileUpload1.SaveAs(savePath);

                BLL.Instance.DropOraTable(tablename);
                BLL.Instance.CreateOraTable(BLL.Instance.ConnectToOdbc(fileName), tablename);
                BLL.Instance.FillOracleTable(BLL.Instance.ConnectToOdbc(fileName), tablename);

                MyLabel.Text = "Конвертация файла " + fileName + " закончена!";

            }
            else
            {
                 
                MyLabel.Text = "Выберите файл для конвертации!";
            
            }

        }

        protected void PromResOKKolvoTPButton_Click(object sender, EventArgs e)
        {

            if (TPTextBox.Text == string.Empty)
            {
                MyLabel.Text = "Введите количество и номера ТП!";
            }
            else
            {
                TextBox tBox = new TextBox();
              
                DataTable ResultTable = new DataTable();

                List<TextBox> tBoxList = new List<TextBox>();

                for (Int32 i = 0; i < PlaceHolder1.Controls.Count; i++)
                {

                    if (PlaceHolder1.Controls[i].GetType() == tBox.GetType())
                    {
                        tBoxList.Add((TextBox)PlaceHolder1.Controls[i]);
                    }
                }



                try
                {
                    switch (ResList.SelectedValue.ToString())
                    {
                        case "Stolb":
                            ResultTable = DAL.Instance.GetOraTableByCommand
                               (BLL.Instance.CreateSqlCommandForPromRes(tBoxList, Constants.StolbPromResTable, Constants.StolbTpPref));
                            BLL.Instance.ConvertToXml(ResultTable, Constants.StolbPromResTable);

                            MyLabel.Text = "Формирование результата завершено!";
                             StolbPromResResultLinkButton.Visible = true;
                            break;

                        case "Uzda":
                            ResultTable = DAL.Instance.GetOraTableByCommand
                                (BLL.Instance.CreateSqlCommandForPromRes(tBoxList, Constants.UzdaPromResTable, Constants.UzdaTpPref));
                            BLL.Instance.ConvertToXml(ResultTable, Constants.UzdaPromResTable);

                            MyLabel.Text = "Формирование результата завершено!";
                             UzdaPromResResultLinkButton.Visible = true;
                            break;

                        case "Derg":
                            ResultTable = DAL.Instance.GetOraTableByCommand
                                 (BLL.Instance.CreateSqlCommandForPromRes(tBoxList, Constants.DergPromResTable, Constants.DergTpPref));
                            BLL.Instance.ConvertToXml(ResultTable, Constants.DergPromResTable);

                            MyLabel.Text = "Формирование результата завершено!";
                             DergPromResResultLinkButton.Visible = true;
                            break;

                        case "Nesv":
                            ResultTable = DAL.Instance.GetOraTableByCommand
                                 (BLL.Instance.CreateSqlCommandForPromRes(tBoxList, Constants.NesvPromResTable, Constants.NesvTpPref));
                            BLL.Instance.ConvertToXml(ResultTable, Constants.NesvPromResTable);

                            MyLabel.Text = "Формирование результата завершено!";
                             NesvPromResResultLinkButton.Visible = true;
                            break;

                        case "Kleck":
                            ResultTable = DAL.Instance.GetOraTableByCommand
                                 (BLL.Instance.CreateSqlCommandForPromRes(tBoxList, Constants.KleckPromResTable, Constants.KleckTpPref));
                            BLL.Instance.ConvertToXml(ResultTable, Constants.KleckPromResTable);

                             MyLabel.Text = "Формирование результата завершено!";
                             KleckPromResResultLinkButton.Visible = true;
                            break;

                    }






                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения при выполнении запроса к таблицам PROMRES: '{0}'", ex.ToString())));
                }

               

            }
        }

        protected void KleckPromResResultHyperLink(object sender, EventArgs e)
        {


            BLL.Instance.XmlFileDownload(Constants.KleckPromResTable);
        }

        protected void DergPromResResultHyperLink(object sender, EventArgs e)
        {


            BLL.Instance.XmlFileDownload(Constants.DergPromResTable);
        }

        protected void UzdaPromResResultHyperLink(object sender, EventArgs e)
        {


            BLL.Instance.XmlFileDownload(Constants.UzdaPromResTable);
        }

        protected void NesvPromResResultHyperLink(object sender, EventArgs e)
        {

            BLL.Instance.XmlFileDownload(Constants.NesvPromResTable);
        }

        protected void StolbPromResResultHyperLink(object sender, EventArgs e)
        {
            BLL.Instance.XmlFileDownload(Constants.StolbPromResTable);
        }


       
    }
}
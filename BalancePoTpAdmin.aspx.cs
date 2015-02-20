using System;
using System.Web.UI;
using Sbyt.Balance_Po_TP;
using Sbyt.App_Service;

namespace Sbyt
{
    public partial class BalancePoTpAdmin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyLabel.Visible = false;
            }
            else
            {
                MyLabel.Visible = true;  
                
            }
        }

        protected void ConvertBtnBalpoTp_Click(object sender, EventArgs e)
        {
            if (!FileUploadBalpoTp.HasFile)
            {
                MyLabel.Text = "Выберите файл формата DBF!";
            }
            else if (MonthDropdwn.SelectedValue == "default")
            {
                MyLabel.Text = "Выберите месяц!";
            }

            else if (YearDropDwn.SelectedValue == "default")
            {
                MyLabel.Text = "Выберите год!";
            }

            else
            {
                String savePath = String.Empty;
                String connStr = String.Empty;
                String message = String.Empty;

                switch (ResList.SelectedValue)
                {
                    case "Stolb":
                        {
                            savePath = Constants.SavePathForFilesConvertStolb;
                            connStr = ConfigurationHelper.OdbcConnectionStringStolb;

                        }
                        break;
                    case "Derg":
                        {
                            savePath = Constants.SavePathForFilesConvertDerg;
                            connStr = ConfigurationHelper.OdbcConnectionStringDerg;
                        }
                        break;
                    case "Uzda":
                        {
                            savePath = Constants.SavePathForFilesConvertUzda;
                            connStr = ConfigurationHelper.OdbcConnectionStringUzda;
                        }
                        break;
                    case "Nesv":
                        {
                            savePath = Constants.SavePathForFilesConvertNesv;
                            connStr = ConfigurationHelper.OdbcConnectionStringNesv;
                        }
                        break;
                    case "Kleck":
                        {
                            savePath = Constants.SavePathForFilesConvertKleck;
                            connStr = ConfigurationHelper.OdbcConnectionStringKleck;
                        }
                        break;
                }

       String fileName = BytPromDropDwn1.SelectedValue + "_" +  
                         MonthDropdwn.SelectedValue + "_"  + 
                           YearDropDwn.SelectedValue;

              
                String fileNameWithExtension = FileUploadBalpoTp.FileName;

              
                savePath += fileNameWithExtension;
                FileUploadBalpoTp.SaveAs(savePath);

              message =  ChekODBCColumns.Instance.CheckColumns(fileNameWithExtension, connStr, BytPromDropDwn1.SelectedValue);
              if (message != string.Empty)
              {
                  MyLabel.Text = message;
              }
              else
              {
                  ConvertTablesToOra.Instance.ConvertToOraForBalancePoTp(ResList.SelectedValue, fileName, fileNameWithExtension);

                  MyLabel.Text = "Конвертация файла " + fileName + " закончена!";
              }

            }
        }

        protected void ConvertBtnBalpoTpStreet_Click(object sender, EventArgs e)
        {

            if (!FileUploadBalpoTpStreet.HasFile)
            {
                MyLabel.Text = "Выберите файл формата DBF!";
            }
            
            else
            {
                String savePath = String.Empty;
                String connStr = String.Empty;
                String message = String.Empty;

                switch (ResList.SelectedValue)
                {
                    case "Stolb":
                        {
                            savePath = Constants.SavePathForFilesConvertStolb;
                            connStr = ConfigurationHelper.OdbcConnectionStringStolb;
                        }
                        break;
                    case "Derg":
                        {
                            savePath = Constants.SavePathForFilesConvertDerg;
                            connStr = ConfigurationHelper.OdbcConnectionStringDerg;
                        }
                        break;
                    case "Uzda":
                        {
                            savePath = Constants.SavePathForFilesConvertUzda;
                            connStr = ConfigurationHelper.OdbcConnectionStringUzda;
                        }
                        break;
                    case "Nesv":
                        {
                            savePath = Constants.SavePathForFilesConvertNesv;
                            connStr = ConfigurationHelper.OdbcConnectionStringNesv;
                        }
                        break;
                    case "Kleck":
                        {
                            savePath = Constants.SavePathForFilesConvertKleck;
                            connStr = ConfigurationHelper.OdbcConnectionStringKleck;
                        }
                        break;
                }

                String fileName = "STREET";
                String fileNameWithExtension = fileName + ".dbf";
                savePath += fileNameWithExtension;
                FileUploadBalpoTpStreet.SaveAs(savePath);
                message = ChekODBCColumns.Instance.CheckColumnsStreetOplati(fileNameWithExtension, connStr);
                if (message != string.Empty)
                {
                    MyLabel.Text = message;
                }
                else
                {
                    ConvertTablesToOra.Instance.ConvertToOraForBalancePoTpStreet(ResList.SelectedValue, fileName, fileNameWithExtension);
                    MyLabel.Text = "Конвертация файла " + fileName + " закончена!";
                }

            }

        }
    }
}
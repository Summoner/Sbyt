using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.UI.WebControls;
using Sbyt.App_Service;
using Sbyt.LogsManagement;

namespace Sbyt.Sravnenie
{
    public class BLL
    {


        //Описание инстанса. Он нужен для доступа к методам DAL слоя из BLL слоя
      

        #region Instance
        private BLL() { }

        [ThreadStatic]
        private static BLL _instance;

        public static BLL Instance
        {
            get { return _instance ?? (_instance = new BLL()); }
        }
        #endregion


        public DataTable ConnectToOdbc(String odbcFileName)
        {
           return DAL.Instance.ConnectToODBC(odbcFileName); 
        }

        public void CreateOraTable(DataTable inpDataTable, String tableName)
        {

            try
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



                String commandText = "Create table " + tableName + "(" + text;


              
               
                DAL.Instance.CreateOracleTable(commandText,tableName);



            }

            catch (Exception ex)
            {

                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex))); 

            }


        }

        public void FillOracleTable(DataTable inpTable, String destTableName)
        {

          
            DAL.Instance.FillOraTable(inpTable, destTableName);
        
        }

        public void SbytFormFunction(String selectedResName, String odbcFileName)
        {
            switch (selectedResName)
            {
                case Constants.StolbResShortName:
                    {
                        DataTable stolbSbyt = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.StolbSbytTable);
                        CreateOraTable(stolbSbyt, Constants.StolbSbytTable);
                        FillOracleTable(stolbSbyt, Constants.StolbSbytTable);

                    }
                    break;
                case Constants.UzdaResShortName:
                    {
                        DataTable uzdaSbyt = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.UzdaSbytTable);
                        CreateOraTable(uzdaSbyt, Constants.UzdaSbytTable);
                        FillOracleTable(uzdaSbyt, Constants.UzdaSbytTable);

                    }
                    break;
                case Constants.DergResShortName:
                    {
                        DataTable dergsbyt = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.DergSbytTable);
                        CreateOraTable(dergsbyt, Constants.DergSbytTable);
                        FillOracleTable(dergsbyt, Constants.DergSbytTable);

                    }
                    break;
                case Constants.NesvResShortName:
                    {
                        DataTable nesvsbyt = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.NesvSbytTable);
                        CreateOraTable(nesvsbyt, Constants.NesvSbytTable);
                        FillOracleTable(nesvsbyt, Constants.NesvSbytTable);

                    }
                    break;
                case Constants.KleckResShortName:
                    {
                        DataTable klecksbyt = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.KleckSbytTable);
                        CreateOraTable(klecksbyt, Constants.KleckSbytTable);
                        FillOracleTable(klecksbyt, Constants.KleckSbytTable);

                    }
                    break;
            }
        }

        public void PasportFormFunction(String selectedResName, String odbcFileName)
        {
            switch (selectedResName)
            {
                case Constants.StolbResShortName:
                    {
                        DataTable stolbpasport = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.StolbPasportTable);
                        CreateOraTable(stolbpasport, Constants.StolbPasportTable);
                        FillOracleTable(stolbpasport, Constants.StolbPasportTable);

                    }
                    break;
                case Constants.UzdaResShortName:
                    {
                        DataTable uzdaPasport = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.UzdaPasportTable);
                        CreateOraTable(uzdaPasport, Constants.UzdaPasportTable);
                        FillOracleTable(uzdaPasport, Constants.UzdaPasportTable);

                    }
                    break;
                case Constants.DergResShortName:
                    {
                        DataTable dergpasport = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.DergPasportTable);
                        CreateOraTable(dergpasport, Constants.DergPasportTable);
                        FillOracleTable(dergpasport, Constants.DergPasportTable);

                    }
                    break;
                case Constants.NesvResShortName:
                    {
                        DataTable nesvspasport = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.NesvPasportTable);
                        CreateOraTable(nesvspasport, Constants.NesvPasportTable);
                        FillOracleTable(nesvspasport, Constants.NesvPasportTable);

                    }
                    break;
                case Constants.KleckResShortName:
                    {
                        DataTable kleckpasport = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.KleckPasportTable);
                        CreateOraTable(kleckpasport, Constants.KleckPasportTable);
                        FillOracleTable(kleckpasport, Constants.KleckPasportTable);

                    }
                    break;
            }
        }

        public void StreetFormFunction(String selectedResName, String odbcFileName)
        {
            switch (selectedResName)
            {
                case Constants.StolbResShortName:
                    {
                        DataTable stolbstreet = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.StolbStreet);
                        CreateOraTable(stolbstreet, Constants.StolbStreet);
                        FillOracleTable(stolbstreet, Constants.StolbStreet);

                    }
                    break;
                case Constants.UzdaResShortName:
                    {
                        DataTable uzdastreet = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.UzdaStreet);
                        CreateOraTable(uzdastreet, Constants.UzdaStreet);
                        FillOracleTable(uzdastreet, Constants.UzdaStreet);

                    }
                    break;
                case Constants.DergResShortName:
                    {
                        DataTable dergstreet = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.DergStreet);
                        CreateOraTable(dergstreet, Constants.DergStreet);
                        FillOracleTable(dergstreet, Constants.DergStreet);

                    }
                    break;
                case Constants.NesvResShortName:
                    {
                        DataTable nesvstreet = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.NesvStreet);
                        CreateOraTable(nesvstreet, Constants.NesvStreet);
                        FillOracleTable(nesvstreet, Constants.NesvStreet);

                    }
                    break;
                case Constants.KleckResShortName:
                    {
                        DataTable kleckstreet = ConnectToOdbc(odbcFileName);
                        DropOraTable(Constants.KleckStreet);
                        CreateOraTable(kleckstreet, Constants.KleckStreet);
                        FillOracleTable(kleckstreet, Constants.KleckStreet);

                    }
                    break;
            }
        }

        public void DropOraTable(String tablename)
        {
           
          DAL.Instance.DropOraTable(tablename);
        
        }

        public string CopyFunc(String fileName)
        {

            String savePath = @"D:\temp\";
            String pattern = @"(\.[A-Za-z]+)";
            String ishodnoe;
            String destination;
            String destination_with_extention;
            // Get the name of the file to upload.
           

            // Append the name of the file to upload to the path.
           ishodnoe =  savePath + fileName;

            fileName = Regex.Replace(fileName, pattern, String.Empty);

            destination = Regex.Replace(ishodnoe, pattern, String.Empty);
            destination_with_extention = ishodnoe;


            try
            {
                FileInfo f1 = new FileInfo(ishodnoe);
                f1.CopyTo(destination, true);
                f1.CopyTo(destination_with_extention, true);
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex)));
            }

            return fileName;
                 
            

        }
        
        public void DergReportView()
        {
            DataTable dergResult = DAL.Instance.CreateOraTablesGetDataForCompare(Constants.DergResShortName);
            ConvertToXml(dergResult, Constants.DergResultFileName);
        }
       
        public void StolbReportView()
        {
            DataTable stolbResult = DAL.Instance.CreateOraTablesGetDataForCompare(Constants.StolbResShortName);
            ConvertToXml(stolbResult, Constants.StolbResultFileName);
        }
        
        public void NesvReportView()
        {
                DataTable nesvResult = DAL.Instance.CreateOraTablesGetDataForCompare(Constants.NesvResShortName);
                ConvertToXml(nesvResult, Constants.NesvResultFileName);
        }

        public void UzdaReportView()
        {

            DataTable uzdaResult = DAL.Instance.CreateOraTablesGetDataForCompare(Constants.UzdaResShortName);
            ConvertToXml(uzdaResult, Constants.UzdaResultFileName);
           
        }
       
        public void KleckReportView()
        {
          DataTable kleckResult =   DAL.Instance.CreateOraTablesGetDataForCompare(Constants.KleckResShortName);
          ConvertToXml(kleckResult, Constants.KleckResultFileName);
        }

        public void ConvertToXml(DataTable tablename,String resultFileName)
        {

            tablename.TableName = "ResultTable";
            tablename.WriteXml(Constants.FilePath + resultFileName + ".xml");

        //    ResultFileName = ResulFileName + ".xml";
        
        }

        public void XmlFileDownload(String fName)
        {

            // Stream data directly to website user
            string sFileName = Constants.FilePath + fName + ".xml";
            FileStream liveStream = new FileStream(sFileName, FileMode.Open, FileAccess.Read);

            byte[] buffer = new byte[(int)liveStream.Length];
            liveStream.Read(buffer, 0, (int)liveStream.Length);
            liveStream.Close();

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AddHeader("Content-Length", buffer.Length.ToString());
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fName + ".xml");
            HttpContext.Current.Response.BinaryWrite(buffer);
            HttpContext.Current.Response.End();
        
        
        
        
        }

        public  bool IsExistFileOnWebServer(String fileName)
        {
            String file = Constants.FilePath + fileName + ".xml";
            if (File.Exists(file))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
        public  bool IsDigit(String inputExpression)
        {
            String pattern = "^[0-9]*$";
            if (String.IsNullOrEmpty(inputExpression))
                return false;
                    else
                return
            Regex.IsMatch(inputExpression, pattern);
       
          
        }

        public string CreateSqlCommandForPromRes(List<TextBox> listtBox, String tableName, String tpPref)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(String.Format("select * from {0} where ",tableName));

            int i = 0;
            foreach (TextBox tb in listtBox)
            {
                if (i > 0)
                {
                    builder.Append("or");
                }

                builder.Append(String.Format(" kodtp = '{0}{1}' ", tpPref,tb.Text));
                if (i == 0)
                {
                    i++;
                }
            }
            return builder.ToString();        
        }
    }
}
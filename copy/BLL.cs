using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using MyXls;


namespace Sbyt
{
    public class BLL
    {
        public BLL()
        { 
        
        }
        public static String FilePath = "D:/SBYT/DOWNLOAD/";
        public static String StolbResultFileName = "STOLBRESULT";
        public static String DergResultFileName = "DERGRESULT";
        public static String NesvResultFileName = "NESVRESULT";
        public static String UzdaResultFileName = "UZDARESULT";
        public static String KleckResultFileName = "KLECKRESULT";


        public DataTable ConnectToOdbc(String ODBCFileName)
        {
            DAL ODBCObj = new DAL();
           DataTable ODBCResult = new DataTable();
           return ODBCResult = ODBCObj.ConnectToODBC(ODBCFileName); 
        }

        public void CreateOraTable(DataTable inp_DataTable, String TableName)
        {

            try
            {
                String CommandText;
                String text = "";
                for (int i = 0; i < inp_DataTable.Columns.Count; i++)
                {

                    if (i != inp_DataTable.Columns.Count - 1)
                    {
                        text += inp_DataTable.Columns[i].ColumnName.ToString() + " Varchar(50), ";
                    }
                    else
                    {
                        text += inp_DataTable.Columns[i].ColumnName.ToString() + " Varchar(50)) ";
                    }
                }



                CommandText = "Create table " + TableName + "(" + text;


                DAL Oraobj = new DAL();
               
                Oraobj.CreateOracleTable(CommandText);



            }

            catch (Exception ex)
            {

                

            }


        }

        public void FillOracleTable(DataTable inp_Table, string DestTableName)
        {

            DAL FillOraObj = new DAL();
            FillOraObj.FillOraTable(inp_Table, DestTableName);
        
        }

        public void SbytFormFunction(String SelectedResName, String ODBCFileName)
        {
            if (SelectedResName == "Stolb")
            {
                DataTable StolbSbyt = new DataTable();
                StolbSbyt = ConnectToOdbc(ODBCFileName);
                DropOraTable("Stolbsbyt");
                CreateOraTable(StolbSbyt, "Stolbsbyt");
                FillOracleTable(StolbSbyt, "Stolbsbyt");

            }
            else
                if (SelectedResName == "Uzda")
                {
                    DataTable UzdaSbyt = new DataTable();
                    UzdaSbyt = ConnectToOdbc(ODBCFileName);
                    DropOraTable("Uzdasbyt");
                    CreateOraTable(UzdaSbyt, "Uzdasbyt");
                    FillOracleTable(UzdaSbyt, "Uzdasbyt");

                }
                else
                    if (SelectedResName == "Derg")
                    {
                        DataTable Dergsbyt = new DataTable();
                        Dergsbyt = ConnectToOdbc(ODBCFileName);
                        DropOraTable("Dergsbyt");
                        CreateOraTable(Dergsbyt, "Dergsbyt");
                        FillOracleTable(Dergsbyt, "Dergsbyt");

                    }
                    else
                        if (SelectedResName == "Nesv")
                        {
                            DataTable Nesvsbyt = new DataTable();
                            Nesvsbyt = ConnectToOdbc(ODBCFileName);
                            DropOraTable("Nesvsbyt");
                            CreateOraTable(Nesvsbyt, "Nesvsbyt");
                            FillOracleTable(Nesvsbyt, "Nesvsbyt");

                        }
                        else
                            if (SelectedResName == "Kleck")
                            {
                                DataTable Klecksbyt = new DataTable();
                                Klecksbyt = ConnectToOdbc(ODBCFileName);
                                DropOraTable("Klecksbyt");
                                CreateOraTable(Klecksbyt, "Klecksbyt");
                                FillOracleTable(Klecksbyt, "Klecksbyt");

                            }
 
        
        }


        public void PasportFormFunction(String SelectedResName, String ODBCFileName)
        {
            if (SelectedResName == "Stolb")
            {
                DataTable Stolbpasport = new DataTable();
                Stolbpasport = ConnectToOdbc(ODBCFileName);
                DropOraTable("Stolbpasport");
                CreateOraTable(Stolbpasport, "Stolbpasport");
                FillOracleTable(Stolbpasport, "Stolbpasport");

            }
            else
                if (SelectedResName == "Uzda")
                {
                    DataTable UzdaPasport = new DataTable();
                    UzdaPasport = ConnectToOdbc(ODBCFileName);
                    DropOraTable("Uzdapasport");
                    CreateOraTable(UzdaPasport, "Uzdapasport");
                    FillOracleTable(UzdaPasport, "Uzdapasport");

                }
                else
                    if (SelectedResName == "Derg")
                    {
                        DataTable Dergpasport = new DataTable();
                        Dergpasport = ConnectToOdbc(ODBCFileName);
                        DropOraTable("Dergpasport");
                        CreateOraTable(Dergpasport, "Dergpasport");
                        FillOracleTable(Dergpasport, "Dergpasport");

                    }
                    else
                        if (SelectedResName == "Nesv")
                        {
                            DataTable Nesvspasport = new DataTable();
                            Nesvspasport = ConnectToOdbc(ODBCFileName);
                            DropOraTable("Nesvspasport");
                            CreateOraTable(Nesvspasport, "Nesvpasport");
                            FillOracleTable(Nesvspasport, "Nesvpasport");

                        }
                        else
                            if (SelectedResName == "Kleck")
                            {
                                DataTable Kleckpasport = new DataTable();
                                Kleckpasport = ConnectToOdbc(ODBCFileName);
                                DropOraTable("Kleckpasport");
                                CreateOraTable(Kleckpasport, "Kleckpasport");
                                FillOracleTable(Kleckpasport, "Kleckpasport");

                            }


        }



        public void StreetFormFunction(String SelectedResName, String ODBCFileName)
        {
            if (SelectedResName == "Stolb")
            {
                DataTable Stolbstreet = new DataTable();
                Stolbstreet = ConnectToOdbc(ODBCFileName);
                DropOraTable("Stolbstreet");
                CreateOraTable(Stolbstreet, "Stolbstreet");
                FillOracleTable(Stolbstreet, "Stolbstreet");

            }
            else
                if (SelectedResName == "Uzda")
                {
                    DataTable Uzdastreet = new DataTable();
                    Uzdastreet = ConnectToOdbc(ODBCFileName);
                    DropOraTable("Uzdastreet");
                    CreateOraTable(Uzdastreet, "Uzdastreet");
                    FillOracleTable(Uzdastreet, "Uzdastreet");

                }
                else
                    if (SelectedResName == "Derg")
                    {
                        DataTable Dergstreet = new DataTable();
                        Dergstreet = ConnectToOdbc(ODBCFileName);
                        DropOraTable("Dergstreet");
                        CreateOraTable(Dergstreet, "Dergstreet");
                        FillOracleTable(Dergstreet, "Dergstreet");

                    }
                    else
                        if (SelectedResName == "Nesv")
                        {
                            DataTable Nesvstreet = new DataTable();
                            Nesvstreet = ConnectToOdbc(ODBCFileName);
                            DropOraTable("Nesvstreet");
                            CreateOraTable(Nesvstreet, "Nesvstreet");
                            FillOracleTable(Nesvstreet, "Nesvstreet");

                        }
                        else
                            if (SelectedResName == "Kleck")
                            {
                                DataTable Kleckstreet = new DataTable();
                                Kleckstreet = ConnectToOdbc(ODBCFileName);
                                DropOraTable("Kleckstreet");
                                CreateOraTable(Kleckstreet, "Kleckstreet");
                                FillOracleTable(Kleckstreet, "Kleckstreet");

                            }


        }



        public void DropOraTable(String Tablename)
        {
            DAL obj = new DAL();
            obj.DropOraTable(Tablename);
        
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
            
            
            }

            return fileName;
                 
            

        }

        public void DergReportView()
         {
           StringBuilder SQLtoORA = new StringBuilder();
           StringBuilder SQLtoORA1 = new StringBuilder();
           DAL RepResult = new DAL();
           DAL RepResult1 = new DAL();
           try
           {
               RepResult.DropOraTable("DERGRESULT");
           }
           catch (Exception ex)
           { }
           SQLtoORA.Append("CREATE TABLE DERGRESULT AS ");
           SQLtoORA.Append("select DISTINCT PASPORTA.AB_N AS PASPORT_AB_N,PASPORTA.FIO AS PASPORT_FIO,");
           SQLtoORA.Append("PASPORTA.STREET  AS PASPORT_STREET, PASPORTA.DOM AS PASPORT_DOM, PASPORTA.N_TP AS PASPORT_N_TP,");
           SQLtoORA.Append("PASPORTA.N_VL  AS PASPORT_N_VL,SBYTOVIKI.AB_N AS SBYTOVIKI_AB_N,SBYTOVIKI.FIO AS SBYTOVIKI_FIO,");
           SQLtoORA.Append("SBYTOVIKI.STREET  AS SBYTOVIKI_STREET, SBYTOVIKI.DOM AS SBYTOVIKI_DOM, SBYTOVIKI.PRPLOM AS SBYTOVIKI_N_TP,");
           SQLtoORA.Append("SBYTOVIKI.FIDER  AS SBYTOVIKI_N_VL ");
           SQLtoORA.Append("from (");
           SQLtoORA.Append("SELECT * FROM sbyt.DERGPASPORT  WHERE NOT ");
           SQLtoORA.Append("(sbyt.DERGPASPORT.AB_N = ANY ");
           SQLtoORA.Append("(SELECT sbyt.DERGPASPORT.AB_N ");
           SQLtoORA.Append("FROM sbyt.DERGPASPORT INNER JOIN sbyt.DERGSBYT ON ");
           SQLtoORA.Append("(sbyt.DERGPASPORT.AB_N = sbyt.DERGSBYT.AB_N ");
           SQLtoORA.Append("AND sbyt.DERGPASPORT.STREET = sbyt.DERGSBYT.STREET ");
           SQLtoORA.Append("AND sbyt.DERGPASPORT.DOM = sbyt.DERGSBYT.DOM ");
           SQLtoORA.Append("AND sbyt.DERGPASPORT.N_TP = sbyt.DERGSBYT.PRPLOM");
           SQLtoORA.Append(")");
           SQLtoORA.Append(")");
           SQLtoORA.Append(") )PASPORTA FULL JOIN ");
           SQLtoORA.Append("(SELECT * FROM sbyt.DERGSBYT  WHERE NOT (sbyt.DERGSBYT.AB_N = ANY (SELECT sbyt.DERGSBYT.AB_N ");
           SQLtoORA.Append("FROM sbyt.DERGSBYT INNER JOIN sbyt.DERGPASPORT ON ");
           SQLtoORA.Append("(sbyt.DERGSBYT.AB_N = sbyt.DERGPASPORT.AB_N ");
           SQLtoORA.Append("AND sbyt.DERGSBYT.STREET = sbyt.DERGPASPORT.STREET ");
           SQLtoORA.Append("AND sbyt.DERGSBYT.DOM = sbyt.DERGPASPORT.DOM ");
           SQLtoORA.Append("AND sbyt.DERGSBYT.PRPLOM = sbyt.DERGPASPORT.N_TP)))) SBYTOVIKI ");
           SQLtoORA.Append("ON (PASPORTA.AB_N = SBYTOVIKI.AB_N)");

           SQLtoORA1.Append("SELECT DISTINCT * FROM ( ");
           SQLtoORA1.Append("select DISTINCT PASPORT_AB_N,PASPORT_FIO, ");
           SQLtoORA1.Append("NAIM AS PASPORT_STREET, PASPORT_DOM, PASPORT_N_TP, ");
           SQLtoORA1.Append("PASPORT_N_VL FROM sbyt.dergresult JOIN sbyt.dergstreet ON ");
           SQLtoORA1.Append("(dergresult.pasport_street = dergstreet.nom)) PASPORTA FULL JOIN ");
           SQLtoORA1.Append("(select DISTINCT SBYTOVIKI_AB_N,SBYTOVIKI_FIO, ");
           SQLtoORA1.Append("NAIM AS SBYTOVIKI_STREET, SBYTOVIKI_DOM, SBYTOVIKI_N_TP, ");
           SQLtoORA1.Append("SBYTOVIKI_N_VL FROM sbyt.dergresult JOIN sbyt.dergstreet ON ");
           SQLtoORA1.Append("(dergresult.sbytoviki_street = dergstreet.nom)) SBYTOVIKI ");
           SQLtoORA1.Append("ON (PASPORTA.PASPORT_AB_N = SBYTOVIKI.SBYTOVIKI_AB_N) ");
           SQLtoORA1.Append("Order by PASPORT_DOM  ");
           
            DataTable DergResult = new DataTable();
                              
           RepResult.CreateOracleTable(SQLtoORA.ToString());
           DergResult = RepResult.ResultReport(SQLtoORA1.ToString());
           ConvertToXml(DergResult, DergResultFileName);
        
        
        }

        public void StolbReportView()
        {
            
                StringBuilder SQLtoORA = new StringBuilder();
                StringBuilder SQLtoORA1 = new StringBuilder();
                DAL RepResult = new DAL();
                try
                {
                RepResult.DropOraTable("STOLBRESULT");
                }
                catch (Exception ex)
                { }

                SQLtoORA.Append("CREATE TABLE STOLBRESULT AS ");
                SQLtoORA.Append("select DISTINCT PASPORTA.AB_N AS PASPORT_AB_N,PASPORTA.FIO AS PASPORT_FIO,");
                SQLtoORA.Append("PASPORTA.STREET  AS PASPORT_STREET, PASPORTA.DOM AS PASPORT_DOM, PASPORTA.N_TP AS PASPORT_N_TP,");
                SQLtoORA.Append("PASPORTA.N_VL  AS PASPORT_N_VL,SBYTOVIKI.AB_N AS SBYTOVIKI_AB_N,SBYTOVIKI.FIO AS SBYTOVIKI_FIO,");
                SQLtoORA.Append("SBYTOVIKI.STREET  AS SBYTOVIKI_STREET, SBYTOVIKI.DOM AS SBYTOVIKI_DOM, SBYTOVIKI.PRPLOM AS SBYTOVIKI_N_TP,");
                SQLtoORA.Append("SBYTOVIKI.FIDER  AS SBYTOVIKI_N_VL ");
                SQLtoORA.Append("from (");
                SQLtoORA.Append("SELECT * FROM sbyt.STOLBPASPORT  WHERE NOT ");
                SQLtoORA.Append("(sbyt.STOLBPASPORT.AB_N = ANY ");
                SQLtoORA.Append("(SELECT sbyt.STOLBPASPORT.AB_N ");
                SQLtoORA.Append("FROM sbyt.STOLBPASPORT INNER JOIN sbyt.STOLBSBYT ON ");
                SQLtoORA.Append("(sbyt.STOLBPASPORT.AB_N = sbyt.STOLBSBYT.AB_N ");
                SQLtoORA.Append("AND sbyt.STOLBPASPORT.STREET = sbyt.STOLBSBYT.STREET ");
                SQLtoORA.Append("AND sbyt.STOLBPASPORT.DOM = sbyt.STOLBSBYT.DOM ");
                SQLtoORA.Append("AND sbyt.STOLBPASPORT.N_TP = sbyt.STOLBSBYT.PRPLOM");
                SQLtoORA.Append(")");
                SQLtoORA.Append(")");
                SQLtoORA.Append(") )PASPORTA FULL JOIN ");
                SQLtoORA.Append("(SELECT * FROM sbyt.STOLBSBYT  WHERE NOT (sbyt.STOLBSBYT.AB_N = ANY (SELECT sbyt.STOLBSBYT.AB_N ");
                SQLtoORA.Append("FROM sbyt.STOLBSBYT INNER JOIN sbyt.STOLBPASPORT ON ");
                SQLtoORA.Append("(sbyt.STOLBSBYT.AB_N = sbyt.STOLBPASPORT.AB_N ");
                SQLtoORA.Append("AND sbyt.STOLBSBYT.STREET = sbyt.STOLBPASPORT.STREET ");
                SQLtoORA.Append("AND sbyt.STOLBSBYT.DOM = sbyt.STOLBPASPORT.DOM ");
                SQLtoORA.Append("AND sbyt.STOLBSBYT.PRPLOM = sbyt.STOLBPASPORT.N_TP)))) SBYTOVIKI ");
                SQLtoORA.Append("ON (PASPORTA.AB_N = SBYTOVIKI.AB_N)");

                SQLtoORA1.Append("SELECT DISTINCT * FROM ( ");
                SQLtoORA1.Append("select DISTINCT PASPORT_AB_N,PASPORT_FIO, ");
                SQLtoORA1.Append("NAIM AS PASPORT_STREET, PASPORT_DOM, PASPORT_N_TP, ");
                SQLtoORA1.Append("PASPORT_N_VL FROM sbyt.stolbresult JOIN sbyt.stolbstreet ON ");
                SQLtoORA1.Append("(stolbresult.pasport_street = stolbstreet.nom)) PASPORTA FULL JOIN ");
                SQLtoORA1.Append("(select DISTINCT SBYTOVIKI_AB_N,SBYTOVIKI_FIO, ");
                SQLtoORA1.Append("NAIM AS SBYTOVIKI_STREET, SBYTOVIKI_DOM, SBYTOVIKI_N_TP, ");
                SQLtoORA1.Append("SBYTOVIKI_N_VL FROM sbyt.stolbresult JOIN sbyt.stolbstreet ON ");
                SQLtoORA1.Append("(stolbresult.sbytoviki_street = stolbstreet.nom)) SBYTOVIKI ");
                SQLtoORA1.Append("ON (PASPORTA.PASPORT_AB_N = SBYTOVIKI.SBYTOVIKI_AB_N) ");
                SQLtoORA1.Append("Order by PASPORT_DOM  ");

                DataTable StolbResult = new DataTable();
                RepResult.CreateOracleTable(SQLtoORA.ToString());
                StolbResult = RepResult.ResultReport(SQLtoORA1.ToString());
                ConvertToXml(StolbResult, StolbResultFileName);
            

            


        }

        public void NesvReportView()
        {

            StringBuilder SQLtoORA = new StringBuilder();
            StringBuilder SQLtoORA1 = new StringBuilder();
            DAL RepResult = new DAL();
            try
            {
                RepResult.DropOraTable("NESVRESULT");
            }
            catch (Exception ex)
            { }

            SQLtoORA.Append("CREATE TABLE NESVRESULT AS ");
            SQLtoORA.Append("select DISTINCT PASPORTA.AB_N AS PASPORT_AB_N,PASPORTA.FIO AS PASPORT_FIO,");
            SQLtoORA.Append("PASPORTA.STREET  AS PASPORT_STREET, PASPORTA.DOM AS PASPORT_DOM, PASPORTA.N_TP AS PASPORT_N_TP,");
            SQLtoORA.Append("PASPORTA.N_VL  AS PASPORT_N_VL,SBYTOVIKI.AB_N AS SBYTOVIKI_AB_N,SBYTOVIKI.FIO AS SBYTOVIKI_FIO,");
            SQLtoORA.Append("SBYTOVIKI.STREET  AS SBYTOVIKI_STREET, SBYTOVIKI.DOM AS SBYTOVIKI_DOM, SBYTOVIKI.PRPLOM AS SBYTOVIKI_N_TP,");
            SQLtoORA.Append("SBYTOVIKI.FIDER  AS SBYTOVIKI_N_VL ");
            SQLtoORA.Append("from (");
            SQLtoORA.Append("SELECT * FROM sbyt.NESVPASPORT  WHERE NOT ");
            SQLtoORA.Append("(sbyt.NESVPASPORT.AB_N = ANY ");
            SQLtoORA.Append("(SELECT sbyt.NESVPASPORT.AB_N ");
            SQLtoORA.Append("FROM sbyt.NESVPASPORT INNER JOIN sbyt.NESVSBYT ON ");
            SQLtoORA.Append("(sbyt.NESVPASPORT.AB_N = sbyt.NESVSBYT.AB_N ");
            SQLtoORA.Append("AND sbyt.NESVPASPORT.STREET = sbyt.NESVSBYT.STREET ");
            SQLtoORA.Append("AND sbyt.NESVPASPORT.DOM = sbyt.NESVSBYT.DOM ");
            SQLtoORA.Append("AND sbyt.NESVPASPORT.N_TP = sbyt.NESVSBYT.PRPLOM");
            SQLtoORA.Append(")");
            SQLtoORA.Append(")");
            SQLtoORA.Append(") )PASPORTA FULL JOIN ");
            SQLtoORA.Append("(SELECT * FROM sbyt.NESVSBYT  WHERE NOT (sbyt.NESVSBYT.AB_N = ANY (SELECT sbyt.NESVSBYT.AB_N ");
            SQLtoORA.Append("FROM sbyt.NESVSBYT INNER JOIN sbyt.NESVPASPORT ON ");
            SQLtoORA.Append("(sbyt.NESVSBYT.AB_N = sbyt.NESVPASPORT.AB_N ");
            SQLtoORA.Append("AND sbyt.NESVSBYT.STREET = sbyt.NESVPASPORT.STREET ");
            SQLtoORA.Append("AND sbyt.NESVSBYT.DOM = sbyt.NESVPASPORT.DOM ");
            SQLtoORA.Append("AND sbyt.NESVSBYT.PRPLOM = sbyt.NESVPASPORT.N_TP)))) SBYTOVIKI ");
            SQLtoORA.Append("ON (PASPORTA.AB_N = SBYTOVIKI.AB_N)");

            SQLtoORA1.Append("SELECT DISTINCT * FROM ( ");
            SQLtoORA1.Append("select DISTINCT PASPORT_AB_N,PASPORT_FIO, ");
            SQLtoORA1.Append("NAIM AS PASPORT_STREET, PASPORT_DOM, PASPORT_N_TP, ");
            SQLtoORA1.Append("PASPORT_N_VL FROM sbyt.NESVresult JOIN sbyt.NESVstreet ON ");
            SQLtoORA1.Append("(NESVresult.pasport_street = NESVstreet.nom)) PASPORTA FULL JOIN ");
            SQLtoORA1.Append("(select DISTINCT SBYTOVIKI_AB_N,SBYTOVIKI_FIO, ");
            SQLtoORA1.Append("NAIM AS SBYTOVIKI_STREET, SBYTOVIKI_DOM, SBYTOVIKI_N_TP, ");
            SQLtoORA1.Append("SBYTOVIKI_N_VL FROM sbyt.NESVresult JOIN sbyt.NESVstreet ON ");
            SQLtoORA1.Append("(NESVresult.sbytoviki_street = NESVstreet.nom)) SBYTOVIKI ");
            SQLtoORA1.Append("ON (PASPORTA.PASPORT_AB_N = SBYTOVIKI.SBYTOVIKI_AB_N) ");
            SQLtoORA1.Append("Order by PASPORT_DOM  ");

            DataTable NesvResult = new DataTable();
            RepResult.CreateOracleTable(SQLtoORA.ToString());
            NesvResult = RepResult.ResultReport(SQLtoORA1.ToString());
            ConvertToXml(NesvResult, NesvResultFileName);
            
        }

        public void UzdaReportView()
        {

            StringBuilder SQLtoORA = new StringBuilder();
            StringBuilder SQLtoORA1 = new StringBuilder();
            DAL RepResult = new DAL();
            try
            {
                RepResult.DropOraTable("UZDARESULT");
            }
            catch (Exception ex)
            { }

            SQLtoORA.Append("CREATE TABLE UZDARESULT AS ");
            SQLtoORA.Append("select DISTINCT PASPORTA.AB_N AS PASPORT_AB_N,PASPORTA.FIO AS PASPORT_FIO,");
            SQLtoORA.Append("PASPORTA.STREET  AS PASPORT_STREET, PASPORTA.DOM AS PASPORT_DOM, PASPORTA.N_TP AS PASPORT_N_TP,");
            SQLtoORA.Append("PASPORTA.N_VL  AS PASPORT_N_VL,SBYTOVIKI.AB_N AS SBYTOVIKI_AB_N,SBYTOVIKI.FIO AS SBYTOVIKI_FIO,");
            SQLtoORA.Append("SBYTOVIKI.STREET  AS SBYTOVIKI_STREET, SBYTOVIKI.DOM AS SBYTOVIKI_DOM, SBYTOVIKI.PRPLOM AS SBYTOVIKI_N_TP,");
            SQLtoORA.Append("SBYTOVIKI.FIDER  AS SBYTOVIKI_N_VL ");
            SQLtoORA.Append("from (");
            SQLtoORA.Append("SELECT * FROM sbyt.UZDAPASPORT  WHERE NOT ");
            SQLtoORA.Append("(sbyt.UZDAPASPORT.AB_N = ANY ");
            SQLtoORA.Append("(SELECT sbyt.UZDAPASPORT.AB_N ");
            SQLtoORA.Append("FROM sbyt.UZDAPASPORT INNER JOIN sbyt.UZDASBYT ON ");
            SQLtoORA.Append("(sbyt.UZDAPASPORT.AB_N = sbyt.UZDASBYT.AB_N ");
            SQLtoORA.Append("AND sbyt.UZDAPASPORT.STREET = sbyt.UZDASBYT.STREET ");
            SQLtoORA.Append("AND sbyt.UZDAPASPORT.DOM = sbyt.UZDASBYT.DOM ");
            SQLtoORA.Append("AND sbyt.UZDAPASPORT.N_TP = sbyt.UZDASBYT.PRPLOM");
            SQLtoORA.Append(")");
            SQLtoORA.Append(")");
            SQLtoORA.Append(") )PASPORTA FULL JOIN ");
            SQLtoORA.Append("(SELECT * FROM sbyt.UZDASBYT  WHERE NOT (sbyt.UZDASBYT.AB_N = ANY (SELECT sbyt.UZDASBYT.AB_N ");
            SQLtoORA.Append("FROM sbyt.UZDASBYT INNER JOIN sbyt.UZDAPASPORT ON ");
            SQLtoORA.Append("(sbyt.UZDASBYT.AB_N = sbyt.UZDAPASPORT.AB_N ");
            SQLtoORA.Append("AND sbyt.UZDASBYT.STREET = sbyt.UZDAPASPORT.STREET ");
            SQLtoORA.Append("AND sbyt.UZDASBYT.DOM = sbyt.UZDAPASPORT.DOM ");
            SQLtoORA.Append("AND sbyt.UZDASBYT.PRPLOM = sbyt.UZDAPASPORT.N_TP)))) SBYTOVIKI ");
            SQLtoORA.Append("ON (PASPORTA.AB_N = SBYTOVIKI.AB_N)");

            SQLtoORA1.Append("SELECT DISTINCT * FROM ( ");
            SQLtoORA1.Append("select DISTINCT PASPORT_AB_N,PASPORT_FIO, ");
            SQLtoORA1.Append("NAIM AS PASPORT_STREET, PASPORT_DOM, PASPORT_N_TP, ");
            SQLtoORA1.Append("PASPORT_N_VL FROM sbyt.UZDARESULT JOIN sbyt.uzdastreet ON ");
            SQLtoORA1.Append("(UZDARESULT.pasport_street = uzdastreet.nom)) PASPORTA FULL JOIN ");
            SQLtoORA1.Append("(select DISTINCT SBYTOVIKI_AB_N,SBYTOVIKI_FIO, ");
            SQLtoORA1.Append("NAIM AS SBYTOVIKI_STREET, SBYTOVIKI_DOM, SBYTOVIKI_N_TP, ");
            SQLtoORA1.Append("SBYTOVIKI_N_VL FROM sbyt.UZDARESULT JOIN sbyt.uzdastreet ON ");
            SQLtoORA1.Append("(UZDARESULT.sbytoviki_street = uzdastreet.nom)) SBYTOVIKI ");
            SQLtoORA1.Append("ON (PASPORTA.PASPORT_AB_N = SBYTOVIKI.SBYTOVIKI_AB_N) ");
            SQLtoORA1.Append("Order by PASPORT_DOM  ");

            DataTable UzdaResult = new DataTable();
            RepResult.CreateOracleTable(SQLtoORA.ToString());
            UzdaResult = RepResult.ResultReport(SQLtoORA1.ToString());
           ConvertToXml(UzdaResult, UzdaResultFileName);
           // ConvertToExcel(UzdaResult, UzdaResultFileName);





        }

        public void KleckReportView()
        {

            StringBuilder SQLtoORA = new StringBuilder();
            StringBuilder SQLtoORA1 = new StringBuilder();
            DAL RepResult = new DAL();
            try
            {
                RepResult.DropOraTable("KLECKRESULT");
            }
            catch (Exception ex)
            { }

            SQLtoORA.Append("CREATE TABLE KLECKRESULT AS ");
            SQLtoORA.Append("select DISTINCT PASPORTA.AB_N AS PASPORT_AB_N,PASPORTA.FIO AS PASPORT_FIO,");
            SQLtoORA.Append("PASPORTA.STREET  AS PASPORT_STREET, PASPORTA.DOM AS PASPORT_DOM, PASPORTA.N_TP AS PASPORT_N_TP,");
            SQLtoORA.Append("PASPORTA.N_VL  AS PASPORT_N_VL,SBYTOVIKI.AB_N AS SBYTOVIKI_AB_N,SBYTOVIKI.FIO AS SBYTOVIKI_FIO,");
            SQLtoORA.Append("SBYTOVIKI.STREET  AS SBYTOVIKI_STREET, SBYTOVIKI.DOM AS SBYTOVIKI_DOM, SBYTOVIKI.PRPLOM AS SBYTOVIKI_N_TP,");
            SQLtoORA.Append("SBYTOVIKI.FIDER  AS SBYTOVIKI_N_VL ");
            SQLtoORA.Append("from (");
            SQLtoORA.Append("SELECT * FROM sbyt.KLECKPASPORT  WHERE NOT ");
            SQLtoORA.Append("(sbyt.KLECKPASPORT.AB_N = ANY ");
            SQLtoORA.Append("(SELECT sbyt.KLECKPASPORT.AB_N ");
            SQLtoORA.Append("FROM sbyt.KLECKPASPORT INNER JOIN sbyt.KLECKSBYT ON ");
            SQLtoORA.Append("(sbyt.KLECKPASPORT.AB_N = sbyt.KLECKSBYT.AB_N ");
            SQLtoORA.Append("AND sbyt.KLECKPASPORT.STREET = sbyt.KLECKSBYT.STREET ");
            SQLtoORA.Append("AND sbyt.KLECKPASPORT.DOM = sbyt.KLECKSBYT.DOM ");
            SQLtoORA.Append("AND sbyt.KLECKPASPORT.N_TP = sbyt.KLECKSBYT.PRPLOM");
            SQLtoORA.Append(")");
            SQLtoORA.Append(")");
            SQLtoORA.Append(") )PASPORTA FULL JOIN ");
            SQLtoORA.Append("(SELECT * FROM sbyt.KLECKSBYT  WHERE NOT (sbyt.KLECKSBYT.AB_N = ANY (SELECT sbyt.KLECKSBYT.AB_N ");
            SQLtoORA.Append("FROM sbyt.KLECKSBYT INNER JOIN sbyt.KLECKPASPORT ON ");
            SQLtoORA.Append("(sbyt.KLECKSBYT.AB_N = sbyt.KLECKPASPORT.AB_N ");
            SQLtoORA.Append("AND sbyt.KLECKSBYT.STREET = sbyt.KLECKPASPORT.STREET ");
            SQLtoORA.Append("AND sbyt.KLECKSBYT.DOM = sbyt.KLECKPASPORT.DOM ");
            SQLtoORA.Append("AND sbyt.KLECKSBYT.PRPLOM = sbyt.KLECKPASPORT.N_TP)))) SBYTOVIKI ");
            SQLtoORA.Append("ON (PASPORTA.AB_N = SBYTOVIKI.AB_N)");

            SQLtoORA1.Append("SELECT DISTINCT * FROM ( ");
            SQLtoORA1.Append("select DISTINCT PASPORT_AB_N,PASPORT_FIO, ");
            SQLtoORA1.Append("NAIM AS PASPORT_STREET, PASPORT_DOM, PASPORT_N_TP, ");
            SQLtoORA1.Append("PASPORT_N_VL FROM sbyt.KLECKresult JOIN sbyt.KLECKstreet ON ");
            SQLtoORA1.Append("(KLECKresult.pasport_street = KLECKstreet.nom)) PASPORTA FULL JOIN ");
            SQLtoORA1.Append("(select DISTINCT SBYTOVIKI_AB_N,SBYTOVIKI_FIO, ");
            SQLtoORA1.Append("NAIM AS SBYTOVIKI_STREET, SBYTOVIKI_DOM, SBYTOVIKI_N_TP, ");
            SQLtoORA1.Append("SBYTOVIKI_N_VL FROM sbyt.KLECKresult JOIN sbyt.KLECKstreet ON ");
            SQLtoORA1.Append("(KLECKresult.sbytoviki_street = KLECKstreet.nom)) SBYTOVIKI ");
            SQLtoORA1.Append("ON (PASPORTA.PASPORT_AB_N = SBYTOVIKI.SBYTOVIKI_AB_N) ");
            SQLtoORA1.Append("Order by PASPORT_DOM  ");
            DataTable KleckResult = new DataTable();
            RepResult.CreateOracleTable(SQLtoORA.ToString());
            KleckResult = RepResult.ResultReport(SQLtoORA1.ToString());
            ConvertToXml(KleckResult, KleckResultFileName);
           // ConvertToExcel(KleckResult, KleckResultFileName);





        }
       

        public void ConvertToXml(DataTable Tablename,String ResulFileName)
        {

            Tablename.TableName = "ResultTable";
            Tablename.WriteXml(BLL.FilePath + ResulFileName + ".xml");

        //    ResultFileName = ResulFileName + ".xml";
        
        }

        public void ConvertToExcel(DataTable Tablename, String ResulFileName)
        {
            System.Web.UI.WebControls.DataGrid datagrid =
                    new System.Web.UI.WebControls.DataGrid();
            datagrid.HeaderStyle.Font.Bold = true;
            datagrid.DataSource = Tablename;
            datagrid.DataBind();

            // render the DataGrid control to a file

            using (StreamWriter sw = new StreamWriter(BLL.FilePath + ResulFileName + ".xls"))
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    datagrid.RenderControl(hw);
                }

            }
        }
        
        public void FileDownload(String fName)
        {

            // Stream data directly to website user
            string sFileName = BLL.FilePath + fName + ".xml";
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

        public static bool ExistFile(String fileName)
        {
            String file = BLL.FilePath + fileName + ".xml";
            if (File.Exists(file))
            {
                return true;
            }
            else
            {
                return false;
            }

        }




    }
}
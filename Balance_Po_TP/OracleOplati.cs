using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using Sbyt.App_Service;
using Sbyt.LogsManagement;

namespace Sbyt.Balance_Po_TP
{
    public class OracleOplati
    {
        //Описание инстанса. Он нужен для доступа к методам DAL слоя из BLL слоя
      
        #region Instance
        private OracleOplati() { }

        [ThreadStatic]
        private static OracleOplati _instance;

        public static OracleOplati Instance
        {
            get { return _instance ?? (_instance = new OracleOplati()); }
        }
        #endregion
       
        private  DataTable GetBytOplatiDataTableTP(string tableName, string connectionString, string nameTp)
        {
            DataTable oplatiTable = new DataTable("OplatiTable");
            DataColumn key1 = oplatiTable.Columns.Add("ABN", typeof(string));
            oplatiTable.Columns.Add(tableName, typeof(string));
            
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT " + tableName +".AB_N as abn,");
            sql.Append(tableName + ".KVT as " + tableName);
            sql.Append(" FROM " +tableName);
            sql.Append(" WHERE " + tableName + ".PRPLOM = " + nameTp);
            

            OracleConnection connect = new OracleConnection(connectionString);
            OracleCommand command = new OracleCommand();
            command.CommandText = sql.ToString();
            command.CommandType = CommandType.Text;
            command.Connection = connect;

            OracleDataAdapter oraDa = new OracleDataAdapter(command.CommandText, connect);
            oraDa.Fill(oplatiTable);
            return oplatiTable;


        }
        private  DataTable GetBytFirstDataTableTP(string tableName,string connectionString, string nameTp)
        {
            DataTable oplatiTable = new DataTable("OplatiTable");
            DataColumn key1 = oplatiTable.Columns.Add("ABN", typeof(string));
            oplatiTable.Columns.Add("FIO", typeof(string));
            oplatiTable.Columns.Add("STREET", typeof(string));
            oplatiTable.Columns.Add("DOM", typeof(string));
            oplatiTable.Columns.Add("KORP", typeof(string));
            oplatiTable.Columns.Add("KVAR", typeof(string));
            oplatiTable.Columns.Add("TIP", typeof(string));
            oplatiTable.Columns.Add("NOMER", typeof(string));
            oplatiTable.Columns.Add("OPOKAZ", typeof(string));

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT " + tableName + ".AB_N as abn,");
            sql.Append(tableName + ".FIO as fio,");
            sql.Append("street.naim as street,");
            sql.Append(tableName + ".Dom AS dom,");
            sql.Append(tableName + ".KORP AS korp,");
            sql.Append(tableName + ".KVAR as kvar,");
            sql.Append(tableName + ".TIP as tip,");
            sql.Append(tableName + ".NOMER as nomer,");
            sql.Append(tableName + ".OPOKAZ as opokaz");
            sql.Append(" FROM " + tableName);
            sql.Append(" JOIN ");
            sql.Append(" street ON " + tableName + ".street  = STREET.nom ");
            sql.Append(" WHERE " + tableName + ".PRPLOM = " + nameTp);
           
            OracleConnection connect = new OracleConnection(connectionString);
            OracleCommand command = new OracleCommand();
            command.CommandText = sql.ToString();
            command.CommandType = CommandType.Text;
            command.Connection = connect;

            OracleDataAdapter oraDa = new OracleDataAdapter(command.CommandText, connect);
            oraDa.Fill(oplatiTable);
            return oplatiTable;


        }


        private  DataTable GetPromOplatiDataTableTP(string tableName, string connectionString, string codeTp)
        {
            DataTable oplatiTable = new DataTable("OplatiTable");
            DataColumn key1 = oplatiTable.Columns.Add("KP", typeof(string));
            oplatiTable.Columns.Add("NAB", typeof(string));
            oplatiTable.Columns.Add("KTU", typeof(string));
            oplatiTable.Columns.Add("KODTP", typeof(string));
            oplatiTable.Columns.Add(tableName, typeof(string));

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT "+ tableName +".kp,");
            sql.Append(tableName + ".nab,");
            sql.Append(tableName + ".ktu,");
            sql.Append(tableName + ".kodtp,(");
            sql.Append(tableName + ".otpusk +" + tableName + ".poteri) as " + tableName);
            sql.Append(" FROM " + tableName );
            sql.Append(" WHERE " + tableName + ".kodtp = '" + codeTp + "'");
           
            OracleConnection connect = new OracleConnection(connectionString);
            OracleCommand command = new OracleCommand();
            command.CommandText = sql.ToString();
            command.CommandType = CommandType.Text;
            command.Connection = connect;

            OracleDataAdapter oraDa = new OracleDataAdapter(command.CommandText, connect);
            oraDa.Fill(oplatiTable);
            return oplatiTable;


        }
        private  DataTable GetPromFirstDataTableTP(string tableName,string connectionString, string codeTp)
        {
            DataTable firstTable = new DataTable("FirstTable");
            DataColumn key1 = firstTable.Columns.Add("KP", typeof(string));
            firstTable.Columns.Add("N1", typeof(string));
            firstTable.Columns.Add("NAB", typeof(string));
            firstTable.Columns.Add("N2", typeof(string));
            firstTable.Columns.Add("KTU", typeof(string));
            firstTable.Columns.Add("N3", typeof(string));
            firstTable.Columns.Add("KODTP", typeof(string));
            firstTable.Columns.Add("NST", typeof(string));
            firstTable.Columns.Add("TIPSCH", typeof(string));
            firstTable.Columns.Add("TPOK", typeof(string));
            firstTable.Columns.Add("KTT", typeof(string));


            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT " + tableName + ".kp,");
            sql.Append(tableName + ".n1,");
            sql.Append(tableName + ".nab,");
            sql.Append(tableName + ".n2,");
            sql.Append(tableName + ".ktu,");
            sql.Append(tableName + ".n3,");
            sql.Append(tableName + ".kodtp,");
            sql.Append(tableName + ".NST,");
            sql.Append(tableName + ".TIPSCH,");
            sql.Append(tableName + ".TPOK,");
            sql.Append(tableName + ".KTT");
            sql.Append(" FROM " + tableName);
            sql.Append(" WHERE " + tableName + ".kodtp = '" + codeTp + "'");

            OracleConnection connect = new OracleConnection(connectionString);
            OracleCommand command = new OracleCommand();
            command.CommandText = sql.ToString();
            command.CommandType = CommandType.Text;
            command.Connection = connect;

            OracleDataAdapter oraDa = new OracleDataAdapter(command.CommandText, connect);
            oraDa.Fill(firstTable);
            return firstTable;
        }


        public DataTable GetOplatiTableBytTP(IList<String> bytMonthYearTablesList, string connectionString, string nameTp)
        {
            //Таблица первая в списке для формирования колонок данных
            DataTable firstOplataTable;

            //Таблицы для хранения оплат 
            DataTable month1OplataTable;
            DataTable month2OplataTable;
            DataTable month3OplataTable;
            DataTable month4OplataTable;
            DataTable month5OplataTable;
            DataTable month6OplataTable;
            DataTable month7OplataTable;
            DataTable month8OplataTable;
            DataTable month9OplataTable;
            DataTable month10OplataTable;
            DataTable month11OplataTable;
            DataTable month12OplataTable;


            switch (bytMonthYearTablesList.Count)
            {
                    
                    
                case 1:
                    firstOplataTable = GetBytFirstDataTableTP(bytMonthYearTablesList[0],connectionString, nameTp);
                    month1OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);


                    var query1Month = from firstTable in firstOplataTable.AsEnumerable()
                                      join month1Oplata in month1OplataTable.AsEnumerable()
                                      on firstTable.Field<string>("ABN") equals month1Oplata.Field<string>("ABN") 
                                      
                                      into temp1
                                      from t in temp1.DefaultIfEmpty()
                                      select new 
                                              {
                                                ABN =   firstTable.Field<string>("ABN"),
                                                FIO =   firstTable.Field<string>("FIO"),
                                                STREET =   firstTable.Field<string>("STREET"),
                                                DOM =   firstTable.Field<string>("DOM"),
                                                KORP = firstTable.Field<string>("KORP"),
                                                KVAR =   firstTable.Field<string>("KVAR"),
                                                TIP = firstTable.Field<string>("TIP"),
                                                NOMER = firstTable.Field<string>("NOMER"),
                                                OPOKAZ = firstTable.Field<string>("OPOKAZ"),
                                                month1Oplata = t == null ? string.Empty:t.Field<string>(bytMonthYearTablesList[0])
                                              };

                 DataTable resultMonth1OplataTable = LINQtoDataSetMethods.CopyToDataTable(query1Month);
                 return resultMonth1OplataTable;
                    
                case 2:
                    firstOplataTable = GetBytFirstDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                    month1OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                    month2OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[1], connectionString, nameTp);

                    var query2Month = from firstTable in firstOplataTable.AsEnumerable()
                                      join month1Oplata in month1OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month1Oplata.Field<string>("ABN")
                                      into temp1
                                      from t1 in temp1.DefaultIfEmpty()
                                      join month2Oplata in month2OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month2Oplata.Field<string>("ABN") 
                                      
                                      into temp2
                                      from t2 in temp2.DefaultIfEmpty()
                                      select new
                                      {
                                          ABN = firstTable.Field<string>("ABN"),
                                          FIO = firstTable.Field<string>("FIO"),
                                          STREET = firstTable.Field<string>("STREET"),
                                          DOM = firstTable.Field<string>("DOM"),
                                          KORP = firstTable.Field<string>("KORP"),
                                          KVAR = firstTable.Field<string>("KVAR"),
                                          TIP = firstTable.Field<string>("TIP"),
                                          NOMER = firstTable.Field<string>("NOMER"),
                                          OPOKAZ = firstTable.Field<string>("OPOKAZ"),
                                          month1Oplata = t1 == null ? string.Empty : t1.Field<string>(bytMonthYearTablesList[0]),
                                          month2Oplata = t2 == null ? string.Empty : t2.Field<string>(bytMonthYearTablesList[1])
                                      };
                   DataTable resultMonth2OplataTable = LINQtoDataSetMethods.CopyToDataTable(query2Month);
                   return resultMonth2OplataTable;

                case 3:
                   firstOplataTable = GetBytFirstDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month1OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month2OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[1], connectionString, nameTp);
                   month3OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[2], connectionString, nameTp);

                   var query3Month = from firstTable in firstOplataTable.AsEnumerable()
                                     join month1Oplata in month1OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month1Oplata.Field<string>("ABN")
                                       into temp1
                                     from t1 in temp1.DefaultIfEmpty()
                                     join month2Oplata in month2OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month2Oplata.Field<string>("ABN")
                                       into temp2
                                     from t2 in temp2.DefaultIfEmpty()
                                     join month3Oplata in month3OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month3Oplata.Field<string>("ABN")
                                       into temp3
                                     from t3 in temp3.DefaultIfEmpty()

                                     select new
                                     {
                                         ABN = firstTable.Field<string>("ABN"),
                                         FIO = firstTable.Field<string>("FIO"),
                                         STREET = firstTable.Field<string>("STREET"),
                                         DOM = firstTable.Field<string>("DOM"),
                                         KORP = firstTable.Field<string>("KORP"),
                                         KVAR = firstTable.Field<string>("KVAR"),
                                         TIP = firstTable.Field<string>("TIP"),
                                         NOMER = firstTable.Field<string>("NOMER"),
                                         OPOKAZ = firstTable.Field<string>("OPOKAZ"),
                                         month1Oplata = t1 == null ? string.Empty : t1.Field<string>(bytMonthYearTablesList[0]),
                                         month2Oplata = t2 == null ? string.Empty : t2.Field<string>(bytMonthYearTablesList[1]),
                                         month3Oplata = t3 == null ? string.Empty : t3.Field<string>(bytMonthYearTablesList[2])
                                     };
                   DataTable resultMonth3OplataTable = LINQtoDataSetMethods.CopyToDataTable(query3Month);
                   return resultMonth3OplataTable;

                case 4:
                   firstOplataTable = GetBytFirstDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month1OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month2OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[1], connectionString, nameTp);
                   month3OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[2], connectionString, nameTp);
                   month4OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[3], connectionString, nameTp);

                   var query4Month = from firstTable in firstOplataTable.AsEnumerable()
                                     join month1Oplata in month1OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month1Oplata.Field<string>("ABN")
                                         into temp1
                                     from t1 in temp1.DefaultIfEmpty()
                                     join month2Oplata in month2OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month2Oplata.Field<string>("ABN")
                                         into temp2
                                     from t2 in temp2.DefaultIfEmpty()
                                     join month3Oplata in month3OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month3Oplata.Field<string>("ABN")
                                         into temp3
                                     from t3 in temp3.DefaultIfEmpty()
                                     join month4Oplata in month4OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month4Oplata.Field<string>("ABN")
                                         into temp4
                                     from t4 in temp4.DefaultIfEmpty()

                                     select new
                                     {
                                         ABN = firstTable.Field<string>("ABN"),
                                         FIO = firstTable.Field<string>("FIO"),
                                         STREET = firstTable.Field<string>("STREET"),
                                         DOM = firstTable.Field<string>("DOM"),
                                         KORP = firstTable.Field<string>("KORP"),
                                         KVAR = firstTable.Field<string>("KVAR"),
                                         TIP = firstTable.Field<string>("TIP"),
                                         NOMER = firstTable.Field<string>("NOMER"),
                                         OPOKAZ = firstTable.Field<string>("OPOKAZ"),
                                         month1Oplata = t1 == null ? string.Empty : t1.Field<string>(bytMonthYearTablesList[0]),
                                         month2Oplata = t2 == null ? string.Empty : t2.Field<string>(bytMonthYearTablesList[1]),
                                         month3Oplata = t3 == null ? string.Empty : t3.Field<string>(bytMonthYearTablesList[2]),
                                         month4Oplata = t4 == null ? string.Empty : t4.Field<string>(bytMonthYearTablesList[3])
                                     };
                   DataTable resultMonth4OplataTable = LINQtoDataSetMethods.CopyToDataTable(query4Month);
                   return resultMonth4OplataTable;

                case 5:
                   firstOplataTable = GetBytFirstDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month1OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month2OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[1], connectionString, nameTp);
                   month3OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[2], connectionString, nameTp);
                   month4OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[3], connectionString, nameTp);
                   month5OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[4], connectionString, nameTp);

                   var query5Month = from firstTable in firstOplataTable.AsEnumerable()
                                     join month1Oplata in month1OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month1Oplata.Field<string>("ABN")
                                         into temp1
                                     from t1 in temp1.DefaultIfEmpty()
                                     join month2Oplata in month2OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month2Oplata.Field<string>("ABN")
                                         into temp2
                                     from t2 in temp2.DefaultIfEmpty()
                                     join month3Oplata in month3OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month3Oplata.Field<string>("ABN")
                                         into temp3
                                     from t3 in temp3.DefaultIfEmpty()
                                     join month4Oplata in month4OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month4Oplata.Field<string>("ABN")
                                         into temp4
                                     from t4 in temp4.DefaultIfEmpty()
                                     join month5Oplata in month5OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month5Oplata.Field<string>("ABN")
                                         into temp5
                                     from t5 in temp5.DefaultIfEmpty()

                                     select new
                                     {
                                         ABN = firstTable.Field<string>("ABN"),
                                         FIO = firstTable.Field<string>("FIO"),
                                         STREET = firstTable.Field<string>("STREET"),
                                         DOM = firstTable.Field<string>("DOM"),
                                         KORP = firstTable.Field<string>("KORP"),
                                         KVAR = firstTable.Field<string>("KVAR"),
                                         TIP = firstTable.Field<string>("TIP"),
                                         NOMER = firstTable.Field<string>("NOMER"),
                                         OPOKAZ = firstTable.Field<string>("OPOKAZ"),
                                         month1Oplata = t1 == null ? string.Empty : t1.Field<string>(bytMonthYearTablesList[0]),
                                         month2Oplata = t2 == null ? string.Empty : t2.Field<string>(bytMonthYearTablesList[1]),
                                         month3Oplata = t3 == null ? string.Empty : t3.Field<string>(bytMonthYearTablesList[2]),
                                         month4Oplata = t4 == null ? string.Empty : t4.Field<string>(bytMonthYearTablesList[3]),
                                         month5Oplata = t5 == null ? string.Empty : t5.Field<string>(bytMonthYearTablesList[4])
                                     };
                   DataTable resultMonth5OplataTable = LINQtoDataSetMethods.CopyToDataTable(query5Month);
                   return resultMonth5OplataTable;

                case 6:
                   firstOplataTable = GetBytFirstDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month1OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month2OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[1], connectionString, nameTp);
                   month3OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[2], connectionString, nameTp);
                   month4OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[3], connectionString, nameTp);
                   month5OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[4], connectionString, nameTp);
                   month6OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[5], connectionString, nameTp);

                   var query6Month = from firstTable in firstOplataTable.AsEnumerable()
                                     join month1Oplata in month1OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month1Oplata.Field<string>("ABN")
                                     into temp1
                                     from t1 in temp1.DefaultIfEmpty()
                                     join month2Oplata in month2OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month2Oplata.Field<string>("ABN")
                                     into temp2
                                     from t2 in temp2.DefaultIfEmpty()
                                     join month3Oplata in month3OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month3Oplata.Field<string>("ABN")
                                     into temp3
                                     from t3 in temp3.DefaultIfEmpty()
                                     join month4Oplata in month4OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month4Oplata.Field<string>("ABN")
                                     into temp4
                                     from t4 in temp4.DefaultIfEmpty()
                                     join month5Oplata in month5OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month5Oplata.Field<string>("ABN")
                                     into temp5
                                     from t5 in temp5.DefaultIfEmpty()
                                     join month6Oplata in month6OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month6Oplata.Field<string>("ABN")
                                     into temp6
                                     from t6 in temp6.DefaultIfEmpty()
                                     select new
                                     {
                                         ABN = firstTable.Field<string>("ABN"),
                                         FIO = firstTable.Field<string>("FIO"),
                                         STREET = firstTable.Field<string>("STREET"),
                                         DOM = firstTable.Field<string>("DOM"),
                                         KORP = firstTable.Field<string>("KORP"),
                                         KVAR = firstTable.Field<string>("KVAR"),
                                         TIP = firstTable.Field<string>("TIP"),
                                         NOMER = firstTable.Field<string>("NOMER"),
                                         OPOKAZ = firstTable.Field<string>("OPOKAZ"),
                                         month1Oplata = t1 == null ? string.Empty : t1.Field<string>(bytMonthYearTablesList[0]),
                                         month2Oplata = t2 == null ? string.Empty : t2.Field<string>(bytMonthYearTablesList[1]),
                                         month3Oplata = t3 == null ? string.Empty : t3.Field<string>(bytMonthYearTablesList[2]),
                                         month4Oplata = t4 == null ? string.Empty : t4.Field<string>(bytMonthYearTablesList[3]),
                                         month5Oplata = t5 == null ? string.Empty : t5.Field<string>(bytMonthYearTablesList[4]),
                                         month6Oplata = t6 == null ? string.Empty : t6.Field<string>(bytMonthYearTablesList[5])
                                     };
                   DataTable resultMonth6OplataTable = LINQtoDataSetMethods.CopyToDataTable(query6Month);
                   return resultMonth6OplataTable;

                case 7:
                   firstOplataTable = GetBytFirstDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month1OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month2OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[1], connectionString, nameTp);
                   month3OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[2], connectionString, nameTp);
                   month4OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[3], connectionString, nameTp);
                   month5OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[4], connectionString, nameTp);
                   month6OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[5], connectionString, nameTp);
                   month7OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[6], connectionString, nameTp);

                   var query7Month = from firstTable in firstOplataTable.AsEnumerable()
                                     join month1Oplata in month1OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month1Oplata.Field<string>("ABN")
                                      into temp1
                                     from t1 in temp1.DefaultIfEmpty()
                                     join month2Oplata in month2OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month2Oplata.Field<string>("ABN")
                                      into temp2
                                     from t2 in temp2.DefaultIfEmpty()
                                     join month3Oplata in month3OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month3Oplata.Field<string>("ABN")
                                      into temp3
                                     from t3 in temp3.DefaultIfEmpty()
                                     join month4Oplata in month4OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month4Oplata.Field<string>("ABN")
                                      into temp4
                                     from t4 in temp4.DefaultIfEmpty()
                                     join month5Oplata in month5OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month5Oplata.Field<string>("ABN")
                                      into temp5
                                     from t5 in temp5.DefaultIfEmpty()
                                     join month6Oplata in month6OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month6Oplata.Field<string>("ABN")
                                      into temp6
                                     from t6 in temp6.DefaultIfEmpty()
                                     join month7Oplata in month7OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month7Oplata.Field<string>("ABN")
                                      into temp7
                                     from t7 in temp7.DefaultIfEmpty()
                                     select new
                                     {
                                         ABN = firstTable.Field<string>("ABN"),
                                         FIO = firstTable.Field<string>("FIO"),
                                         STREET = firstTable.Field<string>("STREET"),
                                         DOM = firstTable.Field<string>("DOM"),
                                         KORP = firstTable.Field<string>("KORP"),
                                         KVAR = firstTable.Field<string>("KVAR"),
                                         TIP = firstTable.Field<string>("TIP"),
                                         NOMER = firstTable.Field<string>("NOMER"),
                                         OPOKAZ = firstTable.Field<string>("OPOKAZ"),
                                         month1Oplata = t1 == null ? string.Empty : t1.Field<string>(bytMonthYearTablesList[0]),
                                         month2Oplata = t2 == null ? string.Empty : t2.Field<string>(bytMonthYearTablesList[1]),
                                         month3Oplata = t3 == null ? string.Empty : t3.Field<string>(bytMonthYearTablesList[2]),
                                         month4Oplata = t4 == null ? string.Empty : t4.Field<string>(bytMonthYearTablesList[3]),
                                         month5Oplata = t5 == null ? string.Empty : t5.Field<string>(bytMonthYearTablesList[4]),
                                         month6Oplata = t6 == null ? string.Empty : t6.Field<string>(bytMonthYearTablesList[5]),
                                         month7Oplata = t7 == null ? string.Empty : t7.Field<string>(bytMonthYearTablesList[6])

                                     };
                   DataTable resultMonth7OplataTable = LINQtoDataSetMethods.CopyToDataTable(query7Month);
                   return resultMonth7OplataTable;

                case 8:
                   firstOplataTable = GetBytFirstDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month1OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month2OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[1], connectionString, nameTp);
                   month3OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[2], connectionString, nameTp);
                   month4OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[3], connectionString, nameTp);
                   month5OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[4], connectionString, nameTp);
                   month6OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[5], connectionString, nameTp);
                   month7OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[6], connectionString, nameTp);
                   month8OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[7], connectionString, nameTp);

                   var query8Month = from firstTable in firstOplataTable.AsEnumerable()
                                     join month1Oplata in month1OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month1Oplata.Field<string>("ABN")
                                      into temp1
                                     from t1 in temp1.DefaultIfEmpty()
                                     join month2Oplata in month2OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month2Oplata.Field<string>("ABN")
                                      into temp2
                                     from t2 in temp2.DefaultIfEmpty()
                                     join month3Oplata in month3OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month3Oplata.Field<string>("ABN")
                                      into temp3
                                     from t3 in temp3.DefaultIfEmpty()
                                     join month4Oplata in month4OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month4Oplata.Field<string>("ABN")
                                      into temp4
                                     from t4 in temp4.DefaultIfEmpty()
                                     join month5Oplata in month5OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month5Oplata.Field<string>("ABN")
                                      into temp5
                                     from t5 in temp5.DefaultIfEmpty()
                                     join month6Oplata in month6OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month6Oplata.Field<string>("ABN")
                                      into temp6
                                     from t6 in temp6.DefaultIfEmpty()
                                     join month7Oplata in month7OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month7Oplata.Field<string>("ABN")
                                      into temp7
                                     from t7 in temp7.DefaultIfEmpty()
                                     join month8Oplata in month8OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month8Oplata.Field<string>("ABN")
                                      into temp8
                                     from t8 in temp8.DefaultIfEmpty()
                                     select new
                                     {
                                         ABN = firstTable.Field<string>("ABN"),
                                         FIO = firstTable.Field<string>("FIO"),
                                         STREET = firstTable.Field<string>("STREET"),
                                         DOM = firstTable.Field<string>("DOM"),
                                         KORP = firstTable.Field<string>("KORP"),
                                         KVAR = firstTable.Field<string>("KVAR"),
                                         TIP = firstTable.Field<string>("TIP"),
                                         NOMER = firstTable.Field<string>("NOMER"),
                                         OPOKAZ = firstTable.Field<string>("OPOKAZ"),
                                         month1Oplata = t1 == null ? string.Empty : t1.Field<string>(bytMonthYearTablesList[0]),
                                         month2Oplata = t2 == null ? string.Empty : t2.Field<string>(bytMonthYearTablesList[1]),
                                         month3Oplata = t3 == null ? string.Empty : t3.Field<string>(bytMonthYearTablesList[2]),
                                         month4Oplata = t4 == null ? string.Empty : t4.Field<string>(bytMonthYearTablesList[3]),
                                         month5Oplata = t5 == null ? string.Empty : t5.Field<string>(bytMonthYearTablesList[4]),
                                         month6Oplata = t6 == null ? string.Empty : t6.Field<string>(bytMonthYearTablesList[5]),
                                         month7Oplata = t7 == null ? string.Empty : t7.Field<string>(bytMonthYearTablesList[6]),
                                         month8Oplata = t8 == null ? string.Empty : t8.Field<string>(bytMonthYearTablesList[7])
                                         
                                     };
                   DataTable resultMonth8OplataTable = LINQtoDataSetMethods.CopyToDataTable(query8Month);
                   return resultMonth8OplataTable;

                case 9:
                   firstOplataTable = GetBytFirstDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month1OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month2OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[1], connectionString, nameTp);
                   month3OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[2], connectionString, nameTp);
                   month4OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[3], connectionString, nameTp);
                   month5OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[4], connectionString, nameTp);
                   month6OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[5], connectionString, nameTp);
                   month7OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[6], connectionString, nameTp);
                   month8OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[7], connectionString, nameTp);
                   month9OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[8], connectionString, nameTp);

                   var query9Month = from firstTable in firstOplataTable.AsEnumerable()
                                     join month1Oplata in month1OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month1Oplata.Field<string>("ABN")
                                      into temp1
                                     from t1 in temp1.DefaultIfEmpty()
                                     join month2Oplata in month2OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month2Oplata.Field<string>("ABN")
                                      into temp2
                                     from t2 in temp2.DefaultIfEmpty()
                                     join month3Oplata in month3OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month3Oplata.Field<string>("ABN")
                                      into temp3
                                     from t3 in temp3.DefaultIfEmpty()
                                     join month4Oplata in month4OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month4Oplata.Field<string>("ABN")
                                      into temp4
                                     from t4 in temp4.DefaultIfEmpty()
                                     join month5Oplata in month5OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month5Oplata.Field<string>("ABN")
                                      into temp5
                                     from t5 in temp5.DefaultIfEmpty()
                                     join month6Oplata in month6OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month6Oplata.Field<string>("ABN")
                                      into temp6
                                     from t6 in temp6.DefaultIfEmpty()
                                     join month7Oplata in month7OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month7Oplata.Field<string>("ABN")
                                      into temp7
                                     from t7 in temp7.DefaultIfEmpty()
                                     join month8Oplata in month8OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month8Oplata.Field<string>("ABN")
                                      into temp8
                                     from t8 in temp8.DefaultIfEmpty()
                                     join month9Oplata in month9OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month9Oplata.Field<string>("ABN")
                                      into temp9
                                     from t9 in temp9.DefaultIfEmpty()
                                     select new
                                     {
                                         ABN = firstTable.Field<string>("ABN"),
                                         FIO = firstTable.Field<string>("FIO"),
                                         STREET = firstTable.Field<string>("STREET"),
                                         DOM = firstTable.Field<string>("DOM"),
                                         KORP = firstTable.Field<string>("KORP"),
                                         KVAR = firstTable.Field<string>("KVAR"),
                                         TIP = firstTable.Field<string>("TIP"),
                                         NOMER = firstTable.Field<string>("NOMER"),
                                         OPOKAZ = firstTable.Field<string>("OPOKAZ"),
                                         month1Oplata = t1 == null ? string.Empty : t1.Field<string>(bytMonthYearTablesList[0]),
                                         month2Oplata = t2 == null ? string.Empty : t2.Field<string>(bytMonthYearTablesList[1]),
                                         month3Oplata = t3 == null ? string.Empty : t3.Field<string>(bytMonthYearTablesList[2]),
                                         month4Oplata = t4 == null ? string.Empty : t4.Field<string>(bytMonthYearTablesList[3]),
                                         month5Oplata = t5 == null ? string.Empty : t5.Field<string>(bytMonthYearTablesList[4]),
                                         month6Oplata = t6 == null ? string.Empty : t6.Field<string>(bytMonthYearTablesList[5]),
                                         month7Oplata = t7 == null ? string.Empty : t7.Field<string>(bytMonthYearTablesList[6]),
                                         month8Oplata = t8 == null ? string.Empty : t8.Field<string>(bytMonthYearTablesList[7]),
                                         month9Oplata = t9 == null ? string.Empty : t9.Field<string>(bytMonthYearTablesList[8])

                                     };
                   DataTable resultMonth9OplataTable = LINQtoDataSetMethods.CopyToDataTable(query9Month);
                   return resultMonth9OplataTable;


                case 10:
                   firstOplataTable = GetBytFirstDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month1OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month2OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[1], connectionString, nameTp);
                   month3OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[2], connectionString, nameTp);
                   month4OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[3], connectionString, nameTp);
                   month5OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[4], connectionString, nameTp);
                   month6OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[5], connectionString, nameTp);
                   month7OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[6], connectionString, nameTp);
                   month8OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[7], connectionString, nameTp);
                   month9OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[8], connectionString, nameTp);
                   month10OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[9], connectionString, nameTp);

                   var query10Month = from firstTable in firstOplataTable.AsEnumerable()
                                     join month1Oplata in month1OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month1Oplata.Field<string>("ABN")
                                      into temp1
                                      from t1 in temp1.DefaultIfEmpty()
                                     join month2Oplata in month2OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month2Oplata.Field<string>("ABN")
                                      into temp2
                                      from t2 in temp2.DefaultIfEmpty()
                                     join month3Oplata in month3OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month3Oplata.Field<string>("ABN")
                                      into temp3
                                      from t3 in temp3.DefaultIfEmpty()
                                     join month4Oplata in month4OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month4Oplata.Field<string>("ABN")
                                      into temp4
                                      from t4 in temp4.DefaultIfEmpty()
                                     join month5Oplata in month5OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month5Oplata.Field<string>("ABN")
                                      into temp5
                                      from t5 in temp5.DefaultIfEmpty()
                                     join month6Oplata in month6OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month6Oplata.Field<string>("ABN")
                                      into temp6
                                      from t6 in temp6.DefaultIfEmpty()
                                     join month7Oplata in month7OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month7Oplata.Field<string>("ABN")
                                      into temp7
                                      from t7 in temp7.DefaultIfEmpty()
                                     join month8Oplata in month8OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month8Oplata.Field<string>("ABN")
                                      into temp8
                                      from t8 in temp8.DefaultIfEmpty()
                                     join month9Oplata in month9OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month9Oplata.Field<string>("ABN")
                                      into temp9
                                      from t9 in temp9.DefaultIfEmpty()
                                     join month10Oplata in month10OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month10Oplata.Field<string>("ABN")
                                      into temp10
                                      from t10 in temp10.DefaultIfEmpty()
                                     select new
                                     {
                                         ABN = firstTable.Field<string>("ABN"),
                                         FIO = firstTable.Field<string>("FIO"),
                                         STREET = firstTable.Field<string>("STREET"),
                                         DOM = firstTable.Field<string>("DOM"),
                                         KORP = firstTable.Field<string>("KORP"),
                                         KVAR = firstTable.Field<string>("KVAR"),
                                         TIP = firstTable.Field<string>("TIP"),
                                         NOMER = firstTable.Field<string>("NOMER"),
                                         OPOKAZ = firstTable.Field<string>("OPOKAZ"),
                                         month1Oplata = t1 == null ? string.Empty : t1.Field<string>(bytMonthYearTablesList[0]),
                                         month2Oplata = t2 == null ? string.Empty : t2.Field<string>(bytMonthYearTablesList[1]),
                                         month3Oplata = t3 == null ? string.Empty : t3.Field<string>(bytMonthYearTablesList[2]),
                                         month4Oplata = t4 == null ? string.Empty : t4.Field<string>(bytMonthYearTablesList[3]),
                                         month5Oplata = t5 == null ? string.Empty : t5.Field<string>(bytMonthYearTablesList[4]),
                                         month6Oplata = t6 == null ? string.Empty : t6.Field<string>(bytMonthYearTablesList[5]),
                                         month7Oplata = t7 == null ? string.Empty : t7.Field<string>(bytMonthYearTablesList[6]),
                                         month8Oplata = t8 == null ? string.Empty : t8.Field<string>(bytMonthYearTablesList[7]),
                                         month9Oplata = t9 == null ? string.Empty : t9.Field<string>(bytMonthYearTablesList[8]),
                                         month10Oplata = t10 == null ? string.Empty : t10.Field<string>(bytMonthYearTablesList[9])

                                     };
                   DataTable resultMonth10OplataTable = LINQtoDataSetMethods.CopyToDataTable(query10Month);
                   return resultMonth10OplataTable;

                case 11:
                   firstOplataTable = GetBytFirstDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month1OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month2OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[1], connectionString, nameTp);
                   month3OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[2], connectionString, nameTp);
                   month4OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[3], connectionString, nameTp);
                   month5OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[4], connectionString, nameTp);
                   month6OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[5], connectionString, nameTp);
                   month7OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[6], connectionString, nameTp);
                   month8OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[7], connectionString, nameTp);
                   month9OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[8], connectionString, nameTp);
                   month10OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[9], connectionString, nameTp);
                   month11OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[10], connectionString, nameTp);

                   var query11Month = from firstTable in firstOplataTable.AsEnumerable()
                                      join month1Oplata in month1OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month1Oplata.Field<string>("ABN")
                                       into temp1
                                      from t1 in temp1.DefaultIfEmpty()
                                      join month2Oplata in month2OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month2Oplata.Field<string>("ABN")
                                       into temp2
                                      from t2 in temp2.DefaultIfEmpty()
                                      join month3Oplata in month3OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month3Oplata.Field<string>("ABN")
                                       into temp3
                                      from t3 in temp3.DefaultIfEmpty()
                                      join month4Oplata in month4OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month4Oplata.Field<string>("ABN")
                                       into temp4
                                      from t4 in temp4.DefaultIfEmpty()
                                      join month5Oplata in month5OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month5Oplata.Field<string>("ABN")
                                       into temp5
                                      from t5 in temp5.DefaultIfEmpty()
                                      join month6Oplata in month6OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month6Oplata.Field<string>("ABN")
                                       into temp6
                                      from t6 in temp6.DefaultIfEmpty()
                                      join month7Oplata in month7OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month7Oplata.Field<string>("ABN")
                                       into temp7
                                      from t7 in temp7.DefaultIfEmpty()
                                      join month8Oplata in month8OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month8Oplata.Field<string>("ABN")
                                       into temp8
                                      from t8 in temp8.DefaultIfEmpty()
                                      join month9Oplata in month9OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month9Oplata.Field<string>("ABN")
                                       into temp9
                                      from t9 in temp9.DefaultIfEmpty()
                                      join month10Oplata in month10OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month10Oplata.Field<string>("ABN")
                                       into temp10
                                      from t10 in temp10.DefaultIfEmpty()
                                      join month11Oplata in month11OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month11Oplata.Field<string>("ABN")
                                       into temp11
                                      from t11 in temp11.DefaultIfEmpty()
                                      select new
                                      {
                                          ABN = firstTable.Field<string>("ABN"),
                                          FIO = firstTable.Field<string>("FIO"),
                                          STREET = firstTable.Field<string>("STREET"),
                                          DOM = firstTable.Field<string>("DOM"),
                                          KORP = firstTable.Field<string>("KORP"),
                                          KVAR = firstTable.Field<string>("KVAR"),
                                          TIP = firstTable.Field<string>("TIP"),
                                          NOMER = firstTable.Field<string>("NOMER"),
                                          OPOKAZ = firstTable.Field<string>("OPOKAZ"),
                                          month1Oplata = t1 == null ? string.Empty : t1.Field<string>(bytMonthYearTablesList[0]),
                                          month2Oplata = t2 == null ? string.Empty : t2.Field<string>(bytMonthYearTablesList[1]),
                                          month3Oplata = t3 == null ? string.Empty : t3.Field<string>(bytMonthYearTablesList[2]),
                                          month4Oplata = t4 == null ? string.Empty : t4.Field<string>(bytMonthYearTablesList[3]),
                                          month5Oplata = t5 == null ? string.Empty : t5.Field<string>(bytMonthYearTablesList[4]),
                                          month6Oplata = t6 == null ? string.Empty : t6.Field<string>(bytMonthYearTablesList[5]),
                                          month7Oplata = t7 == null ? string.Empty : t7.Field<string>(bytMonthYearTablesList[6]),
                                          month8Oplata = t8 == null ? string.Empty : t8.Field<string>(bytMonthYearTablesList[7]),
                                          month9Oplata = t9 == null ? string.Empty : t9.Field<string>(bytMonthYearTablesList[8]),
                                          month10Oplata = t10 == null ? string.Empty : t10.Field<string>(bytMonthYearTablesList[9]),
                                          month11Oplata = t11 == null ? string.Empty : t11.Field<string>(bytMonthYearTablesList[10])

                                      };
                   DataTable resultMonth11OplataTable = LINQtoDataSetMethods.CopyToDataTable(query11Month);
                   return resultMonth11OplataTable;

                case 12:
                   firstOplataTable = GetBytFirstDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month1OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[0], connectionString, nameTp);
                   month2OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[1], connectionString, nameTp);
                   month3OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[2], connectionString, nameTp);
                   month4OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[3], connectionString, nameTp);
                   month5OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[4], connectionString, nameTp);
                   month6OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[5], connectionString, nameTp);
                   month7OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[6], connectionString, nameTp);
                   month8OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[7], connectionString, nameTp);
                   month9OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[8], connectionString, nameTp);
                   month10OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[9], connectionString, nameTp);
                   month11OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[10], connectionString, nameTp);
                   month12OplataTable = GetBytOplatiDataTableTP(bytMonthYearTablesList[11], connectionString, nameTp);

                   var query12Month = from firstTable in firstOplataTable.AsEnumerable()
                                      join month1Oplata in month1OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month1Oplata.Field<string>("ABN")
                                        into temp1
                                      from t1 in temp1.DefaultIfEmpty()
                                      join month2Oplata in month2OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month2Oplata.Field<string>("ABN")
                                        into temp2
                                      from t2 in temp2.DefaultIfEmpty()
                                      join month3Oplata in month3OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month3Oplata.Field<string>("ABN")
                                        into temp3
                                      from t3 in temp3.DefaultIfEmpty()
                                      join month4Oplata in month4OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month4Oplata.Field<string>("ABN")
                                        into temp4
                                      from t4 in temp4.DefaultIfEmpty()
                                      join month5Oplata in month5OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month5Oplata.Field<string>("ABN")
                                        into temp5
                                      from t5 in temp5.DefaultIfEmpty()
                                      join month6Oplata in month6OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month6Oplata.Field<string>("ABN")
                                        into temp6
                                      from t6 in temp6.DefaultIfEmpty()
                                      join month7Oplata in month7OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month7Oplata.Field<string>("ABN")
                                        into temp7
                                      from t7 in temp7.DefaultIfEmpty()
                                      join month8Oplata in month8OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month8Oplata.Field<string>("ABN")
                                        into temp8
                                      from t8 in temp8.DefaultIfEmpty()
                                      join month9Oplata in month9OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month9Oplata.Field<string>("ABN")
                                        into temp9
                                      from t9 in temp9.DefaultIfEmpty()
                                      join month10Oplata in month10OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month10Oplata.Field<string>("ABN")
                                        into temp10
                                      from t10 in temp10.DefaultIfEmpty()
                                      join month11Oplata in month11OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month11Oplata.Field<string>("ABN")
                                        into temp11
                                      from t11 in temp11.DefaultIfEmpty()
                                      join month12Oplata in month12OplataTable.AsEnumerable() on firstTable.Field<string>("ABN") equals month12Oplata.Field<string>("ABN")
                                        into temp12
                                      from t12 in temp12.DefaultIfEmpty()
                                      select new
                                      {
                                          ABN = firstTable.Field<string>("ABN"),
                                          FIO = firstTable.Field<string>("FIO"),
                                          STREET = firstTable.Field<string>("STREET"),
                                          DOM = firstTable.Field<string>("DOM"),
                                          KORP = firstTable.Field<string>("KORP"),
                                          KVAR = firstTable.Field<string>("KVAR"),
                                          TIP = firstTable.Field<string>("TIP"),
                                          NOMER = firstTable.Field<string>("NOMER"),
                                          OPOKAZ = firstTable.Field<string>("OPOKAZ"),
                                          month1Oplata = t1 == null ? string.Empty : t1.Field<string>(bytMonthYearTablesList[0]),
                                          month2Oplata = t2 == null ? string.Empty : t2.Field<string>(bytMonthYearTablesList[1]),
                                          month3Oplata = t3 == null ? string.Empty : t3.Field<string>(bytMonthYearTablesList[2]),
                                          month4Oplata = t4 == null ? string.Empty : t4.Field<string>(bytMonthYearTablesList[3]),
                                          month5Oplata = t5 == null ? string.Empty : t5.Field<string>(bytMonthYearTablesList[4]),
                                          month6Oplata = t6 == null ? string.Empty : t6.Field<string>(bytMonthYearTablesList[5]),
                                          month7Oplata = t7 == null ? string.Empty : t7.Field<string>(bytMonthYearTablesList[6]),
                                          month8Oplata = t8 == null ? string.Empty : t8.Field<string>(bytMonthYearTablesList[7]),
                                          month9Oplata = t9 == null ? string.Empty : t9.Field<string>(bytMonthYearTablesList[8]),
                                          month10Oplata = t10 == null ? string.Empty : t10.Field<string>(bytMonthYearTablesList[9]),
                                          month11Oplata = t11 == null ? string.Empty : t11.Field<string>(bytMonthYearTablesList[10]),
                                          month12Oplata = t12 == null ? string.Empty : t12.Field<string>(bytMonthYearTablesList[11])

                                      };
                    
                   DataTable resultMonth12OplataTable = LINQtoDataSetMethods.CopyToDataTable(query12Month);
                   return resultMonth12OplataTable;


               

               default:
                    return new DataTable();
            }




        }
        public DataTable GetOplatiTablePromTP(IList<String> promMonthYearTablesList, string connectionString, string codeTp)
        {
            //Таблица эталон данных
            DataTable firstOplataTable;

            //Таблицы для хранения оплат 
            DataTable month1OplataTable;
            DataTable month2OplataTable;
            DataTable month3OplataTable;
            DataTable month4OplataTable;
            DataTable month5OplataTable;
            DataTable month6OplataTable;
            DataTable month7OplataTable;
            DataTable month8OplataTable;
            DataTable month9OplataTable;
            DataTable month10OplataTable;
            DataTable month11OplataTable;
            DataTable month12OplataTable;


            switch (promMonthYearTablesList.Count)
            {


                case 1:
                    firstOplataTable = GetPromFirstDataTableTP(promMonthYearTablesList[0],connectionString, codeTp);
                    month1OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);


                    var query1Month = from firstTable in firstOplataTable.AsEnumerable()
                                      join month1Oplata in month1OplataTable.AsEnumerable()
                                      on new {
                                             kp =  firstTable.Field<string>("KP"),
                                             nab =  firstTable.Field<string>("NAB"),
                                             ktu =  firstTable.Field<string>("KTU"),
                                             kodtp = firstTable.Field<string>("KODTP")
                                      } equals new
                                                   {
                                                   kp = month1Oplata.Field<string>("KP"),
                                                   nab = month1Oplata.Field<string>("NAB"),
                                                   ktu = month1Oplata.Field<string>("KTU"),
                                                   kodtp = month1Oplata.Field<string>("KODTP")
                                                   }
                                       into temp1
                                       from t1 in temp1.DefaultIfEmpty()
                                      select new
                                      {
                                          KP = firstTable.Field<string>("KP"),
                                          N1 = firstTable.Field<string>("N1"),
                                          N2 = firstTable.Field<string>("N2"),
                                          N3 = firstTable.Field<string>("N3"),
                                          NST = firstTable.Field<string>("NST"),
                                          TIPSCH = firstTable.Field<string>("TIPSCH"),
                                          TPOK = firstTable.Field<string>("TPOK"),
                                          KTT = firstTable.Field<string>("KTT"),
                                          month1Oplata = t1 == null ? string.Empty: t1.Field<string>(promMonthYearTablesList[0])
                                      };

                    DataTable resultMonth1OplataTable = LINQtoDataSetMethods.CopyToDataTable(query1Month);
                    return resultMonth1OplataTable;
                    
                case 2:
                     firstOplataTable = GetPromFirstDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                     month1OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                     month2OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[1], connectionString, codeTp);


                     var query2Month = from firstTable in firstOplataTable.AsEnumerable()
                                      join month1Oplata in month1OplataTable.AsEnumerable()
                                      on new {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      } equals new
                                                   {
                                                   kp = month1Oplata.Field<string>("KP"),
                                                   nab = month1Oplata.Field<string>("NAB"),
                                                   ktu = month1Oplata.Field<string>("KTU"),
                                                   kodtp = month1Oplata.Field<string>("KODTP")
                                                   }
                                                   into temp1
                                      from t1 in temp1.DefaultIfEmpty()
                                      join month2Oplata in month2OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     } 
                                      equals new
                                        {
                                         kp = month2Oplata.Field<string>("KP"),
                                         nab = month2Oplata.Field<string>("NAB"),
                                         ktu = month2Oplata.Field<string>("KTU"),
                                         kodtp = month2Oplata.Field<string>("KODTP")
                                        }
                                         into temp2
                                      from t2 in temp2.DefaultIfEmpty()
                                       
                                      select new
                                      {
                                          KP = firstTable.Field<string>("KP"),
                                          N1 = firstTable.Field<string>("N1"),
                                          N2 = firstTable.Field<string>("N2"),
                                          N3 = firstTable.Field<string>("N3"),
                                          NST = firstTable.Field<string>("NST"),
                                          TIPSCH = firstTable.Field<string>("TIPSCH"),
                                          TPOK = firstTable.Field<string>("TPOK"),
                                          KTT = firstTable.Field<string>("KTT"),
                                          month1Oplata = t1 == null ? string.Empty: t1.Field<string>(promMonthYearTablesList[0]),
                                          month2Oplata = t2 == null ? string.Empty : t2.Field<string>(promMonthYearTablesList[1])
                                      };

                    DataTable resultMonth2OplataTable = LINQtoDataSetMethods.CopyToDataTable(query2Month);
                    return resultMonth2OplataTable;

                case 3:
                    firstOplataTable = GetPromFirstDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month1OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month2OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[1], connectionString, codeTp);
                    month3OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[2], connectionString, codeTp);


                    var query3Month = from firstTable in firstOplataTable.AsEnumerable()
                                      join month1Oplata in month1OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      } equals new
                                      {
                                          kp = month1Oplata.Field<string>("KP"),
                                          nab = month1Oplata.Field<string>("NAB"),
                                          ktu = month1Oplata.Field<string>("KTU"),
                                          kodtp = month1Oplata.Field<string>("KODTP")
                                      }
                                      into temp1
                                      from t1 in temp1.DefaultIfEmpty()
                                      join month2Oplata in month2OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month2Oplata.Field<string>("KP"),
                                          nab = month2Oplata.Field<string>("NAB"),
                                          ktu = month2Oplata.Field<string>("KTU"),
                                          kodtp = month2Oplata.Field<string>("KODTP")
                                      }
                                      into temp2
                                      from t2 in temp2.DefaultIfEmpty()
                                      join month3Oplata in month3OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month3Oplata.Field<string>("KP"),
                                          nab = month3Oplata.Field<string>("NAB"),
                                          ktu = month3Oplata.Field<string>("KTU"),
                                          kodtp = month3Oplata.Field<string>("KODTP")
                                      }
                                      into temp3
                                      from t3 in temp3.DefaultIfEmpty()
                                      select new
                                      {
                                          KP = firstTable.Field<string>("KP"),
                                          N1 = firstTable.Field<string>("N1"),
                                          N2 = firstTable.Field<string>("N2"),
                                          N3 = firstTable.Field<string>("N3"),
                                          NST = firstTable.Field<string>("NST"),
                                          TIPSCH = firstTable.Field<string>("TIPSCH"),
                                          TPOK = firstTable.Field<string>("TPOK"),
                                          KTT = firstTable.Field<string>("KTT"),
                                          month1Oplata = t1 == null ? string.Empty : t1.Field<string>(promMonthYearTablesList[0]),
                                          month2Oplata = t2 == null ? string.Empty : t2.Field<string>(promMonthYearTablesList[1]),
                                          month3Oplata = t3 == null ? string.Empty : t3.Field<string>(promMonthYearTablesList[2])
                                      };

                    DataTable resultMonth3OplataTable = LINQtoDataSetMethods.CopyToDataTable(query3Month);
                    return resultMonth3OplataTable;

                case 4:
                    firstOplataTable = GetPromFirstDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month1OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month2OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[1], connectionString, codeTp);
                    month3OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[2], connectionString, codeTp);
                    month4OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[3], connectionString, codeTp);


                    var query4Month = from firstTable in firstOplataTable.AsEnumerable()
                                      join month1Oplata in month1OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      } equals new
                                      {
                                          kp = month1Oplata.Field<string>("KP"),
                                          nab = month1Oplata.Field<string>("NAB"),
                                          ktu = month1Oplata.Field<string>("KTU"),
                                          kodtp = month1Oplata.Field<string>("KODTP")
                                      }
                                       into temp1
                                      from t1 in temp1.DefaultIfEmpty()
                                      join month2Oplata in month2OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month2Oplata.Field<string>("KP"),
                                          nab = month2Oplata.Field<string>("NAB"),
                                          ktu = month2Oplata.Field<string>("KTU"),
                                          kodtp = month2Oplata.Field<string>("KODTP")
                                      }
                                       into temp2
                                      from t2 in temp2.DefaultIfEmpty()
                                      join month3Oplata in month3OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month3Oplata.Field<string>("KP"),
                                          nab = month3Oplata.Field<string>("NAB"),
                                          ktu = month3Oplata.Field<string>("KTU"),
                                          kodtp = month3Oplata.Field<string>("KODTP")
                                      }
                                       into temp3
                                      from t3 in temp3.DefaultIfEmpty()
                                      join month4Oplata in month4OplataTable.AsEnumerable()
                                    on new
                                    {
                                        kp = firstTable.Field<string>("KP"),
                                        nab = firstTable.Field<string>("NAB"),
                                        ktu = firstTable.Field<string>("KTU"),
                                        kodtp = firstTable.Field<string>("KODTP")
                                    }
                                     equals new
                                     {
                                         kp = month4Oplata.Field<string>("KP"),
                                         nab = month4Oplata.Field<string>("NAB"),
                                         ktu = month4Oplata.Field<string>("KTU"),
                                         kodtp = month4Oplata.Field<string>("KODTP")
                                     }
                                      into temp4
                                      from t4 in temp4.DefaultIfEmpty()
                                      select new
                                      {
                                          KP = firstTable.Field<string>("KP"),
                                          N1 = firstTable.Field<string>("N1"),
                                          N2 = firstTable.Field<string>("N2"),
                                          N3 = firstTable.Field<string>("N3"),
                                          NST = firstTable.Field<string>("NST"),
                                          TIPSCH = firstTable.Field<string>("TIPSCH"),
                                          TPOK = firstTable.Field<string>("TPOK"),
                                          KTT = firstTable.Field<string>("KTT"),
                                          month1Oplata = t1 == null ? string.Empty : t1.Field<string>(promMonthYearTablesList[0]),
                                          month2Oplata = t2 == null ? string.Empty : t2.Field<string>(promMonthYearTablesList[1]),
                                          month3Oplata = t3 == null ? string.Empty : t3.Field<string>(promMonthYearTablesList[2]),
                                          month4Oplata = t4 == null ? string.Empty : t4.Field<string>(promMonthYearTablesList[3])
                                      };

                    DataTable resultMonth4OplataTable = LINQtoDataSetMethods.CopyToDataTable(query4Month);
                    return resultMonth4OplataTable;

                case 5:
                    firstOplataTable = GetPromFirstDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month1OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month2OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[1], connectionString, codeTp);
                    month3OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[2], connectionString, codeTp);
                    month4OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[3], connectionString, codeTp);
                    month5OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[4], connectionString, codeTp);


                    var query5Month = from firstTable in firstOplataTable.AsEnumerable()
                                      join month1Oplata in month1OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      } equals new
                                      {
                                          kp = month1Oplata.Field<string>("KP"),
                                          nab = month1Oplata.Field<string>("NAB"),
                                          ktu = month1Oplata.Field<string>("KTU"),
                                          kodtp = month1Oplata.Field<string>("KODTP")
                                      }
                                        into temp1
                                      from t1 in temp1.DefaultIfEmpty()
                                      join month2Oplata in month2OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month2Oplata.Field<string>("KP"),
                                          nab = month2Oplata.Field<string>("NAB"),
                                          ktu = month2Oplata.Field<string>("KTU"),
                                          kodtp = month2Oplata.Field<string>("KODTP")
                                      }
                                        into temp2
                                      from t2 in temp2.DefaultIfEmpty()
                                      join month3Oplata in month3OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month3Oplata.Field<string>("KP"),
                                          nab = month3Oplata.Field<string>("NAB"),
                                          ktu = month3Oplata.Field<string>("KTU"),
                                          kodtp = month3Oplata.Field<string>("KODTP")
                                      }
                                        into temp3
                                      from t3 in temp3.DefaultIfEmpty()
                                      join month4Oplata in month4OplataTable.AsEnumerable()
                                    on new
                                    {
                                        kp = firstTable.Field<string>("KP"),
                                        nab = firstTable.Field<string>("NAB"),
                                        ktu = firstTable.Field<string>("KTU"),
                                        kodtp = firstTable.Field<string>("KODTP")
                                    }
                                     equals new
                                     {
                                         kp = month4Oplata.Field<string>("KP"),
                                         nab = month4Oplata.Field<string>("NAB"),
                                         ktu = month4Oplata.Field<string>("KTU"),
                                         kodtp = month4Oplata.Field<string>("KODTP")
                                     }
                                       into temp4
                                      from t4 in temp4.DefaultIfEmpty()
                                      join month5Oplata in month5OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month5Oplata.Field<string>("KP"),
                                          nab = month5Oplata.Field<string>("NAB"),
                                          ktu = month5Oplata.Field<string>("KTU"),
                                          kodtp = month5Oplata.Field<string>("KODTP")
                                      }
                                        into temp5
                                      from t5 in temp5.DefaultIfEmpty()
                                      select new
                                      {
                                          KP = firstTable.Field<string>("KP"),
                                          N1 = firstTable.Field<string>("N1"),
                                          N2 = firstTable.Field<string>("N2"),
                                          N3 = firstTable.Field<string>("N3"),
                                          NST = firstTable.Field<string>("NST"),
                                          TIPSCH = firstTable.Field<string>("TIPSCH"),
                                          TPOK = firstTable.Field<string>("TPOK"),
                                          KTT = firstTable.Field<string>("KTT"),
                                          month1Oplata = t1 == null ? string.Empty : t1.Field<string>(promMonthYearTablesList[0]),
                                          month2Oplata = t2 == null ? string.Empty : t2.Field<string>(promMonthYearTablesList[1]),
                                          month3Oplata = t3 == null ? string.Empty : t3.Field<string>(promMonthYearTablesList[2]),
                                          month4Oplata = t4 == null ? string.Empty : t4.Field<string>(promMonthYearTablesList[3]),
                                          month5Oplata = t5 == null ? string.Empty : t5.Field<string>(promMonthYearTablesList[4])
                                      };

                    DataTable resultMonth5OplataTable = LINQtoDataSetMethods.CopyToDataTable(query5Month);
                    return resultMonth5OplataTable;

                case 6:
                    firstOplataTable = GetPromFirstDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month1OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month2OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[1], connectionString, codeTp);
                    month3OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[2], connectionString, codeTp);
                    month4OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[3], connectionString, codeTp);
                    month5OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[4], connectionString, codeTp);
                    month6OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[5], connectionString, codeTp);


                    var query6Month = from firstTable in firstOplataTable.AsEnumerable()
                                      join month1Oplata in month1OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      } equals new
                                      {
                                          kp = month1Oplata.Field<string>("KP"),
                                          nab = month1Oplata.Field<string>("NAB"),
                                          ktu = month1Oplata.Field<string>("KTU"),
                                          kodtp = month1Oplata.Field<string>("KODTP")
                                      }
                                        into temp1
                                      from t1 in temp1.DefaultIfEmpty()
                                      join month2Oplata in month2OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month2Oplata.Field<string>("KP"),
                                          nab = month2Oplata.Field<string>("NAB"),
                                          ktu = month2Oplata.Field<string>("KTU"),
                                          kodtp = month2Oplata.Field<string>("KODTP")
                                      }
                                        into temp2
                                      from t2 in temp2.DefaultIfEmpty()
                                      join month3Oplata in month3OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month3Oplata.Field<string>("KP"),
                                          nab = month3Oplata.Field<string>("NAB"),
                                          ktu = month3Oplata.Field<string>("KTU"),
                                          kodtp = month3Oplata.Field<string>("KODTP")
                                      }
                                        into temp3
                                      from t3 in temp3.DefaultIfEmpty()
                                      join month4Oplata in month4OplataTable.AsEnumerable()
                                    on new
                                    {
                                        kp = firstTable.Field<string>("KP"),
                                        nab = firstTable.Field<string>("NAB"),
                                        ktu = firstTable.Field<string>("KTU"),
                                        kodtp = firstTable.Field<string>("KODTP")
                                    }
                                     equals new
                                     {
                                         kp = month4Oplata.Field<string>("KP"),
                                         nab = month4Oplata.Field<string>("NAB"),
                                         ktu = month4Oplata.Field<string>("KTU"),
                                         kodtp = month4Oplata.Field<string>("KODTP")
                                     }
                                       into temp4
                                      from t4 in temp4.DefaultIfEmpty()
                                      join month5Oplata in month5OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month5Oplata.Field<string>("KP"),
                                          nab = month5Oplata.Field<string>("NAB"),
                                          ktu = month5Oplata.Field<string>("KTU"),
                                          kodtp = month5Oplata.Field<string>("KODTP")
                                      }
                                        into temp5
                                      from t5 in temp5.DefaultIfEmpty()
                                      join month6Oplata in month6OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month6Oplata.Field<string>("KP"),
                                          nab = month6Oplata.Field<string>("NAB"),
                                          ktu = month6Oplata.Field<string>("KTU"),
                                          kodtp = month6Oplata.Field<string>("KODTP")
                                      }
                                        into temp6
                                      from t6 in temp6.DefaultIfEmpty()
                                      select new
                                      {
                                          KP = firstTable.Field<string>("KP"),
                                          N1 = firstTable.Field<string>("N1"),
                                          N2 = firstTable.Field<string>("N2"),
                                          N3 = firstTable.Field<string>("N3"),
                                          NST = firstTable.Field<string>("NST"),
                                          TIPSCH = firstTable.Field<string>("TIPSCH"),
                                          TPOK = firstTable.Field<string>("TPOK"),
                                          KTT = firstTable.Field<string>("KTT"),
                                          month1Oplata = t1 == null ? string.Empty : t1.Field<string>(promMonthYearTablesList[0]),
                                          month2Oplata = t2 == null ? string.Empty : t2.Field<string>(promMonthYearTablesList[1]),
                                          month3Oplata = t3 == null ? string.Empty : t3.Field<string>(promMonthYearTablesList[2]),
                                          month4Oplata = t4 == null ? string.Empty : t4.Field<string>(promMonthYearTablesList[3]),
                                          month5Oplata = t5 == null ? string.Empty : t5.Field<string>(promMonthYearTablesList[4]),
                                          month6Oplata = t6 == null ? string.Empty : t6.Field<string>(promMonthYearTablesList[5])
                                      };

                    DataTable resultMonth6OplataTable = LINQtoDataSetMethods.CopyToDataTable(query6Month);
                    return resultMonth6OplataTable;

                case 7:
                    firstOplataTable = GetPromFirstDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month1OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month2OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[1], connectionString, codeTp);
                    month3OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[2], connectionString, codeTp);
                    month4OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[3], connectionString, codeTp);
                    month5OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[4], connectionString, codeTp);
                    month6OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[5], connectionString, codeTp);
                    month7OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[6], connectionString, codeTp);


                    var query7Month = from firstTable in firstOplataTable.AsEnumerable()
                                      join month1Oplata in month1OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      } equals new
                                      {
                                          kp = month1Oplata.Field<string>("KP"),
                                          nab = month1Oplata.Field<string>("NAB"),
                                          ktu = month1Oplata.Field<string>("KTU"),
                                          kodtp = month1Oplata.Field<string>("KODTP")
                                      }
                                           into temp1
                                      from t1 in temp1.DefaultIfEmpty()
                                      join month2Oplata in month2OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month2Oplata.Field<string>("KP"),
                                          nab = month2Oplata.Field<string>("NAB"),
                                          ktu = month2Oplata.Field<string>("KTU"),
                                          kodtp = month2Oplata.Field<string>("KODTP")
                                      }
                                           into temp2
                                      from t2 in temp2.DefaultIfEmpty()
                                      join month3Oplata in month3OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month3Oplata.Field<string>("KP"),
                                          nab = month3Oplata.Field<string>("NAB"),
                                          ktu = month3Oplata.Field<string>("KTU"),
                                          kodtp = month3Oplata.Field<string>("KODTP")
                                      }
                                           into temp3
                                      from t3 in temp3.DefaultIfEmpty()
                                      join month4Oplata in month4OplataTable.AsEnumerable()
                                    on new
                                    {
                                        kp = firstTable.Field<string>("KP"),
                                        nab = firstTable.Field<string>("NAB"),
                                        ktu = firstTable.Field<string>("KTU"),
                                        kodtp = firstTable.Field<string>("KODTP")
                                    }
                                     equals new
                                     {
                                         kp = month4Oplata.Field<string>("KP"),
                                         nab = month4Oplata.Field<string>("NAB"),
                                         ktu = month4Oplata.Field<string>("KTU"),
                                         kodtp = month4Oplata.Field<string>("KODTP")
                                     }
                                          into temp4
                                      from t4 in temp4.DefaultIfEmpty()
                                      join month5Oplata in month5OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month5Oplata.Field<string>("KP"),
                                          nab = month5Oplata.Field<string>("NAB"),
                                          ktu = month5Oplata.Field<string>("KTU"),
                                          kodtp = month5Oplata.Field<string>("KODTP")
                                      }
                                           into temp5
                                      from t5 in temp5.DefaultIfEmpty()
                                      join month6Oplata in month6OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month6Oplata.Field<string>("KP"),
                                          nab = month6Oplata.Field<string>("NAB"),
                                          ktu = month6Oplata.Field<string>("KTU"),
                                          kodtp = month6Oplata.Field<string>("KODTP")
                                      }
                                           into temp6
                                      from t6 in temp6.DefaultIfEmpty()
                                      join month7Oplata in month7OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month7Oplata.Field<string>("KP"),
                                          nab = month7Oplata.Field<string>("NAB"),
                                          ktu = month7Oplata.Field<string>("KTU"),
                                          kodtp = month7Oplata.Field<string>("KODTP")
                                      }
                                           into temp7
                                      from t7 in temp7.DefaultIfEmpty()
                                      select new
                                      {
                                          KP = firstTable.Field<string>("KP"),
                                          N1 = firstTable.Field<string>("N1"),
                                          N2 = firstTable.Field<string>("N2"),
                                          N3 = firstTable.Field<string>("N3"),
                                          NST = firstTable.Field<string>("NST"),
                                          TIPSCH = firstTable.Field<string>("TIPSCH"),
                                          TPOK = firstTable.Field<string>("TPOK"),
                                          KTT = firstTable.Field<string>("KTT"),
                                          month1Oplata = t1 == null ? string.Empty : t1.Field<string>(promMonthYearTablesList[0]),
                                          month2Oplata = t2 == null ? string.Empty : t2.Field<string>(promMonthYearTablesList[1]),
                                          month3Oplata = t3 == null ? string.Empty : t3.Field<string>(promMonthYearTablesList[2]),
                                          month4Oplata = t4 == null ? string.Empty : t4.Field<string>(promMonthYearTablesList[3]),
                                          month5Oplata = t5 == null ? string.Empty : t5.Field<string>(promMonthYearTablesList[4]),
                                          month6Oplata = t6 == null ? string.Empty : t6.Field<string>(promMonthYearTablesList[5]),
                                          month7Oplata = t7 == null ? string.Empty : t7.Field<string>(promMonthYearTablesList[6])
                                      };

                    DataTable resultMonth7OplataTable = LINQtoDataSetMethods.CopyToDataTable(query7Month);
                    return resultMonth7OplataTable;

                case 8:
                    firstOplataTable = GetPromFirstDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month1OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month2OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[1], connectionString, codeTp);
                    month3OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[2], connectionString, codeTp);
                    month4OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[3], connectionString, codeTp);
                    month5OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[4], connectionString, codeTp);
                    month6OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[5], connectionString, codeTp);
                    month7OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[6], connectionString, codeTp);
                    month8OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[7], connectionString, codeTp);


                    var query8Month = from firstTable in firstOplataTable.AsEnumerable()
                                      join month1Oplata in month1OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      } equals new
                                      {
                                          kp = month1Oplata.Field<string>("KP"),
                                          nab = month1Oplata.Field<string>("NAB"),
                                          ktu = month1Oplata.Field<string>("KTU"),
                                          kodtp = month1Oplata.Field<string>("KODTP")
                                      }
                                           into temp1
                                      from t1 in temp1.DefaultIfEmpty()
                                      join month2Oplata in month2OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month2Oplata.Field<string>("KP"),
                                          nab = month2Oplata.Field<string>("NAB"),
                                          ktu = month2Oplata.Field<string>("KTU"),
                                          kodtp = month2Oplata.Field<string>("KODTP")
                                      }
                                           into temp2
                                      from t2 in temp2.DefaultIfEmpty()
                                      join month3Oplata in month3OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month3Oplata.Field<string>("KP"),
                                          nab = month3Oplata.Field<string>("NAB"),
                                          ktu = month3Oplata.Field<string>("KTU"),
                                          kodtp = month3Oplata.Field<string>("KODTP")
                                      }
                                           into temp3
                                      from t3 in temp3.DefaultIfEmpty()
                                      join month4Oplata in month4OplataTable.AsEnumerable()
                                    on new
                                    {
                                        kp = firstTable.Field<string>("KP"),
                                        nab = firstTable.Field<string>("NAB"),
                                        ktu = firstTable.Field<string>("KTU"),
                                        kodtp = firstTable.Field<string>("KODTP")
                                    }
                                     equals new
                                     {
                                         kp = month4Oplata.Field<string>("KP"),
                                         nab = month4Oplata.Field<string>("NAB"),
                                         ktu = month4Oplata.Field<string>("KTU"),
                                         kodtp = month4Oplata.Field<string>("KODTP")
                                     }
                                          into temp4
                                      from t4 in temp4.DefaultIfEmpty()
                                      join month5Oplata in month5OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month5Oplata.Field<string>("KP"),
                                          nab = month5Oplata.Field<string>("NAB"),
                                          ktu = month5Oplata.Field<string>("KTU"),
                                          kodtp = month5Oplata.Field<string>("KODTP")
                                      }
                                           into temp5
                                      from t5 in temp5.DefaultIfEmpty()
                                      join month6Oplata in month6OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month6Oplata.Field<string>("KP"),
                                          nab = month6Oplata.Field<string>("NAB"),
                                          ktu = month6Oplata.Field<string>("KTU"),
                                          kodtp = month6Oplata.Field<string>("KODTP")
                                      }
                                           into temp6
                                      from t6 in temp6.DefaultIfEmpty()
                                      join month7Oplata in month7OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month7Oplata.Field<string>("KP"),
                                          nab = month7Oplata.Field<string>("NAB"),
                                          ktu = month7Oplata.Field<string>("KTU"),
                                          kodtp = month7Oplata.Field<string>("KODTP")
                                      }
                                           into temp7
                                      from t7 in temp7.DefaultIfEmpty()
                                      join month8Oplata in month8OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month8Oplata.Field<string>("KP"),
                                          nab = month8Oplata.Field<string>("NAB"),
                                          ktu = month8Oplata.Field<string>("KTU"),
                                          kodtp = month8Oplata.Field<string>("KODTP")
                                      }
                                           into temp8
                                      from t8 in temp8.DefaultIfEmpty()
                                      select new
                                      {
                                          KP = firstTable.Field<string>("KP"),
                                          N1 = firstTable.Field<string>("N1"),
                                          N2 = firstTable.Field<string>("N2"),
                                          N3 = firstTable.Field<string>("N3"),
                                          NST = firstTable.Field<string>("NST"),
                                          TIPSCH = firstTable.Field<string>("TIPSCH"),
                                          TPOK = firstTable.Field<string>("TPOK"),
                                          KTT = firstTable.Field<string>("KTT"),
                                          month1Oplata = t1 == null ? string.Empty : t1.Field<string>(promMonthYearTablesList[0]),
                                          month2Oplata = t2 == null ? string.Empty : t2.Field<string>(promMonthYearTablesList[1]),
                                          month3Oplata = t3 == null ? string.Empty : t3.Field<string>(promMonthYearTablesList[2]),
                                          month4Oplata = t4 == null ? string.Empty : t4.Field<string>(promMonthYearTablesList[3]),
                                          month5Oplata = t5 == null ? string.Empty : t5.Field<string>(promMonthYearTablesList[4]),
                                          month6Oplata = t6 == null ? string.Empty : t6.Field<string>(promMonthYearTablesList[5]),
                                          month7Oplata = t7 == null ? string.Empty : t7.Field<string>(promMonthYearTablesList[6]),
                                          month8Oplata = t8 == null ? string.Empty : t8.Field<string>(promMonthYearTablesList[7])
                                      };

                    DataTable resultMonth8OplataTable = LINQtoDataSetMethods.CopyToDataTable(query8Month);
                    return resultMonth8OplataTable;

                case 9:
                    firstOplataTable = GetPromFirstDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month1OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month2OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[1], connectionString, codeTp);
                    month3OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[2], connectionString, codeTp);
                    month4OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[3], connectionString, codeTp);
                    month5OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[4], connectionString, codeTp);
                    month6OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[5], connectionString, codeTp);
                    month7OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[6], connectionString, codeTp);
                    month8OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[7], connectionString, codeTp);
                    month9OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[8], connectionString, codeTp);


                    var query9Month = from firstTable in firstOplataTable.AsEnumerable()
                                      join month1Oplata in month1OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      } equals new
                                      {
                                          kp = month1Oplata.Field<string>("KP"),
                                          nab = month1Oplata.Field<string>("NAB"),
                                          ktu = month1Oplata.Field<string>("KTU"),
                                          kodtp = month1Oplata.Field<string>("KODTP")
                                      }
                                           into temp1
                                      from t1 in temp1.DefaultIfEmpty()
                                      join month2Oplata in month2OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month2Oplata.Field<string>("KP"),
                                          nab = month2Oplata.Field<string>("NAB"),
                                          ktu = month2Oplata.Field<string>("KTU"),
                                          kodtp = month2Oplata.Field<string>("KODTP")
                                      }
                                           into temp2
                                      from t2 in temp2.DefaultIfEmpty()
                                      join month3Oplata in month3OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month3Oplata.Field<string>("KP"),
                                          nab = month3Oplata.Field<string>("NAB"),
                                          ktu = month3Oplata.Field<string>("KTU"),
                                          kodtp = month3Oplata.Field<string>("KODTP")
                                      }
                                           into temp3
                                      from t3 in temp3.DefaultIfEmpty()
                                      join month4Oplata in month4OplataTable.AsEnumerable()
                                    on new
                                    {
                                        kp = firstTable.Field<string>("KP"),
                                        nab = firstTable.Field<string>("NAB"),
                                        ktu = firstTable.Field<string>("KTU"),
                                        kodtp = firstTable.Field<string>("KODTP")
                                    }
                                     equals new
                                     {
                                         kp = month4Oplata.Field<string>("KP"),
                                         nab = month4Oplata.Field<string>("NAB"),
                                         ktu = month4Oplata.Field<string>("KTU"),
                                         kodtp = month4Oplata.Field<string>("KODTP")
                                     }
                                          into temp4
                                      from t4 in temp4.DefaultIfEmpty()
                                      join month5Oplata in month5OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month5Oplata.Field<string>("KP"),
                                          nab = month5Oplata.Field<string>("NAB"),
                                          ktu = month5Oplata.Field<string>("KTU"),
                                          kodtp = month5Oplata.Field<string>("KODTP")
                                      }
                                           into temp5
                                      from t5 in temp5.DefaultIfEmpty()
                                      join month6Oplata in month6OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month6Oplata.Field<string>("KP"),
                                          nab = month6Oplata.Field<string>("NAB"),
                                          ktu = month6Oplata.Field<string>("KTU"),
                                          kodtp = month6Oplata.Field<string>("KODTP")
                                      }
                                           into temp6
                                      from t6 in temp6.DefaultIfEmpty()
                                      join month7Oplata in month7OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month7Oplata.Field<string>("KP"),
                                          nab = month7Oplata.Field<string>("NAB"),
                                          ktu = month7Oplata.Field<string>("KTU"),
                                          kodtp = month7Oplata.Field<string>("KODTP")
                                      }
                                           into temp7
                                      from t7 in temp7.DefaultIfEmpty()
                                      join month8Oplata in month8OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month8Oplata.Field<string>("KP"),
                                          nab = month8Oplata.Field<string>("NAB"),
                                          ktu = month8Oplata.Field<string>("KTU"),
                                          kodtp = month8Oplata.Field<string>("KODTP")
                                      }
                                           into temp8
                                      from t8 in temp8.DefaultIfEmpty()
                                      join month9Oplata in month9OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month9Oplata.Field<string>("KP"),
                                          nab = month9Oplata.Field<string>("NAB"),
                                          ktu = month9Oplata.Field<string>("KTU"),
                                          kodtp = month9Oplata.Field<string>("KODTP")
                                      }
                                           into temp9
                                      from t9 in temp9.DefaultIfEmpty()
                                      select new
                                      {
                                          KP = firstTable.Field<string>("KP"),
                                          N1 = firstTable.Field<string>("N1"),
                                          N2 = firstTable.Field<string>("N2"),
                                          N3 = firstTable.Field<string>("N3"),
                                          NST = firstTable.Field<string>("NST"),
                                          TIPSCH = firstTable.Field<string>("TIPSCH"),
                                          TPOK = firstTable.Field<string>("TPOK"),
                                          KTT = firstTable.Field<string>("KTT"),
                                          month1Oplata = t1 == null ? string.Empty : t1.Field<string>(promMonthYearTablesList[0]),
                                          month2Oplata = t2 == null ? string.Empty : t2.Field<string>(promMonthYearTablesList[1]),
                                          month3Oplata = t3 == null ? string.Empty : t3.Field<string>(promMonthYearTablesList[2]),
                                          month4Oplata = t4 == null ? string.Empty : t4.Field<string>(promMonthYearTablesList[3]),
                                          month5Oplata = t5 == null ? string.Empty : t5.Field<string>(promMonthYearTablesList[4]),
                                          month6Oplata = t6 == null ? string.Empty : t6.Field<string>(promMonthYearTablesList[5]),
                                          month7Oplata = t7 == null ? string.Empty : t7.Field<string>(promMonthYearTablesList[6]),
                                          month8Oplata = t8 == null ? string.Empty : t8.Field<string>(promMonthYearTablesList[7]),
                                          month9Oplata = t9 == null ? string.Empty : t9.Field<string>(promMonthYearTablesList[8])
                                      };

                    DataTable resultMonth9OplataTable = LINQtoDataSetMethods.CopyToDataTable(query9Month);
                    return resultMonth9OplataTable;

                case 10:
                    firstOplataTable = GetPromFirstDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month1OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month2OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[1], connectionString, codeTp);
                    month3OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[2], connectionString, codeTp);
                    month4OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[3], connectionString, codeTp);
                    month5OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[4], connectionString, codeTp);
                    month6OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[5], connectionString, codeTp);
                    month7OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[6], connectionString, codeTp);
                    month8OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[7], connectionString, codeTp);
                    month9OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[8], connectionString, codeTp);
                    month10OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[9], connectionString, codeTp);


                    var query10Month = from firstTable in firstOplataTable.AsEnumerable()
                                      join month1Oplata in month1OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      } equals new
                                      {
                                          kp = month1Oplata.Field<string>("KP"),
                                          nab = month1Oplata.Field<string>("NAB"),
                                          ktu = month1Oplata.Field<string>("KTU"),
                                          kodtp = month1Oplata.Field<string>("KODTP")
                                      }
                                            into temp1
                                       from t1 in temp1.DefaultIfEmpty()
                                      join month2Oplata in month2OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month2Oplata.Field<string>("KP"),
                                          nab = month2Oplata.Field<string>("NAB"),
                                          ktu = month2Oplata.Field<string>("KTU"),
                                          kodtp = month2Oplata.Field<string>("KODTP")
                                      }
                                            into temp2
                                       from t2 in temp2.DefaultIfEmpty()
                                      join month3Oplata in month3OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month3Oplata.Field<string>("KP"),
                                          nab = month3Oplata.Field<string>("NAB"),
                                          ktu = month3Oplata.Field<string>("KTU"),
                                          kodtp = month3Oplata.Field<string>("KODTP")
                                      }
                                            into temp3
                                       from t3 in temp3.DefaultIfEmpty()
                                      join month4Oplata in month4OplataTable.AsEnumerable()
                                    on new
                                    {
                                        kp = firstTable.Field<string>("KP"),
                                        nab = firstTable.Field<string>("NAB"),
                                        ktu = firstTable.Field<string>("KTU"),
                                        kodtp = firstTable.Field<string>("KODTP")
                                    }
                                     equals new
                                     {
                                         kp = month4Oplata.Field<string>("KP"),
                                         nab = month4Oplata.Field<string>("NAB"),
                                         ktu = month4Oplata.Field<string>("KTU"),
                                         kodtp = month4Oplata.Field<string>("KODTP")
                                     }
                                           into temp4
                                       from t4 in temp4.DefaultIfEmpty()
                                      join month5Oplata in month5OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month5Oplata.Field<string>("KP"),
                                          nab = month5Oplata.Field<string>("NAB"),
                                          ktu = month5Oplata.Field<string>("KTU"),
                                          kodtp = month5Oplata.Field<string>("KODTP")
                                      }
                                            into temp5
                                       from t5 in temp5.DefaultIfEmpty()
                                      join month6Oplata in month6OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month6Oplata.Field<string>("KP"),
                                          nab = month6Oplata.Field<string>("NAB"),
                                          ktu = month6Oplata.Field<string>("KTU"),
                                          kodtp = month6Oplata.Field<string>("KODTP")
                                      }
                                            into temp6
                                       from t6 in temp6.DefaultIfEmpty()
                                      join month7Oplata in month7OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month7Oplata.Field<string>("KP"),
                                          nab = month7Oplata.Field<string>("NAB"),
                                          ktu = month7Oplata.Field<string>("KTU"),
                                          kodtp = month7Oplata.Field<string>("KODTP")
                                      }
                                            into temp7
                                       from t7 in temp7.DefaultIfEmpty()
                                      join month8Oplata in month8OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month8Oplata.Field<string>("KP"),
                                          nab = month8Oplata.Field<string>("NAB"),
                                          ktu = month8Oplata.Field<string>("KTU"),
                                          kodtp = month8Oplata.Field<string>("KODTP")
                                      }
                                            into temp8
                                       from t8 in temp8.DefaultIfEmpty()
                                      join month9Oplata in month9OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month9Oplata.Field<string>("KP"),
                                          nab = month9Oplata.Field<string>("NAB"),
                                          ktu = month9Oplata.Field<string>("KTU"),
                                          kodtp = month9Oplata.Field<string>("KODTP")
                                      }
                                            into temp9
                                       from t9 in temp9.DefaultIfEmpty()
                                       join month10Oplata in month10OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month10Oplata.Field<string>("KP"),
                                           nab = month10Oplata.Field<string>("NAB"),
                                           ktu = month10Oplata.Field<string>("KTU"),
                                           kodtp = month10Oplata.Field<string>("KODTP")
                                       }
                                             into temp10
                                       from t10 in temp10.DefaultIfEmpty()
                                      select new
                                      {
                                          KP = firstTable.Field<string>("KP"),
                                          N1 = firstTable.Field<string>("N1"),
                                          N2 = firstTable.Field<string>("N2"),
                                          N3 = firstTable.Field<string>("N3"),
                                          NST = firstTable.Field<string>("NST"),
                                          TIPSCH = firstTable.Field<string>("TIPSCH"),
                                          TPOK = firstTable.Field<string>("TPOK"),
                                          KTT = firstTable.Field<string>("KTT"),
                                          month1Oplata = t1 == null ? string.Empty : t1.Field<string>(promMonthYearTablesList[0]),
                                          month2Oplata = t2 == null ? string.Empty : t2.Field<string>(promMonthYearTablesList[1]),
                                          month3Oplata = t3 == null ? string.Empty : t3.Field<string>(promMonthYearTablesList[2]),
                                          month4Oplata = t4 == null ? string.Empty : t4.Field<string>(promMonthYearTablesList[3]),
                                          month5Oplata = t5 == null ? string.Empty : t5.Field<string>(promMonthYearTablesList[4]),
                                          month6Oplata = t6 == null ? string.Empty : t6.Field<string>(promMonthYearTablesList[5]),
                                          month7Oplata = t7 == null ? string.Empty : t7.Field<string>(promMonthYearTablesList[6]),
                                          month8Oplata = t8 == null ? string.Empty : t8.Field<string>(promMonthYearTablesList[7]),
                                          month9Oplata = t9 == null ? string.Empty : t9.Field<string>(promMonthYearTablesList[8]),
                                          month10Oplata = t10 == null ? string.Empty : t10.Field<string>(promMonthYearTablesList[9])
                                      };

                    DataTable resultMonth10OplataTable = LINQtoDataSetMethods.CopyToDataTable(query10Month);
                    return resultMonth10OplataTable;

                case 11:
                    firstOplataTable = GetPromFirstDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month1OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month2OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[1], connectionString, codeTp);
                    month3OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[2], connectionString, codeTp);
                    month4OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[3], connectionString, codeTp);
                    month5OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[4], connectionString, codeTp);
                    month6OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[5], connectionString, codeTp);
                    month7OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[6], connectionString, codeTp);
                    month8OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[7], connectionString, codeTp);
                    month9OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[8], connectionString, codeTp);
                    month10OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[9], connectionString, codeTp);
                    month11OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[10], connectionString, codeTp);


                    var query11Month = from firstTable in firstOplataTable.AsEnumerable()
                                       join month1Oplata in month1OplataTable.AsEnumerable()
                                       on new
                                       {
                                           kp = firstTable.Field<string>("KP"),
                                           nab = firstTable.Field<string>("NAB"),
                                           ktu = firstTable.Field<string>("KTU"),
                                           kodtp = firstTable.Field<string>("KODTP")
                                       } equals new
                                       {
                                           kp = month1Oplata.Field<string>("KP"),
                                           nab = month1Oplata.Field<string>("NAB"),
                                           ktu = month1Oplata.Field<string>("KTU"),
                                           kodtp = month1Oplata.Field<string>("KODTP")
                                       }
                                             into temp1
                                       from t1 in temp1.DefaultIfEmpty()
                                       join month2Oplata in month2OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month2Oplata.Field<string>("KP"),
                                           nab = month2Oplata.Field<string>("NAB"),
                                           ktu = month2Oplata.Field<string>("KTU"),
                                           kodtp = month2Oplata.Field<string>("KODTP")
                                       }
                                             into temp2
                                       from t2 in temp2.DefaultIfEmpty()
                                       join month3Oplata in month3OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month3Oplata.Field<string>("KP"),
                                           nab = month3Oplata.Field<string>("NAB"),
                                           ktu = month3Oplata.Field<string>("KTU"),
                                           kodtp = month3Oplata.Field<string>("KODTP")
                                       }
                                             into temp3
                                       from t3 in temp3.DefaultIfEmpty()
                                       join month4Oplata in month4OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month4Oplata.Field<string>("KP"),
                                          nab = month4Oplata.Field<string>("NAB"),
                                          ktu = month4Oplata.Field<string>("KTU"),
                                          kodtp = month4Oplata.Field<string>("KODTP")
                                      }
                                            into temp4
                                       from t4 in temp4.DefaultIfEmpty()
                                       join month5Oplata in month5OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month5Oplata.Field<string>("KP"),
                                           nab = month5Oplata.Field<string>("NAB"),
                                           ktu = month5Oplata.Field<string>("KTU"),
                                           kodtp = month5Oplata.Field<string>("KODTP")
                                       }
                                             into temp5
                                       from t5 in temp5.DefaultIfEmpty()
                                       join month6Oplata in month6OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month6Oplata.Field<string>("KP"),
                                           nab = month6Oplata.Field<string>("NAB"),
                                           ktu = month6Oplata.Field<string>("KTU"),
                                           kodtp = month6Oplata.Field<string>("KODTP")
                                       }
                                             into temp6
                                       from t6 in temp6.DefaultIfEmpty()
                                       join month7Oplata in month7OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month7Oplata.Field<string>("KP"),
                                           nab = month7Oplata.Field<string>("NAB"),
                                           ktu = month7Oplata.Field<string>("KTU"),
                                           kodtp = month7Oplata.Field<string>("KODTP")
                                       }
                                             into temp7
                                       from t7 in temp7.DefaultIfEmpty()
                                       join month8Oplata in month8OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month8Oplata.Field<string>("KP"),
                                           nab = month8Oplata.Field<string>("NAB"),
                                           ktu = month8Oplata.Field<string>("KTU"),
                                           kodtp = month8Oplata.Field<string>("KODTP")
                                       }
                                             into temp8
                                       from t8 in temp8.DefaultIfEmpty()
                                       join month9Oplata in month9OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month9Oplata.Field<string>("KP"),
                                           nab = month9Oplata.Field<string>("NAB"),
                                           ktu = month9Oplata.Field<string>("KTU"),
                                           kodtp = month9Oplata.Field<string>("KODTP")
                                       }
                                             into temp9
                                       from t9 in temp9.DefaultIfEmpty()
                                       join month10Oplata in month10OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month10Oplata.Field<string>("KP"),
                                           nab = month10Oplata.Field<string>("NAB"),
                                           ktu = month10Oplata.Field<string>("KTU"),
                                           kodtp = month10Oplata.Field<string>("KODTP")
                                       }
                                             into temp10
                                       from t10 in temp10.DefaultIfEmpty()
                                       join month11Oplata in month11OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month11Oplata.Field<string>("KP"),
                                           nab = month11Oplata.Field<string>("NAB"),
                                           ktu = month11Oplata.Field<string>("KTU"),
                                           kodtp = month11Oplata.Field<string>("KODTP")
                                       }
                                             into temp11
                                       from t11 in temp11.DefaultIfEmpty()
                                       select new
                                       {
                                           KP = firstTable.Field<string>("KP"),
                                           N1 = firstTable.Field<string>("N1"),
                                           N2 = firstTable.Field<string>("N2"),
                                           N3 = firstTable.Field<string>("N3"),
                                           NST = firstTable.Field<string>("NST"),
                                           TIPSCH = firstTable.Field<string>("TIPSCH"),
                                           TPOK = firstTable.Field<string>("TPOK"),
                                           KTT = firstTable.Field<string>("KTT"),
                                           month1Oplata = t1 == null ? string.Empty : t1.Field<string>(promMonthYearTablesList[0]),
                                           month2Oplata = t2 == null ? string.Empty : t2.Field<string>(promMonthYearTablesList[1]),
                                           month3Oplata = t3 == null ? string.Empty : t3.Field<string>(promMonthYearTablesList[2]),
                                           month4Oplata = t4 == null ? string.Empty : t4.Field<string>(promMonthYearTablesList[3]),
                                           month5Oplata = t5 == null ? string.Empty : t5.Field<string>(promMonthYearTablesList[4]),
                                           month6Oplata = t6 == null ? string.Empty : t6.Field<string>(promMonthYearTablesList[5]),
                                           month7Oplata = t7 == null ? string.Empty : t7.Field<string>(promMonthYearTablesList[6]),
                                           month8Oplata = t8 == null ? string.Empty : t8.Field<string>(promMonthYearTablesList[7]),
                                           month9Oplata = t9 == null ? string.Empty : t9.Field<string>(promMonthYearTablesList[8]),
                                           month10Oplata = t10 == null ? string.Empty : t10.Field<string>(promMonthYearTablesList[9]),
                                           month11Oplata = t11 == null ? string.Empty : t11.Field<string>(promMonthYearTablesList[10])
                                       };

                    DataTable resultMonth11OplataTable = LINQtoDataSetMethods.CopyToDataTable(query11Month);
                    return resultMonth11OplataTable;

                case 12:
                    firstOplataTable = GetPromFirstDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month1OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[0], connectionString, codeTp);
                    month2OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[1], connectionString, codeTp);
                    month3OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[2], connectionString, codeTp);
                    month4OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[3], connectionString, codeTp);
                    month5OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[4], connectionString, codeTp);
                    month6OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[5], connectionString, codeTp);
                    month7OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[6], connectionString, codeTp);
                    month8OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[7], connectionString, codeTp);
                    month9OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[8], connectionString, codeTp);
                    month10OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[9], connectionString, codeTp);
                    month11OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[10], connectionString, codeTp);
                    month12OplataTable = GetPromOplatiDataTableTP(promMonthYearTablesList[11], connectionString, codeTp);


                    var query12Month = from firstTable in firstOplataTable.AsEnumerable()
                                       join month1Oplata in month1OplataTable.AsEnumerable()
                                       on new
                                       {
                                           kp = firstTable.Field<string>("KP"),
                                           nab = firstTable.Field<string>("NAB"),
                                           ktu = firstTable.Field<string>("KTU"),
                                           kodtp = firstTable.Field<string>("KODTP")
                                       } equals new
                                       {
                                           kp = month1Oplata.Field<string>("KP"),
                                           nab = month1Oplata.Field<string>("NAB"),
                                           ktu = month1Oplata.Field<string>("KTU"),
                                           kodtp = month1Oplata.Field<string>("KODTP")
                                       }
                                                into temp1
                                       from t1 in temp1.DefaultIfEmpty()
                                       join month2Oplata in month2OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month2Oplata.Field<string>("KP"),
                                           nab = month2Oplata.Field<string>("NAB"),
                                           ktu = month2Oplata.Field<string>("KTU"),
                                           kodtp = month2Oplata.Field<string>("KODTP")
                                       }
                                                into temp2
                                       from t2 in temp2.DefaultIfEmpty()
                                       join month3Oplata in month3OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month3Oplata.Field<string>("KP"),
                                           nab = month3Oplata.Field<string>("NAB"),
                                           ktu = month3Oplata.Field<string>("KTU"),
                                           kodtp = month3Oplata.Field<string>("KODTP")
                                       }
                                                into temp3
                                       from t3 in temp3.DefaultIfEmpty()
                                       join month4Oplata in month4OplataTable.AsEnumerable()
                                     on new
                                     {
                                         kp = firstTable.Field<string>("KP"),
                                         nab = firstTable.Field<string>("NAB"),
                                         ktu = firstTable.Field<string>("KTU"),
                                         kodtp = firstTable.Field<string>("KODTP")
                                     }
                                      equals new
                                      {
                                          kp = month4Oplata.Field<string>("KP"),
                                          nab = month4Oplata.Field<string>("NAB"),
                                          ktu = month4Oplata.Field<string>("KTU"),
                                          kodtp = month4Oplata.Field<string>("KODTP")
                                      }
                                               into temp4
                                       from t4 in temp4.DefaultIfEmpty()
                                       join month5Oplata in month5OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month5Oplata.Field<string>("KP"),
                                           nab = month5Oplata.Field<string>("NAB"),
                                           ktu = month5Oplata.Field<string>("KTU"),
                                           kodtp = month5Oplata.Field<string>("KODTP")
                                       }
                                                into temp5
                                       from t5 in temp5.DefaultIfEmpty()
                                       join month6Oplata in month6OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month6Oplata.Field<string>("KP"),
                                           nab = month6Oplata.Field<string>("NAB"),
                                           ktu = month6Oplata.Field<string>("KTU"),
                                           kodtp = month6Oplata.Field<string>("KODTP")
                                       }
                                                into temp6
                                       from t6 in temp6.DefaultIfEmpty()
                                       join month7Oplata in month7OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month7Oplata.Field<string>("KP"),
                                           nab = month7Oplata.Field<string>("NAB"),
                                           ktu = month7Oplata.Field<string>("KTU"),
                                           kodtp = month7Oplata.Field<string>("KODTP")
                                       }
                                                into temp7
                                       from t7 in temp7.DefaultIfEmpty()
                                       join month8Oplata in month8OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month8Oplata.Field<string>("KP"),
                                           nab = month8Oplata.Field<string>("NAB"),
                                           ktu = month8Oplata.Field<string>("KTU"),
                                           kodtp = month8Oplata.Field<string>("KODTP")
                                       }
                                                into temp8
                                       from t8 in temp8.DefaultIfEmpty()
                                       join month9Oplata in month9OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month9Oplata.Field<string>("KP"),
                                           nab = month9Oplata.Field<string>("NAB"),
                                           ktu = month9Oplata.Field<string>("KTU"),
                                           kodtp = month9Oplata.Field<string>("KODTP")
                                       }
                                                into temp9
                                       from t9 in temp9.DefaultIfEmpty()
                                       join month10Oplata in month10OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month10Oplata.Field<string>("KP"),
                                           nab = month10Oplata.Field<string>("NAB"),
                                           ktu = month10Oplata.Field<string>("KTU"),
                                           kodtp = month10Oplata.Field<string>("KODTP")
                                       }
                                                into temp10
                                       from t10 in temp10.DefaultIfEmpty()
                                       join month11Oplata in month11OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month11Oplata.Field<string>("KP"),
                                           nab = month11Oplata.Field<string>("NAB"),
                                           ktu = month11Oplata.Field<string>("KTU"),
                                           kodtp = month11Oplata.Field<string>("KODTP")
                                       }
                                                into temp11
                                       from t11 in temp11.DefaultIfEmpty()
                                       join month12Oplata in month12OplataTable.AsEnumerable()
                                      on new
                                      {
                                          kp = firstTable.Field<string>("KP"),
                                          nab = firstTable.Field<string>("NAB"),
                                          ktu = firstTable.Field<string>("KTU"),
                                          kodtp = firstTable.Field<string>("KODTP")
                                      }
                                       equals new
                                       {
                                           kp = month12Oplata.Field<string>("KP"),
                                           nab = month12Oplata.Field<string>("NAB"),
                                           ktu = month12Oplata.Field<string>("KTU"),
                                           kodtp = month12Oplata.Field<string>("KODTP")
                                       }
                                                into temp12
                                       from t12 in temp12.DefaultIfEmpty()
                                       select new
                                       {
                                           KP = firstTable.Field<string>("KP"),
                                           N1 = firstTable.Field<string>("N1"),
                                           N2 = firstTable.Field<string>("N2"),
                                           N3 = firstTable.Field<string>("N3"),
                                           NST = firstTable.Field<string>("NST"),
                                           TIPSCH = firstTable.Field<string>("TIPSCH"),
                                           TPOK = firstTable.Field<string>("TPOK"),
                                           KTT = firstTable.Field<string>("KTT"),
                                           month1Oplata = t1 == null ? string.Empty : t1.Field<string>(promMonthYearTablesList[0]),
                                           month2Oplata = t2 == null ? string.Empty : t2.Field<string>(promMonthYearTablesList[1]),
                                           month3Oplata = t3 == null ? string.Empty : t3.Field<string>(promMonthYearTablesList[2]),
                                           month4Oplata = t4 == null ? string.Empty : t4.Field<string>(promMonthYearTablesList[3]),
                                           month5Oplata = t5 == null ? string.Empty : t5.Field<string>(promMonthYearTablesList[4]),
                                           month6Oplata = t6 == null ? string.Empty : t6.Field<string>(promMonthYearTablesList[5]),
                                           month7Oplata = t7 == null ? string.Empty : t7.Field<string>(promMonthYearTablesList[6]),
                                           month8Oplata = t8 == null ? string.Empty : t8.Field<string>(promMonthYearTablesList[7]),
                                           month9Oplata = t9 == null ? string.Empty : t9.Field<string>(promMonthYearTablesList[8]),
                                           month10Oplata = t10 == null ? string.Empty : t10.Field<string>(promMonthYearTablesList[9]),
                                           month11Oplata = t11 == null ? string.Empty : t11.Field<string>(promMonthYearTablesList[10]),
                                           month12Oplata = t12 == null ? string.Empty : t12.Field<string>(promMonthYearTablesList[11])
                                       };

                    DataTable resultMonth12OplataTable = LINQtoDataSetMethods.CopyToDataTable(query12Month);
                    return resultMonth12OplataTable;


                default:
                    return new DataTable();
            }
        }
        













        /*

        public DataTable PromGetOraTable(string sql, string connectionString, string resName)
        {

            DataTable resultDataTable = new DataTable();

            OracleConnection connect = new OracleConnection(connectionString);
            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.CommandType = CommandType.Text;
            command.Connection = connect;

            OracleDataAdapter OraDa = new OracleDataAdapter(command.CommandText, connect);

            try
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Получение данных из ORACLE для {1} по запросу:{0} ", command.CommandText, resName)));
                OraDa.Fill(resultDataTable);

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex)));
            }

            return resultDataTable;


        }

        public DataTable BytGetOraTable(string sql, string connectionString, string resName)
        {

            DataTable resultDataTable = new DataTable();

            OracleConnection connect = new OracleConnection(connectionString);
            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.CommandType = CommandType.Text;
            command.Connection = connect;

            OracleDataAdapter OraDa = new OracleDataAdapter(command.CommandText, connect);

            try
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Получение данных из ORACLE для {1} по запросу:{0} ", command.CommandText, resName)));
                OraDa.Fill(resultDataTable);

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Ошибка выполнения: '{0}'", ex)));
            }

            return resultDataTable;


        }

        public string FormSqlProm(List<string> listTables,  string tpCode)
        {

            string SQL = string.Empty;
           

                if (listTables.Count == 1)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT KP, N1, N2, N3, NST, TIPSCH, TPOK, KTT, (OTPUSK + POTERI) AS Month1Oplata FROM " + listTables[0] + " WHERE KODTP = '" + tpCode +"'");
                    SQL = sql.ToString();
                }


                else if (listTables.Count == 2)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0] + ".kp," + listTables[0] + ".N1," + listTables[0] + ".N2," + listTables[0] + ".N3," + listTables[0] + ".NST," + listTables[0] + ".TIPSCH," + listTables[0] + ".TPOK," + listTables[0] + ".KTT," + "(" + listTables[0] + ".OTPUSK +" + listTables[0] + ".POTERI) AS Month1Oplata");
                    sql.Append(",(" + listTables[1] + ".OTPUSK +" + listTables[1] + ".POTERI) AS Month2Oplata");
                    sql.Append(" FROM " + listTables[0] + " full join " + listTables[1]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".KP = " + listTables[1] + ".KP");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".NAB = " + listTables[1] + ".NAB");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KTU = " + listTables[1] + ".KTU");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KODTP = " + listTables[1] + ".KODTP");

                    sql.Append(" WHERE ");
                    sql.Append(listTables[0] + ".KODTP = '" + tpCode +"'");
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 3)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0] + ".kp," + listTables[0] + ".N1," + listTables[0] + ".N2," + listTables[0] + ".N3," + listTables[0] + ".NST," + listTables[0] + ".TIPSCH," + listTables[0] + ".TPOK," + listTables[0] + ".KTT,");
                    sql.Append("(" + listTables[0] + ".OTPUSK +" + listTables[0] + ".POTERI) AS Month1Oplata,");
                    sql.Append("(" + listTables[1] + ".OTPUSK +" + listTables[1] + ".POTERI) AS Month2Oplata,");
                    sql.Append("(" + listTables[2] + ".OTPUSK +" + listTables[2] + ".POTERI) AS Month3Oplata");

                    sql.Append(" FROM " + listTables[0] + " full join " + listTables[1]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".KP = " + listTables[1] + ".KP");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".NAB = " + listTables[1] + ".NAB");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KTU = " + listTables[1] + ".KTU");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KODTP = " + listTables[1] + ".KODTP");

                    sql.Append(" full join " + listTables[2]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".KP = " + listTables[2] + ".KP");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".NAB = " + listTables[2] + ".NAB");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KTU = " + listTables[2] + ".KTU");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KODTP = " + listTables[2] + ".KODTP");

                    sql.Append(" WHERE ");
                    sql.Append(listTables[0] + ".KODTP = '" + tpCode +"'");
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 4)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0] + ".kp," + listTables[0] + ".N1," + listTables[0] + ".N2," + listTables[0] + ".N3," + listTables[0] + ".NST," + listTables[0] + ".TIPSCH," + listTables[0] + ".TPOK," + listTables[0] + ".KTT,");
                    sql.Append("(" + listTables[0] + ".OTPUSK +" + listTables[0] + ".POTERI) AS Month1Oplata,");
                    sql.Append("(" + listTables[1] + ".OTPUSK +" + listTables[1] + ".POTERI) AS Month2Oplata,");
                    sql.Append("(" + listTables[2] + ".OTPUSK +" + listTables[2] + ".POTERI) AS Month3Oplata,");
                    sql.Append("(" + listTables[3] + ".OTPUSK +" + listTables[3] + ".POTERI) AS Month4Oplata");

                    sql.Append(" FROM " + listTables[0] + " full join " + listTables[1]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".KP = " + listTables[1] + ".KP");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".NAB = " + listTables[1] + ".NAB");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KTU = " + listTables[1] + ".KTU");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KODTP = " + listTables[1] + ".KODTP");

                    sql.Append(" full join " + listTables[2]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".KP = " + listTables[2] + ".KP");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".NAB = " + listTables[2] + ".NAB");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KTU = " + listTables[2] + ".KTU");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KODTP = " + listTables[2] + ".KODTP");

                    sql.Append(" full join " + listTables[3]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".KP = " + listTables[3] + ".KP");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".NAB = " + listTables[3] + ".NAB");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KTU = " + listTables[3] + ".KTU");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KODTP = " + listTables[3] + ".KODTP");

                    sql.Append(" WHERE ");
                    sql.Append(listTables[0] + ".KODTP = '" + tpCode +"'");
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 5)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0] + ".kp," + listTables[0] + ".N1," + listTables[0] + ".N2," + listTables[0] + ".N3," + listTables[0] + ".NST," + listTables[0] + ".TIPSCH," + listTables[0] + ".TPOK," + listTables[0] + ".KTT,");
                    sql.Append("(" + listTables[0] + ".OTPUSK +" + listTables[0] + ".POTERI) AS Month1Oplata,");
                    sql.Append("(" + listTables[1] + ".OTPUSK +" + listTables[1] + ".POTERI) AS Month2Oplata,");
                    sql.Append("(" + listTables[2] + ".OTPUSK +" + listTables[2] + ".POTERI) AS Month3Oplata,");
                    sql.Append("(" + listTables[3] + ".OTPUSK +" + listTables[3] + ".POTERI) AS Month4Oplata,");
                    sql.Append("(" + listTables[4] + ".OTPUSK +" + listTables[4] + ".POTERI) AS Month5Oplata");
                    sql.Append(" FROM " + listTables[0] + " full join " + listTables[1]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".KP = " + listTables[1] + ".KP");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".NAB = " + listTables[1] + ".NAB");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KTU = " + listTables[1] + ".KTU");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KODTP = " + listTables[1] + ".KODTP");

                    sql.Append(" full join " + listTables[2]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".KP = " + listTables[2] + ".KP");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".NAB = " + listTables[2] + ".NAB");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KTU = " + listTables[2] + ".KTU");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KODTP = " + listTables[2] + ".KODTP");

                    sql.Append(" full join " + listTables[3]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".KP = " + listTables[3] + ".KP");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".NAB = " + listTables[3] + ".NAB");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KTU = " + listTables[3] + ".KTU");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KODTP = " + listTables[3] + ".KODTP");

                    sql.Append(" full join " + listTables[4]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".KP = " + listTables[4] + ".KP");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".NAB = " + listTables[4] + ".NAB");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KTU = " + listTables[4] + ".KTU");
                    sql.Append(" AND ");
                    sql.Append(listTables[0] + ".KODTP = " + listTables[4] + ".KODTP");

                    sql.Append(" WHERE ");
                    sql.Append(listTables[0] + ".KODTP = '" + tpCode +"'");
                    SQL = sql.ToString();
                }

            return SQL;
        }

        public string FormSqlByt(List<string> listTables, string tpName)
        {
            string SQL = string.Empty;
             
                if (listTables.Count == 1)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT AB_N as ABN, FIO, STREET.NAIM as STREET, Dom , Korp,Kvar ,KVT as Month1Oplata");
                    sql.Append(" FROM STREET FULL JOIN " + listTables[0]);
                    sql.Append(" ON " + listTables[0] + ".street  = STREET.nom");
                    sql.Append(" WHERE ");
                    sql.Append(listTables[0] + ".PRPLOM ='" + tpName +"'");
                    sql.Append(" ORDER BY " + listTables[0] + ".AB_N ");
                    SQL = sql.ToString();
                }


                else if (listTables.Count == 2)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0] + ".AB_N as ABN," + listTables[0] + ".FIO, STREET.NAIM as STREET," + listTables[0] + ".Dom," + listTables[0] + ".KORP,"+ listTables[0] + ".Kvar,");
                    sql.Append(listTables[0] + ".KVT as Month1Oplata,");
                    sql.Append(listTables[1] + ".KVT as Month2Oplata");
                    sql.Append(" FROM " + listTables[0] + " FULL JOIN " + listTables[1]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".ab_n = " + listTables[1] + ".ab_n");

                    sql.Append(" FULL JOIN STREET ");
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".street  = STREET.nom");

                    sql.Append(" WHERE ");
                    sql.Append(listTables[0] + ".PRPLOM ='" + tpName +"'");
                    sql.Append(" ORDER BY " + listTables[0] + ".AB_N ");
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 3)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0] + ".AB_N as ABN," + listTables[0] + ".FIO , STREET.NAIM as STREET," + listTables[0] + ".Dom ," + listTables[0] + ".KORP,"+ listTables[0] + ".Kvar ,");
                    sql.Append(listTables[0] + ".KVT as Month1Oplata,");
                    sql.Append(listTables[1] + ".KVT as Month2Oplata,");
                    sql.Append(listTables[2] + ".KVT as Month3Oplata");
                    sql.Append(" FROM " + listTables[0] + " FULL JOIN " + listTables[1]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".ab_n = " + listTables[1] + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[2]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".ab_n = " + listTables[2] + ".ab_n");

                    sql.Append(" FULL JOIN STREET");
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".street  = STREET.nom");


                    sql.Append(" WHERE ");
                    sql.Append(listTables[0] + ".PRPLOM ='" + tpName +"'");
                    sql.Append(" ORDER BY " + listTables[0] + ".AB_N ");
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 4)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0] + ".AB_N as ABN," + listTables[0] + ".FIO, STREET.NAIM as STREET," + listTables[0] + ".Dom ," + listTables[0] + ".KORP," + listTables[0] + ".Kvar ,");
                    sql.Append(listTables[0] + ".KVT as Month1Oplata,");
                    sql.Append(listTables[1] + ".KVT as Month2Oplata,");
                    sql.Append(listTables[2] + ".KVT as Month3Oplata,");
                    sql.Append(listTables[3] + ".KVT as Month4Oplata");

                    sql.Append(" FROM " + listTables[0] + " FULL JOIN " + listTables[1]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".ab_n = " + listTables[1] + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[2]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".ab_n = " + listTables[2] + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[3]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".ab_n = " + listTables[3] + ".ab_n");

                    sql.Append(" FULL JOIN STREET");
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".street  = STREET.nom");


                    sql.Append(" WHERE ");
                    sql.Append(listTables[0] + ".PRPLOM ='" + tpName +"'");
                    sql.Append(" ORDER BY " + listTables[0] + ".AB_N ");
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 5)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0] + ".AB_N as ABN," + listTables[0] + ".FIO , STREET.NAIM as STREET," + listTables[0] + ".Dom ," + listTables[0] + ".KORP," + listTables[0] + ".Kvar,");
                    sql.Append(listTables[0] + ".KVT as Month1Oplata,");
                    sql.Append(listTables[1] + ".KVT as Month2Oplata,");
                    sql.Append(listTables[2] + ".KVT as Month3Oplata,");
                    sql.Append(listTables[3] + ".KVT as Month4Oplata,");
                    sql.Append(listTables[4] + ".KVT as Month5Oplata");

                    sql.Append(" FROM " + listTables[0] + " FULL JOIN " + listTables[1]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".ab_n = " + listTables[1] + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[2]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".ab_n = " + listTables[2] + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[3]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".ab_n = " + listTables[3] + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[4]);
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".ab_n = " + listTables[4] + ".ab_n");

                    sql.Append(" FULL JOIN STREET");
                    sql.Append(" ON ");
                    sql.Append(listTables[0] + ".street  = STREET.nom");


                    sql.Append(" WHERE ");
                    sql.Append(listTables[0] + ".PRPLOM ='" + tpName +"'");
                    sql.Append(" ORDER BY " + listTables[0] + ".AB_N ");
                    SQL = sql.ToString();
                
            }
            return SQL;

        }

        */
    }
}
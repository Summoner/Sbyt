using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using Sbyt.LogsManagement;

namespace Sbyt.App_Service
{
    public class SearchOra
    {


        #region Instance
        private SearchOra() { }

        [ThreadStatic]
        private static SearchOra _instance;

        public static SearchOra Instance
        {
            get { return _instance ?? (_instance = new SearchOra()); }
        }
        #endregion

        private string formSQLProm(IList<string> listTables, string searchExpression)
        {
            string SQL;
            SQL = string.Empty;


            if (listTables.Count == 0)
            {
              
            }

            else if (listTables.Count == 1)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT KP as N_Дог, N1 as Плательщик, N2 as Абонент, N3 as Точка_учета, TP as ТП, (OTPUSK + POTERI) AS " + listTables[0].Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 5));
                    sql.Append(" FROM " + listTables[0]);
                    sql.Append(" WHERE ");
                    sql.Append(" UPPER(KP) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N1) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N2) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N3) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(TP) LIKE UPPER('%" + searchExpression + "%') ");
                    SQL = sql.ToString();
                }


                else if (listTables.Count == 2)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0] + ".kp as N_Дог," + listTables[0].ToString() + ".N1 as Плательщик," + listTables[0].ToString() + ".N2  as Абонент," + listTables[0].ToString() + ".N3 as Точка_учета," + listTables[0].ToString() + ".TP as ТП," + "(" + listTables[0].ToString() + ".OTPUSK +" + listTables[0].ToString() + ".POTERI) AS " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 5));
                    sql.Append(",(" + listTables[1] + ".OTPUSK +" + listTables[1].ToString() + ".POTERI) AS " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 5));
                    sql.Append(" FROM PROMETALON" + " full join " + listTables[0].ToString());
                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[0].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[0].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[0].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[0].ToString() + ".KODTP");
                    sql.Append(" full join " + listTables[1].ToString());
                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[1].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[1].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[1].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[1].ToString() + ".KODTP");



                    sql.Append(" WHERE ");

                    sql.Append(" UPPER(KP) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N1) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N2) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N3) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(TP) LIKE UPPER('%" + searchExpression + "%') ");
                  
                    //   Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 3)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".kp as N_Дог," + listTables[0].ToString() + ".N1 as Плательщик," + listTables[0].ToString() + ".N2 as Абонент," + listTables[0].ToString() + ".N3 as Точка_учета," + listTables[0].ToString() + ".TP as ТП,");
                    sql.Append("(" + listTables[0].ToString() + ".OTPUSK +" + listTables[0].ToString() + ".POTERI) AS " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[1].ToString() + ".OTPUSK +" + listTables[1].ToString() + ".POTERI) AS " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[2].ToString() + ".OTPUSK +" + listTables[2].ToString() + ".POTERI) AS " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 5));
                    sql.Append(" FROM PROMETALON" + " full join " + listTables[0].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[0].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[0].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[0].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[0].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[1].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[1].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[1].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[1].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[2].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[2].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[2].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[2].ToString() + ".KODTP");


                    sql.Append(" WHERE ");


                    sql.Append(" UPPER(KP) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N1) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N2) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N3) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(TP) LIKE UPPER('%" + searchExpression + "%') ");
                    //  Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 4)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".kp as N_Дог," + listTables[0].ToString() + ".N1 as Плательщик," + listTables[0].ToString() + ".N2 as Абонент," + listTables[0].ToString() + ".N3 as Точка_учета," + listTables[0].ToString() + ".TP as ТП,");
                    sql.Append("(" + listTables[0].ToString() + ".OTPUSK +" + listTables[0].ToString() + ".POTERI) AS " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[1].ToString() + ".OTPUSK +" + listTables[1].ToString() + ".POTERI) AS " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[2].ToString() + ".OTPUSK +" + listTables[2].ToString() + ".POTERI) AS " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[3].ToString() + ".OTPUSK +" + listTables[3].ToString() + ".POTERI) AS " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 5));
                    sql.Append(" FROM PROMETALON" + " full join " + listTables[0].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[0].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[0].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[0].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[0].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[1].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[1].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[1].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[1].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[2].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[2].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[2].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[2].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[3].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[3].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[3].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[3].ToString() + ".KODTP");

                    sql.Append(" WHERE ");


                    sql.Append(" UPPER(KP) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N1) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N2) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N3) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(TP) LIKE UPPER('%" + searchExpression + "%') ");
                    // Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 5)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".kp as N_Дог," + listTables[0].ToString() + ".N1 as Плательщик," + listTables[0].ToString() + ".N2 as Абонент," + listTables[0].ToString() + ".N3 as Точка_учета," + listTables[0].ToString() + ".TP as ТП,");
                    sql.Append("(" + listTables[0].ToString() + ".OTPUSK +" + listTables[0].ToString() + ".POTERI) AS " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[1].ToString() + ".OTPUSK +" + listTables[1].ToString() + ".POTERI) AS " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[2].ToString() + ".OTPUSK +" + listTables[2].ToString() + ".POTERI) AS " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[3].ToString() + ".OTPUSK +" + listTables[3].ToString() + ".POTERI) AS " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[4].ToString() + ".OTPUSK +" + listTables[4].ToString() + ".POTERI) AS " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 5));
                    sql.Append(" FROM PROMETALON" + " full join " + listTables[0].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[0].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[0].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[0].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[0].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[1].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[1].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[1].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[1].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[2].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[2].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[2].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[2].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[3].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[3].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[3].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[3].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[4].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[4].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[4].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[4].ToString() + ".KODTP");


                    sql.Append(" WHERE ");


                    sql.Append(" UPPER(KP) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N1) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N2) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N3) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(TP) LIKE UPPER('%" + searchExpression + "%') ");
                    //  Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 6)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".kp as N_Дог," + listTables[0].ToString() + ".N1 as Плательщик," + listTables[0].ToString() + ".N2 as Абонент," + listTables[0].ToString() + ".N3 as Точка_учета," + listTables[0].ToString() + ".TP as ТП,");
                    sql.Append("(" + listTables[0].ToString() + ".OTPUSK +" + listTables[0].ToString() + ".POTERI) AS " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[1].ToString() + ".OTPUSK +" + listTables[1].ToString() + ".POTERI) AS " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[2].ToString() + ".OTPUSK +" + listTables[2].ToString() + ".POTERI) AS " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[3].ToString() + ".OTPUSK +" + listTables[3].ToString() + ".POTERI) AS " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[4].ToString() + ".OTPUSK +" + listTables[4].ToString() + ".POTERI) AS " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[5].ToString() + ".OTPUSK +" + listTables[5].ToString() + ".POTERI) AS " + listTables[5].ToString().Remove(listTables[5].ToString().Length - 4, 2).Remove(0, 5));
                    sql.Append(" FROM PROMETALON" + " full join " + listTables[0].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[0].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[0].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[0].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[0].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[1].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[1].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[1].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[1].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[2].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[2].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[2].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[2].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[3].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[3].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[3].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[3].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[4].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[4].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[4].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[4].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[5].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[5].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[5].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[5].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[5].ToString() + ".KODTP");

                    sql.Append(" WHERE ");

                    sql.Append(" UPPER(KP) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N1) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N2) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N3) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(TP) LIKE UPPER('%" + searchExpression + "%') ");
                    //  Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 7)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".kp as N_Дог," + listTables[0].ToString() + ".N1 as Плательщик," + listTables[0].ToString() + ".N2 as Абонент," + listTables[0].ToString() + ".N3 as Точка_учета," + listTables[0].ToString() + ".TP as ТП,");
                    sql.Append("(" + listTables[0].ToString() + ".OTPUSK +" + listTables[0].ToString() + ".POTERI) AS " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[1].ToString() + ".OTPUSK +" + listTables[1].ToString() + ".POTERI) AS " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[2].ToString() + ".OTPUSK +" + listTables[2].ToString() + ".POTERI) AS " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[3].ToString() + ".OTPUSK +" + listTables[3].ToString() + ".POTERI) AS " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[4].ToString() + ".OTPUSK +" + listTables[4].ToString() + ".POTERI) AS " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[5].ToString() + ".OTPUSK +" + listTables[5].ToString() + ".POTERI) AS " + listTables[5].ToString().Remove(listTables[5].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[6].ToString() + ".OTPUSK +" + listTables[6].ToString() + ".POTERI) AS " + listTables[6].ToString().Remove(listTables[6].ToString().Length - 4, 2).Remove(0, 5));
                    sql.Append(" FROM PROMETALON" + " full join " + listTables[0].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[0].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[0].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[0].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[0].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[1].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[1].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[1].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[1].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[2].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[2].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[2].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[2].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[3].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[3].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[3].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[3].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[4].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[4].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[4].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[4].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[5].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[5].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[5].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[5].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[5].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[6].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[6].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[6].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[6].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[6].ToString() + ".KODTP");

                    sql.Append(" WHERE ");

                    sql.Append(" UPPER(KP) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N1) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N2) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N3) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(TP) LIKE UPPER('%" + searchExpression + "%') ");

                

                    // Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 8)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".kp as N_Дог," + listTables[0].ToString() + ".N1 as Плательщик," + listTables[0].ToString() + ".N2 as Абонент," + listTables[0].ToString() + ".N3 as Точка_учета," + listTables[0].ToString() + ".TP as ТП,");
                    sql.Append("(" + listTables[0].ToString() + ".OTPUSK +" + listTables[0].ToString() + ".POTERI) AS " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[1].ToString() + ".OTPUSK +" + listTables[1].ToString() + ".POTERI) AS " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[2].ToString() + ".OTPUSK +" + listTables[2].ToString() + ".POTERI) AS " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[3].ToString() + ".OTPUSK +" + listTables[3].ToString() + ".POTERI) AS " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[4].ToString() + ".OTPUSK +" + listTables[4].ToString() + ".POTERI) AS " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[5].ToString() + ".OTPUSK +" + listTables[5].ToString() + ".POTERI) AS " + listTables[5].ToString().Remove(listTables[5].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[6].ToString() + ".OTPUSK +" + listTables[6].ToString() + ".POTERI) AS " + listTables[6].ToString().Remove(listTables[6].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[7].ToString() + ".OTPUSK +" + listTables[7].ToString() + ".POTERI) AS " + listTables[7].ToString().Remove(listTables[7].ToString().Length - 4, 2).Remove(0, 5));
                    sql.Append(" FROM PROMETALON" + " full join " + listTables[0].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[0].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[0].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[0].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[0].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[1].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[1].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[1].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[1].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[2].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[2].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[2].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[2].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[3].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[3].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[3].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[3].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[4].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[4].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[4].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[4].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[5].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[5].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[5].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[5].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[5].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[6].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[6].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[6].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[6].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[6].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[7].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[7].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[7].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[7].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[7].ToString() + ".KODTP");



                    sql.Append(" WHERE ");

                    sql.Append(" UPPER(KP) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N1) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N2) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N3) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(TP) LIKE UPPER('%" + searchExpression + "%') ");

                    // Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 9)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".kp as N_Дог," + listTables[0].ToString() + ".N1 as Плательщик," + listTables[0].ToString() + ".N2 as Абонент," + listTables[0].ToString() + ".N3 as Точка_учета," + listTables[0].ToString() + ".TP as ТП,");
                    sql.Append("(" + listTables[0].ToString() + ".OTPUSK +" + listTables[0].ToString() + ".POTERI) AS " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[1].ToString() + ".OTPUSK +" + listTables[1].ToString() + ".POTERI) AS " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[2].ToString() + ".OTPUSK +" + listTables[2].ToString() + ".POTERI) AS " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[3].ToString() + ".OTPUSK +" + listTables[3].ToString() + ".POTERI) AS " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[4].ToString() + ".OTPUSK +" + listTables[4].ToString() + ".POTERI) AS " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[5].ToString() + ".OTPUSK +" + listTables[5].ToString() + ".POTERI) AS " + listTables[5].ToString().Remove(listTables[5].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[6].ToString() + ".OTPUSK +" + listTables[6].ToString() + ".POTERI) AS " + listTables[6].ToString().Remove(listTables[6].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[7].ToString() + ".OTPUSK +" + listTables[7].ToString() + ".POTERI) AS " + listTables[7].ToString().Remove(listTables[7].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[8].ToString() + ".OTPUSK +" + listTables[8].ToString() + ".POTERI) AS " + listTables[8].ToString().Remove(listTables[8].ToString().Length - 4, 2).Remove(0, 5));
                    sql.Append(" FROM PROMETALON" + " full join " + listTables[0].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[0].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[0].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[0].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[0].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[1].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[1].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[1].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[1].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[2].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[2].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[2].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[2].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[3].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[3].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[3].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[3].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[4].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[4].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[4].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[4].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[5].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[5].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[5].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[5].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[5].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[6].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[6].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[6].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[6].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[6].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[7].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[7].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[7].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[7].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[7].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[8].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[8].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[8].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[8].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[8].ToString() + ".KODTP");
                    sql.Append(" WHERE");

                    sql.Append(" UPPER(KP) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N1) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N2) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N3) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(TP) LIKE UPPER('%" + searchExpression + "%') ");       


                    //  Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 10)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".kp as N_Дог," + listTables[0].ToString() + ".N1 as Плательщик," + listTables[0].ToString() + ".N2 as Абонент," + listTables[0].ToString() + ".N3 as Точка_учета," + listTables[0].ToString() + ".TP as ТП,");
                    sql.Append("(" + listTables[0].ToString() + ".OTPUSK +" + listTables[0].ToString() + ".POTERI) AS " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[1].ToString() + ".OTPUSK +" + listTables[1].ToString() + ".POTERI) AS " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[2].ToString() + ".OTPUSK +" + listTables[2].ToString() + ".POTERI) AS " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[3].ToString() + ".OTPUSK +" + listTables[3].ToString() + ".POTERI) AS " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[4].ToString() + ".OTPUSK +" + listTables[4].ToString() + ".POTERI) AS " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[5].ToString() + ".OTPUSK +" + listTables[5].ToString() + ".POTERI) AS " + listTables[5].ToString().Remove(listTables[5].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[6].ToString() + ".OTPUSK +" + listTables[6].ToString() + ".POTERI) AS " + listTables[6].ToString().Remove(listTables[6].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[7].ToString() + ".OTPUSK +" + listTables[7].ToString() + ".POTERI) AS " + listTables[7].ToString().Remove(listTables[7].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[8].ToString() + ".OTPUSK +" + listTables[8].ToString() + ".POTERI) AS " + listTables[8].ToString().Remove(listTables[8].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[9].ToString() + ".OTPUSK +" + listTables[9].ToString() + ".POTERI) AS " + listTables[9].ToString().Remove(listTables[9].ToString().Length - 4, 2).Remove(0, 5));
                    sql.Append(" FROM PROMETALON" + " full join " + listTables[0].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[0].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[0].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[0].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[0].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[1].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[1].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[1].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[1].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[2].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[2].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[2].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[2].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[3].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[3].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[3].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[3].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[4].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[4].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[4].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[4].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[5].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[5].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[5].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[5].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[5].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[6].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[6].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[6].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[6].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[6].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[7].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[7].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[7].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[7].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[7].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[8].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[8].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[8].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[8].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[8].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[9].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[9].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[9].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[9].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[9].ToString() + ".KODTP");


                    sql.Append(" WHERE ");

                    sql.Append(" UPPER(KP) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N1) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N2) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N3) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(TP) LIKE UPPER('%" + searchExpression + "%') ");
                 
                    // Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 11)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".kp as N_Дог," + listTables[0].ToString() + ".N1 as Плательщик," + listTables[0].ToString() + ".N2 as Абонент," + listTables[0].ToString() + ".N3 as Точка_учета," + listTables[0].ToString() + ".TP as ТП,");
                    sql.Append("(" + listTables[0].ToString() + ".OTPUSK +" + listTables[0].ToString() + ".POTERI) AS " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[1].ToString() + ".OTPUSK +" + listTables[1].ToString() + ".POTERI) AS " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[2].ToString() + ".OTPUSK +" + listTables[2].ToString() + ".POTERI) AS " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[3].ToString() + ".OTPUSK +" + listTables[3].ToString() + ".POTERI) AS " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[4].ToString() + ".OTPUSK +" + listTables[4].ToString() + ".POTERI) AS " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[5].ToString() + ".OTPUSK +" + listTables[5].ToString() + ".POTERI) AS " + listTables[5].ToString().Remove(listTables[5].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[6].ToString() + ".OTPUSK +" + listTables[6].ToString() + ".POTERI) AS " + listTables[6].ToString().Remove(listTables[6].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[7].ToString() + ".OTPUSK +" + listTables[7].ToString() + ".POTERI) AS " + listTables[7].ToString().Remove(listTables[7].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[8].ToString() + ".OTPUSK +" + listTables[8].ToString() + ".POTERI) AS " + listTables[8].ToString().Remove(listTables[8].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[9].ToString() + ".OTPUSK +" + listTables[9].ToString() + ".POTERI) AS " + listTables[9].ToString().Remove(listTables[9].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[10].ToString() + ".OTPUSK +" + listTables[10].ToString() + ".POTERI) AS " + listTables[10].ToString().Remove(listTables[10].ToString().Length - 4, 2).Remove(0, 5));
                    sql.Append(" FROM PROMETALON" + " full join " + listTables[0].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[0].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[0].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[0].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[0].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[1].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[1].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[1].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[1].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[2].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[2].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[2].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[2].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[3].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[3].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[3].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[3].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[4].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[4].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[4].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[4].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[5].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[5].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[5].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[5].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[5].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[6].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[6].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[6].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[6].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[6].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[7].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[7].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[7].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[7].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[7].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[8].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[8].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[8].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[8].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[8].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[9].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[9].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[9].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[9].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[9].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[10].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[10].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[10].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[10].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[10].ToString() + ".KODTP");
                    sql.Append(" WHERE ");

                    sql.Append(" UPPER(KP) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N1) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N2) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N3) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(TP) LIKE UPPER('%" + searchExpression + "%') ");
                  
                    //   Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 12)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".kp as N_Дог," + listTables[0].ToString() + ".N1 as Плательщик," + listTables[0].ToString() + ".N2 as Абонент," + listTables[0].ToString() + ".N3 as Точка_учета," + listTables[0].ToString() + ".TP as ТП,");
                    sql.Append("(" + listTables[0].ToString() + ".OTPUSK +" + listTables[0].ToString() + ".POTERI) AS " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[1].ToString() + ".OTPUSK +" + listTables[1].ToString() + ".POTERI) AS " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[2].ToString() + ".OTPUSK +" + listTables[2].ToString() + ".POTERI) AS " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[3].ToString() + ".OTPUSK +" + listTables[3].ToString() + ".POTERI) AS " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[4].ToString() + ".OTPUSK +" + listTables[4].ToString() + ".POTERI) AS " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[5].ToString() + ".OTPUSK +" + listTables[5].ToString() + ".POTERI) AS " + listTables[5].ToString().Remove(listTables[5].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[6].ToString() + ".OTPUSK +" + listTables[6].ToString() + ".POTERI) AS " + listTables[6].ToString().Remove(listTables[6].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[7].ToString() + ".OTPUSK +" + listTables[7].ToString() + ".POTERI) AS " + listTables[7].ToString().Remove(listTables[7].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[8].ToString() + ".OTPUSK +" + listTables[8].ToString() + ".POTERI) AS " + listTables[8].ToString().Remove(listTables[8].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[9].ToString() + ".OTPUSK +" + listTables[9].ToString() + ".POTERI) AS " + listTables[9].ToString().Remove(listTables[9].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[10].ToString() + ".OTPUSK +" + listTables[10].ToString() + ".POTERI) AS " + listTables[10].ToString().Remove(listTables[10].ToString().Length - 4, 2).Remove(0, 5) + ",");
                    sql.Append("(" + listTables[11].ToString() + ".OTPUSK +" + listTables[11].ToString() + ".POTERI) AS " + listTables[11].ToString().Remove(listTables[11].ToString().Length - 4, 2).Remove(0, 5));

                    sql.Append(" FROM PROMETALON" + " full join " + listTables[0].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[0].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[0].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[0].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[0].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[1].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[1].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[1].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[1].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[2].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[2].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[2].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[2].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[3].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[3].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[3].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[3].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[4].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[4].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[4].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[4].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[5].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[5].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[5].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[5].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[5].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[6].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[6].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[6].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[6].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[6].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[7].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[7].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[7].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[7].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[7].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[8].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[8].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[8].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[8].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[8].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[9].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[9].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[9].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[9].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[9].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[10].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[10].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[10].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[10].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[10].ToString() + ".KODTP");

                    sql.Append(" FULL JOIN " + listTables[11].ToString());

                    sql.Append(" ON ");
                    sql.Append("PROMETALON.KP = " + listTables[11].ToString() + ".KP");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.NAB = " + listTables[11].ToString() + ".NAB");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KTU = " + listTables[11].ToString() + ".KTU");
                    sql.Append(" AND ");
                    sql.Append("PROMETALON.KODTP = " + listTables[11].ToString() + ".KODTP");
                    sql.Append(" WHERE ");

                    sql.Append(" UPPER(KP) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N1) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N2) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(N3) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(TP) LIKE UPPER('%" + searchExpression + "%') ");
                
                    //   Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Запрос: 12 таблиц 1 ТП")));
                    SQL = sql.ToString();
                }

           


            return SQL;
        
        
        
        }
        private string formSQLByt(IList<string> listTables, string searchExpression)
        {
            string SQL = string.Empty;
            

           if (listTables.Count == 0)
           {
           
           }

           else if (listTables.Count == 1)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT AB_N as Номер, FIO as ФИО, STREET.NAIM as Улица, Dom AS Дом, Kvar as Квартира,PRPLOM as TП, KVT as " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 4));
                    sql.Append(" FROM STREET FULL JOIN " + listTables[0].ToString());
                    sql.Append(" ON " + listTables[0].ToString() + ".street  = STREET.nom");
                    sql.Append(" WHERE ");
                    sql.Append(" UPPER(AB_N) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(FIO) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(STREET.NAIM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(DOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(PRPLOM) LIKE UPPER('%" + searchExpression + "%') ");
                   // Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                    sql.Append(" ORDER BY PRPLOM");
                    //  Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }


                else if (listTables.Count == 2)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".AB_N as Номер," + listTables[0].ToString() + ".FIO as ФИО, STREET.NAIM as Улица," + listTables[0].ToString() + ".Dom AS Дом," + listTables[0].ToString() + ".KORP as Корпус," + listTables[0].ToString() + ".Kvar as Квартира," + listTables[0].ToString() + ".PRPLOM as ТП,");
                    sql.Append(listTables[0].ToString() + ".KVT as " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[1].ToString() + ".KVT as " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 4));
                    sql.Append(" FROM bytetalon FULL JOIN " + listTables[0].ToString());
                    sql.Append(" ON ");
                    sql.Append(" bytetalon.ab_n = " + listTables[0].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[1].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN STREET");
                    sql.Append(" ON ");
                    sql.Append(listTables[0].ToString() + ".street  = STREET.nom");


                    sql.Append(" WHERE ");
                    sql.Append(" UPPER(AB_N) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(FIO) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(STREET.NAIM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(DOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(PRPLOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" ORDER BY PRPLOM");
                    //  Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 3)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".AB_N as Номер," + listTables[0].ToString() + ".FIO as ФИО, STREET.NAIM as Улица," + listTables[0].ToString() + ".Dom AS Дом," + listTables[0].ToString() + ".KORP as Корпус," + listTables[0].ToString() + ".Kvar as Квартира," + listTables[0].ToString() + ".PRPLOM as ТП,");
                    sql.Append(listTables[0].ToString() + ".KVT as " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[1].ToString() + ".KVT as " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[2].ToString() + ".KVT as " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 4));
                    sql.Append(" FROM bytetalon FULL JOIN " + listTables[0].ToString());
                    sql.Append(" ON ");
                    sql.Append(" bytetalon.ab_n = " + listTables[0].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[1].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[2].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN STREET");
                    sql.Append(" ON ");
                    sql.Append(listTables[0].ToString() + ".street  = STREET.nom");


                    sql.Append(" WHERE ");
                    sql.Append(" UPPER(AB_N) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(FIO) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(STREET.NAIM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(DOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(PRPLOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" ORDER BY PRPLOM");
                    //  Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 4)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".AB_N as Номер," + listTables[0].ToString() + ".FIO as ФИО, STREET.NAIM as Улица," + listTables[0].ToString() + ".Dom AS Дом," + listTables[0].ToString() + ".KORP as Корпус," + listTables[0].ToString() + ".Kvar as Квартира," + listTables[0].ToString() + ".PRPLOM as ТП,");
                    sql.Append(listTables[0].ToString() + ".KVT as " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[1].ToString() + ".KVT as " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[2].ToString() + ".KVT as " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[3].ToString() + ".KVT as " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 4));

                    sql.Append(" FROM bytetalon FULL JOIN " + listTables[0].ToString());
                    sql.Append(" ON ");
                    sql.Append(" bytetalon.ab_n = " + listTables[0].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[1].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[2].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[3].ToString() + ".ab_n");


                    sql.Append(" FULL JOIN STREET");
                    sql.Append(" ON ");
                    sql.Append(listTables[0].ToString() + ".street  = STREET.nom");


                    sql.Append(" WHERE ");
                    sql.Append(" UPPER(AB_N) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(FIO) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(STREET.NAIM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(DOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(PRPLOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" ORDER BY PRPLOM");
                    //   Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 5)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".AB_N as Номер," + listTables[0].ToString() + ".FIO as ФИО, STREET.NAIM as Улица," + listTables[0].ToString() + ".Dom AS Дом," + listTables[0].ToString() + ".KORP as Корпус," + listTables[0].ToString() + ".Kvar as Квартира," + listTables[0].ToString() + ".PRPLOM as ТП,");
                    sql.Append(listTables[0].ToString() + ".KVT as " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[1].ToString() + ".KVT as " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[2].ToString() + ".KVT as " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[3].ToString() + ".KVT as " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[4].ToString() + ".KVT as " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 4));

                    sql.Append(" FROM bytetalon FULL JOIN " + listTables[0].ToString());
                    sql.Append(" ON ");
                    sql.Append(" bytetalon.ab_n = " + listTables[0].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[1].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[2].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[3].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[4].ToString() + ".ab_n");



                    sql.Append(" FULL JOIN STREET");
                    sql.Append(" ON ");
                    sql.Append(listTables[0].ToString() + ".street  = STREET.nom");


                    sql.Append(" WHERE ");
                    sql.Append(" UPPER(AB_N) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(FIO) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(STREET.NAIM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(DOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(PRPLOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" ORDER BY PRPLOM");

                    // Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 6)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".AB_N as Номер," + listTables[0].ToString() + ".FIO as ФИО, STREET.NAIM as Улица," + listTables[0].ToString() + ".Dom AS Дом," + listTables[0].ToString() + ".KORP as Корпус," + listTables[0].ToString() + ".Kvar as Квартира," + listTables[0].ToString() + ".PRPLOM as ТП,");
                    sql.Append(listTables[0].ToString() + ".KVT as " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[1].ToString() + ".KVT as " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[2].ToString() + ".KVT as " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[3].ToString() + ".KVT as " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[4].ToString() + ".KVT as " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[5].ToString() + ".KVT as " + listTables[5].ToString().Remove(listTables[5].ToString().Length - 4, 2).Remove(0, 4));

                    sql.Append(" FROM bytetalon FULL JOIN " + listTables[0].ToString());
                    sql.Append(" ON ");
                    sql.Append(" bytetalon.ab_n = " + listTables[0].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[1].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[2].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[3].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[4].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[5].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[5].ToString() + ".ab_n");





                    sql.Append(" FULL JOIN STREET");
                    sql.Append(" ON ");
                    sql.Append(listTables[0].ToString() + ".street  = STREET.nom");


                    sql.Append(" WHERE ");
                    sql.Append(" UPPER(AB_N) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(FIO) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(STREET.NAIM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(DOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(PRPLOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" ORDER BY PRPLOM");
                    // Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 7)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".AB_N as Номер," + listTables[0].ToString() + ".FIO as ФИО, STREET.NAIM as Улица," + listTables[0].ToString() + ".Dom AS Дом," + listTables[0].ToString() + ".KORP as Корпус," + listTables[0].ToString() + ".Kvar as Квартира," + listTables[0].ToString() + ".PRPLOM as ТП,");
                    sql.Append(listTables[0].ToString() + ".KVT as " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[1].ToString() + ".KVT as " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[2].ToString() + ".KVT as " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[3].ToString() + ".KVT as " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[4].ToString() + ".KVT as " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[5].ToString() + ".KVT as " + listTables[5].ToString().Remove(listTables[5].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[6].ToString() + ".KVT as " + listTables[6].ToString().Remove(listTables[6].ToString().Length - 4, 2).Remove(0, 4));

                    sql.Append(" FROM bytetalon FULL JOIN " + listTables[0].ToString());
                    sql.Append(" ON ");
                    sql.Append(" bytetalon.ab_n = " + listTables[0].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[1].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[2].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[3].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[4].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[5].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[5].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[6].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[6].ToString() + ".ab_n");




                    sql.Append(" FULL JOIN STREET");
                    sql.Append(" ON ");
                    sql.Append(listTables[0].ToString() + ".street  = STREET.nom");


                    sql.Append(" WHERE ");
                    sql.Append(" UPPER(AB_N) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(FIO) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(STREET.NAIM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(DOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(PRPLOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" ORDER BY PRPLOM");



                    // Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }



                else if (listTables.Count == 8)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".AB_N as Номер," + listTables[0].ToString() + ".FIO as ФИО, STREET.NAIM as Улица," + listTables[0].ToString() + ".Dom AS Дом," + listTables[0].ToString() + ".KORP as Корпус," + listTables[0].ToString() + ".Kvar as Квартира," + listTables[0].ToString() + ".PRPLOM as ТП,");
                    sql.Append(listTables[0].ToString() + ".KVT as " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[1].ToString() + ".KVT as " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[2].ToString() + ".KVT as " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[3].ToString() + ".KVT as " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[4].ToString() + ".KVT as " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[5].ToString() + ".KVT as " + listTables[5].ToString().Remove(listTables[5].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[6].ToString() + ".KVT as " + listTables[6].ToString().Remove(listTables[6].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[7].ToString() + ".KVT as " + listTables[7].ToString().Remove(listTables[7].ToString().Length - 4, 2).Remove(0, 4));

                    sql.Append(" FROM bytetalon FULL JOIN " + listTables[0].ToString());
                    sql.Append(" ON ");
                    sql.Append(" bytetalon.ab_n = " + listTables[0].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[1].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[2].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[3].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[4].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[5].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[5].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[6].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[6].ToString() + ".ab_n");


                    sql.Append(" FULL JOIN " + listTables[7].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[7].ToString() + ".ab_n");


                    sql.Append(" FULL JOIN STREET");
                    sql.Append(" ON ");
                    sql.Append(listTables[0].ToString() + ".street  = STREET.nom");


                    sql.Append(" WHERE ");
                    sql.Append(" UPPER(AB_N) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(FIO) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(STREET.NAIM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(DOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(PRPLOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" ORDER BY PRPLOM");

                    //  Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 9)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".AB_N as Номер," + listTables[0].ToString() + ".FIO as ФИО, STREET.NAIM as Улица," + listTables[0].ToString() + ".Dom AS Дом," + listTables[0].ToString() + ".KORP as Корпус," + listTables[0].ToString() + ".Kvar as Квартира," + listTables[0].ToString() + ".PRPLOM as ТП,");
                    sql.Append(listTables[0].ToString() + ".KVT as " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[1].ToString() + ".KVT as " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[2].ToString() + ".KVT as " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[3].ToString() + ".KVT as " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[4].ToString() + ".KVT as " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[5].ToString() + ".KVT as " + listTables[5].ToString().Remove(listTables[5].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[6].ToString() + ".KVT as " + listTables[6].ToString().Remove(listTables[6].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[7].ToString() + ".KVT as " + listTables[7].ToString().Remove(listTables[7].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[8].ToString() + ".KVT as " + listTables[8].ToString().Remove(listTables[8].ToString().Length - 4, 2).Remove(0, 4));

                    sql.Append(" FROM bytetalon FULL JOIN " + listTables[0].ToString());
                    sql.Append(" ON ");
                    sql.Append(" bytetalon.ab_n = " + listTables[0].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[1].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[2].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[3].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[4].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[5].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[5].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[6].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[6].ToString() + ".ab_n");


                    sql.Append(" FULL JOIN " + listTables[7].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[7].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[8].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[8].ToString() + ".ab_n");


                    sql.Append(" FULL JOIN STREET");
                    sql.Append(" ON ");
                    sql.Append(listTables[0].ToString() + ".street  = STREET.nom");


                    sql.Append(" WHERE ");
                    sql.Append(" UPPER(AB_N) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(FIO) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(STREET.NAIM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(DOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(PRPLOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" ORDER BY PRPLOM");




                    //   Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 10)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".AB_N as Номер," + listTables[0].ToString() + ".FIO as ФИО, STREET.NAIM as Улица," + listTables[0].ToString() + ".Dom AS Дом," + listTables[0].ToString() + ".KORP as Корпус," + listTables[0].ToString() + ".Kvar as Квартира," + listTables[0].ToString() + ".PRPLOM as ТП,");
                    sql.Append(listTables[0].ToString() + ".KVT as " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[1].ToString() + ".KVT as " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[2].ToString() + ".KVT as " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[3].ToString() + ".KVT as " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[4].ToString() + ".KVT as " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[5].ToString() + ".KVT as " + listTables[5].ToString().Remove(listTables[5].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[6].ToString() + ".KVT as " + listTables[6].ToString().Remove(listTables[6].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[7].ToString() + ".KVT as " + listTables[7].ToString().Remove(listTables[7].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[8].ToString() + ".KVT as " + listTables[8].ToString().Remove(listTables[8].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[9].ToString() + ".KVT as " + listTables[9].ToString().Remove(listTables[9].ToString().Length - 4, 2).Remove(0, 4));

                    sql.Append(" FROM bytetalon FULL JOIN " + listTables[0].ToString());
                    sql.Append(" ON ");
                    sql.Append(" bytetalon.ab_n = " + listTables[0].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[1].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[2].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[3].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[4].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[5].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[5].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[6].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[6].ToString() + ".ab_n");


                    sql.Append(" FULL JOIN " + listTables[7].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[7].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[8].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[8].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[9].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[9].ToString() + ".ab_n");


                    sql.Append(" FULL JOIN STREET");
                    sql.Append(" ON ");
                    sql.Append(listTables[0].ToString() + ".street  = STREET.nom");


                    sql.Append(" WHERE ");
                    sql.Append(" UPPER(AB_N) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(FIO) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(STREET.NAIM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(DOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(PRPLOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" ORDER BY PRPLOM");
                    //  Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }

                else if (listTables.Count == 11)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".AB_N as Номер," + listTables[0].ToString() + ".FIO as ФИО, STREET.NAIM as Улица," + listTables[0].ToString() + ".Dom AS Дом," + listTables[0].ToString() + ".KORP as Корпус," + listTables[0].ToString() + ".Kvar as Квартира," + listTables[0].ToString() + ".PRPLOM as ТП,");
                    sql.Append(listTables[0].ToString() + ".KVT as " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[1].ToString() + ".KVT as " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[2].ToString() + ".KVT as " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[3].ToString() + ".KVT as " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[4].ToString() + ".KVT as " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[5].ToString() + ".KVT as " + listTables[5].ToString().Remove(listTables[5].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[6].ToString() + ".KVT as " + listTables[6].ToString().Remove(listTables[6].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[7].ToString() + ".KVT as " + listTables[7].ToString().Remove(listTables[7].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[8].ToString() + ".KVT as " + listTables[8].ToString().Remove(listTables[8].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[9].ToString() + ".KVT as " + listTables[9].ToString().Remove(listTables[9].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[10].ToString() + ".KVT as " + listTables[10].ToString().Remove(listTables[10].ToString().Length - 4, 2).Remove(0, 4));

                    sql.Append(" FROM bytetalon FULL JOIN " + listTables[0].ToString());
                    sql.Append(" ON ");
                    sql.Append(" bytetalon.ab_n = " + listTables[0].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[1].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[2].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[3].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[4].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[5].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[5].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[6].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[6].ToString() + ".ab_n");


                    sql.Append(" FULL JOIN " + listTables[7].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[7].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[8].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[8].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[9].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[9].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[10].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[10].ToString() + ".ab_n");




                    sql.Append(" FULL JOIN STREET");
                    sql.Append(" ON ");
                    sql.Append(listTables[0].ToString() + ".street  = STREET.nom");


                    sql.Append(" WHERE ");
                    sql.Append(" UPPER(AB_N) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(FIO) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(STREET.NAIM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(DOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(PRPLOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" ORDER BY PRPLOM");
                    //  Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
                }
                else if (listTables.Count == 12)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT " + listTables[0].ToString() + ".AB_N as Номер," + listTables[0].ToString() + ".FIO as ФИО, STREET.NAIM as Улица," + listTables[0].ToString() + ".Dom AS Дом," + listTables[0].ToString() + ".KORP as Корпус," + listTables[0].ToString() + ".Kvar as Квартира," + listTables[0].ToString() + ".PRPLOM as ТП,");
                    sql.Append(listTables[0].ToString() + ".KVT as " + listTables[0].ToString().Remove(listTables[0].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[1].ToString() + ".KVT as " + listTables[1].ToString().Remove(listTables[1].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[2].ToString() + ".KVT as " + listTables[2].ToString().Remove(listTables[2].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[3].ToString() + ".KVT as " + listTables[3].ToString().Remove(listTables[3].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[4].ToString() + ".KVT as " + listTables[4].ToString().Remove(listTables[4].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[5].ToString() + ".KVT as " + listTables[5].ToString().Remove(listTables[5].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[6].ToString() + ".KVT as " + listTables[6].ToString().Remove(listTables[6].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[7].ToString() + ".KVT as " + listTables[7].ToString().Remove(listTables[7].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[8].ToString() + ".KVT as " + listTables[8].ToString().Remove(listTables[8].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[9].ToString() + ".KVT as " + listTables[9].ToString().Remove(listTables[9].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[10].ToString() + ".KVT as " + listTables[10].ToString().Remove(listTables[10].ToString().Length - 4, 2).Remove(0, 4) + ",");
                    sql.Append(listTables[11].ToString() + ".KVT as " + listTables[11].ToString().Remove(listTables[11].ToString().Length - 4, 2).Remove(0, 4));

                    sql.Append(" FROM bytetalon FULL JOIN " + listTables[0].ToString());
                    sql.Append(" ON ");
                    sql.Append(" bytetalon.ab_n = " + listTables[0].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[1].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[1].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[2].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[2].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[3].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[3].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[4].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[4].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[5].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[5].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[6].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[6].ToString() + ".ab_n");


                    sql.Append(" FULL JOIN " + listTables[7].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[7].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[8].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[8].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[9].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[9].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[10].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[10].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN " + listTables[11].ToString());
                    sql.Append(" ON ");
                    sql.Append("bytetalon.ab_n = " + listTables[11].ToString() + ".ab_n");

                    sql.Append(" FULL JOIN STREET");
                    sql.Append(" ON ");
                    sql.Append(listTables[0].ToString() + ".street  = STREET.nom");


                    sql.Append(" WHERE ");
                    sql.Append(" UPPER(AB_N) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(FIO) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(STREET.NAIM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(DOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" OR ");
                    sql.Append(" UPPER(PRPLOM) LIKE UPPER('%" + searchExpression + "%') ");
                    sql.Append(" ORDER BY PRPLOM");
                    //    Logger.Instance.WriteToLogFile(ConfigurationHelper.ErrorLogProgramm, (string.Format("Сформировали запрос:{0} ", sql)));
                    SQL = sql.ToString();
              
            }
            return SQL;



        }

        public DataTable PromGetOraTable(List<string> listTables,string searchExpression,string connectionString, string resName)
        {

            DataTable resultDataTable = new DataTable();
            string sql = string.Empty;

            sql = formSQLProm(listTables, searchExpression);
            if (sql != null)
            {
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


            }



            return resultDataTable;


        }
        public DataTable BytGetOraTable(List<string> listTables, string searchExpression, string connectionString, string resName)
        {

            DataTable resultDataTable = new DataTable();
            string sql = string.Empty;

            sql = formSQLByt(listTables, searchExpression);
            if (sql != null)
            {
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


            }



            return resultDataTable;


        }

    }
}
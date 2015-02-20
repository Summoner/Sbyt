using System;
using System.Collections.Generic;
using System.Web;

namespace Sbyt.App_Service
{
    public class TimePeriod
    {

         #region Instance
        private TimePeriod() { }

        [ThreadStatic]
        private static TimePeriod _instance;

        public static TimePeriod Instance
        {
            get { return _instance ?? (_instance = new TimePeriod()); }
        }
        #endregion



        private List<string> GetListMonthYear(string startMonth, string startYear, string endMonth, string endYear)
        {
            Dictionary<Int32, string> year =  new Dictionary<Int32, string>();
            Dictionary<Int32, string> month = new Dictionary<Int32, string>();
            List<string> listMonthYear = new List<string>();

            int intStartYear = 0;
            int intEndYear = 0;

            int intStartMonth = 0;
            int intEndMonth = 0;


         
            year.Add(1, "2011");
            year.Add(2, "2012");
            year.Add(3, "2013");
            year.Add(4, "2014");
            year.Add(5, "2015");
            year.Add(6, "2016");

            month.Add(1, "January");
            month.Add(2, "February");
            month.Add(3, "Marth");
            month.Add(4, "April");
            month.Add(5, "May");
            month.Add(6, "June");
            month.Add(7, "July");
            month.Add(8, "August");
            month.Add(9, "September");
            month.Add(10, "October");
            month.Add(11, "November");
            month.Add(12, "December");



            if (year.ContainsValue(startYear))
            {
                intStartYear = GetKeyByValue(year,startYear);            
            }

            if (month.ContainsValue(startMonth))
            {
                intStartMonth = GetKeyByValue(month, startMonth);
            }


            if (year.ContainsValue(endYear))
            {
                intEndYear = GetKeyByValue(year, endYear);
            }

            if (month.ContainsValue(endMonth))
            {
                intEndMonth = GetKeyByValue(month, endMonth);
            }


            //Если год один и тот же
            #region SameYear
            if (intStartYear == intEndYear)
            {

                string yearvalue;
                string monthvalue;

                if (intStartMonth <= intEndMonth)
                {
                    for (int i = intStartYear; i <= intEndYear; i++)
                    {
                        for (int j = intStartMonth; j <= intEndMonth; j++)
                        {
                            year.TryGetValue(i, out yearvalue);


                            month.TryGetValue(j, out monthvalue);

                            listMonthYear.Add(monthvalue + "_" + yearvalue);


                        }
                    }
                }

                else if (intStartMonth >= intEndMonth)
                {
                    for (int i = intStartYear; i <= intEndYear; i++)
                    {

                        for (int j = intStartMonth; j >= intEndMonth; j--)
                        {
                            year.TryGetValue(i, out yearvalue);


                            month.TryGetValue(j, out monthvalue);

                            listMonthYear.Add(monthvalue + "_" + yearvalue);


                        }
                    }
                
                }

               

            }
            #endregion


            //Если cтартовый год меньше ендового
            #region StartEnd
            else if (intStartYear < intEndYear)
            {
                string yearvalue;
                string monthvalue;
                for (int i = intStartYear; i <= intEndYear; i++)
                {
                    
                    if (i == intStartYear)
                    {
                        for (int j = intStartMonth; j <= 12; j++)
                        {
                            year.TryGetValue(i, out yearvalue);


                            month.TryGetValue(j, out monthvalue);

                            listMonthYear.Add(monthvalue + "_" + yearvalue);


                        }
                    }
                    else if ((i != intStartYear) && (i != intEndYear))
                    {
                        for (int j = 1; j <= 12; j++)
                        {
                            year.TryGetValue(i, out yearvalue);


                            month.TryGetValue(j, out monthvalue);

                            listMonthYear.Add(monthvalue + "_" + yearvalue);


                        }
                    
                    
                    
                    }

                    else if (i == intEndYear)
                    {
                        for (int j = 1; j <= intEndMonth; j++)
                        {
                            year.TryGetValue(i, out yearvalue);


                            month.TryGetValue(j, out monthvalue);

                            listMonthYear.Add(monthvalue + "_" + yearvalue);


                        }
                    
                    }
                }
            }

            #endregion


            //Если ендовый год меньше стартового
            #region EndStart
            else if (intEndYear < intStartYear)
            {


                string Yearvalue = "";
                string Monthvalue = "";

                for (int i = intStartYear; i >= intEndYear; i--)
                {
                    if (i == intStartYear)
                    {
                        for (int j = intStartMonth; j >= 1; j--)
                        {
                             
                            year.TryGetValue(i, out Yearvalue);


                            
                            month.TryGetValue(j, out Monthvalue);

                            listMonthYear.Add(Monthvalue + "_" + Yearvalue);


                        }
                    }
                    else if ((i != intStartYear) && (i != intEndYear))
                    {
                        for (int j = 12; j >= 1; j--)
                        {
                             
                            year.TryGetValue(i, out Yearvalue);


                           
                            month.TryGetValue(j, out Monthvalue);

                            listMonthYear.Add(Monthvalue + "_" + Yearvalue);


                        }



                    }

                    else if (i == intEndYear)
                    {
                        for (int j = 12; j >= intEndMonth; j--)
                        {
                             
                            year.TryGetValue(i, out Yearvalue);


                            
                            month.TryGetValue(j, out Monthvalue);

                            listMonthYear.Add(Monthvalue + "_" + Yearvalue);


                        }

                    }



                }


            }

            #endregion





            return listMonthYear;
            

        
        }



        private Int32 GetKeyByValue(Dictionary<Int32, string> dictionary, string value)
        {
            foreach (var recordOfDictionary in dictionary)
            {
                if (recordOfDictionary.Value.Equals(value))
                    return recordOfDictionary.Key;
            }
            return 0;
        }



        public List<string> GetListPromTables(string startMonth, string startYear, string endMonth, string endYear)
        {
            List<string> listpromTables = new List<string>();


            //список месяц + год
            List<string> listMonthYear = GetListMonthYear(startMonth, startYear, endMonth, endYear);


            foreach (string str in listMonthYear)
            {
                listpromTables.Add("PROM_" + str);
            
            }



            return listpromTables;
        
        
        
        }

        public List<string> GetListBytTables(string startMonth, string startYear, string endMonth, string endYear)
        {
            List<string> ListMonthYear = new List<string>();
            List<string> ListbytTables = new List<string>();


            //список месяц + год
            ListMonthYear = GetListMonthYear(startMonth, startYear, endMonth, endYear);


            foreach (string str in ListMonthYear)
            {
                ListbytTables.Add("BYT_" + str);

            }



            return ListbytTables;



        }

    }

    
}
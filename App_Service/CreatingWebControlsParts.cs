using System;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace Sbyt.App_Service
{
    public class CreatingWebControlsParts
    {

        #region Instance
        private CreatingWebControlsParts() { }

        [ThreadStatic]
        private static CreatingWebControlsParts _instance;

        public static CreatingWebControlsParts Instance
        {
            get { return _instance ?? (_instance = new CreatingWebControlsParts()); }
        }
        #endregion

        public static string CreateMonthYearHeader(string bytOrPromMonthYear)
        {

            string _month = string.Empty;
            string _year = string.Empty;

            //Парсим месяц
            string monthPattern = "_[A-Za-z]+_";
            Regex regM = new Regex(monthPattern);
            Match matchM = regM.Match(bytOrPromMonthYear);
            string month = matchM.Value.Replace("_", "");


            switch (month.ToUpper())
            {
                case "JANUARY":
                    _month = "Январь";
                    break;
                case "FEBRUARY":
                    _month = "Февраль";
                    break;
                case "MARTH":
                    _month = "Март";
                    break;
                case "APRIL":
                    _month = "Апрель";
                    break;
                case "MAY":
                    _month = "Май";
                    break;
                case "JUNE":
                    _month = "Июнь";
                    break;
                case "JULY":
                    _month = "Июль";
                    break;
                case "AUGUST":
                    _month = "Август";
                    break;
                case "SEPTEMBER":
                    _month = "Сентябрь";
                    break;
                case "OCTOBER":
                    _month = "Октябрь";
                    break;
                case "NOVEMBER":
                    _month = "Ноябрь";
                    break;
                case "DECEMBER":
                    _month = "Декабрь";
                    break;
            }


            //парсим год
            string pattern = "_[0-9]+";
            Regex regY = new Regex(pattern);
            Match matchY = regY.Match(bytOrPromMonthYear);
            _year = matchY.Value.Replace("_", "").Remove(0, 2);


            //Формируем нужный заголовок для колонки таблицы
            return _month + "_" + _year;

        }

        public BoundField CreateEtalontGridViewColumn(string dataField, string columnHeader)
        {
            BoundField column = new BoundField {DataField = dataField, Visible = true, HeaderText = columnHeader};
            column.ControlStyle.Font.Size = 16;
            column.ControlStyle.Font.Bold = true;
            column.SortExpression = dataField;
            return column;

        }

        public BoundField CreateOplatiGridViewColumn(string dataField,string bytOrPromMonthYear)
        {
            BoundField column = new BoundField();
            column.DataField = dataField;
            column.Visible = true;
            column.HeaderText = CreateMonthYearHeader(bytOrPromMonthYear);
            column.ControlStyle.Font.Size = 16;
            column.ControlStyle.Font.Bold = true;
            column.SortExpression = dataField;
            return column;

        }

        
    }
}
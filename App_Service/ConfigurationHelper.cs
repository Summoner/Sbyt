using System.Configuration;
using Sbyt.LogsManagement;

namespace Sbyt.App_Service
{
    public static class ConfigurationHelper
    {
        private static string _stolbSqlOracleQuery;
        private static string _stolbStreetSqlOracleQuery;

        private static string _dergSqlOracleQuery;
        private static string _dergStreetSqlOracleQuery;

        private static string _uzdaSqlOracleQuery;
        private static string _uzdaStreetSqlOracleQuery;

        private static string _kleckSqlOracleQuery;
        private static string _kleckStreetSqlOracleQuery;

        private static string _nesvSqlOracleQuery;
        private static string _nesvStreetSqlOracleQuery;

     /*   private static string _errorLogPath;
        private static string _errorLogPathBalancePoTp;
        private static string _errorLogPathBalancePoVL;
        private static string _errorLogConvert;
        private static string _errorLogSearch;
        */

        private static string _errorLogProgramm;

        private static string _kleckPassportConnectionString;
        private static string _uzdaPassportConnectionString;
        private static string _stolbPassportConnectionString;
        private static string _dergPassportConnectionString;
        private static string _nesvPassportConnectionString;
        
        private static string _kleckOraConnectionStringBalPoTP;
        private static string _stolbOraConnectionStringBalPoTP;
        private static string _uzdaOraConnectionStringBalPoTP;
        private static string _dergOraConnectionStringBalPoTP;
        private static string _nesvOraConnectionStringBalPoTP;

        private static string _odbcConnectionStringUzda;
        private static string _odbcConnectionStringKleck;
        private static string _odbcConnectionStringStolb;
        private static string _odbcConnectionStringDerg;
        private static string _odbcConnectionStringNesv;



        private static string GetParameterFromConfig(string parameter)
        {
            string str = ConfigurationManager.AppSettings[parameter];
            if (string.IsNullOrEmpty(str))
            {
               Logger.Instance.WriteToLogFile(ErrorLogProgramm,(string.Format("Not found parameter '{0}' on app.config.exe", parameter)));
            }
            return str;
        }



        public static string StolbSqlOracleQuery
        {
            get
            {
                if (string.IsNullOrEmpty(_stolbSqlOracleQuery))
                {
                    _stolbSqlOracleQuery = GetParameterFromConfig("StolbSqlOracleQuery");
                }
                return _stolbSqlOracleQuery;
            }
        }
        public static string StolbStreetSqlOracleQuery
        {
            get
            {
                if (string.IsNullOrEmpty(_stolbStreetSqlOracleQuery))
                {
                    _stolbStreetSqlOracleQuery = GetParameterFromConfig("StolbStreetSqlOracleQuery");
                }
                return _stolbStreetSqlOracleQuery;
            }
        }


        public static string DergSqlOracleQuery
        {
            get
            {
                if (string.IsNullOrEmpty(_dergSqlOracleQuery))
                {
                    _dergSqlOracleQuery = GetParameterFromConfig("DergSqlOracleQuery");
                }
                return _dergSqlOracleQuery;
            }
        }
        public static string DergStreetSqlOracleQuery
        {
            get
            {
                if (string.IsNullOrEmpty(_dergStreetSqlOracleQuery))
                {
                    _dergStreetSqlOracleQuery = GetParameterFromConfig("DergStreetSqlOracleQuery");
                }
                return _dergStreetSqlOracleQuery;
            }
        }

        public static string UzdaSqlOracleQuery
        {
            get
            {
                if (string.IsNullOrEmpty(_uzdaSqlOracleQuery))
                {
                    _uzdaSqlOracleQuery = GetParameterFromConfig("UzdaSqlOracleQuery");
                }
                return _uzdaSqlOracleQuery;
            }
        }
        public static string UzdaStreetSqlOracleQuery
        {
            get
            {
                if (string.IsNullOrEmpty(_uzdaStreetSqlOracleQuery))
                {
                    _uzdaStreetSqlOracleQuery = GetParameterFromConfig("UzdaStreetSqlOracleQuery");
                }
                return _uzdaStreetSqlOracleQuery;
            }
        }
        
        public static string KleckSqlOracleQuery
        {
            get
            {
                if (string.IsNullOrEmpty(_kleckSqlOracleQuery))
                {
                    _kleckSqlOracleQuery = GetParameterFromConfig("KleckSqlOracleQuery");
                }
                return _kleckSqlOracleQuery;
            }
        }
        public static string KleckStreetSqlOracleQuery
        {
            get
            {
                if (string.IsNullOrEmpty(_kleckStreetSqlOracleQuery))
                {
                    _kleckStreetSqlOracleQuery = GetParameterFromConfig("KleckStreetSqlOracleQuery");
                }
                return _kleckStreetSqlOracleQuery;
            }
        }


        public static string NesvSqlOracleQuery
        {
            get
            {
                if (string.IsNullOrEmpty(_nesvSqlOracleQuery))
                {
                    _nesvSqlOracleQuery = GetParameterFromConfig("NesvSqlOracleQuery");
                }
                return _nesvSqlOracleQuery;
            }
        }
        public static string NesvStreetSqlOracleQuery
        {
            get
            {
                if (string.IsNullOrEmpty(_nesvStreetSqlOracleQuery))
                {
                    _nesvStreetSqlOracleQuery = GetParameterFromConfig("NesvStreetSqlOracleQuery");
                }
                return _nesvStreetSqlOracleQuery;
            }
        }
        /*
        public static string ErrorLogPath
        {
            get
            {
                if (string.IsNullOrEmpty(_errorLogPath))
                {
                    _errorLogPath = GetParameterFromConfig("ErrorLogPath");
                }
                return _errorLogPath;
            }
        }
        public static string ErrorLogPathBalancePoTp
        {
            get
            {
                if (string.IsNullOrEmpty(_errorLogPathBalancePoTp))
                {
                    _errorLogPathBalancePoTp = GetParameterFromConfig("ErrorLogPathBalancePoTp");
                }
                return _errorLogPathBalancePoTp;
            }
        }
        public static string ErrorLogPathBalancePoVL
        {
            get
            {
                if (string.IsNullOrEmpty(_errorLogPathBalancePoVL))
                {
                    _errorLogPathBalancePoVL = GetParameterFromConfig("ErrorLogPathBalancePoVL");
                }
                return _errorLogPathBalancePoVL;
            }
        }
        public static string ErrorLogConvert
        {
            get
            {
                if (string.IsNullOrEmpty(_errorLogConvert))
                {
                    _errorLogConvert = GetParameterFromConfig("ErrorLogConvert");
                }
                return _errorLogConvert;
            }
        }
        public static string ErrorLogSearch
        {
            get
            {
                if (string.IsNullOrEmpty(_errorLogSearch))
                {
                    _errorLogSearch = GetParameterFromConfig("ErrorLogSearch");
                }
                return _errorLogSearch;
            }
        }
        */
        public static string ErrorLogProgramm
        {
            get
            {
                if (string.IsNullOrEmpty(_errorLogProgramm))
                {
                    _errorLogProgramm = GetParameterFromConfig("ErrorLogProgramm");
                }
                return _errorLogProgramm;
            }
        }



        public static string KleckPassportConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_kleckPassportConnectionString))
                {
                    _kleckPassportConnectionString = GetParameterFromConfig("KleckPassportConnectionString");
                }
                return _kleckPassportConnectionString;
            }
        }
        public static string StolbPassportConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_stolbPassportConnectionString))
                {
                    _stolbPassportConnectionString = GetParameterFromConfig("StolbPassportConnectionString");
                }
                return _stolbPassportConnectionString;
            }
        }
        public static string UzdaPassportConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_uzdaPassportConnectionString))
                {
                    _uzdaPassportConnectionString = GetParameterFromConfig("UzdaPassportConnectionString");
                }
                return _uzdaPassportConnectionString;
            }
        }
        public static string DergPassportConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_dergPassportConnectionString))
                {
                    _dergPassportConnectionString = GetParameterFromConfig("DergPassportConnectionString");
                }
                return _dergPassportConnectionString;
            }
        }
        public static string NesvPassportConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_nesvPassportConnectionString))
                {
                    _nesvPassportConnectionString = GetParameterFromConfig("NesvPassportConnectionString");
                }
                return _nesvPassportConnectionString;
            }
        }


        public static string KleckOraConnectionStringBalPoTP
        {
            get
            {
                if (string.IsNullOrEmpty(_kleckOraConnectionStringBalPoTP))
                {
                    _kleckOraConnectionStringBalPoTP = GetParameterFromConfig("KleckOraConnectionStringBalPoTP");
                }
                return _kleckOraConnectionStringBalPoTP;
            }
        }
        public static string StolbOraConnectionStringBalPoTP
        {
            get
            {
                if (string.IsNullOrEmpty(_stolbOraConnectionStringBalPoTP))
                {
                    _stolbOraConnectionStringBalPoTP = GetParameterFromConfig("StolbOraConnectionStringBalPoTP");
                }
                return _stolbOraConnectionStringBalPoTP;
            }
        }
        public static string UzdaOraConnectionStringBalPoTP
        {
            get
            {
                if (string.IsNullOrEmpty(_uzdaOraConnectionStringBalPoTP))
                {
                    _uzdaOraConnectionStringBalPoTP = GetParameterFromConfig("UzdaOraConnectionStringBalPoTP");
                }
                return _uzdaOraConnectionStringBalPoTP;
            }
        }
        public static string DergOraConnectionStringBalPoTP
        {
            get
            {
                if (string.IsNullOrEmpty(_dergOraConnectionStringBalPoTP))
                {
                    _dergOraConnectionStringBalPoTP = GetParameterFromConfig("DergOraConnectionStringBalPoTP");
                }
                return _dergOraConnectionStringBalPoTP;
            }
        }
        public static string NesvOraConnectionStringBalPoTP
        {
            get
            {
                if (string.IsNullOrEmpty(_nesvOraConnectionStringBalPoTP))
                {
                    _nesvOraConnectionStringBalPoTP = GetParameterFromConfig("NesvOraConnectionStringBalPoTP");
                }
                return _nesvOraConnectionStringBalPoTP;
            }
        }


        public static string OdbcConnectionStringUzda
        {
            get
            {
                if (string.IsNullOrEmpty(_odbcConnectionStringUzda))
                {
                    _odbcConnectionStringUzda = GetParameterFromConfig("ODBCConnectionStringUzda");
                }
                return _odbcConnectionStringUzda;
            }
        }
        public static string OdbcConnectionStringStolb
        {
            get
            {
                if (string.IsNullOrEmpty(_odbcConnectionStringStolb))
                {
                    _odbcConnectionStringStolb = GetParameterFromConfig("ODBCConnectionStringStolb");
                }
                return _odbcConnectionStringStolb;
            }
        }
        public static string OdbcConnectionStringKleck
        {
            get
            {
                if (string.IsNullOrEmpty(_odbcConnectionStringKleck))
                {
                    _odbcConnectionStringKleck = GetParameterFromConfig("ODBCConnectionStringKleck");
                }
                return _odbcConnectionStringKleck;
            }
        }
        public static string OdbcConnectionStringDerg
        {
            get
            {
                if (string.IsNullOrEmpty(_odbcConnectionStringDerg))
                {
                    _odbcConnectionStringDerg = GetParameterFromConfig("ODBCConnectionStringDerg");
                }
                return _odbcConnectionStringDerg;
            }
        }
        public static string OdbcConnectionStringNesv
        {
            get
            {
                if (string.IsNullOrEmpty(_odbcConnectionStringNesv))
                {
                    _odbcConnectionStringNesv = GetParameterFromConfig("ODBCConnectionStringNesv");
                }
                return _odbcConnectionStringNesv;
            }
        }







    }
}
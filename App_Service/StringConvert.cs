using System;

namespace Sbyt.App_Service
{
    public class StringConvert
    {

        #region Instance
        private StringConvert() { }

        [ThreadStatic]
        private static StringConvert _instance;

        public static StringConvert Instance
        {
            get { return _instance ?? (_instance = new StringConvert()); }
        }
        #endregion
        
        public string RemoveSymbols(string inputMessage)
        { 
        if (inputMessage.Length >= 300)
        {
          inputMessage =   inputMessage.Remove(300);
        }
        return inputMessage;
        }

       
        
    }
}
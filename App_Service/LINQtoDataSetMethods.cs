using System.Collections.Generic;
using System.Data;

namespace Sbyt.App_Service
{
    public static class LINQtoDataSetMethods
    {

        public  static DataTable  CopyToDataTable<T>(this IEnumerable<T> source )
        {
            ObjectShredder<T> obj = new ObjectShredder<T>();
            return  obj.Shred(source,null,null);

           
           
        }

        public static DataTable CopyToDataTable<T>(this IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            ObjectShredder<T> obj = new ObjectShredder<T>();
            return obj.Shred(source,table,options);
        }
    }
}
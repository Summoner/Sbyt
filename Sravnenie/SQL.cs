using System.Text;

namespace Sbyt.Sravnenie
{
    public static class SQL
    {
        //Входной параметр - Constants.***ResShortName
       public static string GetSbytovikiSqlCommand(string resShortName)
       {
           StringBuilder sbytoviki = new StringBuilder();
           sbytoviki.Append("CREATE TABLE " + resShortName + "SBYTOVIKI AS ");
           sbytoviki.Append("SELECT AB_N,FIO,STREET,DOM,PRPLOM,FIDER FROM " + resShortName + "SBYT ");
           sbytoviki.Append(" WHERE NOT ");
           sbytoviki.Append("( ");
           sbytoviki.Append(" UPPER(TRIM(" + resShortName + "SBYT.AB_N)) = ANY ");
           sbytoviki.Append("( ");
           sbytoviki.Append("SELECT UPPER(TRIM(" + resShortName + "SBYT.AB_N))   ");
           sbytoviki.Append("FROM " + resShortName + "SBYT INNER JOIN " + resShortName + "PASPORT ON  ");
           sbytoviki.Append("( ");
           sbytoviki.Append(" UPPER(TRIM(" + resShortName + "SBYT.AB_N)) = UPPER(TRIM(" + resShortName + "PASPORT.AB_N)) ");
           sbytoviki.Append(" AND ");
           sbytoviki.Append(" UPPER(TRIM(" + resShortName + "SBYT.STREET)) = UPPER(TRIM(" + resShortName + "PASPORT.STREET)) ");
           sbytoviki.Append(" AND ");
           sbytoviki.Append(" UPPER(TRIM(" + resShortName + "SBYT.DOM)) = UPPER(TRIM(" + resShortName + "PASPORT.DOM)) ");
           sbytoviki.Append(" AND ");
           sbytoviki.Append(" UPPER(TRIM(" + resShortName + "SBYT.PRPLOM)) = UPPER(TRIM(" + resShortName + "PASPORT.N_TP)) ");
           sbytoviki.Append(") ");
           sbytoviki.Append(") ");
           sbytoviki.Append(") ");

           return sbytoviki.ToString();
       }

       //Входной параметр - Constants.***ResShortName
       public static string GetPasportaSqlCommand(string resShortName)
       {
           StringBuilder pasporta = new StringBuilder();
           pasporta.Append(" CREATE TABLE " + resShortName + "PASPORTA AS ");
           pasporta.Append(" SELECT AB_N,FIO,STREET,DOM,N_TP,N_VL FROM " + resShortName + "PASPORT ");
           pasporta.Append(" WHERE NOT ");
           pasporta.Append(" ( ");
           pasporta.Append(" UPPER(TRIM(" + resShortName + "PASPORT.AB_N)) = ANY ");
           pasporta.Append("(");
           pasporta.Append(" SELECT UPPER(TRIM(" + resShortName + "PASPORT.AB_N)) ");
           pasporta.Append(" FROM " + resShortName + "PASPORT INNER JOIN " + resShortName + "SBYT ON ");
           pasporta.Append(" ( ");
           pasporta.Append(" UPPER(TRIM(" + resShortName + "PASPORT.AB_N)) = UPPER(TRIM(" + resShortName + "SBYT.AB_N)) ");
           pasporta.Append(" AND ");
           pasporta.Append(" UPPER(TRIM(" + resShortName + "PASPORT.STREET)) = UPPER(TRIM(" + resShortName + "SBYT.STREET)) ");
           pasporta.Append(" AND ");
           pasporta.Append(" UPPER(TRIM(" + resShortName + "PASPORT.DOM)) = UPPER(TRIM(" + resShortName + "SBYT.DOM)) ");
           pasporta.Append(" AND ");
           pasporta.Append(" UPPER(TRIM(" + resShortName + "PASPORT.N_TP)) = UPPER(TRIM(" + resShortName + "SBYT.PRPLOM))) ");
           pasporta.Append(" ) ");
           pasporta.Append(" ) ");

           return pasporta.ToString();
       }

       //Входной параметр - Constants.***ResShortName
       public static string GetResResultSqlCommand(string resShortName)
       {
           StringBuilder result = new StringBuilder();
           result.Append(" CREATE TABLE " + resShortName + "RESULT AS ");
           result.Append(" SELECT DISTINCT ");
           result.Append(resShortName + "PASPORTA.AB_N AS PASPORT_AB_N, ");
           result.Append(resShortName + "PASPORTA.FIO AS PASPORT_FIO, ");
           result.Append(resShortName + "PASPORTA.STREET  AS PASPORT_STREET, ");
           result.Append(resShortName + "PASPORTA.DOM AS PASPORT_DOM, ");
           result.Append(resShortName + "PASPORTA.N_TP AS PASPORT_N_TP, ");
           result.Append(resShortName + "PASPORTA.N_VL  AS PASPORT_N_VL, ");
           result.Append(resShortName + "SBYTOVIKI.AB_N AS SBYTOVIKI_AB_N, ");
           result.Append(resShortName + "SBYTOVIKI.FIO AS SBYTOVIKI_FIO, ");
           result.Append(resShortName + "SBYTOVIKI.STREET  AS SBYTOVIKI_STREET, ");
           result.Append(resShortName + "SBYTOVIKI.DOM AS SBYTOVIKI_DOM, ");
           result.Append(resShortName + "SBYTOVIKI.PRPLOM AS SBYTOVIKI_N_TP, ");
           result.Append(resShortName + "SBYTOVIKI.FIDER  AS SBYTOVIKI_N_VL ");
           result.Append(" from ");
           result.Append(resShortName + "PASPORTA ");
           result.Append(" FULL JOIN ");
           result.Append(resShortName + "SBYTOVIKI ");
           result.Append(" ON ("+ resShortName +"PASPORTA.AB_N = " + resShortName + "SBYTOVIKI.AB_N) ");

           return result.ToString();
       }

       //Входной параметр - Constants.***ResShortName
       public static string GetResResultSqlCommandForStreets(string resShortName)
       {
           StringBuilder result = new StringBuilder();
           result.Append(" SELECT DISTINCT * FROM ");
           result.Append(" ( ");
           result.Append(" SELECT DISTINCT ");
           result.Append("PASPORT_AB_N, ");
           result.Append("PASPORT_FIO, ");
           result.Append("NAIM AS PASPORT_STREET, ");
           result.Append("PASPORT_DOM, ");
           result.Append("PASPORT_N_TP, ");
           result.Append("PASPORT_N_VL ");
           result.Append(" FROM ");
           result.Append(resShortName + "result ");
           result.Append(" JOIN ");
           result.Append(resShortName + "street ");
           result.Append(" ON ");
           result.Append(" ( ");
           result.Append(" UPPER(TRIM(" + resShortName + "result.pasport_street)) = UPPER(TRIM(" + resShortName + "street.nom))  ");
           result.Append(" )  ");
           result.Append(" ) "+ resShortName +"PASPORTA ");
           result.Append(" FULL JOIN  ");
           result.Append(" (  ");
           result.Append(" SELECT DISTINCT  ");
           result.Append("SBYTOVIKI_AB_N, ");
           result.Append("SBYTOVIKI_FIO, ");
           result.Append("NAIM AS SBYTOVIKI_STREET, ");
           result.Append("SBYTOVIKI_DOM, ");
           result.Append("SBYTOVIKI_N_TP, ");
           result.Append("SBYTOVIKI_N_VL ");
           result.Append(" FROM ");
           result.Append(resShortName + "result ");
           result.Append(" JOIN  ");
           result.Append(resShortName + "street  ");
           result.Append(" ON ");
           result.Append(" (UPPER(TRIM(" + resShortName + "result.sbytoviki_street)) = UPPER(TRIM(" + resShortName + "street.nom))) ");
           result.Append("  ) "+ resShortName +"SBYTOVIKI ");
           result.Append(" ON ");
           result.Append("  (UPPER(TRIM("+ resShortName +"PASPORTA.PASPORT_AB_N)) = UPPER(TRIM("+ resShortName + "SBYTOVIKI.SBYTOVIKI_AB_N))) ");

           return result.ToString();
       }

      
    }
}
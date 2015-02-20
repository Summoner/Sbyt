using System.Data;
using System.Data.Common;

/// <summary>
/// Класс для реализации всех общих задач  приложения
/// </summary>
public abstract class BaseDal
{

    
     

    //Для обновления

    protected int ExecuteNonQuery(DbCommand cmd)
    {
        return cmd.ExecuteNonQuery();
    }

    //Для выборки данных
    protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
    {
        return cmd.ExecuteReader(behavior);
    }

    protected IDataReader ExecuteReader(DbCommand cmd)
    {
        return ExecuteReader(cmd, CommandBehavior.Default);
    }

    protected object ExecuteScalar(DbCommand cmd)
    {
        return cmd.ExecuteScalar();
    }

    
}
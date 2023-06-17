using System.Data;

namespace VoFtwE.DataCommander;
/// <summary>
/// Inteface.SaveData
/// </summary>
public interface ISaveData
{
    /// <summary>
    /// SaveData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <param name="parameters"></param>
    /// <param name="connectionString"></param>
    /// <param name="commandType"></param>
    /// <param name="databaseType"></param>
    Task Execute<T>(string query, T parameters, string connectionString, CommandType commandType, DatabaseType databaseType);
}

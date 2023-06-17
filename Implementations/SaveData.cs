using Dapper;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System.Data;

namespace VoFtwE.DataCommander;

/// <summary>
/// Implementation.SaveData
/// </summary>
public class SaveData : ISaveData
{
    readonly ILogger<SaveData> _logger;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    public SaveData(ILogger<SaveData> logger) => _logger = logger;
    /// <summary>
    /// SaveData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="q">Query</param>
    /// <param name="p">Parameters</param>
    /// <param name="cS">ConnectionString</param>
    /// <param name="ct">CommandType</param>
    /// <param name="databaseType"></param>
    /// <returns>Nothing</returns>
    public async Task Execute<T>(string q, T p, string cS = "DefaultCon", CommandType ct = CommandType.StoredProcedure, DatabaseType databaseType = DatabaseType.MsSql)
    {
        switch (databaseType)
        {
            case DatabaseType.MySql:
                using (MySqlConnection connection = new(cS))
                {
                    await connection.ExecuteAsync(q, p, commandType: ct);
                }
                break;
            case DatabaseType.MsSql:
                break;
            case DatabaseType.PgSql:
                break;
            default:
                _logger.LogError("Somehow!!! No.Database Has Been Selected");
                break;
        }
    }
}

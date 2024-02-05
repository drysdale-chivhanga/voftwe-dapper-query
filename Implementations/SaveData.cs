using Dapper;
using Microsoft.Data.SqlClient;
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
    /// <param name="qry">Query[Raw/Stored-Procedure]</param>
    /// <param name="prms">Query.Paramerters</param>
    /// <param name="conStrng">Targeted.ConnectionString[PLAIN]</param>
    /// <param name="tCmdT">Targeted.CommandType</param>
    /// <param name="tDbT">Targeted.DatabaseType</param>
    /// <returns>Nothing</returns>
    public async Task ExecuteAsync<T>(string qry, T prms, string conStrng, CommandType tCmdT, DatabaseType tDbT)
    {
        switch (tDbT)
        {
            case DatabaseType.MySql:
                using (MySqlConnection connection = new(conStrng))
                {
                    await connection.ExecuteAsync(qry, prms, commandType: tCmdT);
                }
                break;
            case DatabaseType.MsSql:
                using (IDbConnection connection = new SqlConnection(conStrng))
                {
                    await connection.ExecuteAsync(qry, prms, commandType: tCmdT);
                }
                break;
            case DatabaseType.PgSql:
                //using (NpgsqlConnection connection = new(cS))
                //{
                //    await connection.ExecuteAsync(q, p, commandType: ct);
                //}
                break;
            default:
                _logger.LogError("Somehow!!! No.Database Has Been Selected");
                break;
        }
    }
}

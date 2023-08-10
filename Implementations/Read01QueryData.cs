using Dapper;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System.Data;

namespace VoFtwE.DataCommander;

/// <summary>
/// Implementation.Read01QueryData
/// </summary>
public class Read01QueryData : IRead01QueryData
{
    readonly ILogger<Read01QueryData> _logger;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    public Read01QueryData(ILogger<Read01QueryData> logger) => _logger = logger;

    /// <summary>
    /// Read01QueryData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="qry">Query[Raw/Stored-Procedure]</param>
    /// <param name="prms">Query.Paramerters</param>
    /// <param name="conStrng">Targeted.ConnectionString[PLAIN]</param>
    /// <param name="tCmdT">Targeted.CommandType</param>
    /// <param name="tDbT">Targeted.DatabaseType</param>
    /// <returns>01-List.Of.Type[T]</returns>
    public async Task<IEnumerable<T>> ExecuteAsync<T, U>(string qry, U prms, string conStrng, CommandType tCmdT, DatabaseType tDbT)
    {
        List<T> response = new();
        switch (tDbT)
        {
            case DatabaseType.MySql:
                using (MySqlConnection connection = new(conStrng))
                {
                    response = (List<T>)await connection.QueryAsync<T>(sql: qry, param: prms, commandType: tCmdT);
                }
                break;
            case DatabaseType.MsSql:
                //using (IDbConnection connection = new SqlConnection(cS))
                //{
                //    response = (List<T>)await connection.QueryAsync<T>(sql: q, param: p, commandType: cT);
                //}
                break;
            case DatabaseType.PgSql:
                //using (NpgsqlConnection connection = new(cS))
                //{
                //    response = (List<T>)await connection.QueryAsync<T>(sql: q, param: p, commandType: cT);
                //}
                break;
            default:
                _logger.LogError("Somehow!!! No.Database Has Been Selected");
                break;
        }
        return response;
    }
}

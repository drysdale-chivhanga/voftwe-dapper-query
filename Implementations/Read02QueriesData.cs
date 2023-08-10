using Dapper;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System.Data;

namespace VoFtwE.DataCommander;

/// <summary>
/// Implementation.Read02QueriesData
/// </summary>
public class Read02QueriesData : IRead02QueriesData
{
    readonly ILogger<Read02QueriesData> _logger;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    public Read02QueriesData(ILogger<Read02QueriesData> logger) => _logger = logger;

    /// <summary>
    /// Read02QueriesData
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="qry">Query[Raw/Stored-Procedure]</param>
    /// <param name="prms">Query.Paramerters</param>
    /// <param name="conStrng">Targeted.ConnectionString[PLAIN]</param>
    /// <param name="tCmdT">Targeted.CommandType</param>
    /// <param name="tDbT">Targeted.DatabaseType</param>
    /// <returns>02-List.Of.Type[T1,T2]</returns>
    public async Task<Tuple<List<T1>, List<T2>>> ExecuteAsync<T1, T2, U>(string qry, U prms, string conStrng, CommandType tCmdT, DatabaseType tDbT)
    {
        List<T1> list01 = new();
        List<T2> list02 = new();
        switch (tDbT)
        {
            case DatabaseType.MySql:
                using (MySqlConnection connection = new(conStrng))
                {
                    using var lists = await connection.QueryMultipleAsync(sql: qry, param: prms, commandType: tCmdT);
                    list01 = lists.Read<T1>().ToList();
                    list02 = lists.Read<T2>().ToList();
                }
                break;
            case DatabaseType.MsSql:
                //using (IDbConnection connection = new SqlConnection(cS))
                //{
                //    using var lists = await connection.QueryMultipleAsync(sql: q, param: p, commandType: cT);
                //    list01 = lists.Read<T1>().ToList();
                //    list02 = lists.Read<T2>().ToList();
                //}
                break;
            case DatabaseType.PgSql:
                //using (NpgsqlConnection connection = new(cS))
                //{
                //    using var lists = await connection.QueryMultipleAsync(sql: q, param: p, commandType: cT);
                //    list01 = lists.Read<T1>().ToList();
                //    list02 = lists.Read<T2>().ToList();
                //}
                break;
            default:
                _logger.LogError("Somehow!!! No.Database Has Been Selected");
                break;
        }
        return new Tuple<List<T1>, List<T2>>(list01, list02);
    }
}

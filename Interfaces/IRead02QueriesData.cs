using System.Data;

namespace VoFtwE.DataCommander;

/// <summary>
/// Interface.Read02QueriesData
/// </summary>
public interface IRead02QueriesData
{
    /// <summary>
    /// Read02QueriesData
    /// </summary>
    /// <typeparam name="T1"/>
    /// <typeparam name="T2"/>
    /// <typeparam name="U"/>
    /// <param name="qry">Query[Raw/Stored-Procedure]</param>
    /// <param name="prms">Query.Paramerters</param>
    /// <param name="conStrng">Targeted.ConnectionString[PLAIN]</param>
    /// <param name="tCmdT">Targeted.CommandType</param>
    /// <param name="tDbT">Targeted.DatabaseType</param>
    /// <returns>02-Lists.Of.Types[T1,T2]</returns>
    Task<Tuple<List<T1>, List<T2>>> ExecuteAsync<T1, T2, U>(string qry, U prms, string conStrng, CommandType tCmdT, DatabaseType tDbT);
}

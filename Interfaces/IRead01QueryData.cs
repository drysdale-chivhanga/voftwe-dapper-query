using System.Data;

namespace VoFtwE.DataCommander;

/// <summary>
/// Interface.Read01QueryData
/// </summary>
public interface IRead01QueryData
{
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
    Task<IEnumerable<T>> ExecuteAsync<T, U>(string qry, U prms, string conStrng, CommandType tCmdT, DatabaseType tDbT);
}

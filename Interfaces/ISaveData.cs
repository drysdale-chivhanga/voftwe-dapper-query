﻿using System.Data;

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
    /// <param name="qry">Query[Raw/Stored-Procedure]</param>
    /// <param name="prm">Query.Paramerters</param>
    /// <param name="conStrng">Targeted.ConnectionString[PLAIN]</param>
    /// <param name="tCmdT">Targeted.CommandType</param>
    /// <param name="tDbT">Targeted.DatabaseType</param>
    /// <returns>Nothing</returns>
    Task ExecuteAsync<T>(string qry, T prm, string conStrng, CommandType tCmdT, DatabaseType tDbT);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Log
{
    public enum LogLevel : byte
    {
        Info,
        Warning,
        Error
    }

    public static void Info(string message)
    {
        DebugLog(LogLevel.Info, message);
    }

    public static void Warning(string message)
    {
        DebugLog(LogLevel.Warning, message);
    }

    public static void Error(string message)
    {
        DebugLog(LogLevel.Error, message);
    }

    private static void DebugLog(LogLevel level, string message)
    {
        switch (level)
        {
            case LogLevel.Info: Debug.Log(message); break;
            case LogLevel.Warning: Debug.LogWarning(message); break;
            case LogLevel.Error: Debug.LogError(message); break;
        }
    }
}

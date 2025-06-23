using System;
using UnityEngine;

namespace LCCommonTools.DebugUtility
{
    [Flags]
    public enum LogLevel
    {
        NONE = 0,
        LOG = 1,
        WARNING = 2,
        ERROR = 4,
        EXCEPTION = 8,
        ALL = LOG | WARNING | ERROR | EXCEPTION
    }

    /// <summary>
    /// DebugLog的封装，方便Runtime的开闭
    /// </summary>
    public static class LogUtility
    {
        public static LogLevel logLevel { get; set; } = LogLevel.ALL;

        public static void Log(object obj, string tag = "", Color? logColor = null)
        {
            if((logLevel & LogLevel.LOG) == LogLevel.NONE) return;
            Debug.Log(logColor != null
                ? $"<b><color={ColorUtility.ToHtmlStringRGB(logColor.Value)}>{tag}:{obj}</color></b>"
                : $"{tag}:{obj}");
        }
        
        public static void LogWarning(object obj, string tag = "", Color? logColor = null)
        {
            if((logLevel & LogLevel.ERROR) == LogLevel.NONE) return;
            Debug.LogWarning(logColor != null
                ? $"<b><color={ColorUtility.ToHtmlStringRGB(logColor.Value)}>{tag}:{obj}</color></b>"
                : $"{tag}:{obj}");
        }
        
        public static void LogError(object obj, string tag = "", Color? logColor = null)
        {
            if((logLevel & LogLevel.ERROR) == LogLevel.NONE) return;
            Debug.LogError(logColor != null
                ? $"<b><color={ColorUtility.ToHtmlStringRGB(logColor.Value)}>{tag}:{obj}</color></b>"
                : $"{tag}:{obj}");
        }
        
        public static void LogException(Exception e)
        {
            if((logLevel & LogLevel.EXCEPTION) == LogLevel.NONE) return;
            Debug.LogException(e);
        }
    }
}
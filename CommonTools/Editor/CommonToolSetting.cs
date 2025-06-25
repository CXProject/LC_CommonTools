using LCCommonTools.DebugUtility;
using UnityEditor;
using UnityEngine;
using LogLevel = LCCommonTools.DebugUtility.LogLevel;

namespace LCCommonTools
{
    /// <summary>
    /// 一些Settings的GUI
    /// </summary>
    public class CommonToolSetting : EditorWindow
    {
        [MenuItem("LAPCATTools/CommonTools/CommonToolSetting")]
        public static void ShowWindow()
        {
            var win = GetWindow<CommonToolSetting>();
            win.titleContent = new GUIContent("CommonToolSetting");
            win.Initialize();
            win.Show();
        }

        private void Initialize()
        {
        }

        private void OnGUI()
        {
            ShowLogPanel();
        }

        #region LogUtility
        
        private static string[] LogLevelStr = new string[] { "Debug", "Info", "Warning", "Error" };

        private void ShowLogPanel()
        {
            using (new GUILayout.VerticalScope("Box"))
            {
                GUILayout.Label("Log Level:");
                var logLevel = EditorGUILayout.MaskField((int) LogUtility.logLevel, LogLevelStr);
                if (GUI.changed)
                {
                    LogUtility.logLevel = (LogLevel) logLevel;
                }
            }
        }

        #endregion

        
    }
}
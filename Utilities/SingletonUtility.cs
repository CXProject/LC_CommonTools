using UnityEngine;

namespace LCCommonTools.ScriptUtility
{
    /// <summary>
    /// 单例
    /// </summary>
    public class Singleton<T> where T : class, new()
    {
        private static T _instance;
        
        public static bool IsExist => _instance != null;

        public static T Reset()
        {
            _instance = new T();
            return _instance;
        }

        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new T();
                return _instance;
            }
        }
    }

    /// <summary>
    /// MonoBehaviour的单例
    /// </summary>
    public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
    {
        private static T _instance;
        public static bool IsExist => _instance != null;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = (T)FindAnyObjectByType(typeof(T));
                if(_instance == null)
                    _instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                _instance.InitializeInternal();
                return _instance;
            }
        }

        protected virtual bool DonDestroyOnLoad { get; } = false;

        private void InitializeInternal()
        {
            if (DonDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
            Initialize();
        }

        protected virtual void Initialize()
        {
        }

        public static void DestroyInstance()
        {
            if(_instance == null) return;
            Destroy(_instance.gameObject);
            _instance = null;
        }
    }
}
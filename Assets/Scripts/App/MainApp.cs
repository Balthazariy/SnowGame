using System;
using UnityEngine;

namespace SnowGame
{
    public class MainApp : MonoBehaviour
    {
        public Action OnGameLoadedEvent;

        private static MainApp _Instance;
        public static MainApp Instance
        {
            get { return _Instance; }
            private set { _Instance = value; }
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            Application.targetFrameRate = 60;
        }

        private void Start()
        {
            if (Instance == this)
            {
                GameClient.Instance.InitServices();
            }
        }

        private void Update()
        {
            if (Instance == this)
            {
                GameClient.Instance.Update();
            }
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                GameClient.Instance.Dispose();
                Instance = null;
            }
        }

        public void Dispose()
        {
            MonoBehaviour.Destroy(gameObject);
        }
    }
}


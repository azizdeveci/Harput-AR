using UnityEngine;
using System;
using System.Collections.Generic;

namespace HarputAR.Managers
{
    [Serializable]
    public class LogEntry
    {
        public string sessionId;
        public string scenarioId;
        public string eventType;
        public string timestamp;
    }

    public class LogManager : MonoBehaviour
    {
        public static LogManager Instance { get; private set; }
        List<LogEntry> loglar = new();
        string sessionId;

        void Awake()
        {
            if (Instance != null) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            sessionId = Guid.NewGuid().ToString("N")[..8];
        }

        public void Log(string scenarioId, string eventType)
        {
            loglar.Add(new LogEntry {
                sessionId  = this.sessionId,
                scenarioId = scenarioId,
                eventType  = eventType,
                timestamp  = DateTime.UtcNow.ToString("o")
            });
            Debug.Log($"[LOG] {scenarioId} | {eventType}");
        }

        void OnApplicationQuit()
        {
            string yol = Application.persistentDataPath + $"/log_{sessionId}.json";
            System.IO.File.WriteAllText(yol, JsonUtility.ToJson(new { logs = loglar }));
        }
    }
}
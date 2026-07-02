using UnityEngine;
using UnityEngine.SceneManagement;

namespace HarputAR.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public enum ActiveScenario { None, S1_Kule, S2_Kabartma, S3_ZamanGecisi, S4_CocukMisyon }
        public ActiveScenario CurrentScenario { get; private set; } = ActiveScenario.None;

        void Awake()
        {
            if (Instance != null) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void LoadScenario(ActiveScenario scenario)
        {
            CurrentScenario = scenario;
            Debug.Log($"[GameManager] Senaryo: {scenario}");
        }

        public void QuitApp() => Application.Quit();
    }
}
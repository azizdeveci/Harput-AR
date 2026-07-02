using UnityEngine;
using UnityEngine.SceneManagement;
using HarputAR.Managers;

namespace HarputAR.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [Header("Paneller")]
        [SerializeField] GameObject anaMenuPanel;
        [SerializeField] GameObject ayarlarPanel;

        void Start() => anaMenuPanel?.SetActive(true);

        public void S1Yukle() => SceneManager.LoadScene("S1_KuleRekonstruksiyonu");
        public void S2Yukle() => SceneManager.LoadScene("S2_KabartmaAnimasyon");
        public void S3Yukle() => SceneManager.LoadScene("S3_ZamanGecisi");
        public void S4Yukle() => SceneManager.LoadScene("S4_CocukMisyon");

        public void AyarlariAc()
        {
            anaMenuPanel?.SetActive(false);
            ayarlarPanel?.SetActive(true);
        }

        public void UygulamaKapat() => Application.Quit();
    }
}
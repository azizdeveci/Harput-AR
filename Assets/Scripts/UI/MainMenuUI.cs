using UnityEngine;
using UnityEngine.SceneManagement;

namespace HarputAR.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        public void S1Yukle() => SceneManager.LoadScene("S1_KuleRekonstruksiyonu");
        public void S2Yukle() => SceneManager.LoadScene("S2_KabartmaAnimasyon");
        public void S3Yukle() => SceneManager.LoadScene("S3_ZamanGecisi");
        public void S4Yukle() => SceneManager.LoadScene("S4_CocukMisyon");

        public void UygulamaKapat() => Application.Quit();
    }
}
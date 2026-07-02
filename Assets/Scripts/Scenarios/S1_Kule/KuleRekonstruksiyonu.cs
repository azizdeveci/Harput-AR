using UnityEngine;
using System.Collections;

namespace HarputAR.Scenarios.S1
{
    public class KuleRekonstruksiyonu : MonoBehaviour
    {
        [Header("Donem Modelleri")]
        [SerializeField] GameObject[] donemModelleri;
        [SerializeField] float gecisHizi = 0.8f;

        [Header("Bilgi Karti")]
        [SerializeField] GameObject bilgiKartiPanel;
        [SerializeField] TMPro.TextMeshProUGUI baslikText;
        [SerializeField] TMPro.TextMeshProUGUI icerikText;

        int aktifIndex = 3;

        readonly string[] donemAdlari = {
            "Tunc Cagi MO 2000", "Urartu MO 800", "Bizans MS 600",
            "Artuklu 1100", "Eyyubi 1220", "Osmanli 1517", "Gunumuz"
        };

        void Start() => DonemGoster(aktifIndex);

        public void DonemDegistir(int index)
        {
            if (index < 0 || index >= donemModelleri.Length) return;
            StartCoroutine(DonemGecis(index));
        }

        IEnumerator DonemGecis(int yeniIndex)
        {
            if (donemModelleri[aktifIndex] != null)
                donemModelleri[aktifIndex].SetActive(false);

            yield return new WaitForSeconds(gecisHizi);

            aktifIndex = yeniIndex;
            DonemGoster(aktifIndex);
        }

        void DonemGoster(int index)
        {
            for (int i = 0; i < donemModelleri.Length; i++)
                if (donemModelleri[i] != null)
                    donemModelleri[i].SetActive(i == index);

            Debug.Log($"[S1] Donem: {donemAdlari[index]}");
        }

        public void BilgiKartiAc()
        {
            if (bilgiKartiPanel == null) return;
            baslikText.text  = donemAdlari[aktifIndex];
            icerikText.text  = $"{donemAdlari[aktifIndex]} donemi hakkinda bilgi.";
            bilgiKartiPanel.SetActive(true);
        }

        public void BilgiKartiKapat() => bilgiKartiPanel?.SetActive(false);

        public void EkranGoruntusuAl() =>
            ScreenCapture.CaptureScreenshot($"HarputAR_{System.DateTime.Now:yyyyMMdd_HHmmss}.png");
    }
}
using UnityEngine;
using System.Collections.Generic;

namespace HarputAR.Scenarios.S4
{
    public class CocukMisyon : MonoBehaviour
    {
        public static CocukMisyon Instance { get; private set; }

        [Header("UI")]
        [SerializeField] TMPro.TextMeshProUGUI ilerlemeText;
        [SerializeField] GameObject sertifikaPanel;
        [SerializeField] GameObject[] misyonTikIsaretleri;

        public enum Misyon { M1_Zindan, M2_Kabartma, M3_Motif, M4_Damga }

        Dictionary<Misyon, bool> tamamlananlar = new();

        void Awake()
        {
            if (Instance != null) { Destroy(gameObject); return; }
            Instance = this;
            foreach (Misyon m in System.Enum.GetValues(typeof(Misyon)))
                tamamlananlar[m] = false;
        }

        public void MisyonTamamla(Misyon misyon)
        {
            if (tamamlananlar[misyon]) return;
            tamamlananlar[misyon] = true;

            int index = (int)misyon;
            if (misyonTikIsaretleri != null && index < misyonTikIsaretleri.Length)
                misyonTikIsaretleri[index].SetActive(true);

            IlerlemeGuncelle();
            if (TumunuTamamladi()) sertifikaPanel?.SetActive(true);
            Debug.Log($"[S4] Tamamlandi: {misyon}");
        }

        void IlerlemeGuncelle()
        {
            int n = 0;
            foreach (var v in tamamlananlar.Values) if (v) n++;
            if (ilerlemeText != null) ilerlemeText.text = $"{n} / 4 Tamamlandi";
        }

        bool TumunuTamamladi()
        {
            foreach (var v in tamamlananlar.Values) if (!v) return false;
            return true;
        }

        public bool MisyonDurumu(Misyon m) => tamamlananlar[m];
    }
}
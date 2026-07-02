using UnityEngine;
using System.Collections;

namespace HarputAR.Scenarios.S3
{
    public class ZamanGecisi : MonoBehaviour
    {
        [Header("Donem Modelleri")]
        [SerializeField] GameObject[] donemModelleri;
        [SerializeField] AudioClip[]  donemSesleri;
        [SerializeField] TMPro.TextMeshProUGUI donemEtiketi;

        AudioSource audioSource;
        int  aktifIndex;
        bool gecisYapiliyor;

        readonly string[] donemAdlari = { "MO 2000","MO 800","MS 600","1100","1517","Gunumuz" };

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            DonemGoster(0);
        }

        Vector2 swipeBaslangic;

        void Update()
        {
            if (Input.touchCount != 1) return;
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began) swipeBaslangic = t.position;
            if (t.phase == TouchPhase.Ended)
            {
                float dx = t.position.x - swipeBaslangic.x;
                if (Mathf.Abs(dx) > 50f)
                {
                    if (dx > 0 && aktifIndex > 0) DonemGoster(aktifIndex - 1);
                    else if (dx < 0 && aktifIndex < donemModelleri.Length - 1) DonemGoster(aktifIndex + 1);
                }
            }
        }

        void DonemGoster(int index)
        {
            if (gecisYapiliyor) return;
            StartCoroutine(GecisAnimasyon(index));
        }

        IEnumerator GecisAnimasyon(int yeni)
        {
            gecisYapiliyor = true;
            donemModelleri[aktifIndex]?.SetActive(false);
            yield return new WaitForSeconds(0.4f);
            aktifIndex = yeni;
            donemModelleri[aktifIndex]?.SetActive(true);
            if (audioSource != null && donemSesleri != null && yeni < donemSesleri.Length)
            { audioSource.clip = donemSesleri[yeni]; audioSource.Play(); }
            if (donemEtiketi != null) donemEtiketi.text = donemAdlari[yeni];
            gecisYapiliyor = false;
            Debug.Log($"[S3] Donem: {donemAdlari[yeni]}");
        }
    }
}
using UnityEngine;

namespace HarputAR.Scenarios.S2
{
    public class KabartmaAnimasyon : MonoBehaviour
    {
        [Header("Figurler")]
        [SerializeField] Animator[]    savasciFigurleri;
        [SerializeField] ParticleSystem sembolParlama;

        [Header("Ses")]
        [SerializeField] AudioSource spatialAudio;
        [SerializeField] AudioClip   ortamSesi;

        [Header("Arastirmaci Modu")]
        [SerializeField] GameObject arastirmaciPanel;
        [SerializeField] float      uzunBasmaSuresi = 1.5f;

        bool  animasyonAktif;
        float basmaZamani;
        bool  uzunBasmaBasladi;

        public void AnimasyonBaslat()
        {
            if (animasyonAktif) return;
            animasyonAktif = true;
            foreach (var fig in savasciFigurleri)
                fig?.SetTrigger("Canlan");
            sembolParlama?.Play();
            if (spatialAudio != null) { spatialAudio.clip = ortamSesi; spatialAudio.loop = true; spatialAudio.Play(); }
            Debug.Log("[S2] Animasyon basladi");
        }

        public void AnimasyonDurdur()
        {
            animasyonAktif = false;
            foreach (var fig in savasciFigurleri) fig?.SetTrigger("Dur");
            spatialAudio?.Stop();
            sembolParlama?.Stop();
        }

        void Update()
        {
            if (Input.touchCount == 0) return;
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) { basmaZamani = Time.time; uzunBasmaBasladi = true; }
            if (uzunBasmaBasladi && Time.time - basmaZamani >= uzunBasmaSuresi)
            {
                arastirmaciPanel?.SetActive(true);
                uzunBasmaBasladi = false;
            }
            if (touch.phase == TouchPhase.Ended) uzunBasmaBasladi = false;
        }

        public void ArastirmaciKapat() => arastirmaciPanel?.SetActive(false);
    }
}
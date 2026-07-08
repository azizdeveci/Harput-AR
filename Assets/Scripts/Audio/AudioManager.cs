using UnityEngine;

namespace HarputAR.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [Header("Fon Muzigi")]
        [SerializeField] AudioClip fonMuzigi;
        [SerializeField] float muzikSesi = 0.4f;

        [Header("Buton Sesi (Varsayilan)")]
        [SerializeField] AudioClip varsayilanTiklamaSesi;
        [SerializeField] float efektSesi = 0.7f;

        AudioSource muzikKaynagi;
        AudioSource efektKaynagi;

        void Awake()
        {
            if (Instance != null) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            muzikKaynagi = gameObject.AddComponent<AudioSource>();
            muzikKaynagi.loop = true;
            muzikKaynagi.playOnAwake = false;
            muzikKaynagi.volume = muzikSesi;

            efektKaynagi = gameObject.AddComponent<AudioSource>();
            efektKaynagi.playOnAwake = false;
            efektKaynagi.volume = efektSesi;

            if (fonMuzigi != null)
            {
                muzikKaynagi.clip = fonMuzigi;
                muzikKaynagi.Play();
            }
        }

        public void TiklamaSesiCal(AudioClip ozelSes = null)
        {
            AudioClip calinacak = ozelSes != null ? ozelSes : varsayilanTiklamaSesi;
            if (calinacak != null)
                efektKaynagi.PlayOneShot(calinacak);
        }

        public void MuzikSesiAyarla(float deger) => muzikKaynagi.volume = deger;
        public void EfektSesiAyarla(float deger) => efektKaynagi.volume = deger;

        public void MuzikDurdur() => muzikKaynagi.Stop();
        public void MuzikBaslat()
        {
            if (fonMuzigi != null && !muzikKaynagi.isPlaying)
                muzikKaynagi.Play();
        }
    }
}
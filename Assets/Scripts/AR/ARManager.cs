using UnityEngine;
using System.Collections;

namespace HarputAR.AR
{
    public class ARManager : MonoBehaviour
    {
        public static ARManager Instance { get; private set; }

        [Header("GPS")]
        [SerializeField] float gpsUpdateInterval = 2f;
        [SerializeField] float poiTriggerRadius  = 15f;

        public Vector2 CurrentGPS { get; private set; }
        public bool    GPSActive  { get; private set; }

        void Awake()
        {
            if (Instance != null) { Destroy(gameObject); return; }
            Instance = this;
        }

        void Start() => StartCoroutine(InitGPS());

        IEnumerator InitGPS()
        {
            if (!Input.location.isEnabledByUser) yield break;
            Input.location.Start(1f, 1f);
            int t = 10;
            while (Input.location.status == LocationServiceStatus.Initializing && t-- > 0)
                yield return new WaitForSeconds(1f);

            if (Input.location.status == LocationServiceStatus.Running)
            {
                GPSActive = true;
                StartCoroutine(UpdateGPS());
            }
        }

        IEnumerator UpdateGPS()
        {
            while (true)
            {
                CurrentGPS = new Vector2(
                    Input.location.lastData.latitude,
                    Input.location.lastData.longitude);
                yield return new WaitForSeconds(gpsUpdateInterval);
            }
        }

        public bool IsNearPOI(Vector2 poi)
        {
            float R = 6371000f;
            float dLat = Mathf.Deg2Rad * (poi.x - CurrentGPS.x);
            float dLon = Mathf.Deg2Rad * (poi.y - CurrentGPS.y);
            float h = Mathf.Sin(dLat/2)*Mathf.Sin(dLat/2) +
                      Mathf.Cos(Mathf.Deg2Rad*CurrentGPS.x)*Mathf.Cos(Mathf.Deg2Rad*poi.x)*
                      Mathf.Sin(dLon/2)*Mathf.Sin(dLon/2);
            return R * 2 * Mathf.Atan2(Mathf.Sqrt(h), Mathf.Sqrt(1-h)) <= poiTriggerRadius;
        }

        void OnDestroy() => Input.location.Stop();
    }
}
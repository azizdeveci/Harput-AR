using UnityEngine;
using System.Collections.Generic;

namespace HarputAR.Data
{
    [CreateAssetMenu(fileName = "POIData", menuName = "HarputAR/POI Data")]
    public class POIData : ScriptableObject
    {
        [System.Serializable]
        public class POIPoint
        {
            public string id;
            public string ad;
            public string senaryo;
            public float  latitude;
            public float  longitude;
            public float  tetiklemeMesafesi = 15f;
            [TextArea] public string aciklama;
        }

        public List<POIPoint> noktalar = new()
        {
            new POIPoint { id="P01", ad="Kuzey Kulesi",   senaryo="S1", latitude=38.7512f, longitude=39.2698f },
            new POIPoint { id="P02", ad="Guney Kulesi",   senaryo="S1", latitude=38.7508f, longitude=39.2695f },
            new POIPoint { id="P03", ad="Kabartma Alani", senaryo="S2", latitude=38.7515f, longitude=39.2702f },
            new POIPoint { id="P04", ad="Ana Kale Girisi",senaryo="S3", latitude=38.7510f, longitude=39.2700f },
            new POIPoint { id="P05", ad="Zindan",         senaryo="S4", latitude=38.7506f, longitude=39.2693f },
        };
    }
}
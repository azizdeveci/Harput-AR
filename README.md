# 🏰 Harput Kalesi AR — Unity Proje Kurulum Rehberi

## Gereksinimler
- Unity 2022.3 LTS (veya üzeri)
- Unity Hub 3.x
- Android Build Support (SDK + NDK)
- iOS Build Support (Xcode 14+)
- AR Foundation 5.1+

## Kurulum Adımları

### 1. Unity Hub'da Proje Aç
```
Unity Hub → Add → Bu klasörü seç → HarputAR/
```

### 2. Paketleri Yükle (otomatik)
`Packages/manifest.json` dosyası açılınca Unity otomatik yükler:
- AR Foundation
- ARCore XR Plugin (Android)
- ARKit XR Plugin (iOS)
- Input System
- TextMeshPro
- Addressables

### 3. Android Ayarları
```
Edit → Project Settings → XR Plug-in Management
✅ ARCore işaretle
```
```
Edit → Project Settings → Player → Android
- Min API Level: 26 (Android 8.0)
- Target API: 33+
- Scripting Backend: IL2CPP
- Architecture: ARM64
```

### 4. iOS Ayarları
```
Edit → Project Settings → XR Plug-in Management → iOS
✅ ARKit işaretle
```
```
Player → iOS
- Camera Usage Description: "AR deneyimi için kamera gereklidir"
- Location Usage Description: "AR noktalarına yönlendirme için konum gereklidir"
```

### 5. Sahneler
| Sahne | Açıklama |
|-------|----------|
| MainMenu | Ana menü ve senaryo seçimi |
| S1_KuleRekonstruksiyonu | Kule AR deneyimi |
| S2_KabartmaAnimasyon | Kabartma animasyon deneyimi |
| S3_ZamanGecisi | Dönemler arası geçiş |
| S4_CocukMisyon | Çocuk misyon modu |

### 6. Script Hiyerarşisi
```
HarputAR/Assets/Scripts/
├── Managers/
│   ├── GameManager.cs      ← Singleton, sahne yönetimi
│   └── LogManager.cs       ← Anonim analitik log
├── AR/
│   └── ARManager.cs        ← GPS + görüntü tanıma
├── UI/
│   └── MainMenuUI.cs       ← Ana menü kontrolü
├── Data/
│   └── POIData.cs          ← GPS koordinatları (ScriptableObject)
└── Scenarios/
    ├── S1_KuleRekonstruksiyonu/KuleRekonstruksiyonu.cs
    ├── S2_KabartmaAnimasyon/KabartmaAnimasyon.cs
    ├── S3_ZamanGecisi/ZamanGecisi.cs
    └── S4_CocukMisyon/CocukMisyon.cs
```

### 7. Performans Hedefleri
| Metrik | Hedef |
|--------|-------|
| Frame Rate | ≥ 25 FPS |
| Model Yükleme | ≤ 4 sn |
| GPS Hatası | ≤ 1 m |
| Uygulama Boyutu | ≤ 28 MB |
| Çökme Oranı | ≤ %2 |

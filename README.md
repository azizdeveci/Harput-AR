# 🏰 Harput Kalesi AR Uygulaması

> Artırılmış Gerçeklik teknolojisi ile Harput Kalesi'nin 4000 yıllık tarihini keşfet.

[![Unity](https://img.shields.io/badge/Unity-6000.5.1f1-black?logo=unity)](https://unity.com)
[![AR Foundation](https://img.shields.io/badge/AR%20Foundation-6.x-blue)](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@6.0)
[![Platform](https://img.shields.io/badge/Platform-Android-green)](https://github.com)
[![License](https://img.shields.io/badge/License-MIT-yellow)](LICENSE)

---

## 📱 Uygulamayı Hemen Dene

**APK İndir (Android):** [Releases sayfasından indir](../../releases/latest)

```
1. Yukarıdaki linkten APK dosyasını indir
2. Android telefonunda Ayarlar → Güvenlik → Bilinmeyen kaynaklar: AÇ
3. APK'ya tıkla → Yükle
4. Harput Kalesi'ne git ve uygulamayı aç!
```

> ⚠️ **Önemli:** Uygulamanın AR özelliklerinin tam çalışması için telefonunuzun **Google Play Services for AR (ARCore)** desteklemesi gerekir. Cihazınızın destekleyip desteklemediğini şu adresten kontrol edebilirsiniz: https://developers.google.com/ar/devices

---

## 🎯 Uygulama Nedir?

Yazılım Mühendisliği Güncel Konular dersi projesi kapsamında geliştirilen bu uygulama, Harput Kalesi ziyaretçilerine **4 farklı AR deneyimi** sunar. Her senaryonun kendine özgü bir arka plan teması, fon müziği ve geri navigasyon butonu bulunur.

| Senaryo | Açıklama | Süre | Hedef Kullanıcı |
|---------|----------|------|------------------|
| 🏛️ **S1** Kule Rekonstrüksiyonu | Yıkık surları 7 tarihi dönemde (MÖ 2000 → Günümüz) yeniden görselleştirir | 4-7 dk | Herkes |
| 🪨 **S2** Kabartma Animasyonu | 4000 yıllık savaş sahnesi kabartmasını canlandırır, araştırmacı modu sunar | 6-10 dk | Turist + Araştırmacı |
| ⏳ **S3** Zaman Geçişi | Parmak kaydırarak aynı noktada 6 farklı yüzyılı karşılaştırır | 5-8 dk | Yetişkin |
| 🎮 **S4** Çocuk Misyon Modu | 4 görevli oyunlaştırılmış keşif; rozet ve sertifika kazanımı | 30-45 dk | 7-14 yaş |

---

## 🛠️ Geliştirici Kurulum Rehberi

> Bu rehber, Unity ve AR geliştirme konusunda **hiçbir bilgisi olmayan** birinin bile projeyi adım adım çalıştırabilmesi için yazılmıştır.

### Adım 1 — Gerekli Programları Yükle

```
1. Unity Hub'ı indir: https://unity.com/download
2. Unity Hub'ı aç → Installs → Add → 6000.5.1f1 (veya üstü) sürümünü seç
   Kurulum sırasında şu modülleri de işaretle:
   ✅ Android Build Support
   ✅ Android SDK & NDK Tools
   ✅ OpenJDK
3. Git'i indir (zaten kurulu değilse): https://git-scm.com/downloads
```

### Adım 2 — Projeyi Bilgisayarına İndir (Clone)

Bilgisayarında bir klasör aç (örn. `C:\projects`), içine sağ tık → "Git Bash Here" veya bir terminal aç:

```bash
git clone https://github.com/azizdeveci/Harput-AR.git
cd Harput-AR
```

### Adım 3 — Unity'de Aç

```
1. Unity Hub'ı aç
2. Projects sekmesi → Add → az önce indirdiğin Harput-AR klasörünü seç
3. Listede beliren projeye tıkla, Unity 6000.5.1f1 ile açılsın
4. İlk açılışta Unity tüm paketleri otomatik indirip derler (5-10 dakika sürebilir, bekle)
```

### Adım 4 — Gerekli Paketlerin Kurulu Olduğunu Kontrol Et

```
Unity Editör → Window → Package Manager
Şunların listede olduğunu doğrula:
✅ AR Foundation
✅ Google ARCore XR Plugin
✅ TextMeshPro
✅ Input System
```
Eksik olan varsa, Package Manager'da sol üstten **Unity Registry**'yi seçip isimle arayarak **Install** edebilirsin.

### Adım 5 — Android Build Ayarlarını Yap

```
File → Build Profiles → Android sekmesine tıkla → "Switch Platform" bas (aktif değilse)
```

```
Edit → Project Settings → XR Plug-in Management → Android sekmesi
✅ Google ARCore işaretli olsun
```

```
Edit → Project Settings → Player → Android → Other Settings
Minimum API Level: Android 8.0 (API level 26)
Scripting Backend: IL2CPP
Target Architectures: ARM64
```

> 💡 **ARCore sertifikasız bir cihazda test ediyorsan:** `XR Plug-in Management → Android → ARCore` altındaki **Requirement** ayarını **Optional** yap. Bu, uygulamanın AR desteklemeyen cihazlarda da çökmeden açılmasını sağlar (AR özellikleri çalışmaz ama arayüz test edilebilir).

### Adım 6 — Sahneleri Kontrol Et

```
File → Build Profiles → Scene List (Open Scene List)
Şu 5 sahnenin sırayla listede olduğunu doğrula:
1. MainMenu
2. S1_KuleRekonstruksiyonu
3. S2_KabartmaAnimasyon
4. S3_ZamanGecisi
5. S4_CocukMisyon
```

### Adım 7 — Editörde Test Et

```
Assets/Scenes/MainMenu.unity dosyasına çift tıkla (açılsın)
Üstteki ▶ Play butonuna bas
```

> ⚠️ AR kamera görüntüsü **sadece gerçek cihazda** çalışır. Unity Editöründe Play moduna basınca kamera görüntüsü yerine simülatör ekranı veya siyah ekran görmen normaldir.

### Adım 8 — Telefona Yükle (Gerçek Test)

```
1. Telefonunda: Ayarlar → Telefon Hakkında → Yapı Numarasına 7 kez dokun (Geliştirici modu açılır)
2. Ayarlar → Geliştirici Seçenekleri → USB Hata Ayıklama: AÇ
3. Telefonu USB kablosuyla bilgisayara bağla
4. Telefonda çıkan "Bu bilgisayara izin ver?" sorusuna İzin Ver de
5. Unity'de: File → Build Profiles → Android → Run Device'da telefonunu seç
6. "Build And Run" butonuna bas
```

---

## 📁 Proje Yapısı

```
Harput-AR/
├── Assets/
│   ├── Scripts/
│   │   ├── Managers/
│   │   │   ├── GameManager.cs        # Sahne/senaryo durumu yönetimi (Singleton)
│   │   │   └── LogManager.cs         # Anonim kullanım logu (KVKK uyumlu)
│   │   ├── AR/
│   │   │   └── ARManager.cs          # GPS okuma, POI mesafe hesaplama, görüntü tanıma
│   │   ├── Audio/
│   │   │   └── AudioManager.cs       # Fon müziği + buton tıklama sesi (Singleton, sahne değişse de çalışır)
│   │   ├── UI/
│   │   │   ├── MainMenuUI.cs         # Ana menü buton fonksiyonları (S1-S4'e geçiş)
│   │   │   └── BackButtonNav.cs      # "< Geri" butonu — her senaryo sahnesinden MainMenu'ye döner
│   │   ├── Data/
│   │   │   └── POIData.cs            # GPS koordinatlı ilgi noktaları (ScriptableObject)
│   │   └── Scenarios/
│   │       ├── S1_Kule/KuleRekonstruksiyonu.cs
│   │       ├── S2_Kabartma/KabartmaAnimasyon.cs
│   │       ├── S3_Zaman/ZamanGecisi.cs
│   │       └── S4_Cocuk/CocukMisyon.cs
│   ├── Scenes/
│   │   ├── MainMenu.unity            # Ana menü: arka plan + 4 buton + fon müziği başlangıcı
│   │   ├── S1_KuleRekonstruksiyonu.unity
│   │   ├── S2_KabartmaAnimasyon.unity
│   │   ├── S3_ZamanGecisi.unity
│   │   └── S4_CocukMisyon.unity
│   ├── Textures/                     # Her senaryoya özel tasarlanmış arka plan görselleri
│   │   ├── harput_ar_menu_background.png   (MainMenu)
│   │   ├── s1_kule_background.png          (S1 — kule/inşa temalı)
│   │   ├── s2_kabartma_background.png      (S2 — kaya kabartması temalı)
│   │   ├── s3_zaman_gecisi_background.png  (S3 — iki dönem/zaman geçişi temalı)
│   │   └── s4_cocuk_misyon_background.png  (S4 — renkli macera haritası temalı)
│   ├── Audio/
│   │   ├── Ambient/                  # Fon müziği dosyaları
│   │   └── SFX/                      # Buton tıklama sesi
│   ├── Advance Studios/Medieval Castle/   # 3. parti 3B model paketi (Unity Asset Store, ücretsiz)
│   │   └── Prefabs/Tower A.prefab, Tower B.prefab  # S1 kule modeli için kullanılıyor
│   ├── Models/                       # Proje içi özel modeller/prefablar
│   └── XR/                           # AR Foundation / ARCore otomatik ayar dosyaları
├── docs/                             # Değerlendirme dokümanları (PDF)
│   ├── SWOT.pdf
│   ├── RAMS.pdf
│   ├── THS_report.pdf
│   ├── Requirements.pdf
│   └── UserScenario.pdf
├── Packages/
│   └── manifest.json                 # Unity paket bağımlılıkları listesi
├── Trello_link.txt                   # Proje takip panosu linki
├── .gitignore
└── README.md                         # Bu dosya
```

---

## 🔧 Sık Karşılaşılan Sorunlar ve Çözümleri

| Sorun | Çözüm |
|-------|-------|
| "ARCore cihazınızla uyumlu değil" hatası | Cihazın [ARCore destek listesinde](https://developers.google.com/ar/devices) olup olmadığını kontrol et. Değilse, `XR Plug-in Management → ARCore → Requirement: Optional` yap. |
| Build sırasında "Vulkan minimum SDK" hatası | `Player Settings → Android → Other Settings → Graphics APIs` listesinden Vulkan'ı kaldır, sadece OpenGLES3 bırak. |
| Script Add Component'te görünmüyor | Console'da kırmızı hata var mı kontrol et (genelde `using` sırası veya parantez hatası). Script dosyasını tamamen silip yeniden yapıştırmak çoğu zaman çözer. |
| Canvas UI, Game ekranında görünmüyor ama Scene'de görünüyor | `Canvas → Render Mode`'u **Screen Space - Overlay** yap. |
| Sahnede 3B model arka plan görselinin arkasında kalıyor | AR sahnelerinde (S1-S4) arka plan görseli yalnızca **UI-only** bağlamda kullanılmalı; gerçek AR modunda arka plan telefonun kamerasıdır. |
| Editörde Play modunda AR kamerası siyah ekran gösteriyor | Normal — AR Foundation gerçek kamera donanımı gerektirir, sadece gerçek cihazda çalışır. |

---

## 📊 Teknik Hedef Metrikler

| Metrik | Hedef |
|--------|-------|
| Frame Rate | ≥ 25 FPS |
| Model Yükleme Süresi | ≤ 4 sn |
| GPS Konumlandırma Hatası | ≤ 1 m |
| Uygulama Boyutu | ≤ 28 MB |
| Çökme Oranı | ≤ %2 |
| Kullanıcı Memnuniyeti | ≥ %75 |

Detaylı gereksinimler için: [docs/Requirements.pdf](docs/Requirements.pdf)

---

## 👤 Ekip

Bu proje tek kişilik bir ekip tarafından yürütülmüştür — proje yönetimi, Unity/AR geliştirme, script mimarisi, saha testleri, GitHub/Trello süreç yönetimi ve dokümantasyon dahil tüm sorumluluklar tek kişi tarafından üstlenilmiştir.

---

## 📚 Dokümantasyon

| Doküman | Açıklama |
|---------|----------|
| [SWOT.pdf](docs/SWOT.pdf) | Güçlü/zayıf yönler, fırsat ve tehdit analizi |
| [RAMS.pdf](docs/RAMS.pdf) | Güvenilirlik, Erişilebilirlik, Sürdürülebilirlik, Güvenlik metrikleri |
| [THS_report.pdf](docs/THS_report.pdf) | Teknik Hazırlık Seviyesi değerlendirmesi (güncel: THS-6) |
| [Requirements.pdf](docs/Requirements.pdf) | Fonksiyonel ve fonksiyonel olmayan gereksinimler |
| [UserScenario.pdf](docs/UserScenario.pdf) | Persona bazlı kullanıcı deneyim senaryoları |

---

## 🔗 Bağlantılar

- **Trello Board:** [Trello_link.txt](Trello_link.txt) dosyasına bakın
- **ARCore Destekli Cihaz Listesi:** https://developers.google.com/ar/devices

---



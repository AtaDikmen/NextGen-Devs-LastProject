# NextGen Devs 2024 🚀

# Mergeunion: Space War
## Proje Boyutu

**Takım Adı: Takım-1 (Opsiyonel)**

**Proje Süresi: 1 Hafta**

**Takım Üyeleri:**
   - **Takım Lideri**:
      * <a><img align="center" /></a> [Ata Dikmen](https://www.linkedin.com/in/ata-dikmen/)

   - **Developers**:
      * <a><img align="center" /></a> [Ata Dikmen](https://www.linkedin.com/in/ata-dikmen/)
      * <a><img align="center" /></a> [Can Usluel](https://www.linkedin.com/in/canusluel/)
      * <a><img align="center" /></a> [Hatice Esra Yılmaz](https://www.linkedin.com/in/hesrayilmaz/)
      * <a><img align="center" /></a> [Emir Özçelik](https://www.linkedin.com/in/emir-ozcelik/)

   - **Game Designers**:
      * <a><img align="center" /></a> [Utku Gezensoy](https://www.linkedin.com/in/utkugezensoy/)
      * <a><img align="center" /></a> [Ebrar Tekiş](https://www.linkedin.com/in/ebrartekis/)

   - **Artist**:
      * <a><img align="center" /></a> [Ferhan Sönmez](https://www.linkedin.com/in/ferhansonmez/)


## Oyun Tanımı
- **Özet**
 
    * Oyuncuların askerleri birleştirerek (merge) daha güçlü hale getirdiği ve düşman alanına ulaşmaya çalıştığı oyundur. Askerler belirli yollar (lanes) üzerinde ilerler ve düşmanla savaşıp onların alanına ulaşarak hasar verirler. Oyunun amacı her seviyede düşmanı yenerek bir sonraki seviyeye geçmektir.
 
- **Tema**

    * Koridor tabanlı birleştirme ve sci-fi türünde oyundur.
 
## Esinlenilen Eserler
- **Warlords: Call to Arms Warlords: Call to Arms**

    * Bu oyun, lane-based savaş mekaniği ile dikkat çekmektedir. Askerlerin belirli lane'lerde ilerleyerek düşman bölgesine saldırdığı bu sistem, oyunumuzun temel strateji unsurlarını şekillendirmiştir.
      
- **Street Life: Merge to Survive**

    * Birleşme (merge) mekanikleri ile öne çıkan bu oyunda, oyuncular karakterlerini birleştirerek güçlendirir. Bu sistem, oyunumuzda askerlerin güçlendirilmesi ve stratejik olarak kullanılmasında ilham kaynağı olmuştur.
      
- **Age of War**

    * Tarihsel ilerleme ve savunma mekaniği ile bilinen bu oyun, oyuncuların çağlar arasında ilerleyerek ordularını geliştirmesini ve savunma yapmasını sağlar. Bu mekaniği, oyunumuzun ilerleme ve savunma stratejilerini planlamak için kullandık.
      

## Oyun Mekaniği
  
  * Oyun askerleri birleştirerek daha güçlü birlikler oluşturmayı ve bu birlikleri stratejik olarak konumlandırarak düşman hatlarını aşmayı amaçlayan bir savaş oyunudur. Oyuncu her seviye başında belirli sayıda en güçsüz (default) askerle oyuna başlar.
  * İki askeri birleştirerek daha güçlü bir asker elde eder ve bu yeni askeri aynı seviyede başka bir askerle birleştirebilir, boş bir kutuya koyabilir veya yerinde bırakabilir.
  * Askerler oyuncunun kontrolüyle koridor başında işaretlenmiş alana sürüklenir ve buradan sağ tarafa doğru ilerler.
  * Yol boyunca karşılaştıkları düşmanlarla savaşır ve lane sonuna ulaştıklarında üstteki hasar barını etkilerler.


- **Birleştirme (Merge)**
  
  * Oyuncu her zorlukta belirli sayıda default (en güçsüz) askerle oyuna başlar. İki askeri birleştirerek daha güçlü bir asker elde edilir. Birleştirme işlemi sonrası yeni asker, aynı seviyede başka bir askerle birleştirilebilir, boş bir kutuya konabilir veya yerinde bırakılabilir.

- **Koridor (Lane) Savaşı**
  
  * Merge alanındaki askerler sürüklenip lane başında işaretlenmiş alana bırakılırsa, asker sağ tarafa (düşmana) doğru ilerlemeye başlar. Yol boyunca önüne çıkan her düşmanla savaşır. Lane sonuna ulaştığında verdiği hasar üstteki barı etkiler. Bar tamamen dolarsa oyun kazanılır, boşalırsa oyun kaybedilir.

- **Yeni Asker Spawn**
  
  * Oyuncu, Merge alanına yeni asker spawnlamak için sağ üstteki butona basar. Butona her bastığında 2 default asker spawn olur. Askerlerin performansına göre butona basma sayısı artar ve buton üstünde gösterilir. 

 - **Özellik Kullanımı**
   * **Özellik 1 (Bomba):** Sürüklendiği lane’deki bütün askerleri öldürür.
   *  **Özellik 2 (Akıllı Bomba):** Sürüklendiği lane’deki düşman askerlerini öldürür.
   *   **Özellik 3 (Can):** Sürüklendiği lane’deki bütün dost askerlerin canı dolar.
  

- **Düşman Yapay Zeka**
  
  * Oyun başladığından itibaren belli aralılar ile gönderebileceği asker seviyesi artar ve rastgele olarak bu birliklerden birini koridora gönderir. Bu rastgeleliğin içinde HulkBuster birimi dahil değildir.
  * Hulk Buster birimini 30 saniyede bir kez koridora gönderir.
  * Koridorların asker gücünü hesaplar ve en zayıf koridora asker yollayıp savunma yapar.
  * Aynı zamanda boş koridorları tarayıp çok düşük ihtimalle birlik gönderebilmektedir.
  * Kolay modda birliklerin gücü %20 düşer, Normal modda aynı kalır, Zor modda ise birliklerin gücü yarı yarıya artar.

- **Mağaza**
  
  * Her level sonunda mağaza otomatik açılır. Oyuncu kazandığı parayla alışveriş yapabilir. Hareket hızı, saldırı hızı, saldırı gücü (damage) ve can gibi karakter özelliklerini yükseltebilir.

 
## Karakterler

- **Birlikler**

  - **LaserDuelist Level 1:** Işın kılıcı kullanır ilk seviye birimdir.
    
![lightSaber-removebg-preview](https://github.com/user-attachments/assets/cb2b7698-daea-4f76-92e9-40a8839b01c8)
  - **Laser Gunner Level 2:** 1 saniye aralıklar ile ateş eden ikinci seviye birimdir.
    
![pistolMan-removebg-preview_1](https://github.com/user-attachments/assets/04d30b07-0ea1-4961-b8b1-1897145e6b15)

  - **RifleBot Level 3:** 1 saniye aralıkla 2 saniye boyunca ard arda ateş eden üçüncü seviye birimdir.
![rifleMan-removebg-preview_1](https://github.com/user-attachments/assets/745c5be4-e1e8-48e1-9bb7-453a5f71ede3)

  - **BomberBot Level 4:** Alan hasarı veren güçlü bombalar atan dördüncü seviye birimdir.
![bomber-removebg-preview_1](https://github.com/user-attachments/assets/498969f0-64b8-46fb-998a-c707748380e8)

  - **HulkBuster Level 5:** Yüksek hasar ve cana sahip en güçlü birimdir, beşinci seviye.
![tank-removebg-preview](https://github.com/user-attachments/assets/e4215e6f-a938-4bae-8173-debc7d3e810d)





## Temel Asset Listesi


### Modellenen Assetler
   - **LaserDuelist**
   - **Laser Gunner**
   - **RifleBot**
   - **BomberBot**
   - **HulkBuster**
   - **Bomba**
   - **Merge Masası 2D**


### Hazır Assetler
   - **UI Paketi:** https://assetstore.unity.com/packages/2d/gui/sci-fi-gui-skin-15606
   - **VFX Paketleri**


## Temel Ses Listesi

   - **MergeLvl1:** 1. seviye Merge yapılırken çalacak ses
   - **MergeLvl2:** 2. seviye Merge yapılırken çalacak ses
   - **MergeLvl3** 3. seviye Merge yapılırken çalacak ses
   - **MergeLvl4:**  4. seviye Merge yapılırken çalacak ses
   - **Decline:** Merge yapılamazken çalacak ses
   - **Spawn:** Spawn butonuna tıklandığında çalacak ses
   - **TankRobotHit:** (3 farklı ses) TankRobot karakterinin saldırısı sırasında random çalınacak sesler
   - **Lightsaber:** (4 farklı ses) Lightsaber kullanan karakter saldırısı sırasında random çalınacak sesler
   - **LazerGunShot:** Gun Laser silahı kullanan karakterin saldırısı sırasında çalınacak ses
   - **LazerRifleLoop:** Rifle Laser silahı kullanan karakterin saldırısı sırasında loop halinde çalınacak ses
   - **BombThrow:** Bomba kullanan karakterin bombayı fırlatması sırasında çalınacak ses
   - **BombExplode:** Bombanın patlaması sırasında çalınacak ses
   - **RobotDie:** (3 farklı ses) Robotlar ölünce random olarak çalınacak sesler
   - **BombThrow:** Bomba kullanan karakterin bombayı fırlatması sırasında çalınacak ses
   - **Metallic:** Karakterleri Merge masasından koridora sürükleyip bıraktığımızda çıkacak ses
   - **BtnClick:** Ana menü butonlarına tıklandığında çıkacak ses
   - **BtnNegative:** Upgrade gerçekleşemediğinde (yetersiz kaynak) çıkacak ses
   - **MainMenuMusic:** Ana menüde arka planda çalacak müzik.
   - **GameplayMusic:** Oyun esnasında arka planda çalacak müzik.

## Oyun İçi Görüntüler
   

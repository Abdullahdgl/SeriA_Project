# ⚽ ASP.NET Core MVC & Web API (.NET 6) SeriA — Lig, Fikstür ve Maç Yönetimi

M&Y Yazılım Eğitim Akademi Danışmanlık bünyesinde aldığım eğitim sürecinde, öğrendiklerimi pratiğe dökerek Serie A temalı bir lig uygulaması geliştirdim: veri katmanı ayrı bir Web API’de, arayüz katmanı ASP.NET Core MVC’de durur.

Amacım tek bir MVC projesine hem SQL hem HTML sıkıştırmak değil; takım, maç, maç olayı ve puan durumu için REST uçları üreten bir API ile bu uçları `HttpClient` üzerinden tüketen, sayfaları ViewComponent parçalarına bölen sürdürülebilir bir yapı inşa etmekti.

---

## 🛠️ Mimari ve Teknik Detaylar

- **Çift proje:** `SeriA.API` (Web API + EF Core + SQL Server) ve `SeriA.UI` (MVC). Solution adı `SeriA_Project`.
- **Katman ayrımı:** UI veritabanına bağlanmaz. Controller’lar `IHttpClientFactory` ile `https://localhost:7155` adresindeki API’yi çağırır.
- **Entity Framework Core:** `Team`, `Match`, `MatchEvent`, `MatchStatistic`, `LeagueTable` entity’leri `ApiContext` üzerinden SQL Server’a map edilir.
- **REST uçları:** Takım, maç, maç olayı ve lig tablosu JSON olarak sunulur. Geliştirme ortamında Swagger açıktır.
- **DTO:** API yanıtları UI tarafında `ResultTeamDto`, `ResultMatchDto`, `ResultMatchDetailDto`, `ResultLeagueDto` gibi sınıflara çevrilir. JSON dönüşümü Newtonsoft.Json ile yapılır.
- **ViewComponent mimarisi:** HTML şablonları atomik parçalara bölündü. Her parça bir C# `ViewComponent` sınıfı + `Views/Shared/Components/{Ad}/Default.cshtml` dosyasıdır.
- **İki kabuk:** Admin ekranları `_AdminLayout` paylaşır. Fikstür, puan durumu ve maç detayı `Layout = null` ile kendi iskeletini kurar.
- **İlişki kuralları:** Maçın ev sahibi ve deplasman takımı `Restrict` ile bağlıdır; takım, üzerinde maç varken silinmez.

---

## 📌 Uygulama Modülleri

### ▫️ API (`SeriA.API` — `https://localhost:7155`)

| Metot | Adres | İş |
|---|---|---|
| GET, POST | `/api/Team` | Takım listesi ve kayıt |
| GET, POST | `/api/Match` | Maç listesi ve kayıt |
| GET | `/api/Match/{id}` | Tek maç |
| GET | `/api/MatchEvent/{id}` | Maça ait olaylar |
| GET | `/api/League` | Puan durumu (puan, ardından averaj) |

### ▫️ Arayüz (`SeriA.UI` — `https://localhost:7212`)

#### 🛡️ Yönetim
- **Takım yönetimi** — `_AdminLayout` içinde; menü, üst çubuk, tablo ve modal ViewComponent’lere ayrıldı
- **Maç oluşturma** — API’den takım listesi çekilir, `POST /api/Match` ile kayıt atılır

#### 📅 Haftalık fikstür
- Hafta seçici, maç listesi, haftanın özeti ve öne çıkan maç kartı
- Sayfa kendi `<head>` ve `fixtures.css` / `fixtures.js` dosyalarını kullanır

#### 📊 Puan durumu
- Lig tablosu, özet kartlar, yan panel
- `LeagueController` `GET /api/League` yanıtını DTO listesine çevirir

#### 🏟️ Maç detayı
- Skor kahramanı, zaman çizelgesi, goller, kartlar, değişiklikler, ilk yarı skoru ve maç bilgisi
- İki istek: `GET /api/Match/{id}` ve `GET /api/MatchEvent/{id}`

---

## 💻 Kullanılan Teknoloji Yığını

**Backend & Framework:** ASP.NET Core Web API (.NET 6) │ ASP.NET Core MVC (.NET 6) │ C#  
**Veri:** Entity Framework Core 6 │ SQL Server │ Migrations  
**HTTP & JSON:** `IHttpClientFactory` │ Newtonsoft.Json │ Swashbuckle (Swagger)  
**Frontend:** Razor Views │ ViewComponents │ Bootstrap 5 │ HTML5 / CSS3 │ JavaScript  
**Çözüm:** Visual Studio 2022 │ `SeriA_Project.sln`

---

## ▶️ Çalıştırma

SQL Server’ın ayakta olması gerekir. Bağlantı cümlesi `SeriA.API/Context/ApiContext.cs` içindeki `OnConfiguring` metodundadır; sunucu adını kendi makinenize göre düzenleyin.

```bash
dotnet ef database update --project SeriA.API
dotnet run --project SeriA.API
dotnet run --project SeriA.UI
```

- API / Swagger: `https://localhost:7155/swagger`
- Arayüz: `https://localhost:7212` (varsayılan route: `League/Index`)

İki proje birlikte çalışmalıdır. UI, listeler için API’ye HTTP atar.

---

## 💡 Kazanımlar & Deneyim

M&Y Yazılım Eğitim Akademi Danışmanlık bünyesinde aldığım eğitim sürecinde, öğrendiklerimi pratiğe dökerek SeriA lig uygulamasını geliştirdim. Bu çalışma sayesinde yalnızca bir arayüz ortaya çıkarmış olmadım; aynı zamanda Web API ile MVC’nin ayrı süreçler olarak yaşaması, EF Core ile ilişkili entity tasarımı, REST uçlarının Swagger üzerinden doğrulanması, `HttpClient` ile JSON’un DTO’ya dönüştürülmesi ve büyük HTML şablonlarının ViewComponent’lere bölünmesi konularında da deneyim kazandım.

Eğitim sürecime katkı sağlayan, bilgi ve tecrübeleriyle gelişimime destek olan **Murat Yücedağ** ve **Erhan Gündüz** hocalarıma emekleri için teşekkür ederim.

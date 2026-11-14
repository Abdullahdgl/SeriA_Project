# ⚽ ASP.NET Core MVC & Web API (.NET 6) SeriA — Lig, Fikstür ve Maç Yönetimi

M&Y Yazılım Eğitim Akademi Danışmanlık bünyesinde aldığım eğitim sürecinde, öğrendiklerimi pratiğe dökerek Serie A temalı, API + MVC ayrımına dayalı full-stack bir lig uygulaması geliştirdim.

Amacım tek bir MVC projesine hem SQL hem HTML sıkıştırmak değil; takım, maç ve puan durumunu REST uçlarıyla sunan bir Web API’nin arkasında, sayfaları ViewComponent parçalarına bölen sürdürülebilir bir arayüz mimarisi inşa etmekti.

## 🛠️ Mimari ve Teknik Detaylar

- **Çift proje mimarisi:** `SeriA.API` (Web API + EF Core) ve `SeriA.UI` (ASP.NET Core MVC) ayrı süreçlerde çalışır. Solution adı `SeriA_Project`.
- **Katman ayrımı:** UI veritabanına bağlanmaz. Controller’lar `IHttpClientFactory` ile `https://localhost:7155` üzerindeki API’yi tüketir.
- **EF Core & MSSQL:** Code-First yaklaşımıyla `Team`, `Match`, `MatchEvent`, `MatchStatistic` ve `LeagueTable` entity’leri Migration’lar üzerinden SQL Server’a map edildi.
- **İlişkisel model:** Maçın ev sahibi ve deplasmanı `Team` ile bağlanır; silme kuralı `Restrict`’tir. Puan satırı `TeamId` üzerinden takıma bağlıdır.
- **REST & DTO:** JSON yanıtları UI tarafında tip güvenli DTO’lara (`ResultTeamDto`, `ResultMatchDto`, `ResultLeagueDto` vb.) dönüştürülür. Swagger ile uçlar doğrulanır.
- **Modüler arayüz:** HTML şablonları ViewComponent’lere bölündü. Admin ekranları `_AdminLayout` paylaşır; fikstür, puan durumu ve maç detayı kendi sayfa iskeletini kurar.

## 📌 Uygulama Modülleri

### ▫️ API (`SeriA.API`)
- 🛡️ **Takım** — `GET/POST /api/Team`
- ⚽ **Maç** — `GET/POST /api/Match`, `GET /api/Match/{id}`
- 📋 **Maç olayları** — `GET /api/MatchEvent/{id}`
- 📊 **Puan durumu** — `GET /api/League` (puan, ardından averaj)

### ▫️ Yönetim paneli
- 👥 **Takım yönetimi** — admin kabuğu, menü, tablo ve modal ViewComponent’leri
- ➕ **Maç oluşturma** — API’den takım listesi, `POST /api/Match`

### ▫️ Seyirci ekranları
- 📅 **Haftalık fikstür** — hafta seçici, maç listesi, özet ve öne çıkan maç
- 📈 **Puan durumu** — lig tablosu, özet kartlar, yan panel
- 🏟️ **Maç detayı** — skor, zaman çizelgesi, goller, kartlar, değişiklikler ve ilk yarı

## 💻 Kullanılan Teknoloji Yığını

**Backend & Framework:** ASP.NET Core Web API (.NET 6) │ ASP.NET Core MVC (.NET 6) │ C# │ LINQ  
**Veritabanı & ORM:** Entity Framework Core (Code-First) │ SQL Server (MSSQL) │ Migrations  
**HTTP & JSON:** `IHttpClientFactory` │ Newtonsoft.Json │ Swashbuckle (Swagger)  
**Frontend & UI Components:** ViewComponent │ Razor Views │ Bootstrap 5 │ HTML5 / CSS3 │ JavaScript

## ▶️ Çalıştırma

SQL Server ayakta olmalıdır. Bağlantı cümlesi `SeriA.API/Context/ApiContext.cs` içindeki `OnConfiguring` metodundadır.

```bash
dotnet ef database update --project SeriA.API
dotnet run --project SeriA.API
dotnet run --project SeriA.UI
```

- API / Swagger: `https://localhost:7155/swagger`
- Arayüz: `https://localhost:7212`

## 💡 Kazanımlar & Deneyim

M&Y Yazılım Eğitim Akademi Danışmanlık bünyesinde aldığım eğitim sürecinde, öğrendiklerimi pratiğe dökerek SeriA lig uygulamasını geliştirdim. Bu çalışma sayesinde yalnızca bir web arayüzü ortaya çıkarmış olmadım; aynı zamanda Web API ile MVC’nin ayrı süreçler olarak yaşaması, ilişkisel veritabanı tasarımı, REST uçlarının DTO’ya dönüştürülmesi, `HttpClient` ile servis tüketimi ve büyük HTML şablonlarının ViewComponent’lere bölünmesi konularında da önemli deneyimler kazandım.

Eğitim sürecime katkı sağlayan, bilgi ve tecrübeleriyle gelişimime destek olan **Murat Yücedağ** ve **Erhan Gündüz** hocalarıma emekleri için teşekkür ederim.

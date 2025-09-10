# ERP System Backend API

Bu proje, .NET 7.0 tabanlı bir ERP (Enterprise Resource Planning) sistemi backend API'sidir. Farklı departmanlar için talep yönetimi ve onay süreçlerini içerir.

## 🚀 Özellikler

### 📋 Talep Yönetimi

- **Genel Talepler**: Ana talep sistemi
- **Fatura Talepleri**: Mali işler departmanı için
- **Sipariş Talepleri**: Satın alma departmanı için
- **Kargo Talepleri**: Lojistik departmanı için
- **BT/IT Talepleri**: Bilgi teknolojileri erişim talepleri
- **Hukuk Talepleri**: Hukuk departmanı için dava yönetimi

### 🔧 Teknik Özellikler

- **Framework**: .NET 7.0 Web API
- **Veritabanı**: PostgreSQL
- **ORM**: Entity Framework Core 7.0.4
- **Logging**: Serilog
- **API Dokümantasyonu**: Swagger/OpenAPI
- **Global Error Handling**: Merkezi hata yönetimi
- **Generic Repository Pattern**: Kod tekrarını önleyen repository pattern
- **DTO Pattern**: API request/response için Data Transfer Objects
- **Model Validation**: Data Annotations ile validasyon

## 🏗️ Proje Yapısı

```
alisanljoj/
├── Controllers/          # API Controller'ları
├── Data/                # DbContext ve veritabanı yapılandırması
├── DTOs/                # Data Transfer Objects
├── Middleware/          # Global exception handling
├── Migrations/          # Entity Framework migrations
├── Model/               # Entity modelleri
│   ├── BaseRequest.cs   # Temel talep modeli
│   ├── BaseSystemRequest.cs # Sistem erişim talepleri için
│   ├── BaseLawRequest.cs # Hukuk talepleri için
│   └── ...
├── Repositories/        # Generic repository pattern
└── Program.cs           # Uygulama giriş noktası
```

## 🗄️ Veritabanı Tabloları

- **Request**: Ana talep tablosu
- **Fatura**: Fatura talepleri
- **Sipariş**: Sipariş talepleri
- **Kargo**: Kargo talepleri
- **KargoYonetici**: Kargo yönetici talepleri
- **Yonetici**: Yönetici talepleri
- **BtRequest**: BT talepleri
- **ItRequest**: IT talepleri
- **RequestBt**: BT talep onay süreçleri
- **LawRequest**: Hukuk talepleri
- **Duruşma**: Hukuk duruşma kayıtları
- **HukukSonuc**: Hukuk sonuç kayıtları

## 🚀 Kurulum ve Çalıştırma

### Gereksinimler

- .NET 7.0 SDK
- PostgreSQL 12+
- Visual Studio 2022 veya VS Code

### Kurulum

1. Projeyi klonlayın
2. PostgreSQL veritabanını oluşturun
3. `appsettings.json` dosyasında connection string'i güncelleyin
4. Migration'ları çalıştırın:
   ```bash
   dotnet ef database update
   ```
5. Projeyi çalıştırın:
   ```bash
   dotnet run
   ```

### API Dokümantasyonu

Uygulama çalıştıktan sonra Swagger UI'ya şu adresten erişebilirsiniz:

- Development: `https://localhost:5001/swagger`

## 📡 API Endpoints

### Request Controller

- `GET /api/Request` - Tüm talepleri getir
- `GET /api/Request/{id}` - ID'ye göre talep getir
- `POST /api/Request/Create` - Yeni talep oluştur
- `POST /api/Request/Update2` - İlk seviye onay
- `POST /api/Request/Update3` - İkinci seviye onay
- `DELETE /api/Request/delete/{id}` - Talep sil

### FaturaRequest Controller

- `GET /api/FaturaRequest` - Tüm fatura taleplerini getir
- `GET /api/FaturaRequest/{id}` - ID'ye göre fatura talebi getir
- `POST /api/FaturaRequest/CreateFatura` - Yeni fatura talebi oluştur
- `DELETE /api/FaturaRequest/delete/{id}` - Fatura talebi sil

## 🔧 Geliştirme

### Yeni Model Ekleme

1. `Model/` klasöründe yeni model sınıfı oluşturun
2. Uygun base sınıftan türetin (`BaseRequest`, `BaseSystemRequest`, vb.)
3. `Data/RequestContext.cs`'e DbSet ekleyin
4. Migration oluşturun: `dotnet ef migrations add MigrationName`
5. Migration'ı uygulayın: `dotnet ef database update`

### Yeni Controller Ekleme

1. `Controllers/` klasöründe yeni controller oluşturun
2. `IGenericRepository<T>` kullanın
3. DTO'ları kullanarak API response'ları oluşturun
4. Swagger dokümantasyonu ekleyin

## 📝 Logging

Uygulama Serilog kullanarak loglama yapar:

- Console'a log yazdırır
- `logs/` klasörüne günlük dosyalar oluşturur
- Log seviyeleri: Information, Warning, Error, Fatal

## 🛡️ Güvenlik

- CORS yapılandırması mevcut
- Global exception handling ile hata yönetimi
- Model validation ile input kontrolü
- PostgreSQL bağlantı güvenliği

## 🔄 Onay Süreçleri

Sistem iki seviyeli onay süreci destekler:

1. **Update2**: İlk seviye onay (Status, DescriptionDeny)
2. **Update3**: İkinci seviye onay (Status, DescriptionDeny2)

## 📊 Performans

- Generic repository pattern ile kod tekrarı azaltıldı
- Async/await pattern kullanılarak performans artırıldı
- Entity Framework Core ile optimize edilmiş veritabanı sorguları

## 🐛 Hata Ayıklama

- Global exception middleware ile merkezi hata yönetimi
- Detaylı loglama ile hata takibi
- Swagger UI ile API test etme
- Model validation ile input kontrolü

## 📈 Gelecek Geliştirmeler

- [ ] Authentication/Authorization (JWT)
- [ ] Unit test coverage
- [ ] Integration testler
- [ ] Caching mekanizması
- [ ] Rate limiting
- [ ] API versioning
- [ ] Health checks
- [ ] Metrics ve monitoring

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır.

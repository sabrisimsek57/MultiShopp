# MultiShop - E-Ticaret Platformu (Mikroservis Mimarisi)

## Projenin Temel Amacı
**MultiShop** projesi, kullanıcıların oturum açarak veya ziyaretçi olarak siteye giriş yapmalarını sağlayan, kapsamlı bir e-ticaret platformudur. Kullanıcılar, ürünleri arayabilir, listeleyebilir ve sepetlerine ekleyebilirler. Alışveriş sonunda güvenli bir şekilde sipariş oluşturabilir ve siparişlerini kullanıcı panelinden takip edebilirler.

Bu proje, **ASP.NET Core Web API 6.0** ile yazılmış mikroservislerin, **MVC** tarafında tüketildiği bir mimariye sahiptir. Proje, **Tek Katmanlı Mimari**, **N Katmanlı Mimari** ve **Onion Mimari** gibi mimarilere dayanır. Kullanılan tasarım desenleri ise **Repository**, **CQRS** ve **Mediator**'dur. Ayrıca 5 farklı veritabanı kullanılarak uygulamanın esnekliği ve ölçeklenebilirliği sağlanmıştır.

## Kullanılan Teknolojiler

### Frontend
- HTML
- CSS
- JavaScript
- Bootstrap

### Backend
- C#
- ASP.NET Core 6.0
- ASP.NET Web API
- Entity Framework Code First (LINQ)
- Dapper
- Docker
- Swagger
- SignalR

### Veritabanları
- MSSQL
- MongoDB
- PostgreSQL
- Redis

## Mikroservisler ve Veritabanları
- **Basket** - Docker Redis
- **Cargo** - Docker MSSQL
- **Catalog** - MongoDb
- **Comment** - Docker MSSQL
- **Discount** - Local MSSQL Dapper
- **Images** - Local SQL
- **Message** - PostgreSQL
- **Order** - Docker MSSQL
- **IdentityServer4** - Docker MSSQL
- **Payment** - RabbitMQ, SignalR, RapidApi

## Teknik Özellikler
- **Ziyaretçi veya Kullanıcı Girişi** - IdentityServer4
- **Asp.Net Core 6.0** ve **Asp.Net Web API** ile yazılmıştır
- **Onion Architecture**, **N Katmanlı Mimari**, **Tek Katmanlı Mimari**
- **CQRS**, **Mediator**, **Repository** tasarım desenleri
- **Entity Framework Code First** ve **Dapper** kullanımı
- **SignalR** ile canlı veri takibi
- **Redis** ile sepete ekleme işlemleri
- **MongoDB** ile katalog mikroservisi entegrasyonu
- **Admin Paneli** ve **Kullanıcı Paneli** ile yönetim ve kullanıcı takibi

## Kullanılan Diğer Araçlar
- Postman
- RabbitMQ
- Ocelot Gateway
- FluentValidation
- Docker
- DBeaver
- RapidApi
## Resimler
![1](https://github.com/user-attachments/assets/efe999fa-31d1-4e74-91d5-604b34a0420b)

![2](https://github.com/user-attachments/assets/95174507-eeba-4012-b40f-85f84476957a)

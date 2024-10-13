##MultiShop - E-Ticaret (Microservice)
Projenin Temel Amacı
MultiShop projesi, kullanıcıların oturum açarak veya ziyaretçi olarak siteye giriş yapmalarını sağlayan, kapsamlı bir e-ticaret platformudur. Kullanıcılar, ürünler içerisinden diledikleri ürünleri arayabilir, listeleyebilir ve sepetlerine ekleyebilirler. Alışveriş sürecinin sonunda, kullanıcılar siparişlerini güvenle oluşturabilirler. Oluşturdukları siparişleri kullanıcı panelinden takip edebilirler.

Bu proje, tüm mikroservislerin ASP.NET Core Web API 6.0 ile yazıldığı ve MVC tarafında tüketildiği bir mimariye sahiptir. Her mikroserviste, mimari ve tasarım desenleri uygulanmıştır. Kullanılan mimariler arasında Tek Katmanlı Mimari, N Katmanlı Mimari ve Onion Mimari yer alırken, uygulamada tercih edilen tasarım desenleri Repository, CQRS ve Mediator’dur. Ayrıca, 5 farklı veritabanı ile uygulamanın içeriği zenginleştirilmiştir, bu da esneklik ve ölçeklenebilirlik sağlamaktadır.

Kullanılan Teknolojiler
Asp.Net Core 6.0 Web App
Asp.Net Web API
MSSQL
MongoDb
Redis
PostgreSQL
Docker
DBeaver
Dapper
Postman
Swagger
RabbitMQ
RapidApi
Google Cloud Storage
Onion Architecture
CQRS Design Pattern
Mediator Design Pattern
Repository Design Pattern
IdentityServer4
Ocelot Gateway
SignalR
Json Web Token
MailKit
FluentValidation
Html
Css
JavaScript
Bootstrap
Frontend
Html
Css
JavaScript
Bootstrap
Backend
C#
MSSQL
Swagger
Docker
PostgreSQL
MongoDB
DBeaver
Mikroservisler ve Veritabanları
Basket - Docker Redis
Cargo - Docker MSSQL
Catalog - MongoDb
Comment - Docker MSSQL
Discount - Local MSSQL Dapper
Images - Local SQL
Message - PostgreSQL
Order - Docker MSSQL
IdentityServer4 - Docker MSSQL
Payment -
RabbitMQ
SignalR
RapidApi
Teknik Özellikler
Ziyaretçi veya Kulllanıcı Girişi - IdentityServer4
Asp.Net Core 6.0
Asp.Net Core Web API
Onion Architecture
N Tier Architecture
One Tier Architecture
CQRS, Mediator, Repository Dessign Pattern
Entity Framework Code First LINQ
Dapper
SignalR ile canlı veri takibi
Redis ile sepete ekleme
Docker MSSQL ile yorum yapma
MongoDB ile catalog mikroservisi consume
Admin Paneli
Kullanıcı Paneli
Google cloud storage ile ürün görselleri

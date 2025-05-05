using Microsoft.OpenApi.Models;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// DbContext'i ekliyoruz. Bu, uygulaman�n veritaban� ile etkile�im kurmas�n� sa�lar.
builder.Services.AddDbContext<MovieContext>();

// Servisleri (handler'lar) DI (Dependency Injection) container'�na ekliyoruz.
#region Handlers Tan�mlama
builder.Services.AddScoped<CreateCategoryCommandHandler>();  // Kategori olu�turma komutunu i�leyen handler
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();  // Kategori id'sine g�re sorgu i�leyen handler
builder.Services.AddScoped<GetCategoryQueryHandler>();      // T�m kategorileri sorgulayan handler
builder.Services.AddScoped<RemoveCategoryCommandHandler>(); // Kategori silme komutunu i�leyen handler
builder.Services.AddScoped<UpdateCategoryCommandHandler>(); // Kategori g�ncelleme komutunu i�leyen handler

builder.Services.AddScoped<CreateMovieCommandHandler>();    // Film olu�turma komutunu i�leyen handler
builder.Services.AddScoped<GetMovieByIdQueryHandler>();     // Film id'sine g�re sorgu i�leyen handler
builder.Services.AddScoped<GetMovieQueryHandler>();         // T�m filmleri sorgulayan handler
builder.Services.AddScoped<RemoveMovieCommandHandler>();    // Film silme komutunu i�leyen handler
builder.Services.AddScoped<UpdateMovieCommandHandler>();    // Film g�ncelleme komutunu i�leyen handler
#endregion

// MVC Controller'lar� ekliyoruz. API endpoint'lerini y�neten s�n�flar.
builder.Services.AddControllers();

// Endpoint'leri ke�fetmek i�in gerekli olan servisleri ekliyoruz. (Swagger ile entegrasyon i�in gereklidir)
builder.Services.AddEndpointsApiExplorer();

// Swagger ayarlar�n� yap�yoruz. API'yi test etmek i�in bir kullan�c� aray�z� sa�lar.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "V1" });
});

var app = builder.Build();

// HTTP request pipeline'� yap�land�r�yoruz.
// E�er geli�tirme ortam�nda isek (development), Swagger'� kullan�ma sunuyoruz.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Swagger'� etkinle�tirir.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1");  // Swagger UI'yi g�sterir.
    });
}

// HTTPS y�nlendirmesini etkinle�tiriyoruz. (HTTP'den HTTPS'ye y�nlendirme)
app.UseHttpsRedirection();

// Kullan�c� do�rulama i�lemleri (authorization) yap�lacaksa bu middleware'i kullan�yoruz.
app.UseAuthorization();

// API Controller'lar�n�n tan�mland��� y�nlendirmeleri yap�yoruz.
app.MapControllers();

// Uygulaman�n �al��maya ba�lamas�n� sa�l�yoruz.
app.Run();

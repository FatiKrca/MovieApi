using Microsoft.OpenApi.Models;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// DbContext'i ekliyoruz. Bu, uygulamanýn veritabaný ile etkileþim kurmasýný saðlar.
builder.Services.AddDbContext<MovieContext>();

// Servisleri (handler'lar) DI (Dependency Injection) container'ýna ekliyoruz.
#region Handlers Tanýmlama
builder.Services.AddScoped<CreateCategoryCommandHandler>();  // Kategori oluþturma komutunu iþleyen handler
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();  // Kategori id'sine göre sorgu iþleyen handler
builder.Services.AddScoped<GetCategoryQueryHandler>();      // Tüm kategorileri sorgulayan handler
builder.Services.AddScoped<RemoveCategoryCommandHandler>(); // Kategori silme komutunu iþleyen handler
builder.Services.AddScoped<UpdateCategoryCommandHandler>(); // Kategori güncelleme komutunu iþleyen handler

builder.Services.AddScoped<CreateMovieCommandHandler>();    // Film oluþturma komutunu iþleyen handler
builder.Services.AddScoped<GetMovieByIdQueryHandler>();     // Film id'sine göre sorgu iþleyen handler
builder.Services.AddScoped<GetMovieQueryHandler>();         // Tüm filmleri sorgulayan handler
builder.Services.AddScoped<RemoveMovieCommandHandler>();    // Film silme komutunu iþleyen handler
builder.Services.AddScoped<UpdateMovieCommandHandler>();    // Film güncelleme komutunu iþleyen handler
#endregion

// MVC Controller'larý ekliyoruz. API endpoint'lerini yöneten sýnýflar.
builder.Services.AddControllers();

// Endpoint'leri keþfetmek için gerekli olan servisleri ekliyoruz. (Swagger ile entegrasyon için gereklidir)
builder.Services.AddEndpointsApiExplorer();

// Swagger ayarlarýný yapýyoruz. API'yi test etmek için bir kullanýcý arayüzü saðlar.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "V1" });
});

var app = builder.Build();

// HTTP request pipeline'ý yapýlandýrýyoruz.
// Eðer geliþtirme ortamýnda isek (development), Swagger'ý kullanýma sunuyoruz.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Swagger'ý etkinleþtirir.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1");  // Swagger UI'yi gösterir.
    });
}

// HTTPS yönlendirmesini etkinleþtiriyoruz. (HTTP'den HTTPS'ye yönlendirme)
app.UseHttpsRedirection();

// Kullanýcý doðrulama iþlemleri (authorization) yapýlacaksa bu middleware'i kullanýyoruz.
app.UseAuthorization();

// API Controller'larýnýn tanýmlandýðý yönlendirmeleri yapýyoruz.
app.MapControllers();

// Uygulamanýn çalýþmaya baþlamasýný saðlýyoruz.
app.Run();

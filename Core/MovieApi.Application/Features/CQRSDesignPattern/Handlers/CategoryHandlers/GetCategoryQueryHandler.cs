using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    // Handler sınıfı: GetCategoryQuery sorgusunu işleyerek tüm kategorileri getirir.
    // Bu sınıf, GetCategoryQuery sorgusunu alır ve veritabanındaki tüm kategorileri getirir
    // ve sonucu GetCategoryQueryResult listesi olarak döndürür.

    public class GetCategoryQueryHandler
    {
        private readonly MovieContext _context;

        // Yapıcı metot (constructor): MovieContext (veritabanı bağlamı) ile ilişkilendirilir.
        public GetCategoryQueryHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu: Veritabanındaki tüm kategorileri alır ve her kategori için GetCategoryQueryResult döndürür.
        // Kategoriler, GetCategoryQueryResult formatında bir liste olarak döndürülür.
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _context.Categories.ToListAsync(); // Veritabanındaki tüm kategoriler alınır.
            return values.Select(x => new GetCategoryQueryResult
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToList(); // Her bir kategori, GetCategoryQueryResult formatında döndürülür.
        }
    }
}

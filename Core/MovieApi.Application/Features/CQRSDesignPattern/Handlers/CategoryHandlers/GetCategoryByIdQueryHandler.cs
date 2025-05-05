using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    // Handler sınıfı: GetCategoryByIdQuery sorgusunu işleyerek belirli bir kategoriyi ID'ye göre getirir.
    // Bu sınıf, GetCategoryByIdQuery sorgusundan gelen CategoryId ile veritabanından ilgili kategoriyi bulur
    // ve sonucu GetCategoryByIdQueryResult olarak döndürür.

    public class GetCategoryByIdQueryHandler
    {
        private readonly MovieContext _context;

        // Yapıcı metot (constructor): MovieContext (veritabanı bağlamı) ile ilişkilendirilir.
        public GetCategoryByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu: GetCategoryByIdQuery sorgusunu alır ve belirtilen CategoryId'ye göre kategori bilgisini veritabanından getirir.
        // Veritabanında ilgili kategori bulunur ve kategori bilgisi GetCategoryByIdQueryResult formatında döndürülür.
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var value = await _context.Categories.FindAsync(query.CategoryId); // Kategori ID'sine göre veritabanında arama yapılır.
            return new GetCategoryByIdQueryResult
            {
                CategoryId = value.CategoryId,
                CategoryName = value.CategoryName
            };
        }
    }
}

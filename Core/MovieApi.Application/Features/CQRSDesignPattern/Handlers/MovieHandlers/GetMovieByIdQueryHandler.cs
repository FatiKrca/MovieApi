using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    // Handler sınıfı: GetMovieByIdQuery sorgusunu işleyerek belirli bir filmi ID'ye göre getirir.
    // Bu sınıf, GetMovieByIdQuery sorgusundan gelen MovieId ile veritabanındaki ilgili filmi bulur
    // ve sonucu GetMovieByIdQueryResult formatında döndürür.

    public class GetMovieByIdQueryHandler
    {

        private readonly MovieContext _context;

        // Yapıcı metot (constructor): MovieContext (veritabanı bağlamı) ile ilişkilendirilir.
        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu: GetMovieByIdQuery sorgusunu alır ve belirtilen MovieId'ye göre film bilgisini veritabanından getirir.
        // Veritabanında ilgili film bulunur ve film bilgisi GetMovieByIdQueryResult formatında döndürülür.
        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            var value = await _context.Movies.FindAsync(query.MovieId); // Film ID'sine göre veritabanında arama yapılır.
            return new GetMovieByIdQueryResult
            {
                MovieId = value.MovieId,
                Title = value.Title,
                Description = value.Description,
                CoverImageUrl = value.CoverImageUrl,
                CreatedYear = value.CreatedYear,
                RelaseDate = value.RelaseDate,
                Duration = value.Duration,
                Rating = value.Rating,
                Status = value.Status
            };
        }
    }
}

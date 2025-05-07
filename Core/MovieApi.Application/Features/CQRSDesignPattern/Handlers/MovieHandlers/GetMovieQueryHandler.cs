using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    // Handler sınıfı: GetMovieQuery sorgusunu işleyerek tüm filmleri getirir.
    // Bu sınıf, veritabanındaki tüm filmleri alır ve bunları GetMovieQueryResult formatında döndürür.

    public class GetMovieQueryHandler
    {
        private readonly MovieContext _context;

        // Yapıcı metot (constructor): MovieContext (veritabanı bağlamı) ile ilişkilendirilir.
        public GetMovieQueryHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu: GetMovieQuery sorgusunu alır ve veritabanındaki tüm filmleri getirir.
        // Tüm filmler alınır ve her bir film GetMovieQueryResult formatına dönüştürülür.
        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var values = await _context.Movies.ToListAsync(); // Tüm filmler veritabanından alınır.
            return values.Select(x => new GetMovieQueryResult
            {
                MovieId = x.MovieId,
                Title = x.Title,
                Description = x.Description,
                CoverImageUrl = x.CoverImageUrl,
                CreatedYear = x.CreatedYear,
                ReleaseDate = x.RelaseDate,
                Duration = x.Duration,
                Rating = x.Rating,
                Status = x.Status
            }).ToList(); // Filmler, GetMovieQueryResult formatına dönüştürülür.
        }
    }
}

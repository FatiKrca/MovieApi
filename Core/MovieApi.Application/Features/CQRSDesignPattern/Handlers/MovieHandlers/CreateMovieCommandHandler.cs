using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    // Handler sınıfı: CreateMovieCommand komutunu işleyerek yeni bir film oluşturur.
    // Bu sınıf, CreateMovieCommand komutundan gelen verilerle yeni bir Movie (film) nesnesi oluşturur
    // ve bunu veritabanına ekler.

    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context;

        // Yapıcı metot (constructor): MovieContext (veritabanı bağlamı) ile ilişkilendirilir.
        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu: CreateMovieCommand komutunu alır ve yeni bir film ekler.
        // Film bilgileri komuttan alınır ve Movie nesnesi oluşturularak veritabanına eklenir.
        public async Task Handle(CreateMovieCommand command)
        {
            _context.Movies.Add(new Movie
            {
                Title = command.Title,
                CoverImageUrl = command.CoverImageUrl,
                Rating = command.Rating,
                Description = command.Description,
                Duration = command.Duration,
                RelaseDate = command.RelaseDate,
                CreatedYear = command.CreatedYear,
                Status = command.Status
            });
            await _context.SaveChangesAsync(); // Değişiklikler veritabanına kaydedilir.
        }
    }
}

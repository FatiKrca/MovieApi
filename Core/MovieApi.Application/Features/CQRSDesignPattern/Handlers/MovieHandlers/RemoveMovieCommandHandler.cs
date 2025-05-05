using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    // Handler sınıfı: RemoveMovieCommand komutunu işleyerek bir filmi siler.
    // Bu sınıf, RemoveMovieCommand komutundan gelen MovieId ile veritabanındaki ilgili filmi bulur
    // ve siler.

    public class RemoveMovieCommandHandler
    {

        private readonly MovieContext _context;

        // Yapıcı metot (constructor): MovieContext (veritabanı bağlamı) ile ilişkilendirilir.
        public RemoveMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu: RemoveMovieCommand komutunu alır ve belirtilen MovieId'ye göre film bilgisini siler.
        // Veritabanında ilgili film bulunur ve silinir.
        public async Task Handle(RemoveMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.MovieId); // Film ID'sine göre veritabanında arama yapılır.
            _context.Movies.Remove(value); // Bulunan film silinir.
            await _context.SaveChangesAsync(); // Değişiklikler veritabanına kaydedilir.
        }
    }
}

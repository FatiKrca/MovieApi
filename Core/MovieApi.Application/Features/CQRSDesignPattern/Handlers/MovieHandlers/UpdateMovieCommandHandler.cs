using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    // Handler sınıfı: UpdateMovieCommand komutunu işleyerek bir filmin bilgilerini günceller.
    // Bu sınıf, UpdateMovieCommand komutundan gelen MovieId ile veritabanındaki ilgili filmi bulur
    // ve sağlanan yeni verilerle bu filmi günceller.

    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _movieContext;

        // Yapıcı metot (constructor): MovieContext (veritabanı bağlamı) ile ilişkilendirilir.
        public UpdateMovieCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        // Handler metodu: UpdateMovieCommand komutunu alır, belirtilen MovieId'ye göre veritabanındaki filmi bulur
        // ve komutta sağlanan yeni verilerle günceller.
        public async Task Handler(UpdateMovieCommand command)
        {
            var value = await _movieContext.Movies.FindAsync(command.MovieId); // Film ID'sine göre veritabanında arama yapılır.

            // Film bilgileri güncellenir.
            value.Rating = command.Rating;
            value.Status = command.Status;
            value.Duration = command.Duration;
            value.CoverImageUrl = command.CoverImageUrl;
            value.CreatedYear = command.CreatedYear;
            value.Description = command.Description;
            value.RelaseDate = command.RelaseDate;
            value.Title = command.Title;

            await _movieContext.SaveChangesAsync(); // Değişiklikler veritabanına kaydedilir.
        }
    }
}

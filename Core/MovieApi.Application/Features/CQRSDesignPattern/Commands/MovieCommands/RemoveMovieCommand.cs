

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands
{
    // Komut (Command) sınıfı: Bir filmi silme işlemi için kullanılır.
    public class RemoveMovieCommand
    {
        public RemoveMovieCommand(int movieId)
        {
            MovieId = movieId;
        }

        public int MovieId { get; set; }

    }
}


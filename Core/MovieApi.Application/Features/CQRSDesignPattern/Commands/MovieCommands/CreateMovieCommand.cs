 

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands
{
    // Komut (Command) sınıfı: Yeni bir film oluşturma işlemi için kullanılır.
    public class CreateMovieCommand
    {
         public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CreatedYear { get; set; }
        public bool Status { get; set; }
    }
}

 

namespace MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults
{

    // Sonuç sınıfı: GetMovieByIdQuery sorgusunun sonucunu temsil eder.
    // Bu sınıf, belirli bir filmin bilgilerini tutar ve genellikle sorgu işleme sonrası döndürülen veriyi taşır.

    public class GetMovieByIdQueryResult
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime RelaseDate { get; set; }
        public string CreatedYear { get; set; }
        public bool Status { get; set; }
    }
}

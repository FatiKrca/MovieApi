 
namespace MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults
{
    // Sonuç sınıfı: GetMovieQuery sorgusunun sonucunu temsil eder.
    // Bu sınıf, tüm filmlerin bilgilerini tutar ve genellikle sorgu işleme sonrası döndürülen veriyi taşır.
    public class GetMovieQueryResult
    {
        public int MovieId { get; set; }
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

namespace MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries
{
    // Sorgu sınıfı (Query): Belirli bir filmi almak için kullanılır.
    // Bu sınıf, MovieId'yi alarak veritabanından ilgili film bilgisini sorgulamak için kullanılır.

    public class GetMovieByIdQuery
    {
        // Yapıcı metot (constructor): Film ID'sini alır.
        public GetMovieByIdQuery(int movieId)
        {
            MovieId = movieId;
        }

        // Sorgulanan film ID'si.
        public int MovieId { get; set; }
    }
}

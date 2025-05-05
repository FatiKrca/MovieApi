namespace MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults
{
    // Sonuç sınıfı: GetCategoryByIdQuery sorgusunun sonucunu temsil eder.
    // Bu sınıf, sorgulanan kategorinin bilgilerini tutar ve genellikle sorgu işleme sonrası döndürülen veriyi taşır.

    public class GetCategoryByIdQueryResult
    {
        // Kategori ID'si
        public int CategoryId { get; set; }

        // Kategori adı
        public string CategoryName { get; set; }
    }
}

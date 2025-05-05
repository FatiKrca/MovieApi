namespace MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults
{
    // Sonuç sınıfı: GetCategoryQuery sorgusunun sonucunu temsil eder.
    // Bu sınıf, tüm kategorilerin bilgilerini tutar ve genellikle sorgu işleme sonrası döndürülen veriyi taşır.

    public class GetCategoryQueryResult
    {
        // Kategori ID'si
        public int CategoryId { get; set; }

        // Kategori adı
        public string CategoryName { get; set; }
    }
}

namespace MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries
{
    // Sorgu sınıfı (Query): Belirli bir kategoriyi almak için kullanılır.
    // Bu sınıf, CategoryId'yi alarak veritabanından ilgili kategori bilgisini sorgulamak için kullanılır.

    public class GetCategoryByIdQuery
    {
        // Yapıcı metot (constructor): Kategori ID'sini alır.
        public GetCategoryByIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }

        // Sorgulanan kategori ID'si.
        public int CategoryId { get; set; }
    }
}

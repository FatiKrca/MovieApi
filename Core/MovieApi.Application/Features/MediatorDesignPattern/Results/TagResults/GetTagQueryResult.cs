 

namespace MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults
{
    // GetTagQueryResult sınıfı, çoklu etiketlerin (tags) sonuçlarını döndürür.

    public class GetTagQueryResult
    {
        public int TagId { get; set; }
        public string Title { get; set; }
    }
}

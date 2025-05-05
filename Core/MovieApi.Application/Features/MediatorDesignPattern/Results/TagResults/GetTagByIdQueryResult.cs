 
namespace MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults
{
    public class GetTagByIdQueryResult
    {    // GetTagByIdQueryResult sınıfı, bir etiketin (tag) detaylarını döndüren sonucu temsil eder.

        public int TagId { get; set; }
        public string Title { get; set; }
    }
}

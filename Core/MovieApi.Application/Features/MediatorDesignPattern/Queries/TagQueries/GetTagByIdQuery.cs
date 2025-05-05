using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries
{
    // IRequest<GetTagByIdQueryResult> arayüzünü implement eder, yani GetTagByIdQuery'nin sonucu GetTagByIdQueryResult türünde olmalıdır.
    public class GetTagByIdQuery : IRequest<GetTagByIdQueryResult>
    {
        // Bu sınıf, belirli bir TagId'ye sahip etiketi almak için kullanılır.
        public GetTagByIdQuery(int tagId)
        {
            TagId = tagId;
        }

        // Etiketin id'sini tutar.
        public int TagId { get; set; }
    }
}

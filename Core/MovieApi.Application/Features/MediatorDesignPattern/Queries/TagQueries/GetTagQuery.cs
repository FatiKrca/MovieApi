using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries
{
    // IRequest<List<GetTagQueryResult>> arayüzünü implement eder, yani GetTagQuery'nin sonucu List<GetTagQueryResult> türünde olmalıdır.
    public class GetTagQuery : IRequest<List<GetTagQueryResult>>
    {
    }
}

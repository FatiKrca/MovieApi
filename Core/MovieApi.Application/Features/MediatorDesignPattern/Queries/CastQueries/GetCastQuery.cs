using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries
{
    // IRequest<List<GetCastQueryResult>> arayüzünü implement eder, yani GetCastQuery'nin sonucu List<GetCastQueryResult> türünde olmalıdır.
    public class GetCastQuery : IRequest<List<GetCastQueryResult>>
    {
    }
}

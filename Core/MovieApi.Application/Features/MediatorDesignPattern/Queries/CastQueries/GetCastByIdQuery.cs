using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries
{
    // IRequest<GetCastByIdQueryResult> arayüzünü implement eder, yani GetCastByIdQuery'nin sonucu GetCastByIdQueryResult türünde olmalıdır.
    public class GetCastByIdQuery : IRequest<GetCastByIdQueryResult>
    {
        // Yapıcı metod, castId'yi alarak sorgu nesnesini başlatır.
        public GetCastByIdQuery(int castId)
        {
            CastId = castId;
        }

        // GetCastByIdQuery nesnesi, sorgulamak için kullanılacak castId'yi tutar.
        public int CastId { get; set; }
    }
}

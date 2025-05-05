using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    // IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult> arayüzünü implement eder, GetTagByIdQuery komutunu işler.
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
    {
        private readonly MovieContext _context;

        // MovieContext sınıfı, veritabanı işlemleri için kullanılır.
        public GetTagByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu, GetTagByIdQuery komutunu işler ve ID'ye göre veritabanından tag verisini alır.
        public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            // TagId'ye göre veritabanından etiketi arar.
            var values = await _context.Tags.FindAsync(request.TagId);

            // Etiketi ve bilgilerini döner.
            return new GetTagByIdQueryResult
            {
                TagId = values.TagId,
                Title = values.Title
            };
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    // IRequestHandler<GetTagQuery, List<GetTagQueryResult>> arayüzünü implement eder, GetTagQuery komutunu işler.
    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
    {
        private readonly MovieContext _context;

        // MovieContext sınıfı, veritabanı işlemleri için kullanılır.
        public GetTagQueryHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu, GetTagQuery komutunu işler ve tüm etiketleri veritabanından alır.
        public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            // Tüm etiketleri veritabanından alır.
            var values = await _context.Tags.ToListAsync();

            // Etiketlerin bilgilerini GetTagQueryResult nesnelerine dönüştürüp döner.
            return values.Select(x => new GetTagQueryResult
            {
                TagId = x.TagId,
                Title = x.Title
            }).ToList();
        }
    }
}

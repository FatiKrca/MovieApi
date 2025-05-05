using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    // GetCastQuery sorgusunu işleyen sınıf: Tüm oyuncuları (cast) veritabanından almak için kullanılır.
    // MediatR arayüzü olan IRequestHandler<TQuery, TResult> arayüzünü implement eder.
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MovieContext _context;

        // Bağlantı için MovieContext sınıfı kullanılır.
        public GetCastQueryHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu, gelen sorgu (query) ile veritabanından tüm oyuncuları (cast) çeker ve döner.
        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            // Veritabanından tüm oyuncular (casts) alınır.
            var values = await _context.Casts.ToListAsync();

            // Alınan oyuncu listesi, GetCastQueryResult nesnesine dönüştürülür ve liste olarak döndürülür.
            return values.Select(x => new GetCastQueryResult
            {
                CastId = x.CastId,
                Title = x.Title,
                Name = x.Name,
                Surname = x.Surname,
                ImageUrl = x.ImageUrl,
                Overview = x.Overview,
                Biography = x.Biography
            }).ToList();
        }
    }
}

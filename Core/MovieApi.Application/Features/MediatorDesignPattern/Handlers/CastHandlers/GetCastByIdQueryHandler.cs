using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    // GetCastByIdQuery sorgusunu işleyen sınıf: Bir oyuncuyu (cast) ID'sine göre veritabanından çekmek için kullanılır.
    // MediatR arayüzü olan IRequestHandler<TQuery, TResult> arayüzünü implement eder.
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;

        // Bağlantı için MovieContext sınıfı kullanılır.
        public GetCastByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu, gelen sorgu (query) ile veritabanından oyuncuyu (cast) ID'sine göre arar ve döner.
        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            // İlgili oyuncu (cast) ID'sine göre veritabanında arama yapılır.
            var values = await _context.Casts.FindAsync(request.CastId);

            // Sorgu sonucunda oyuncu bilgileri GetCastByIdQueryResult nesnesine aktarılır.
            return new GetCastByIdQueryResult
            {
                CastId = values.CastId,
                Title = values.Title,
                Name = values.Name,
                Surname = values.Surname,
                ImageUrl = values.ImageUrl,
                Overview = values.Overview,
                Biography = values.Biography
            };
        }
    }
}

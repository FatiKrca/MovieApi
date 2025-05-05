using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    // Komut işleyici sınıfı: Yeni bir Cast (oyuncu) oluşturma işlemini gerçekleştirir.
    // MediatR arayüzü olan IRequestHandler<T> arayüzünü implement eder.
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly MovieContext _context;

        // Bağlantı için MovieContext sınıfı kullanılır.
        public CreateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        // Komut işleme metodu: Yeni bir oyuncu (cast) veritabanına ekler.
        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            // Yeni Cast (oyuncu) nesnesi oluşturulup veritabanına eklenir.
            _context.Casts.Add(new Cast
            {
                Title = request.Title,
                Name = request.Name,
                Surname = request.Surname,
                ImageUrl = request.ImageUrl,
                Overview = request.Overview,
                Biography = request.Biography
            });

            // Değişiklikler veritabanına kaydedilir.
            await _context.SaveChangesAsync();
        }
    }
}

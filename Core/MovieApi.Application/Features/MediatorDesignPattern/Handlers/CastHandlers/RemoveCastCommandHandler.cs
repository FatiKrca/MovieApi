using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    // RemoveCastCommand komutunu işleyen sınıf. Bu sınıf, bir oyuncuyu (cast) veritabanından silmek için kullanılır.
    // MediatR arayüzü olan IRequestHandler<TCommand> arayüzünü implement eder.
    public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
    {
        private readonly MovieContext _context;

        // MovieContext sınıfı, veritabanına erişim için kullanılır.
        public RemoveCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu, gelen RemoveCastCommand komutuna göre veritabanından belirtilen oyuncuyu siler.
        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            // Veritabanında, belirtilen CastId'ye sahip olan oyuncuyu bulur.
            var values = await _context.Casts.FindAsync(request.CastId);

            // Eğer oyuncu bulunursa, silme işlemi yapılır.
            if (values != null)
            {
                _context.Casts.Remove(values);
                // Değişiklikleri veritabanına kaydeder.
                await _context.SaveChangesAsync();
            }
        }
    }
}

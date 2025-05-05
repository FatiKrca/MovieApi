using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    // IRequestHandler<UpdateCastCommand> arayüzünü implement eder ve UpdateCastCommand komutunu işler.
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly MovieContext _context;

        // MovieContext sınıfı, veritabanı işlemlerine erişim için kullanılır.
        public UpdateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu, UpdateCastCommand komutunu işler ve gelen veriye göre veritabanındaki oyuncu bilgisini günceller.
        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            // Veritabanında belirtilen CastId'ye sahip oyuncuyu bulur.
            var values = await _context.Casts.FindAsync(request.CastId);

            if (values != null)
            {
                // Oyuncunun bilgilerini, komuttan alınan verilerle günceller.
                values.Title = request.Title;
                values.Name = request.Name;
                values.Surname = request.Surname;
                values.ImageUrl = request.ImageUrl;
                values.Overview = request.Overview;
                values.Biography = request.Biography;

                // Değişiklikleri veritabanına kaydeder.
                await _context.SaveChangesAsync();
            }
        }
    }
}

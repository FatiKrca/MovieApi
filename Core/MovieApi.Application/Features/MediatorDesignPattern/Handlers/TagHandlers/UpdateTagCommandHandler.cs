using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    // IRequestHandler<UpdateTagCommand> arayüzünü implement eder.
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
    {
        private readonly MovieContext _context;

        // Constructor'da MovieContext sınıfı bağlanır.
        public UpdateTagCommandHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu, UpdateTagCommand komutunu işleyip etiket güncelleme işlemini yapar.
        public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            // Güncellenecek etiket, TagId'ye göre bulunur.
            var values = await _context.Tags.FindAsync(request.TagId);

            // Bulunan etiketin Title özelliği, gelen komuttan alınan yeni değerle güncellenir.
            values.Title = request.Title;

            // Değişiklikler veritabanına kaydedilir.
            await _context.SaveChangesAsync();
        }
    }
}

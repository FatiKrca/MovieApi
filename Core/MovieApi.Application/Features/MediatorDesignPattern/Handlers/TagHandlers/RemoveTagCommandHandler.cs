using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    // IRequestHandler<RemoveTagCommand> arayüzünü implement eder.
    public class RemoveTagCommandHandler : IRequestHandler<RemoveTagCommand>
    {
        private readonly MovieContext _context;

        // Constructor'da MovieContext sınıfı bağlanır.
        public RemoveTagCommandHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu, RemoveTagCommand komutunu işleyip etiket silme işlemini yapar.
        public async Task Handle(RemoveTagCommand request, CancellationToken cancellationToken)
        {
            // Silinecek etiket, TagId'ye göre bulunur.
            var values = await _context.Tags.FindAsync(request.TagId);

            // Etiket bulunmuşsa, silme işlemi yapılır.
            _context.Tags.Remove(values);

            // Değişiklikler veritabanına kaydedilir.
            await _context.SaveChangesAsync();
        }
    }
}

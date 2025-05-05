using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    // IRequestHandler<CreateTagCommand> arayüzünü implement eder, CreateTagCommand komutunu işler.
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
    {
        private readonly MovieContext _context;

        // MovieContext sınıfı, veritabanı işlemleri için kullanılır.
        public CreateTagCommandHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu, CreateTagCommand komutunu işler ve gelen veriye göre yeni bir Tag (etiket) oluşturur.
        public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            // Yeni bir Tag (etiket) nesnesi oluşturur ve veritabanına ekler.
            _context.Tags.Add(new Tag
            {
                Title = request.Title
            });

            // Değişiklikleri veritabanına kaydeder.
            await _context.SaveChangesAsync();
        }
    }
}

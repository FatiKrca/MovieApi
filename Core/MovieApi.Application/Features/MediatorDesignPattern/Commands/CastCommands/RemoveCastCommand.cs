using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands
{
    // Komut sınıfı: Bir oyuncuyu (cast) silme işlemi için kullanılır.
    // MediatR arayüzünü implement eder, böylece komut işleme işlemine dahil olabilir.

    public class RemoveCastCommand : IRequest
    {
        // Oyuncu silme işlemi için gerekli olan oyuncu ID'si
        public RemoveCastCommand(int castId)
        {
            CastId = castId;
        }

        // Silinecek oyuncunun ID'si
        public int CastId { get; set; }
    }
}

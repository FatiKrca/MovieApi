using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    // Komut sınıfı: Bir etiketi (tag) silme işlemi için kullanılır.
    // MediatR arayüzünü implement eder, böylece komut işleme işlemine dahil olabilir.

    public class RemoveTagCommand : IRequest
    {
        // Silinmek istenen etiketin ID'si
        public int TagId { get; set; }

        // Constructor: TagId'yi almak için kullanılan yapıcı metod.
        public RemoveTagCommand(int tagId)
        {
            TagId = tagId;
        }
    }
}

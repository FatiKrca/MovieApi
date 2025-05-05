using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    // Komut sınıfı: Yeni bir etiket (tag) oluşturma işlemi için kullanılır.
    // MediatR arayüzünü implement eder, böylece komut işleme işlemine dahil olabilir.

    public class CreateTagCommand : IRequest
    {
        // Yeni oluşturulacak etiketin başlığı (örneğin: "Action", "Drama")
        public string Title { get; set; }
    }
}

 
using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    // Komut sınıfı: Var olan bir etiketi (tag) güncelleme işlemi için kullanılır.
    // MediatR arayüzünü implement eder, böylece komut işleme işlemine dahil olabilir.

    public class UpdateTagCommand : IRequest
    {
        public int TagId { get; set; }
        public string Title { get; set; }
    }
}

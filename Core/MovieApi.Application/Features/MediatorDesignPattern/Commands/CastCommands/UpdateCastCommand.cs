 
using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands
{
    // Komut sınıfı: Bir oyuncunun bilgilerini güncelleme işlemi için kullanılır.
    // MediatR arayüzünü implement eder, böylece komut işleme işlemine dahil olabilir.

    public class UpdateCastCommand : IRequest
    {
        public int CastId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string? Overview { get; set; }
        public string? Biography { get; set; }
    }
}

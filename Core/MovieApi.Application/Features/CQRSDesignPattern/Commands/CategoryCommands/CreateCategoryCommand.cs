// Komut (Command) sınıfı: Yeni bir kategori oluşturmak için gerekli verileri taşır.
// CQRS (Command Query Responsibility Segregation) deseninde "write" işlemleri için kullanılır.

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands
{
    public class CreateCategoryCommand
    {
        // Oluşturulacak kategorinin adını temsil eder.
        public string CategoryName { get; set; }
    }
}

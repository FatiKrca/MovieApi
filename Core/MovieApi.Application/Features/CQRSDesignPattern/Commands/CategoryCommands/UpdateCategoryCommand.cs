// Komut (Command) sınıfı: Var olan bir kategoriyi güncellemek için kullanılır.
// CQRS deseninde "write" işlemi olan güncelleme işlemi bu sınıfla temsil edilir.

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        // Güncellenecek kategorinin benzersiz kimliğini (Id) temsil eder.
        public int CategoryId { get; set; }

        // Kategorinin yeni adını temsil eder.
        public string CategoryName { get; set; }
    }
}

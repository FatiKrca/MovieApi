// Komut (Command) sınıfı: Belirli bir kategoriyi silmek için kullanılır.
// CQRS deseninde "write" işlemi olan silme işlemi bu sınıfla temsil edilir.

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands
{
    public class RemoveCategoryCommand
    {
        // Yapıcı metot (constructor): Komut nesnesi oluşturulurken CategoryId atanmasını sağlar.
        public RemoveCategoryCommand(int categoryId)
        {
            CategoryId = categoryId;
        }

        // Silinecek kategorinin benzersiz kimliğini (Id) temsil eder.
        public int CategoryId { get; set; }

    }
}

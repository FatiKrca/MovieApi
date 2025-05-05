using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    // Handler sınıfı: RemoveCategoryCommand komutunu işleyerek belirtilen kategoriyi siler.
    // Bu sınıf, RemoveCategoryCommand komutundan gelen CategoryId ile veritabanındaki ilgili kategoriyi bulur
    // ve ardından bu kategoriyi veritabanından siler.

    public class RemoveCategoryCommandHandler
    {
        private readonly MovieContext _context;

        // Yapıcı metot (constructor): MovieContext (veritabanı bağlamı) ile ilişkilendirilir.
        public RemoveCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu: RemoveCategoryCommand komutunu alır ve belirtilen CategoryId'ye göre kategori bilgisini veritabanından siler.
        public async Task Handle(RemoveCategoryCommand command)
        {
            var value = await _context.Categories.FindAsync(command.CategoryId); // Kategori ID'sine göre veritabanında arama yapılır.
            _context.Categories.Remove(value); // Kategori silinir.
            await _context.SaveChangesAsync(); // Değişiklikler veritabanına kaydedilir.
        }
    }
}

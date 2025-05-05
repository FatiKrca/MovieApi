using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    // Handler sınıfı: UpdateCategoryCommand komutunu işleyerek belirtilen kategoriyi günceller.
    // Bu sınıf, UpdateCategoryCommand komutundan gelen CategoryId ile veritabanındaki ilgili kategoriyi bulur
    // ve ardından kategori adını günceller.

    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _context;

        // Yapıcı metot (constructor): MovieContext (veritabanı bağlamı) ile ilişkilendirilir.
        public UpdateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu: UpdateCategoryCommand komutunu alır ve belirtilen CategoryId'ye göre kategori bilgisini günceller.
        public async Task Handle(UpdateCategoryCommand command)
        {
            var value = await _context.Categories.FindAsync(command.CategoryId); // Kategori ID'sine göre veritabanında arama yapılır.
            value.CategoryName = command.CategoryName; // Kategori adı güncellenir.
            await _context.SaveChangesAsync(); // Değişiklikler veritabanına kaydedilir.
        }
    }
}

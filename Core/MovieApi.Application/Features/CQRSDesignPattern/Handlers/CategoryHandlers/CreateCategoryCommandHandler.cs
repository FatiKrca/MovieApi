using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    // Handler sınıfı: CreateCategoryCommand komutunu işleyerek yeni bir kategori oluşturur.
    // Bu sınıf, CreateCategoryCommand komutundan gelen verilerle veritabanına yeni bir kategori ekler.
    // Veritabanı işlemi asenkron olarak yapılır.

    public class CreateCategoryCommandHandler
    {
        private readonly MovieContext _context;

        // Yapıcı metot (constructor): MovieContext (veritabanı bağlamı) ile ilişkilendirilir.
        public CreateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        // Handle metodu: CreateCategoryCommand komutunu alır ve yeni kategoriyi veritabanına ekler.
        // Komutun içindeki CategoryName verisini kullanarak yeni bir kategori ekler ve değişiklikleri kaydeder.
        public async Task Handle(CreateCategoryCommand command)
        {
            _context.Categories.Add(new Category
            {
                CategoryName = command.CategoryName
            });
            await _context.SaveChangesAsync(); // Asenkron olarak veritabanına kaydedilir.
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;

namespace MovieApi.WebApi.Controllers
{
    // API yolunu belirler. [controller] ifadesi, controller adından (CategoriesController) alınarak "categories" olarak değiştirilir.
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // Handler sınıflarını enjekte ederiz. Bu sınıflar, CQRS tasarım desenine göre sorguları ve komutları işler.
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

        // Controller constructor'ı, gerekli handler'ları enjekte eder.
        public CategoriesController(GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler)
        {
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
        }

        // GET: api/categories -> Tüm kategorileri listeler.
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            // GetCategoryQueryHandler ile kategorilerin listesini alır.
            var value = await _getCategoryQueryHandler.Handle();

            // Veriyi JSON formatında döneriz.
            return Ok(value);
        }

        // POST: api/categories -> Yeni bir kategori ekler.
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            // CreateCategoryCommand ile yeni kategori ekler.
            await _createCategoryCommandHandler.Handle(command);

            // İşlem başarılı olduğunda "Kategori Ekleme İşlemi Başarılı" mesajını döneriz.
            return Ok("Kategori Ekleme İşlemi Başarılı");
        }

        // DELETE: api/categories -> Belirli bir kategoriyi siler.
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            // Silinecek kategori ID'sini kullanarak RemoveCategoryCommand komutunu göndeririz.
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));

            // İşlem başarılı olduğunda "Silme İşlemi Başarılı" mesajını döneriz.
            return Ok("Silme İşlemi Başarılı");
        }

        // PUT: api/categories -> Var olan bir kategoriyi günceller.
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            // UpdateCategoryCommand ile var olan kategoriyi güncelleriz.
            await _updateCategoryCommandHandler.Handle(command);

            // İşlem başarılı olduğunda "Güncelleme işlemi başarılı" mesajını döneriz.
            return Ok("Güncelleme işlemi başarılı");
        }

        // GET: api/categories/GetCategory -> Belirli bir kategoriyi ID'ye göre getirir.
        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            // GetCategoryByIdQuery ile verilen ID'ye sahip kategoriyi getiririz.
            var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));

            // Kategorinin bilgilerini JSON formatında döneriz.
            return Ok(value);
        }
    }
}

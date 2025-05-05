using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    // "MoviesController" API yolunu tanımlar. Burada [controller] kısmı, controller adından (MoviesController) alınarak "movies" olarak değiştirilir.
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // Command ve Query handler'larını enjekte ederiz.
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;

        // Constructor, gerekli handler'ları enjekte eder.
        public MoviesController(CreateMovieCommandHandler createMovieCommandHandler, GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, RemoveMovieCommandHandler removeMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler)
        {
            _createMovieCommandHandler = createMovieCommandHandler;
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
        }

        // HTTP GET (Tüm Filmler) -> Tüm filmleri listeleme işlemi.
        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            // GetMovieQueryHandler ile filmleri getiririz.
            var value = await _getMovieQueryHandler.Handle();
            return Ok(value); // Filmlerin listesini JSON formatında döneriz.
        }

        // HTTP POST (Yeni Film Ekleme) -> Yeni bir film ekler.
        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
        {
            // CreateMovieCommand ile yeni bir film ekleriz.
            await _createMovieCommandHandler.Handle(command);
            return Ok("Film Ekleme İşlemi Başarılı"); // Başarılı ekleme mesajı döneriz.
        }

        // HTTP DELETE (Film Silme) -> Verilen ID'ye sahip filmi siler.
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            // Silinecek film ID'sine göre RemoveMovieCommand komutunu işleriz.
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("Silme İşlemi Başarılı"); // Silme işlemi başarılı olduğunda mesaj döner.
        }

        // HTTP GET (ID'ye Göre Film Getirme) -> Belirli bir film ID'sine göre film verilerini alır.
        [HttpGet("GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            // GetMovieByIdQuery ile film ID'sine göre veriyi getiririz.
            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(value); // Verilen ID'ye sahip filmin bilgilerini döneriz.
        }

        // HTTP PUT (Film Güncelleme) -> Var olan bir filmi günceller.
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            // UpdateMovieCommand ile filmi güncelleriz.
            await _updateMovieCommandHandler.Handler(command);
            return Ok("Film Güncelleme işlemi başarılı"); // Güncelleme başarılı olduğunda mesaj döneriz.
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;

namespace MovieApi.WebApi.Controllers
{
    // Route, bu controller'ın URL yolunu tanımlar. [controller] ifadesi, controller adından (CastsController) alınarak "casts" olarak değiştirilir.
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;  // MediatR'ı kullanarak komutları ve sorguları yönlendirecek mediator servisi.

        // Controller'ı oluştururken, IMediator'ı constructor'a enjekte ediyoruz.
        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/casts -> Tüm cast (oyuncu) listesini alır.
        [HttpGet]
        public IActionResult CastList()
        {
            // GetCastQuery komutunu MediatR ile gönderiyoruz ve tüm cast verilerini alıyoruz.
            var value = _mediator.Send(new GetCastQuery());

            // Ok() ile 200 OK yanıtı ve veri döndürülür.
            return Ok(value);
        }

        // POST: api/casts -> Yeni bir oyuncu (cast) ekler.
        [HttpPost]
        public IActionResult CreateCast(CreateCastCommand command)
        {
            // CreateCastCommand komutunu MediatR ile gönderiyoruz. Bu komut, yeni bir oyuncu ekler.
            _mediator.Send(command);

            // İşlem başarılı olduğunda "Ekleme İşlemi Başarılı" mesajını döneriz.
            return Ok("Ekleme İşlemi Başarılı");
        }

        // DELETE: api/casts -> Belirli bir oyuncuyu siler.
        [HttpDelete]
        public IActionResult DeleteCast(int id)
        {
            // Silinecek oyuncu ID'sini kullanarak RemoveCastCommand komutunu gönderiyoruz.
            _mediator.Send(new RemoveCastCommand(id));

            // İşlem başarılı olduğunda "Silme İşlemi Başarılı" mesajını döneriz.
            return Ok("Silme İşlemi Başarılı");
        }

        // GET: api/casts/GetCastById -> Belirli bir oyuncuyu ID'ye göre getirir.
        [HttpGet("GetCastById")]
        public IActionResult GetCastById(int id)
        {
            // GetCastByIdQuery komutunu, belirtilen ID'ye sahip oyuncunun bilgilerini almak için gönderiyoruz.
            var value = _mediator.Send(new GetCastByIdQuery(id));

            // Ok() ile oyuncunun bilgilerini döndürürüz.
            return Ok(value);
        }

        // PUT: api/casts -> Var olan bir oyuncuyu günceller.
        [HttpPut]
        public IActionResult UpdateCast(UpdateCastCommand command)
        {
            // UpdateCastCommand komutunu gönderiyoruz. Bu komut, oyuncu bilgisini günceller.
            _mediator.Send(command);

            // İşlem başarılı olduğunda "Güncelleme İşlemi Başarılı" mesajını döneriz.
            return Ok("Güncelleme İşlemi Başarılı");
        }
    }
}

using ApiAwsExamen.Models;
using ApiAwsExamen.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiAwsExamen.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private RepositoryEventos repo;

        public EventosController(RepositoryEventos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<List<Categoria>> GetCategorias()
        {
            return await this.repo.GetCategoriasAsync();
        }

        [HttpGet]
        public async Task<List<Evento>> GetEventos()
        {
            return await this.repo.GetEventosAsync();
        }

        [HttpGet("{idcategoria}")]
        public async Task<List<Evento>> FindCubosMarca(int idcategoria)
        {
            return await this.repo.GetEventoCategoriaAsync(idcategoria);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvento(Evento evento)
        {
            await this.repo.CreateEventoAsync(evento.Nombre, evento.Artista, evento.IdCategoria, evento.Imagen);
            return Ok();
        }
    }
}

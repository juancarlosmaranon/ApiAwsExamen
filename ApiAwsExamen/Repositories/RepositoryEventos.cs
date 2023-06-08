using ApiAwsExamen.Data;
using ApiAwsExamen.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAwsExamen.Repositories
{
    public class RepositoryEventos
    {
        private EventosContext context;

        public RepositoryEventos(EventosContext context)
        {
            this.context = context;
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            return await this.context.Categorias.ToListAsync();
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            return await this.context.Eventos.ToListAsync();
        }

        public async Task<List<Evento>> GetEventoCategoriaAsync(int idcategoria)
        {
            return await this.context.Eventos.Where(x => x.IdCategoria == idcategoria).ToListAsync();
        }

        public async Task<bool> CreateEventoAsync(string nombre, string artista, int idcategoria, string imagen)
        {
            int newid = await this.context.Eventos.AnyAsync() ? await this.context.Eventos.MaxAsync(x => x.Id) + 1 : 1;
            Evento evento = new Evento
            {
                Id = newid,
                Nombre = nombre,
                Artista = artista,
                IdCategoria = idcategoria,
                Imagen = imagen
            };

            await this.context.Eventos.AddAsync(evento);
            return await context.SaveChangesAsync() > 0;
        }
    }
}

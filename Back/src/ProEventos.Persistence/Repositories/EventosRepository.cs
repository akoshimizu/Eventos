using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Data;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence.Repositories
{
    public class EventosRepository : IEventoRepository
    {
        private readonly EventoContext _context;
        public EventosRepository(EventoContext context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool incluirPalestrate = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(p => p.Lotes)
                .Include(p => p.RedeSociais);
            
            if(incluirPalestrate)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query
                .AsNoTracking()
                .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool incluirPalestrate = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(p => p.Lotes)
                .Include(p => p.RedeSociais);
            
            if(incluirPalestrate)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query
                .AsNoTracking()
                .OrderBy(e => e.Id)
                .Where(e => e.Id == eventoId);
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrate = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(p => p.Lotes)
                .Include(p => p.RedeSociais);
            
            if(incluirPalestrate)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query
                .AsNoTracking()
                .OrderBy(e => e.Id)
                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            
            return await query.ToArrayAsync();
        }
    }
}
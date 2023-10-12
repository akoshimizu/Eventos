using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Interfaces
{
    public interface IEventoRepository
    {
        Task<Evento[]> GetAllEventosAsync(bool incluirPalestrates = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool incluirPalestrates = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrates = false);
    }
}
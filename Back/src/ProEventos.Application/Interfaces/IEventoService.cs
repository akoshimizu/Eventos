using ProEventos.Application.Dtos;

namespace ProEventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<EventoDto> AddEventos(EventoDto eventoModel);
        Task<EventoDto> UpdateEventos(int eventoId, EventoDto eventoModel);
        Task<bool> DeleteEventos(int eventoId);
        Task<EventoDto[]> GetAllEventosAsync(bool incluirPalestrates = false);
        Task<EventoDto> GetEventoByIdAsync(int eventoId, bool incluirPalestrates = false);
        Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrates = false);
    }
}
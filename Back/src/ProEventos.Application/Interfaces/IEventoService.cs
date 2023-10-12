using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain.Models;

namespace ProEventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento eventoModel);
        Task<Evento> UpdateEventos(int eventoId, Evento eventoModel);
        Task<bool> DeleteEventos(int eventoId);
        Task<Evento[]> GetAllEventosAsync(bool incluirPalestrates = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool incluirPalestrates = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrates = false);
    }
}
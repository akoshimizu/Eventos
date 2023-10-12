using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IGeralRepository _geralRepository;

        public EventoService(IGeralRepository geralRepository, IEventoRepository eventoRepository)
        {
            _geralRepository = geralRepository;
            _eventoRepository = eventoRepository;
        }

        public async Task<Evento> AddEventos(Evento eventoModel)
        {
            try
            {
                _geralRepository.Add<Evento>(eventoModel);
                if(await _geralRepository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetEventoByIdAsync(eventoModel.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Evento> UpdateEventos(int eventoId, Evento eventoModel)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, false);
                if(evento == null) return null;

                eventoModel.Id = evento.Id;

                _geralRepository.Update(eventoModel);
                if(await _geralRepository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetEventoByIdAsync(eventoModel.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEventos(int eventoId)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, false);
                if(evento == null) throw new Exception("Evento para deletar não foi encontrado");

                _geralRepository.Delete<Evento>(evento);
                return await _geralRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool incluirPalestrates = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosAsync(incluirPalestrates);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrates = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosByTemaAsync(tema, incluirPalestrates);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool incluirPalestrates = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetEventoByIdAsync(eventoId, incluirPalestrates);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
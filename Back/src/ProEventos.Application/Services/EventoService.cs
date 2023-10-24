using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IGeralRepository _geralRepository;
        private readonly IMapper _mapper;

        public EventoService(IGeralRepository geralRepository, IEventoRepository eventoRepository, IMapper mapper)
        {
            _geralRepository = geralRepository;
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }

        public async Task<EventoDto> AddEventos(EventoDto eventoModel)
        {
            try
            {
                var evento = _mapper.Map<Evento>(eventoModel);
                _geralRepository.Add(evento);
                if(await _geralRepository.SaveChangesAsync())
                {
                    return _mapper.Map<EventoDto>( await _eventoRepository.GetEventoByIdAsync(evento.Id, false));
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<EventoDto> UpdateEventos(int eventoId, EventoDto eventoModel)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, false);
                if(evento == null) return null;

                eventoModel.Id = evento.Id;
                _mapper.Map(eventoModel, evento);

                _geralRepository.Update(evento);
                if(await _geralRepository.SaveChangesAsync())
                {
                    return _mapper.Map<EventoDto>( await _eventoRepository.GetEventoByIdAsync(evento.Id, false));
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEventos(int eventoId)
        {return false;
            // try
            // {
            //     var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, false);
            //     if(evento == null) throw new Exception("Evento para deletar não foi encontrado");

            //     _geralRepository.Delete<EventoDto>(evento);
            //     return await _geralRepository.SaveChangesAsync();
            // }
            // catch (Exception ex)
            // {
            //     throw new Exception(ex.Message);
            // }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool incluirPalestrates = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosAsync(incluirPalestrates);
                if(eventos == null) return null;

                var eventosDto = _mapper.Map<EventoDto[]>(eventos);

                return eventosDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrates = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosByTemaAsync(tema, incluirPalestrates);
                if(eventos == null) return null;

                var eventosDto = _mapper.Map<EventoDto[]>(eventos);

                return eventosDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int eventoId, bool incluirPalestrates = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetEventoByIdAsync(eventoId, incluirPalestrates);
                if(eventos == null) return null;

                var eventosDto = _mapper.Map<EventoDto>(eventos);

                return eventosDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Domain.Models;

namespace ProEventos.Application.Helpers
{
    public class EventosProfile : Profile
    {
        public EventosProfile()
        {
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Palestrante, PalestranteDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
        }
    }
}
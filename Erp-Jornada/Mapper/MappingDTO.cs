﻿using AutoMapper;
using Erp_Jornada.Dtos.Marca;
using Erp_Jornada.Dtos.UsuarioDTO;
using Erp_Jornada.Model;

namespace Erp_Jornada.Mapper
{
    public class MappingDTO : Profile
    {
        public MappingDTO()
        {
            CreateMap<Marca, MarcaAddDTO>().ReverseMap();
            CreateMap<Marca, MarcaListDTO>().ReverseMap();
            CreateMap<Marca, MarcaDTO>().ReverseMap();
            CreateMap<Marca, MarcaUpdateDTO>().ReverseMap();

            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioUpdateDTO>().ReverseMap();
        }
    }
}

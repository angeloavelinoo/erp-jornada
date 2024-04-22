using AutoMapper;
using Erp_Jornada.Dtos;
using Erp_Jornada.Dtos.Marca;
using Erp_Jornada.Dtos.UsuarioDTO;
using Erp_Jornada.Model;
using Erp_Jornada.Repository;
using Erp_Jornada.Tools;
using Erp_Jornada.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Erp_Jornada.Services
{
    public class MarcaService(MarcaRepository marcaRepository, UsuarioService usuarioService, IMapper mapper)
    {
        private readonly MarcaRepository _marcaRepository = marcaRepository;
        private readonly UsuarioService _usuarioService = usuarioService;
        private readonly IMapper _mapper = mapper;
        public async Task<ResultModel<dynamic>> Add(MarcaAddDTO marcaDTO)
        {
            var marca = new Marca(
                new(marcaDTO.Nome),
                (marcaDTO.Email),
                (marcaDTO.Cnpj),
                BCrypt.Net.BCrypt.HashPassword(marcaDTO.Senha));


            if (await _marcaRepository.AlredyExist(marcaDTO.Email))
                return new(HttpStatusCode.Conflict, "Email já cadastrado");

            await _marcaRepository.Create(marca);

            RegisterDto register = new RegisterDto(marca.Nome, marca.Email, marca.Senha, "Marca");

            await _usuarioService.Add(register);

            return new();

        }

        public async Task<ResultModel<MarcaDTO>> GetById(int id)
        {
            Marca marca = await _marcaRepository.GetById(id);

            if (marca == null)
                return new(HttpStatusCode.NotFound, "Marca não encontrada");

            return new(_mapper.Map<MarcaDTO>(marca));
        }

        public async Task<ResultModel<BaseDTOPagination<MarcaListDTO>>> GetList(int pageNumber, int pageSize)
        {
            var marcas = await _marcaRepository.GetItens();

            if (marcas.Count == 0)
                return new(HttpStatusCode.NotFound, "Nenhuma marca foi encontrada");

            return new(new BaseDTOPagination<MarcaListDTO>(
                          new(await _marcaRepository.CountItens(),
                          pageNumber,
                          pageSize),
                          _mapper.Map<IList<MarcaListDTO>>(marcas)));
        }

        public async Task<ResultModel<dynamic>> Remove(int id)
        {
            Marca marca = await _marcaRepository.GetById(id);

            if (marca == null)
                return new(HttpStatusCode.NotFound, "Marca não encontrada");

            await _marcaRepository.Remove(marca);

            return new();

        }

        public async Task<ResultModel<dynamic>> Update(MarcaUpdateDTO model)
        {

            var marca = await _marcaRepository.GetById(model.Id);

            if (marca == null)
                return new(HttpStatusCode.NotFound, "Marca não encontrada");

            marca.Nome = model.Nome;
            marca.Cnpj = model.Cnpj;
            marca.Email = model.Email;
            marca.Senha = model.Senha;
            await _marcaRepository.Update(marca);

            return new();

        }

      
    }
}

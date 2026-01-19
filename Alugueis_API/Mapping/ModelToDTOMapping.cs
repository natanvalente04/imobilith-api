using Alugueis_API.Models;
using AutoMapper;
using Alugueis_API.Models.DTOs.Response;

namespace Alugueis_API.Mapping
{
    public class ModelToDTOMapping : Profile
    {
        public ModelToDTOMapping()
        {
            CreateMap<Usuario, GetUsuarioDTO>();
        }
    }
}

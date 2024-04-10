using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Models;

namespace CitasMedicas.Mappers
{
    public class AppoMapping : Profile
    {
        public AppoMapping()
        {
            CreateMap<AppoDTO, AppoModel>();
            CreateMap<AppoModel, AppoDTO>();
        }
    }
}

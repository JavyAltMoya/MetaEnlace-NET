using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Models;

namespace CitasMedicas.Mappers
{
    public class DiagMapping : Profile
    {
        public DiagMapping()
        {
            CreateMap<DiagDTO, DiagModel>();
            CreateMap<DiagModel, DiagDTO>();
        }
    }
}

using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Models;

namespace CitasMedicas.Mappers
{
    public class PacientMapping : Profile
    {
        public PacientMapping()
        {
            CreateMap<PacientDTO, PacientModel>();
            CreateMap<PacientModel, PacientDTO>();
        }
    }
}

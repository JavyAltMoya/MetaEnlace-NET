using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Models;

namespace CitasMedicas.Mappers
{
    public class MedicMapping : Profile
    {
        public MedicMapping()
        {
            CreateMap<MedicDTO, MedicModel>();
            CreateMap<MedicModel, MedicDTO>();
        }
    }
}

using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Models;

namespace CitasMedicas.Mappers
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserDTO, UserModel>();
            CreateMap<UserModel, UserDTO>();
        }
    }
}

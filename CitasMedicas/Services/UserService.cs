using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<UserDTO> Get()
        {
            var UsersFromRepo = _mapper.Map<IEnumerable<UserDTO>>(_unitOfWork.User.GetAll());
            return UsersFromRepo;
        }

        public void Post([FromBody] UserDTO userDTO)
        {
            var UsersFromRepo = _mapper.Map<UserModel>(userDTO);
            _unitOfWork.User.Add(UsersFromRepo);
            _unitOfWork.Save();
        }

        public UserDTO GetById(long id)
        {
            var UsersFromRepo = _mapper.Map<UserDTO>(_unitOfWork.User.GetById(id));
            return UsersFromRepo;
        }

        public void DeleteById(long id)
        {
            var UsersFromRepo = _unitOfWork.User.GetById(id);
            _unitOfWork.User.Remove(UsersFromRepo);
            _unitOfWork.Save();
        }

        public UserDTO Update([FromBody] UserDTO userDTO, long id)
        {
            var UsersFromRepo = _unitOfWork.User.GetById(id);

            if (userDTO.Nombre != null && userDTO.Nombre.Length != 0)
                UsersFromRepo.nombre = userDTO.Nombre;

            if (userDTO.Apellidos != null && userDTO.Apellidos.Length != 0)
                UsersFromRepo.apellidos = userDTO.Apellidos;

            if (userDTO.Usuario != null && userDTO.Usuario.Length != 0)
                UsersFromRepo.usuario = userDTO.Usuario;

            if (userDTO.Clave != null && userDTO.Clave.Length != 0)
                UsersFromRepo.clave = userDTO.Clave;


            _unitOfWork.User.Update(UsersFromRepo);
            _unitOfWork.Save();

            return _mapper.Map<UserDTO>(UsersFromRepo);
        }
    }
}

using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Services
{
    public class PacientService : IPacientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;    

        public PacientService(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<PacientDTO> Get()
        {
            var PacientFromRepo = _mapper.Map<IEnumerable<PacientDTO>>(_unitOfWork.Pacient.GetAll());

            return PacientFromRepo;
        }

        public void Post([FromBody] PacientDTO pacientDTO)
        {
            var PacientFromRepo = _mapper.Map<PacientModel>(pacientDTO);
            _unitOfWork.Pacient.Add(PacientFromRepo);
            _unitOfWork.Save();
        }

        public PacientDTO GetById(long id)
        {
            var PacientFromRepo = _mapper.Map<PacientDTO>(_unitOfWork.Pacient.GetById(id));
            return PacientFromRepo;
        }

        public void DeleteById(long id)
        {
            var PacientFromRepo = _unitOfWork.Pacient.GetById(id);
            _unitOfWork.Pacient.Remove(PacientFromRepo);
            _unitOfWork.Save();
        }

        public PacientDTO Update([FromBody] PacientDTO pacientDTO, long id)
        {
            var PacientFromRepo = _unitOfWork.Pacient.GetById(id);

            if (pacientDTO.Nombre != null && pacientDTO.Nombre.Length != 0)
                PacientFromRepo.nombre = pacientDTO.Nombre;

            if (pacientDTO.Apellidos != null && pacientDTO.Apellidos.Length != 0)
                PacientFromRepo.apellidos = pacientDTO.Apellidos;

            if (pacientDTO.Usuario != null && pacientDTO.Usuario.Length != 0)
                PacientFromRepo.usuario = pacientDTO.Usuario;

            if (pacientDTO.Clave != null && pacientDTO.Clave.Length != 0)
                PacientFromRepo.clave = pacientDTO.Clave;

            if (pacientDTO.Nss != null && pacientDTO.Nss.Length != 0)
                PacientFromRepo.nss = pacientDTO.Nss;

            if (pacientDTO.NumTarjeta != null && pacientDTO.NumTarjeta.Length != 0)
                PacientFromRepo.numTarjeta = pacientDTO.NumTarjeta;

            if (pacientDTO.Telefono != null && pacientDTO.Telefono.Length != 0)
                PacientFromRepo.telefono = pacientDTO.Telefono;

            if (pacientDTO.Direccion != null && pacientDTO.Direccion.Length != 0)
                PacientFromRepo.direccion = pacientDTO.Direccion;

            _unitOfWork.Pacient.Update(PacientFromRepo);
            _unitOfWork.Save();

            return _mapper.Map<PacientDTO>(PacientFromRepo);
        }
    }
}

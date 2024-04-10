using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Services
{
    public class MedicService : IMedicService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicService(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<MedicDTO> Get()
        {
            var MedicFromRepo = _mapper.Map<IEnumerable<MedicDTO>>(_unitOfWork.Medic.GetAll());
            return MedicFromRepo;
        }

        public void Post([FromBody] MedicDTO medicDTO)
        {
            var MedicFromRepo = _mapper.Map<MedicModel>(medicDTO);
            _unitOfWork.Medic.Add(MedicFromRepo);
            _unitOfWork.Save();
        }

        public MedicDTO GetById(long id)
        {
            var MedicFromRepo = _mapper.Map<MedicDTO>(_unitOfWork.Medic.GetById(id));
            return MedicFromRepo;
        }

        public void DeleteById(long id)
        {
            var MedicFromRepo = _unitOfWork.Medic.GetById(id);
            _unitOfWork.Medic.Remove(MedicFromRepo);
            _unitOfWork.Save();
        }

        public MedicDTO Update([FromBody] MedicDTO medicDTO, long id)
        {
            var MedicFromRepo = _unitOfWork.Medic.GetById(id);

            if (medicDTO.Nombre != null && medicDTO.Nombre.Length != 0)
                MedicFromRepo.nombre = medicDTO.Nombre;

            if (medicDTO.Apellidos != null && medicDTO.Apellidos.Length != 0)
                MedicFromRepo.apellidos = medicDTO.Apellidos;

            if (medicDTO.Usuario != null && medicDTO.Usuario.Length != 0)
                MedicFromRepo.usuario = medicDTO.Usuario;

            if (medicDTO.Clave != null && medicDTO.Clave.Length != 0)
                MedicFromRepo.clave = medicDTO.Clave;

            if (medicDTO.NumColegiado != null && medicDTO.NumColegiado.Length != 0)
                MedicFromRepo.numColegiado = medicDTO.NumColegiado;

            _unitOfWork.Medic.Update(MedicFromRepo);
            _unitOfWork.Save();

            return _mapper.Map<MedicDTO>(MedicFromRepo);
        }
    }
}

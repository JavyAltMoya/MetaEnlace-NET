using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Services
{
    public class AppoService : IAppoService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppoService(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<AppoDTO> Get()
        {
            var AppoFromRepo = _mapper.Map<IEnumerable<AppoDTO>>(_unitOfWork.Appo.GetAll());
            return AppoFromRepo;
        }

        public void Post([FromBody] AppoDTO appoDTO)
        {
            var AppoFromRepo = _mapper.Map<AppoModel>(appoDTO);
            _unitOfWork.Appo.Add(AppoFromRepo);
            _unitOfWork.Save();
        }

        public AppoDTO GetById(long id)
        {
            var AppoFromRepo = _mapper.Map<AppoDTO>(_unitOfWork.Appo.GetById(id));
            return AppoFromRepo;
        }

        public void DeleteById(long id)
        {
            var AppoFromRepo = _unitOfWork.Appo.GetById(id);
            _unitOfWork.Appo.Remove(AppoFromRepo);
            _unitOfWork.Save();

        }

        public AppoDTO Update([FromBody] AppoDTO appoDTO, long id)
        {
            var AppoFromRepo = _unitOfWork.Appo.GetById(id);

            if (appoDTO.MotivoCita != null && appoDTO.MotivoCita.Length != 0)
                AppoFromRepo.motivoCita = appoDTO.MotivoCita;

            if (appoDTO.Attribute11 != 0)
                AppoFromRepo.attribute11 = appoDTO.Attribute11;

            _unitOfWork.Appo.Update(AppoFromRepo);

            _unitOfWork.Save();

            return _mapper.Map<AppoDTO>(AppoFromRepo);
        }
    }
}

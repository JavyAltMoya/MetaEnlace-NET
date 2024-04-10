using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Services
{
    public class DiagService : IDiagService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiagService(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<DiagDTO> Get()
        {
            var DiagFromRepo = _mapper.Map<IEnumerable<DiagDTO>>(_unitOfWork.Diag.GetAll());
            return DiagFromRepo;
        }
        public void Post([FromBody] DiagDTO diagDTO)
        {
            var DiagFromRepo = _mapper.Map<DiagModel>(diagDTO);
            _unitOfWork.Diag.Add(DiagFromRepo);
            _unitOfWork.Save();
        }

        public DiagDTO GetById(long id)
        {
            var DiagFromRepo = _mapper.Map<DiagDTO>(_unitOfWork.Diag.GetById(id));
            return DiagFromRepo;
        }

        public void DeleteById(long id)
        {
            var DiagFromRepo = _unitOfWork.Diag.GetById(id);
            _unitOfWork.Diag.Remove(DiagFromRepo);
            _unitOfWork.Save();
        }

        public DiagDTO Update([FromBody] DiagDTO diagDTO, long id)
        {
            var DiagFromRepo = _unitOfWork.Diag.GetById(id);

            if (diagDTO.ValoracionEspecialista != null && diagDTO.ValoracionEspecialista.Length != 0)
                DiagFromRepo.valoracionEspecialista = diagDTO.ValoracionEspecialista;

            if (diagDTO.Enfermedad != null && diagDTO.Enfermedad.Length != 0)
                DiagFromRepo.enfermedad = diagDTO.Enfermedad;

            _unitOfWork.Diag.Update(DiagFromRepo);

            _unitOfWork.Save();

            return _mapper.Map<DiagDTO>(DiagFromRepo);
        }
    }
}

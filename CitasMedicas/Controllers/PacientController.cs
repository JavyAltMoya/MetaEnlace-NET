using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using CitasMedicas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Controllers
{
    [Route("Paciente")]
    [ApiController]
    public class PacientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPacientService _pacientService;

        public PacientController(IUnitOfWork UnitOfWork, IMapper mapper, IPacientService pacientService)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
            _pacientService = pacientService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var PacientFromRepo = _pacientService.Get();
            return Ok(PacientFromRepo);
        }

        [HttpPost]
        public ActionResult Post([FromBody] PacientDTO pacientDTO)
        {
            _pacientService.Post(pacientDTO);
            return Ok("Paciente Agregado Correctamente!");
        }

        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            var PacientFromRepo = _pacientService.GetById(id);
            return Ok(PacientFromRepo);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(long id)
        {
            _pacientService.DeleteById(id);
            return Ok("Paciente Borrado Correctamente!");
        }

        [HttpPatch("{id}")]
        public ActionResult Update([FromBody] PacientDTO pacientDTO, long id)
        {
            var PacientFromRepo = _pacientService.Update(pacientDTO, id);

            return Ok(PacientFromRepo);
        }
    }
}

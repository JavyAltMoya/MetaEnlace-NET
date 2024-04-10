using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Controllers
{
    [Route("Medico")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMedicService _medicService;

        public MedicController(IUnitOfWork UnitOfWork, IMapper mapper, IMedicService medicService)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
            _medicService = medicService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var MedicFromRepo = _medicService.Get();
            return Ok(MedicFromRepo);
        }

        [HttpPost]
        public ActionResult Post([FromBody] MedicDTO medicDTO)
        {
            _medicService.Post(medicDTO);
            return Ok("Médico Agregado Correctamente!");
        }

        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            var MedicFromRepo = _medicService.GetById(id);
            return Ok(MedicFromRepo);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(long id)
        {
            _medicService.DeleteById(id);
            return Ok("Médico Borrado Correctamente!");
        }

        [HttpPatch("{id}")]
        public ActionResult Update([FromBody] MedicDTO medicDTO, long id)
        {
            var MedicFromRepo = _medicService.Update(medicDTO, id);

            return Ok(MedicFromRepo);
        }
    }
}

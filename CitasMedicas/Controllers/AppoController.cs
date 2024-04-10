using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Controllers
{
    [Route("Cita")]
    [ApiController]
    public class AppoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppoService _appoService;

        public AppoController(IUnitOfWork UnitOfWork, IMapper mapper, IAppoService appoService)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
            _appoService = appoService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var AppoFromRepo = _appoService.Get();
            return Ok(AppoFromRepo);
        }

        [HttpPost]
        public ActionResult Post([FromBody] AppoDTO appoDTO)
        {
            _appoService.Post(appoDTO);
            return Ok("Cita Agregada Correctamente!");
        }

        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            var AppoFromRepo = _appoService.GetById(id);
            return Ok(AppoFromRepo);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(long id)
        {
            _appoService.DeleteById(id);    
            return Ok("Cita Borrada Correctamente!");
        }

        [HttpPatch("{id}")]
        public ActionResult Update([FromBody] AppoDTO appoDTO, long id)
        {
            var AppoFromRepo = _appoService.Update(appoDTO, id);

            return Ok(AppoFromRepo);
        }
    }
}

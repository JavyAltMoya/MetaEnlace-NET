using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Controllers
{
    [Route("Diag")]
    [ApiController]
    public class DiagController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDiagService _diagService;

        public DiagController(IUnitOfWork UnitOfWork, IMapper mapper, IDiagService diagService)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
            _diagService = diagService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var DiagFromRepo = _diagService.Get();
            return Ok(DiagFromRepo);
        }

        [HttpPost]
        public ActionResult Post([FromBody] DiagDTO diagDTO)
        {
            _diagService.Post(diagDTO);
            return Ok("Diagnóstico Agregado Correctamente!");
        }

        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            var DiagFromRepo = _diagService.GetById(id);
            return Ok(DiagFromRepo);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(long id)
        {
            _diagService.DeleteById(id);
            return Ok("Diagnóstico Borrado Correctamente!");
        }

        [HttpPatch("{id}")]
        public ActionResult Update([FromBody] DiagDTO diagDTO, long id)
        {
            var DiagFromRepo = _diagService.Update(diagDTO,id);

            return Ok(DiagFromRepo);
        }
    }
}

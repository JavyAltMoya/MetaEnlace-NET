using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Implements;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Controllers
{
    [Route("Usuario")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IUnitOfWork UnitOfWork, IMapper mapper, IUserService userService) {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var UsersFromRepo = _userService.Get();
            return Ok(UsersFromRepo);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserDTO userDTO) 
        {
            _userService.Post(userDTO);
            return Ok("Usuario Agregado Correctamente!");
        }

        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            var UsersFromRepo = _userService.GetById(id);
            return Ok(UsersFromRepo);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(long id)
        {
            _userService.DeleteById(id);
            return Ok("Usuario Borrado Correctamente!");
        }

        [HttpPatch("{id}")]
        public ActionResult Update([FromBody] UserDTO userDTO, long id)
        {
            var UsersFromRepo = _userService.Update(userDTO, id);

            return Ok(UsersFromRepo);
        }

    }
}

using CitasMedicas.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<UserDTO> Get();

        public void Post([FromBody] UserDTO userDTO);

        public UserDTO GetById(long id);

        public void DeleteById(long id);

        public UserDTO Update([FromBody] UserDTO userDTO, long id);
    }
}

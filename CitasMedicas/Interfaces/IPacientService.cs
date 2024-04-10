using CitasMedicas.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Interfaces
{
    public interface IPacientService
    {
        public IEnumerable<PacientDTO> Get();

        public void Post([FromBody] PacientDTO pacientDTO);

        public PacientDTO GetById(long id);

        public void DeleteById(long id);

        public PacientDTO Update([FromBody] PacientDTO pacientDTO, long id);
    }
}

using CitasMedicas.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Interfaces
{
    public interface IDiagService
    {
        public IEnumerable<DiagDTO> Get();

        public void Post([FromBody] DiagDTO diagDTO);

        public DiagDTO GetById(long id);

        public void DeleteById(long id);

        public DiagDTO Update([FromBody] DiagDTO diagDTO, long id);
    }
}

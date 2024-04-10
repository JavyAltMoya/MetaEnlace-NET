using CitasMedicas.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Interfaces
{
    public interface IAppoService
    {
        public IEnumerable<AppoDTO> Get();

        public void Post([FromBody] AppoDTO appoDTO);

        public AppoDTO GetById(long id);

        public void DeleteById(long id);

        public AppoDTO Update([FromBody] AppoDTO appoDTO, long id);
    }
}

using CitasMedicas.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Interfaces
{
    public interface IMedicService
    {
        public IEnumerable<MedicDTO> Get();

        public void Post([FromBody] MedicDTO medicDTO);

        public MedicDTO GetById(long id);

        public void DeleteById(long id);

        public MedicDTO Update([FromBody] MedicDTO medicDTO, long id);
    }
}

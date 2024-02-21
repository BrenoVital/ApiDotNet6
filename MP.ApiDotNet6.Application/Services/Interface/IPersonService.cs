using MP.ApiDotNet6.Application.DTO;

namespace MP.ApiDotNet6.Application.Services.Interface
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> Create(PersonDTO person); 

        Task<ResultService<PersonDTO>> Update(PersonDTO person);
        Task<ResultService<PersonDTO>> Delete(int id);
        Task<ResultService<PersonDTO>> GetById(int id);
        Task<ResultService<ICollection<PersonDTO>>> GetAll();
    }
}

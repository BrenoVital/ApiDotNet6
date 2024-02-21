
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetById(int id);
        Task<ICollection<Person>> GetAll();
        Task<Person> Create(Person person);
        Task<Person> Update(Person person);
        Task<Person> Delete(Person person);
        Task<int> GetByDocument(string document);

    }
}

using AutoMapper;
using MP.ApiDotNet6.Application.DTO;
using MP.ApiDotNet6.Application.DTO.Validations;
using MP.ApiDotNet6.Application.Services.Interface;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotNet6.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<PersonDTO>> Create(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail<PersonDTO>("Pessoa não pode ser nula");

            var result = new PersonDTOValidator().Validate(personDTO);
            if (!result.IsValid)
                return ResultService.RequestError<PersonDTO>("Problema de validade", result);

            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.Create(person);
            return ResultService.Ok(_mapper.Map<PersonDTO>(data));
        }

        public async Task<ResultService<PersonDTO>> Delete(int id)
        {
            var person = await _personRepository.GetById(id);
            if (person == null)
            {
                return ResultService.Fail<PersonDTO>("Pessoa não encontrada");
            }
            await _personRepository.Delete(person);
            return ResultService.Ok(
                _mapper.Map<PersonDTO>(person)
                );
        }

        public async Task<ResultService<ICollection<PersonDTO>>> GetAll()
        {
            var people = await _personRepository.GetAll();
            return ResultService.Ok(_mapper.Map<ICollection<PersonDTO>>(people));
        }

        public async Task<ResultService<PersonDTO>> GetById(int id)
        {
            var person = await _personRepository.GetById(id);
            if (person == null)
            {
                return ResultService.Fail<PersonDTO>("Pessoa não encontrada");
            }
            return ResultService.Ok(_mapper.Map<PersonDTO>(person));
        }


        public async Task<ResultService<PersonDTO>> Update(PersonDTO person)
        {
            if (person == null)
            {
                return ResultService.Fail<PersonDTO>("Objeto deve ser informado!");
            }

            var validation = new PersonDTOValidator().Validate(person);
            if (!validation.IsValid)
            {
                return ResultService.RequestError<PersonDTO>("Problema com a validação dos campos", validation);
            }

            var result = new PersonDTOValidator().Validate(person);
            if (!result.IsValid)
                return ResultService.RequestError<PersonDTO>("Problema de validade", result);

            var data = await _personRepository.Update(_mapper.Map<Person>(person));
            return ResultService.Ok(_mapper.Map<PersonDTO>(data));
        }

    }
}

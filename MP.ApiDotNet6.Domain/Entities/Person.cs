
using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet6.Domain.Entities

{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }
        public Person(string name, string document, string phone)
        {
            Validation(document, name, phone);
            Purchases = new List<Purchase>();
        }

        public Person(int id, string name, string document, string phone)
        {
            DomainValidationException.When(id < 0, "Id inválido");
            Id = id;
            Validation(document, name, phone);
            Purchases = new List<Purchase>();
        }

        private void Validation(string document, string name, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome é obrigatório");
            DomainValidationException.When(name.Length < 3, "O campo nome precisa ter no mínimo 3 caracteres");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Documento é obrigatório");
            DomainValidationException.When(document.Length < 11, "O campo documento precisa ter no mínimo 11 caracteres");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Telefone é obrigatório");
            DomainValidationException.When(phone.Length < 8, "O campo telefone precisa ter no mínimo 9 caracteres");

            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}

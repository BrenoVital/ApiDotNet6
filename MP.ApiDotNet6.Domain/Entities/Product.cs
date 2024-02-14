
using MP.ApiDotNet6.Domain.Validations;
using System.Numerics;

namespace MP.ApiDotNet6.Domain.Entities

{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }
        public Product(string name, string codErp, decimal price)
        {
            Validation(name, codErp, price);
        }

        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationException.When(id < 0, "Id do produto deve ser informado.");
            Id = id;
            Validation(codErp, name, price);
        }

        private void Validation(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome é obrigatório");
            DomainValidationException.When(name.Length < 3, "O campo nome precisa ter no mínimo 3 caracteres");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "Código ERP é obrigatório");
            DomainValidationException.When(price < 0, "Preço é obrigatório");

            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}

using Cadastro.Domain.Entities;

namespace Cadastro.Domain.Entities
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool Active { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}

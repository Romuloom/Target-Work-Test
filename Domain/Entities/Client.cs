﻿namespace Cadastro.Domain.Entities
{
    public class Client : BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Ative { get; set; }
        public DateTime DataCadastro { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
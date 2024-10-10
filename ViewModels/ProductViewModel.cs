namespace Cadastro.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool Active { get; set; }
        public int? ClientId { get; set; }
        public string ClientName { get; set; }
    }
}

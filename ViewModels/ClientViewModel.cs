using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }
        public bool Ative { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}

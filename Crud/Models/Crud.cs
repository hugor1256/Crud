using System.ComponentModel.DataAnnotations;

namespace Crud.Models
{
    public class Crud
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Informe o CPF")]
        public string Cpf { get; set; }
        
        [Required(ErrorMessage = "Informe a Senha")]
        public string Senha { get; set; }
    }
}
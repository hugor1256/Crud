using System.ComponentModel.DataAnnotations;

namespace Crud.ViewModel;

public class CrudViewModel
{
    public int Id { get; set; }

    [Display(Name = "CPF")]
    [Required(ErrorMessage = "O CPF é Obrigatório")]
    public string Cpf { get; set; }

    [Display(Name = "Senha")]
    [Required(ErrorMessage = "A senha é Obrigatório")]
    public string Senha { get; set; }
}
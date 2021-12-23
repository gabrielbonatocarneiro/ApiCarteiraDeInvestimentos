using System.ComponentModel.DataAnnotations;

namespace CarteiraInvestimentos.Models
{
  public class Acao
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(20, ErrorMessage = "Este campo deve conter no máximo 20 caracteres")]
    public string Codigo { get; set; }
    
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(255, ErrorMessage = "Este campo deve conter no máximo 255 caracteres")]
    public string RazaoSocialEmpresa { get; set; }
  }
}
using System.ComponentModel.DataAnnotations;

namespace CarteiraInvestimentos.Models
{
  public class Operacao
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "Ação inválida")]
    public int AcaoId { get; set; }
    public Acao? Acao { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(1, ErrorMessage = "Este campo deve ter somente 1 caractere")]
    [MinLength(1, ErrorMessage = "Este campo deve ter somente 1 caractere")]
    public string TipoOperacao { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(0.0, Double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O quantidade deve ser maior que zero")]
    public int Quantidade { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public DateTime DataOperacao { get; set; }

    [Range(0.0, Double.MaxValue, ErrorMessage = "O valor total da compra deve ser maior que zero")]
    public decimal ValorTotalOperacao { get; set; }
  }
}
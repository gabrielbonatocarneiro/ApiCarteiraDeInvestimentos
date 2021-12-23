namespace CarteiraInvestimentos.Helpers
{
  public class CalculaTotalOperacao
  {
    public decimal Handle(int qtdAcoes, decimal valorCompraAcao)
    {
      int valorCompraAcaoInt = (int) valorCompraAcao;

      // Custo de corretagem de compra (R$ 5,00 por operação) + Emolumentos (R$ 0,0325% do valor da operação).
      var emolumentos = System.Convert.ToDecimal((0.0325 * valorCompraAcaoInt) / valorCompraAcaoInt);

      var custoCorretagem = 5.00M + Math.Round(emolumentos, 2);

      // Cálculo Total Operacao -> ((quantidade de ações * valor de compra) + custos da operação)
      return ((qtdAcoes * valorCompraAcao) + custoCorretagem);
    }
  }
}

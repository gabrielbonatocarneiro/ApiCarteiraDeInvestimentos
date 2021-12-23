namespace CarteiraInvestimentos.Services
{
    public class YahooFinanceService
    {
      public async Task<String> GetCotacao(string codigoAcao)
      {
        // Exemplo código ação: BOVA11.SA, VALE3.SA, PETR4.SA...
        HttpClient client = new HttpClient { BaseAddress = new Uri(
          "https://query1.finance.yahoo.com/v8/finance/chart/" + codigoAcao + "?" + 
          "region=US&" +
          "lang=en-US&" +
          "includePrePost=false&" +
          "interval=2m&" +
          "useYfid=true&" +
          "range=1d&" +
          "corsDomain=finance.yahoo.com&" +
          ".tsrc=finance")};

        var response = await client.GetAsync("");
        var content = await response.Content.ReadAsStringAsync();

        return content;
      }
    }
}

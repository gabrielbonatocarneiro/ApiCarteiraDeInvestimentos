using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CarteiraInvestimentos.Dtos;

namespace CarteiraInvestimentos.Adapters
{
    public class YahooFinanceAdapter
    {
      public CotacaoAcaoYahooFinanceDto Handle(string content)
      {
        JObject parsedObject = JObject.Parse(content);

        var cotacao = (JObject)JsonConvert.DeserializeObject(parsedObject["chart"]["result"][0]["meta"].ToString());
        cotacao.Property("currentTradingPeriod").Remove();
        cotacao.Property("validRanges").Remove();

        var cotacaoDto = JsonConvert.DeserializeObject<CotacaoAcaoYahooFinanceDto>(cotacao.ToString());

        return cotacaoDto;
      }
    }
}

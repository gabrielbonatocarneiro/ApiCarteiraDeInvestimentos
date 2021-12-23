using Microsoft.AspNetCore.Mvc;
using CarteiraInvestimentos.Dtos;
using CarteiraInvestimentos.Services;
using CarteiraInvestimentos.Adapters;

namespace CarteiraInvestimentos.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CotacaoAcaoController : ControllerBase
  {
    /// <summary>
    /// Pesquisa cotação da ação no Yahoo Finance. Exemplo código ação: BOVA11.SA, VALE3.SA, PETR4.SA...
    /// </summary>    
    [HttpGet]
    [Route("yahoo-finance/{codigoAcao}")]
    public async Task<ActionResult<CotacaoAcaoYahooFinanceDto>> GetCotacaoYahooFinance(string codigoAcao)
    {
      try
      {
        var resultCotacaoYahooFinance = await new YahooFinanceService().GetCotacao(codigoAcao);

        return new YahooFinanceAdapter().Handle(resultCotacaoYahooFinance);
      }
      catch (Exception)
      {
        return BadRequest("Não foi possível obter a ação.");
      }
    }
  }
}
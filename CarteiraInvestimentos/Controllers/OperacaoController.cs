using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarteiraInvestimentos.Data;
using CarteiraInvestimentos.Models;
using CarteiraInvestimentos.Helpers;

namespace CarteiraInvestimentos.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class OperacaoController : ControllerBase
  {
    /// <summary>
    /// Pesquisa as Operações
    /// </summary>
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Operacao>>> GetOperacoes([FromServices] DataContext context)
    {
      return await context.Operacao.Include(x => x.Acao).ToListAsync();
    }

    /// <summary>
    /// Relatório das operação de uma ação
    /// </summary>
    [HttpGet]
    [Route("relatorio/{codigoAcao}")]
    public async Task<ActionResult<Operacao>> GetOperacaoByCodigoAcao([FromServices] DataContext context, string codigoAcao)
    {
      var operacao = await context.Operacao.Include(x => x.Acao)
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Acao.Codigo == codigoAcao);

      if (operacao is null)
      {
        return NotFound("Não foi possível encontrar a operação.");
      }

      return operacao;
    }

    /// <summary>
    /// Registro de compra de uma ação - Tipo operação C
    /// </summary>
    [HttpPost]
    [Route("/compra")]
    public async Task<ActionResult<Operacao>> PostOperacaoCompra(
      [FromServices] DataContext context,
      [FromBody] Operacao model)
    {
      if (ModelState.IsValid && model.TipoOperacao == "C")
      {
        var valorTotal = new CalculaTotalOperacao().Handle(model.Quantidade, model.Preco);
        
        model.ValorTotalOperacao = valorTotal;

        context.Operacao.Add(model);
        await context.SaveChangesAsync();
        
        return model;
      }

      
      return BadRequest("Não foi possível registrar a compra dessa ação. Fovor verificar os campos preenchidos.");
    }

    /// <summary>
    /// Registro de venda de uma ação - Tipo operação V
    /// </summary>
    [HttpPost]
    [Route("/venda")]
    public async Task<ActionResult<Operacao>> PostOperacaoVenda(
      [FromServices] DataContext context,
      [FromBody] Operacao model)
    {
      if (ModelState.IsValid && model.TipoOperacao == "V")
      {
        var valorTotal = new CalculaTotalOperacao().Handle(model.Quantidade, model.Preco);

        model.ValorTotalOperacao = valorTotal;

        context.Operacao.Add(model);
        await context.SaveChangesAsync();
        
        return model;
      }

      return BadRequest("Não foi possível registrar a venda dessa ação. Fovor verificar os campos preenchidos.");
    }
  }
}
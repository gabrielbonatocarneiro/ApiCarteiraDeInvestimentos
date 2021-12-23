using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarteiraInvestimentos.Data;
using CarteiraInvestimentos.Models;

namespace CarteiraInvestimentos.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AcaoController : ControllerBase
  {
    /// <summary>
    /// Pesquisa as ações
    /// </summary>
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Acao>>> Get([FromServices] DataContext context)
    {
      return await context.Acao.ToListAsync();
    }

    /// <summary>
    /// Pesquisa uma ação especifica
    /// </summary>
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Acao>> GetById([FromServices] DataContext context, int id)
    {
      var acao = await context.Acao.FindAsync(id);

      if (acao is null)
      {
        return NotFound("Não foi possível encontrar a ação.");
      }

      return acao;
    }

    /// <summary>
    /// Cria uma ação
    /// </summary>
    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Acao>> Post(
      [FromServices] DataContext context,
      [FromBody] Acao model)
    {
      if (ModelState.IsValid)
      {
        context.Acao.Add(model);
        await context.SaveChangesAsync();
        
        return model;
      }

      return BadRequest("Não foi possível cadastrar essa ação. Favor verificar os campos preenchidos.");
    }

    /// <summary>
    /// Atualiza uma ação
    /// </summary>
    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Acao>> Put (
      [FromServices] DataContext context,
      [FromBody] Acao model,
      int id)
    {
      if (ModelState.IsValid)
      {
        context.Entry(model).State = EntityState.Modified;

        try
        {
          await context.SaveChangesAsync();

          return CreatedAtAction("GetById", new { id = model.Id }, model);
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!AcaoExists(id, context))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
      }

      return BadRequest("Não foi possível atualizar essa ação. Favor verificar os campos preenchidos.");
    }

    /// <summary>
    /// Deleta uma ação
    /// </summary>
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<String>> Delete ([FromServices] DataContext context, int id)
    {
      var acao = await context.Acao.FindAsync(id);

      if (acao is null)
      {
        return NotFound("Não foi possível encontrar a ação para realizar a remoção dela.");
      }

      context.Acao.Remove(acao);
      await context.SaveChangesAsync();

      return "Ação removida com sucesso";
    }

    private bool AcaoExists(int id, [FromServices] DataContext context)
    {
      return context.Acao.Any(e => e.Id == id);
    }
  }
}
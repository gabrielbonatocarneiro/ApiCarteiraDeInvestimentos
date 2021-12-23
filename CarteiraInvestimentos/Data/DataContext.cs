using Microsoft.EntityFrameworkCore;
using CarteiraInvestimentos.Models;

namespace CarteiraInvestimentos.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options)
      : base(options)
    {
    }

    public DbSet<Acao> Acao { get; set; }

    public DbSet<Operacao> Operacao { get; set; }
  }
}
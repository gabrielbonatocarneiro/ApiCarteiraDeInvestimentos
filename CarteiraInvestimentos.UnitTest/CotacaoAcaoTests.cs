using Xunit;
using CarteiraInvestimentos.Adapters;
using CarteiraInvestimentos.Services;
using CarteiraInvestimentos.Dtos;

namespace CarteiraInvestimentos.UnitTest
{
    public class CotacaoAcaoTests
    {
        [Fact]
        public async void DeveEntrarCotacaoAcao()
        {
            try
            {
                var resultCotacaoYahooFinance = await new YahooFinanceService().GetCotacao("BOVA11.SA");

                Assert.True(true);
            }
            catch (System.Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async void NaoDeveEntrarCotacaoAcao()

        {
            try
            {
                var resultCotacaoYahooFinance = await new YahooFinanceService().GetCotacao("BOVA12.SA");

                Assert.True(false);
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async void DeveEntrarEFormatarCotacaoAcao()
        {
            try
            {
                var resultCotacaoYahooFinance = await new YahooFinanceService().GetCotacao("BOVA11.SA");

                CotacaoAcaoYahooFinanceDto cotacao = new YahooFinanceAdapter().Handle(resultCotacaoYahooFinance);

                if (cotacao != null)
                {
                    Assert.True(false);
                }
            }
            catch (System.Exception)
            {
                Assert.True(false);
            }
        }
    }
}
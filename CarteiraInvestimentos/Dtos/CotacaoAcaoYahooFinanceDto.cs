namespace CarteiraInvestimentos.Dtos
{
    public class CotacaoAcaoYahooFinanceDto
    {
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public string ExchangeName { get; set; }
        public string InstrumentType { get; set; }
        public long FirstTradeDate { get; set; }
        public long RegularMarketTime { get; set; }
        public long Gmtoffset { get; set; }
        public string Timezone { get; set; }
        public string ExchangeTimezoneName { get; set; }
        public double RegularMarketPrice { get; set; }
        public double ChartPreviousClose { get; set; }
        public double PreviousClose { get; set; }
        public long Scale { get; set; }
        public long PriceHint { get; set; }
        public string DataGranularity { get; set; }
        public string Range { get; set; }
    }
}

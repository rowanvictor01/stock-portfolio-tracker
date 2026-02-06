using ThreeFourteen.Finnhub.Client;
using ThreeFourteen.Finnhub.Client.Model;

namespace StockPortfolioTracker.Client;

static class Client {
    static private string _apiKey = "d62qvqhr01qnpu82c0t0d62qvqhr01qnpu82c0tg";
    static private FinnhubClient _client = new FinnhubClient(_apiKey);

    static async Task<Symbol[]> SymbolLookupAsync(string symbol)
    {
        Symbol[] symbols = new Symbol[symbol.Length];
        
        try
        {
            symbols = await _client.Stock.GetSymbols(symbol);
        }
        catch (FinnhubException e)
        {
            // handle errors
        }

        return symbols;
    }

    static async Task<Dictionary<string, Quote>> GetQuotesAsync(string[] symbols)
    {
        Dictionary<string, Quote> quotes = new Dictionary<string, Quote>();

        foreach (string symbol in symbols)
        {
            try
            {
                var quote = await _client.Stock.GetQuote(symbol);
                quotes.Add(symbol, quote);
            }
            catch (FinnhubException e)
            {
                // handle errors
            }
        }

        return quotes;
    }
}

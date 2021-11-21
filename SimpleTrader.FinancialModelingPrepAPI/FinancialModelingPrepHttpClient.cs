using Newtonsoft.Json;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    internal class FinancialModelingPrepHttpClient : HttpClient
    {
        public FinancialModelingPrepHttpClient()
        {
            BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/");
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await GetAsync($"{endpoint}?apikey=86f94ff6a84a7fa0f964a8a2548269ed");
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(content)!;
            return result;
        }
    }
}

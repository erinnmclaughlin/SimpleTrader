using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            var uri = "majors-indexes/" + GetUriEndpoint(indexType);
            using var client = new FinancialModelingPrepHttpClient();

            var index = await client.GetAsync<MajorIndex>(uri);
            index.Type = indexType;
            
            return index;
        }

        private static string GetUriEndpoint(MajorIndexType indexType)
        {
            return indexType switch
            {
                MajorIndexType.DowJones => ".DJI",
                MajorIndexType.Nasdaq => ".IXIC",
                MajorIndexType.SP500 => ".INX",
                _ => throw new NotSupportedException("Index not supported")
            };
        }
    }
}
 
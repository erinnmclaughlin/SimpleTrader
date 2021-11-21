using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services
{
    public interface IMajorIndexService
    {
        Task<MajorIndex> GetMajorIndex(MajorIndexType indexType);
    }
}

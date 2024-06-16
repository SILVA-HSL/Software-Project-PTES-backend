using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;

namespace TicketMate.Reporting.Application.ReportingService
{
    public class PredictionCacheService: IPredictionCacheService
    {
        private const string CacheKey = "BusPredictions";
        private List<BusPredictionOutputDTO> _cache;
        private DateTime _cacheTime;

        private readonly TimeSpan _cacheDuration = TimeSpan.FromDays(1);

        public bool IsCacheValid()
        {
            return _cache != null && (DateTime.Now - _cacheTime) < _cacheDuration;
        }

        public Task<List<BusPredictionOutputDTO>> GetPredictionsAsync()
        {
            return Task.FromResult(_cache);
        }

        public Task SetPredictionsAsync(List<BusPredictionOutputDTO> predictions)
        {
            _cache = predictions;
            _cacheTime = DateTime.Now;
            return Task.CompletedTask;
        }

        //    private List<BusPredictionOutputDTO> _cache = new List<BusPredictionOutputDTO>(); // Initialize to an empty list
        //    private DateTime _lastCacheTime;

        //    public async Task<List<BusPredictionOutputDTO>> GetPredictionsAsync()
        //    {
        //        return await Task.FromResult(_cache);
        //    }

        //    public async Task SetPredictionsAsync(List<BusPredictionOutputDTO> predictions)
        //    {
        //        _cache = predictions;
        //        _lastCacheTime = DateTime.Now;
        //        await Task.CompletedTask;
        //    }

        //    public bool IsCacheValid()
        //    {
        //        return _cache != null && (DateTime.Now - _lastCacheTime).TotalDays < 1;
        //    }
    }
}

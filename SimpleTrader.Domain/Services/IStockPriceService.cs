﻿namespace SimpleTrader.Domain.Services
{
    public interface IStockPriceService
    {
        Task<double> GetPrice(string symbol);
    }
}

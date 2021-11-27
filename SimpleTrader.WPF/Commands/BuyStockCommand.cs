using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    internal class BuyStockCommand : ICommand
    {
        private readonly BuyViewModel _viewModel;
        private readonly IBuyStockService _buyStockService;

        public event EventHandler? CanExecuteChanged;

        public BuyStockCommand(BuyViewModel viewModel, IBuyStockService buyStockService)
        {
            _viewModel = viewModel;
            _buyStockService = buyStockService;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                await _buyStockService.BuyStock(new Account
                {
                    Id = Guid.NewGuid(),
                    Balance = 500,
                    AssetTransactions = new List<AssetTransaction>()
                }, _viewModel.Symbol!, _viewModel.SharesToBuy);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

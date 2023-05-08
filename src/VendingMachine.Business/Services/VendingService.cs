using VendingMachine.Business.Models;
using VendingMachine.Business.Repository;
using Microsoft.EntityFrameworkCore;

namespace VendingMachine.Business.Services
{
    public class VendingService : IVendingService
    {
        private readonly IVendingMachineRepository _repo;
        public VendingService(IVendingMachineRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Product>> GetProductInventory()
        {
            var items = _repo.GetProducts();
            return await items;
        }

        public async Task<Product?> GetProductInventoryById(int productId)
        {
            var item = _repo.GetProductById(productId);
            return await item;
        }

        public async Task<Transaction?> GetTransactionById(int id)
        {
            var transaction = _repo.GetTransactionById(id);
            return await transaction;
        }

        public async Task<List<Transaction>> GetTransactions()
        {
            var transactions = _repo.GetTransactions();
            return await transactions;
        }

        public async Task<Transaction> Purchase(Transaction transaction)
        {            
            return await _repo.AddTransactionToLedger(transaction);
        }

        public async Task<bool> VoidTransaction(int id)
        {
            return await _repo.VoidTransactionFromLedger(id);
        }
    }
}
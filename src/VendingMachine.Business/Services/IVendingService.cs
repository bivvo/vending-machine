using VendingMachine.Business.Models;
using VendingMachine.Business.Repository;

namespace VendingMachine.Business.Services
{
    public interface IVendingService
    {
        public Task<List<Product>> GetProductInventory();
        public Task<Product?> GetProductInventoryById(int productId);
        Task<List<Transaction>> GetTransactions();
        Task<Transaction?> GetTransactionById(int id);
        public Task<Transaction> Purchase(Transaction transaction);
        public Task<bool> VoidTransaction(int transactionId);


    }
}
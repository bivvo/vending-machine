using VendingMachine.Business.Models;

namespace VendingMachine.Business.Repository
{
    public interface IVendingMachineRepository
    {
        Task<Transaction> AddTransactionToLedger(Transaction transaction);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
        Task<Transaction> GetTransactionById(int id);
        Task<List<Transaction>> GetTransactions();
        Task<bool> VoidTransactionFromLedger(int transactionId);
    }
}
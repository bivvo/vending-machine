using VendingMachine.Business.Models;

namespace VendingMachine.Business.Repository
{

    public class VendingMachineRepository : IVendingMachineRepository
    {
        private RepositoryLedger _repoLedger;
        private List<Product> _repoProducts;

        public VendingMachineRepository()
        {
            this._repoLedger = new RepositoryLedger();
            this._repoLedger.Transactions = IntialTransactions();
            this._repoProducts = InitalProducts();
        }

        public async Task<List<Transaction>> GetTransactions()
            => _repoLedger.Transactions;

        public async Task<Transaction> GetTransactionById(int id)
            => _repoLedger.Transactions.FirstOrDefault(w => w.Id == id);

        public async Task<List<Product>> GetProducts()
            => _repoProducts;

        public async Task<Product> GetProductById(int id)
            => _repoProducts.FirstOrDefault(w => w.Id == id);

        public async Task<Transaction> AddTransactionToLedger(Transaction transaction)
        {
            transaction.Id = _repoLedger.Transactions.Last().Id + 1;
            transaction.AmountPaid = transaction.Products.Sum(s => s.Price * s.Quantity);
            _repoLedger.Transactions.Add(transaction);
            return transaction;
        }

        public async Task<bool> VoidTransactionFromLedger(int transactionId)
        {
            int index = _repoLedger.Transactions.FindIndex(f => f.Id == transactionId);
            if (index == -1)
                return false;
            else
                _repoLedger.Transactions.RemoveAt(index);
            return true;
            
        }


        private List<Product> InitalProducts()
        {
            var products = new List<Product>();
            products.Add(new Product(1, "Soda", 0.95m, 100));
            products.Add(new Product(2, "Chips", 0.99m, 100));
            products.Add(new Product(3, "Candy Bar", 0.60m, 100));
            return products;
        }

        private List<Transaction> IntialTransactions() 
        {
            return new List<Transaction>() {
                new Transaction(){
                    Id = 1,
                    AmountPaid = 0.95m,
                    Products = new List<Product>(){
                        new Product(1, "Soda", 0.95m, 1)
                    }
                }
            };
        }


    }
}
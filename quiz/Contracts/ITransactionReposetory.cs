using quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz.Contracts
{
    public interface ITransactionReposetory
    {
        public bool create(Transaction t);
        public List<Transaction> GetAll();
        public List<Transaction> GetAllReports(string cardnum);
        public Transaction GetById(int id);
        public bool update(Transaction t);
        public bool delete(int id);
    }
}

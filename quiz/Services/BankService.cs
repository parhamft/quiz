using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using quiz.Entities;
using quiz.Contracts;
using quiz.reposetories;
using System.Runtime.InteropServices;

namespace quiz.Services
{
    public class BankService
    {
        ITransactionReposetory trepo= new TransactionReposetory();
        ICardReposetory crepo= new CardReposetory();
        public string transfer(Card cs, string DestinationCardNumber, float Amount)
        {
            float total = 0;
            foreach(Transaction trans in trepo.GetAllReports(cs.CardNumber))
            {
                if (DateOnly.FromDateTime(trans.TransferDate)==DateOnly.FromDateTime(DateTime.Now))
                {
                    if (trans.SourceCardNumber == cs.CardNumber) { total += trans.Amount; }
                }
                

            }
            total += Amount;    
            if (total > 250) { throw new Exception("you can no longer transfer any money for today");  }


            Card dc = crepo.GetById(DestinationCardNumber);
            if (dc == null) { return "Destination Card does not exist"; }
            if (cs.Balance<Amount) { return "not enough balance"; }
            cs.Balance = cs.Balance - Amount;
            dc.Balance=dc.Balance + Amount;
            if(crepo.update(dc)==false) { return "something went Wrong"; }
            if (crepo.update(cs)==false) { return "something went Wrong"; }
            Transaction t = new Transaction(cs.CardNumber, DestinationCardNumber, Amount, DateTime.Now, true);
            if (trepo.create(t)==false) { return "something went Wrong"; }
            return "transaction compeleted";
        }
        public List<Transaction> Reports(string cardnum)
        {
            if (crepo.GetById(cardnum) == null) { throw new Exception("that card does not exist"); }
            return trepo.GetAllReports(cardnum);

        }
    }
}

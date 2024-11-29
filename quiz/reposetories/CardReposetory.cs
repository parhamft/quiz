using quiz.Contracts;
using quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz.reposetories
{
    public class CardReposetory : ICardReposetory
    {
        BankDBContext _dbContext = new BankDBContext();

        public bool create(Card c)
        {
            _dbContext.Cards.Add(c);
            _dbContext.SaveChanges();
            return true;
        }

        public bool delete(string num)
        {
            Card c=_dbContext.Cards.FirstOrDefault(x=>x.CardNumber==num);
            if (c==null) return false;
            _dbContext.Cards.Remove(c);
            _dbContext.SaveChanges();
            return true;

        }

        public bool delete(int num)
        {
            throw new NotImplementedException();
        }

        public List<Card> GetAll()
        {
            return _dbContext.Cards.ToList();
        }

        public Card GetById(string id)
        {
            return _dbContext.Cards.FirstOrDefault(x => x.CardNumber == id);
        }


        public bool update(Card c)
        {
            _dbContext.Cards.Update(c);
            _dbContext.SaveChanges();
            return true;

        }
    }
}

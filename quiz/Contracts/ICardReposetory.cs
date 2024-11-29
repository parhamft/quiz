using quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz.Contracts
{
    public interface ICardReposetory
    {
        public bool create(Card c);
        public List<Card> GetAll();
        public Card GetById(string id);
        public bool update(Card c);
        public bool delete(string num);

    }
}

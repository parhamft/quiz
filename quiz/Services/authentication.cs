using quiz.Contracts;
using quiz.Entities;
using quiz.reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace quiz.Services
{
    public class authentication
    {
        ICardReposetory CRepo= new CardReposetory();
        public Card Login(string cardnum,string password)
        {
             Card c= CRepo.GetById(cardnum);

            if (c==null ) { throw new Exception("card number is incorrect"); }
            if (c.IsActive==false) { throw new Exception("card is no longer activce"); }
            if (c.Password != password) { 
                c.tries += 1;
                CRepo.update(c);
                if (c.tries==3) { c.IsActive = false; CRepo.update(c); throw new Exception("password is incorrect! card has been deactivated"); }
                throw new Exception("password is incorrect"); 
            }
            return c;


        }
    }
}

using quiz.Contracts;
using quiz.Entities;
using quiz.reposetories;
using quiz.Services;

authentication auth = new authentication();
BankService Service = new BankService();


bool end = false;
bool stop = false;

while (end == false)
{
    try
    {
        int options = 0;
        Console.Clear();
        Console.WriteLine("1- Login");
        Console.WriteLine("3- Exit");
        options = Convert.ToInt32(Console.ReadLine());
        switch (options)
        {
            case 1:
                Console.Clear();
                Console.Write("please enter your cards number : ");
                string cardnum = Console.ReadLine();
                if (cardnum.Length!=16) { throw new Exception("something is wrong"); }
                Console.Write("please enter your password : ");
                string password = Console.ReadLine();
                var acc = auth.Login(cardnum, password);
                if (acc == null) { throw new Exception("User does not exist"); }      
                
                CardMenu(acc);

                Console.ReadKey();
                break;

            case 2:
                Console.Clear();
                end = true;
                Console.ReadKey();
                break;

        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
    }

}



void CardMenu(Card c)
{
    stop = false;
    while (stop == false)
    {
        try
        {


            int option = 0;
            Console.Clear();
            Console.WriteLine("1- transfer");
            Console.WriteLine("2- show reports");
            Console.WriteLine("3- show balance");
            Console.WriteLine("5- Exit");

            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Clear();
                    Console.Clear();

                    Console.Write("please enter the receivers cards number : ");
                    string reccardnum = Console.ReadLine();
                    if (reccardnum.Length != 16 ) { throw new Exception("something is wrong"); }
                    Console.Write("please enter the amount : ");
                    float amount = float.Parse(Console.ReadLine());
                    if (amount <=0) { }
                    Console.WriteLine(Service.transfer(c,reccardnum,amount));

                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();

                    List<Transaction> tranlist=Service.Reports(c.CardNumber);
                    foreach (Transaction t in tranlist) { Console.WriteLine($"{t.Id}) {t.SourceCardNumber} => {t.DestinationCardNumber}-     |{t.TransferDate}    {t.Amount}$ |"); }
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine($"{c.HolderName} ({c.CardNumber})\n Balance={c.Balance}$");
                    Console.ReadKey();
                    break;
                default:

                    Console.WriteLine("idont know what you are saying");
                    break;

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }
}
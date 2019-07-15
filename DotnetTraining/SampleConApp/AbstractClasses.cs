using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Abstract classes are those classes that have atleast one abstract method in it. 
 * A method that is created with no body but is expected to be implemented by its derived classes is abstract method.
 * abstract keyword must be set to the method as well as the class that contain such methods. 
 * Abstract classes are incomplete classes, as one or more methods are not implemented, so U cannot use the class, in other words, it cannot be instantiated. however, U could instantiate the object of the abstract class to the derived class and call its methods as long as the derived class implements all the abstract methods in it. 
 */
namespace SampleConApp
{
    enum AccountType { SB, RD };
    abstract class Account
    {
        public int AccountNo { get; set; }
        public string CustomerName { get; set; }
        public int Balance { get; private set; } = 5000;
        public void Credit(int amount) => Balance += amount;
        public void Debit(int amount)
        {
            if (amount > Balance)
                throw new Exception("Insufficient funds");
            Balance -= amount;
        }
        public abstract void CalculateInterest();
    }

    class SBAccount : Account
    {
        //override is applied on those methods that are marked as abstract in its base
        public override void CalculateInterest()
        {
            var amount = Balance * 1 / 12 * 6.5 / 100;
            Credit((int)amount);
        }
    }

    class RDAccount: Account
    {
        //Term is 5 years, Interest is 7.5%...
        public override void CalculateInterest()
        {
            throw new NotImplementedException("Do it in the assignment");
        }
    }

    static class AccountFactory
    {
        public static Account CreateAccount(AccountType type)
        {
            switch (type)
            {
                case AccountType.SB:
                    return new SBAccount();
                case AccountType.RD:
                    return new RDAccount();
            }
            throw new Exception("Invalid Account Type");
        }
    }
    class AbstractClasses
    {
        static void Main(string[] args)
        {
            try
            {
                Account acc = AccountFactory.CreateAccount(AccountType.RD);
                acc.AccountNo = 111;
                acc.CustomerName = "Phaniraj";
                acc.Credit(5000);
                acc.Debit(400);
                acc.CalculateInterest();
                Console.WriteLine("The current balance:" + acc.Balance);
                acc.Debit(234456);
                Console.WriteLine("The current balance:" + acc.Balance);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

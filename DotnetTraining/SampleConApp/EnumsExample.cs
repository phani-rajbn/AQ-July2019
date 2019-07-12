using System;

namespace SampleConApp
{
    //Enums are named constants used to represent a intergral number as a const name.

    enum AccountType
    {
        SBAccount, RDAccount, FDAccount, CreditCard
    }
    class EnumsExample
    {
        static void Main()
        {
            AccountType acc = AccountType.FDAccount;
            Console.WriteLine("The Account selected:" + acc);
            Console.WriteLine("The integral value is " + (int)acc);
            //Extract all the possible values from an Enum....
            Array enumValues = Enum.GetValues(typeof(AccountType));
            foreach (object value in enumValues) Console.WriteLine(value);
            Console.WriteLine("Type one from the list above");
            acc = (AccountType)Enum.Parse(typeof(AccountType), Console.ReadLine(),true);
            Console.WriteLine("The selected Account is " + acc);
           

        }
    }
}

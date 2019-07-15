using System;

//method overriding is a feature that allows a method of the base class be modifyable in the derived class. IN this case, the base class should allow the developers to modify its functions by using a modifier called virtual. 
//The derived classes will modify those virtual functions using modifier called override. Only methods that are declared as virtual or override in their base classes can be overriden in the derived classes. 
//Method overriding leads to Runtime Polymorphism where the base class object when instantiated to the derived class will behave like derived class object when it accesses the overriden methods....
namespace SampleConApp
{
    enum PaymentMode {  Cash, Paytm, UPI };
    class TeaBusiness
    {

        public void MakePayment(int amount)
        {
            Console.WriteLine("Payment made thro Cheque for {0:C}", amount);
        }
        public virtual void TakePayment(int amount, PaymentMode mode)
        {
            switch (mode)
            {
                case PaymentMode.Cash:
                case PaymentMode.Paytm:
                    Console.WriteLine($"Payment of {amount:C} recieved thro {mode}");
                    break;
                case PaymentMode.UPI:
                    Console.WriteLine("Payment not acceptable");
                    break;
            }
        }
    }

    class NewTeaBusiness : TeaBusiness
    {
        public override void TakePayment(int amount, PaymentMode mode)
        {
            switch (mode)
            {
                case PaymentMode.Cash:
                   
                case PaymentMode.Paytm:
                   
                case PaymentMode.UPI:
                    Console.WriteLine($"Payment of {amount:C} recieved thro {mode}");
                    break;
                
            }
        }

        public new void MakePayment(int amount)
        {
            Console.WriteLine("Payment of {0:C} is made by CC", amount);
        }
    }
    class MethodOverriding
    {
        static void Main(string[] args)
        {
            TeaBusiness tea = new TeaBusiness();
            tea.TakePayment(10, PaymentMode.Cash);
            tea.TakePayment(10, PaymentMode.Paytm);
            tea.TakePayment(10, PaymentMode.Paytm);
            tea.TakePayment(10, PaymentMode.Cash);
            tea.TakePayment(10, PaymentMode.UPI);
            tea.MakePayment(65000);
            tea = new NewTeaBusiness();
            tea.TakePayment(10, PaymentMode.Cash);
            tea.TakePayment(10, PaymentMode.Paytm);
            tea.TakePayment(10, PaymentMode.Paytm);
            tea.TakePayment(10, PaymentMode.Cash);
            tea.TakePayment(10, PaymentMode.UPI);
            if(tea is NewTeaBusiness)
            {
                var temp = tea as NewTeaBusiness;
                temp.MakePayment(5600);
            }
            
        }
    }
}

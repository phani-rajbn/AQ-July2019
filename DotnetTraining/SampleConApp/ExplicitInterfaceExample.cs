using System;

namespace SampleConApp
{
    interface IExample
    {
        void Create();
    }
    interface ISimple
    {
        void Create();
    }
    class SimpleExample : IExample, ISimple
    {
        public void Create()//No change in the signature of the method...
        {
            Console.WriteLine("Example implemented in Example class");
        }

        void IExample.Create()
        {
            Console.WriteLine("Create method for IExample");    
        }

        void ISimple.Create() => Console.WriteLine("Create method for ISimple");
    }
    class ExplicitInterfaceExample
    {
        static void Main(string[] args)
        {
            IExample ex = new SimpleExample();
            ex.Create();

            ISimple sim = new SimpleExample();
            sim.Create();

            SimpleExample exSim = new SimpleExample();
            exSim.Create();
        }
    }
}

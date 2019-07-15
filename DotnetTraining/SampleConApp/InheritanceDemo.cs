using System;

//Inheritance is a way of reusing existing classes either by providing additional functionalities or modifying the existing functionalities. 
//based in Open-Closed Principle. A Class is closed for Modification but is OPEN for Extension. 
//Classes created as Immutable(Not changable). U can however extend the class, and implement UR new requirements in the new class and retain the older functionalities as it is. 
//Inheritance in C# is single Inheritance. UR class can have only one base class at any level.
//There is no private or public inheritance in C#, U have simply inheritance where all the members of the base class retain their accessibility in the derived classes. private will not at all be accessible in the derived  classes. 

namespace SampleConApp
{
    class BaseClass
    {
        public void SetValue(int value) => Value = value;
        public int Value { get; protected set; }//available for derived classes also
        public void BaseFunc() => Console.WriteLine("Base Func in the base class");
    }

    //Syntax of Inheritance in C#.....
    class DerivedClass : BaseClass
    {
        public void DisplayValue() => Console.WriteLine("Value:" + Value);
        public void DerivedFunc() => Console.WriteLine("Derived Func in Derived class");
    }
    class InheritanceDemo
    {
        static void Main(string[] args)
        {
            BaseClass cls = new BaseClass();
            cls.SetValue(555);
            cls.BaseFunc();
            //DerivedClass cls2 = new DerivedClass();
            //cls2.BaseFunc();
            //cls2.DerivedFunc();

            //Base type variable is instantaited to the derived type..

            cls = new DerivedClass();
            cls.SetValue(555);
            cls.BaseFunc();
            Console.WriteLine(cls.GetHashCode());
            //New methods of the derived are inaccessible to the base type. 
            //If the base type is instantaited to the derived type, then U could type cast it to the derived type and then invoke its methods...
            //There is no new object creation, it is just a reference(Alias)....
            if (cls is DerivedClass)
            {
                DerivedClass alias = cls as DerivedClass;
                alias.DerivedFunc();
                alias.DisplayValue();
                Console.WriteLine(alias.GetHashCode());
            };


        }
    }
}

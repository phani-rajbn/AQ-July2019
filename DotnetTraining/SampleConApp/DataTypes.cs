using System;
namespace SampleConApp
{
    /*
     * Value Types:
     * Integral: byte(Byte), short(Int16), int(Int32), long(Int64)
     * Floating: float(Single), double(Double), decimal(Decimal)
     * Other types: char(Char), bool(Boolean)
     * UDTs: structs and Enums
     * .NET itself gives smaller types like DateTime as structs. A
     * All Value types are structs... 
     * Every value type is a struct, struct has some basic functions. 
     * Parse is a function of all Value types to convert string to its type.
     * Data conversions are possible in C# if the conversion guarantees that there is no loss of data while the conversion happens. Larger range variables can hold smaller range values, but the reverse is not possible implicitly. U could however typecast(Explicit) the variable to the other type, there by impliing that U R aware of the possible loss of the data. 
     */
    class DataTypesExample
    {
        static void Main(string[] args)
        {
            //simpleInputsExample();
            //typeConversionExample();
            //objectConversion();
            convertExample();
        }

        private static void convertExample()
        {
            int value = 234;
            long longValue = value;//Implicit....
            longValue += int.MaxValue;
            checked
            {
                value = (int)longValue;//Casting is unsafe, it does not guarantee the safe conversion if the range does not match....However, U could use the check Option which ensures that unsafe casting is throwing an Exception instead of giving abnormal results...
            }
            
            //value = Convert.ToInt32(longValue);
            Console.WriteLine("Value:" + value);
        }

        //3rd Example
        private static void objectConversion()
        {
            //object is the base type for all kinds of data. 
            object anything = 123;
            int temp = (int)anything;
            temp += 234;
            anything = temp;
            Console.WriteLine(anything);
            anything = "Apple123";
            Console.WriteLine(anything);
            anything = DateTime.Now;
            Console.WriteLine(anything);
            //Assigning an object variable with a value of any datatype is called as BOXING. BOXING is Implicit. 
            DateTime copy = (DateTime)anything;//UNBOXING is explicit. Unboxing can be done to that type from which it was boxed. 
            copy = copy.AddMonths(34);
            anything = copy;
            Console.WriteLine(anything);
            int years = ((DateTime)anything).Year;
            Console.WriteLine("YEar:" + years);
        }

        //2nd Example
        private static void typeConversionExample()
        {
            Console.WriteLine("Enter a number");
            double no = double.Parse(Console.ReadLine());

            int smallInt = (int)no;//Use C style casting to convert from one value type to another...
            Console.WriteLine(smallInt);
        }
        //FirstExample
        private static void simpleInputsExample()
        {
            Console.WriteLine("Enter value1");
            double value1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter value2");
            double value2 = double.Parse(Console.ReadLine());
            double result = value1 + value2;
            Console.WriteLine("The Result:" + result);
        }
    }
}
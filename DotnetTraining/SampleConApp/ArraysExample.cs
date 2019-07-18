using System;
namespace SampleConApp
{
    //Arrays are fixed in size, U cannot create dynamic arrays in C#. U can create an Array Dynamically. 
    class ArraysDemo
    {
        static void Main(string[] args)
        {
            //simpleArrayExample();
            //multiDimensionalArray();
            //jaggedArray();
            //Explore how to create an Array dynamically including the datatype of the Array...
            dynamicArrayCreation();
        }

        private static void dynamicArrayCreation()
        {
            //get the size
            var size = Prompt.GetNumber("Enter the size of array");
            //get the type
            string typeName = Prompt.GetString("Enter the CTS type for the Array");
            Type type = Type.GetType(typeName);
            if(type == null)
            {
                Console.WriteLine("Invalid CTS Type");
                return;
            }
            //create the array
            Array array = Array.CreateInstance(type, size);
            //set the values
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter the value for the type " + type.Name);
                array.SetValue(Convert.ChangeType(Console.ReadLine(), type), i);
            }
            Console.WriteLine("All the values are set");
            //display all
            foreach (var value in array) Console.WriteLine( value);
        }

        private static void jaggedArray()
        {
            //Array of Arrays is called Jagged Array.
            //It has fixed no of Rows but variable no of columns in each row...
            //A School is an array of classrooms where class has variable no of students. 
            int[][] school = new int[2][];
            school[0] = new int[] { 67, 66, 77, 87 };
            school[1] = new int[] { 56, 66, 76, 56, 45, 56, 56, 88, 87 };
            //Using Foreach statement...
            foreach(int [] classRoom in school)
            {
                foreach(int score in classRoom)
                    Console.Write(score + "  ");
                Console.WriteLine();//Move to next line...
            }

        }

        private static void multiDimensionalArray()
        {
            int[,] classRoom = new int[2, 2];
            Console.WriteLine("The No of dimennsions:" + classRoom.Rank);
            for (int i = 0; i < classRoom.GetLength(0); i++)
            {
                Console.WriteLine("Enter the scores of Student no: " + (i +1));
                for (int j = 0; j < classRoom.GetLength(1); j++)
                {
                    Console.WriteLine("Enter the Marks of Subject "+ (j+1));
                    classRoom[i, j] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Thanks for entering the marks");
            }
            Console.WriteLine("Lets display the results....");
            for (int i = 0; i < classRoom.GetLength(0); i++)
            {
                Console.Write("StudentNo"+ (i+1) + "\t");
                for(int j = 0; j < classRoom.GetLength(1); j++)
                {
                    Console.Write(classRoom[i,j] + "\t");
                }
                Console.WriteLine();
            }
        }

        private static void simpleArrayExample()
        {
            Console.WriteLine("Enter the size");
            string[] basket = new string[int.Parse(Console.ReadLine())];
            
            for (int i = 0; i < basket.Length; i++)
            {
                Console.WriteLine("Enter the value for " + i);
                basket[i] = Console.ReadLine();
            }
            Console.WriteLine("All the data is set");
            foreach (string item in basket) Console.WriteLine(item);
            //string[] fruits = { "Apple", "Mango", "Orange" };
            //string[] items = new string[] { "TV", "Fridge", "SofaSet", "Dinning Table" };
        }
    }
    /*
     * Points:
     * An Array is a reference type to store data in a conteginous memory. 
     * All arrays are objects of a class System.Array. 
     * There are properties to get info about the Array
     * Length: Gets the no of elements within the array
     * GetLength(int) is a function to get the no of elements of a specified dimension for a multi dimensional array.
     * Rank is a property that is used to get the No of dimensions within an Array. 
     * GetLowerBound and GetUpperBound are used to get the Lower index and the Max Index within the Array object. 
     * Clone is a method of the Array to create a shallow copy of an array into another. 
     * CopyTo is used to deep copy contents of the original to the copy from a specified index and the specified no of elements from that index. 
     * There is a static function CreateInstance to create an Array dynamically.
     * 
     */
}
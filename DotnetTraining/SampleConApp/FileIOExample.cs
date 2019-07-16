using System;
using System.IO;//Contains clases for performing file io related operations....
using System.Runtime.Serialization.Formatters.Binary;
namespace SampleConApp
{
    [Serializable]
    class Student
    {
        public int StudentNo { get; set; }
        public string Name { get; set; }
        public int MathScore { get; set; }
        public int ScienceScore { get; set; }
        public int EnglishScore { get; set; }
        public int SocialScore { get; set; }
        public int LanguageScore { get; set; }
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5},{6}", StudentNo, Name, MathScore, ScienceScore, SocialScore, EnglishScore, LanguageScore);
        }
    }
    class FileIOExample
    {
        static void Main(string[] args)
        {
            //fileWriting();
            //fileReading();
            //serializing();
            deserialize();

        }

        private static void deserialize()
        {
            FileStream fs = new FileStream("Data.Bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter fm = new BinaryFormatter();
            Student copy = fm.Deserialize(fs) as Student;
            Console.WriteLine(copy);
            fs.Close();
        }

        private static void serializing()
        {
            //Serialization is a feature of saving the state of the object to a storage device like discs and retriving it as it is(State) later. 
            FileStream fs = new FileStream("Data.Bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Student student = new Student
            {
                EnglishScore = 56,
                LanguageScore = 66,
                MathScore = 78,
                Name = "Phaniraj",
                ScienceScore = 67,
                SocialScore = 75,
                StudentNo = 222
            };
            BinaryFormatter fm = new BinaryFormatter();
            fm.Serialize(fs, student);
            fs.Close();
        }

        private static void fileReading()
        {
            StreamReader reader = new StreamReader("Students.csv");
            //var contents = reader.ReadToEnd();
            //Console.WriteLine(contents);

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var words = line.Split(',');
                var total = int.Parse(words[2]) + int.Parse(words[3]) + int.Parse(words[4]) + int.Parse(words[5]) + int.Parse(words[6]);
                Console.WriteLine(words[1] + " scored " + total);
            }
            reader.Close();
        }

        private static void fileWriting()
        {
            Student student = new Student { EnglishScore = 56, LanguageScore = 66, MathScore = 78, Name = "Phaniraj", ScienceScore = 67, SocialScore = 75, StudentNo = 222 };
            StreamWriter writer = new StreamWriter("Students.csv", true);
            writer.WriteLine(student);
            writer.Flush();
            writer.Close();
        }
    }
}

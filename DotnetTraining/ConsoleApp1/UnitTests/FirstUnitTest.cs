using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewFeatures;

[TestClass]
public class MathComponentTestClass
{
    //Add the reference of Microsoft.VisualStudio.QualityTools.UnitTestFramework
    [TestMethod]
    public void TestForAddFunc()
    {
        var com = new MathComponent();
        var res = com.AddFunc(123, 123);
        Assert.AreEqual(246, res);
    }
}

[TestClass]
public class StringTestClass
{
    private NewFeatures.StringEncoder coder;
    [TestInitialize]
    public void Initialize()
    {
        coder = new NewFeatures.StringEncoder();
    }
    [TestMethod]
    public void UTC01_01()
    {
        string input = "bangalore";
        string actual = coder.EncodeString(input);
        string expected = "30,20,21,92,20,80,32,31,02";
        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void UTC01_02()
    {
        string input = "mindtree";
        string actual = coder.EncodeString(input);
        string expected = "52,12,21,22,00,31,02,02";
        Assert.AreEqual(expected, actual);
    }
    
}

/*
 * The text “the quick and brown fox jumps over the lazy dog” contains all the 26 alphabets in English.
We can generate a code for any letter in the following manner:
The code is a combination two digits. The first digit represents the index of the word (first occurrence), which contains the letter and the second digit represents the index of that letter in the found word.
For example, the letter “m” is found in the word “jumps” which is at index 5 in the sentence and in that word, “m” is found at index 2. Hence the code is 52. Similarly, the letter “v” is found in the word “over” which is at index 6 in the sentence and in that word, “v” is at index 1. Hence the code for the letter “v” is 61.
Write a program that accepts a String and returns the encoded String of the input.
Input
Input is a case-insensitive String containing one or more words delimited by space.
Output
The output is a String containing codes for each letter separated by comma. The space in the input is replaced by a hyphen in the output.
 */

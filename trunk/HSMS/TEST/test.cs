using System;

public class SubStringTest
{
    public static void Main()
    {

        string[] info = { "Name: Felica Walker", "Title: Mz.", "Age: 47", "Location: Paris", "Gender: F" };
        int found = 0;

        Console.WriteLine("The initial values in the array are:");
        foreach (string s in info)
            Console.WriteLine(s);

        Console.WriteLine("{0}We want to retrieve only the key information. That is:", Environment.NewLine);

        foreach (string s in info)
        {
            found = s.IndexOf(":");
            Console.WriteLine(s.Substring(found + 1).Trim());
        }
    }
}

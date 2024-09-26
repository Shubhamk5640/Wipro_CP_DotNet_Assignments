using System;
using System.Linq;
using System.Xml.Linq;

namespace XMLQueryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specify the full path to the XML file
            string xmlFilePath = @"C:\Users\Shubham\Desktop\Wipro_CP_DotNet_Training_56days\5.C#.Net with DS and Algorithms\Day-23 (5Sept)\books.xml";

            // Load the XML file into an XDocument
            XDocument xdoc = XDocument.Load(xmlFilePath);

            // Print all book details
            Console.WriteLine("All Book Details:");
            var allBooks = from book in xdoc.Descendants("book")
                           select new
                           {
                               Title = book.Element("title")?.Value,
                               Author = book.Element("author")?.Value,
                               Price = book.Element("price")?.Value
                           };

            foreach (var book in allBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Price: {book.Price}");
            }

            // Query to select and print titles of all books authored by "John Doe"
            var booksByJohnDoe = from book in xdoc.Descendants("book")
                                 where (string)book.Element("author") == "John Doe"
                                 select book.Element("title").Value;

            Console.WriteLine("\nBooks authored by John Doe:");
            foreach (var title in booksByJohnDoe)
            {
                Console.WriteLine(title);
            }

            // Query to find and print the average price of all books
            var averagePrice = xdoc.Descendants("book")
                                   .Average(book => (decimal)book.Element("price"));

            Console.WriteLine($"\nAverage price of all books: {averagePrice:C}");
        }
    }
}

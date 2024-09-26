using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace XMLQueryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the XML content
            string xmlContent = @"<?xml version='1.0' encoding='utf-8'?>
                                 <bookstore>
                                    <book>
                                        <title>The Art of War</title>
                                        <author>John Doe</author>
                                        <price>150</price>
                                    </book>
                                    <book>
                                        <title>Mindset</title>
                                        <author>Jane Smith</author>
                                        <price>129</price>
                                    </book>
                                    <book>
                                        <title>Atomic Habits</title>
                                        <author>John Doe</author>
                                        <price>99</price>
                                    </book>
                                 </bookstore>";

            // Get the path to the directory where the executable is running
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            // Define the path to the XML file
            string xmlFilePath = Path.Combine(directoryPath, "books1.xml");

            // Create and write the XML file
            File.WriteAllText(xmlFilePath, xmlContent);

            Console.WriteLine($"XML file created at: {xmlFilePath}");

            // Load the XML file into an XDocument
            XDocument xdoc = XDocument.Load(xmlFilePath);

            // Print all book details
            Console.WriteLine("\nAll Book Details:");
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

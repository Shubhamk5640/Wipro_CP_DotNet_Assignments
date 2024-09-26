using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutPbyWratio_FractionalKnapsack
{
    internal class Item
    {
        public string Name { get; set; }
        public int Profit { get; set; }
        public int Weight { get; set; }

        public Item(string name, int profit, int weight)
        {
            Name = name;
            Profit = profit;
            Weight = weight;
        }
        static void Main()
        {
            List<Item> items = new List<Item>
            {
            new Item("A", 6, 1),
            new Item("B", 10, 2),
            new Item("C", 8, 4),
            new Item("D", 4, 2),
            new Item("E", 12, 6),
            new Item("F", 14, 7),
            new Item("G", 2, 1)
            };

            Console.WriteLine("Enter Capacity : ");
            int capacity = int.Parse(Console.ReadLine());

            Console.WriteLine("{0,-10} {1,-10} {2,-10}", "Object", "Profit", "Weight");


            foreach (var item in items)
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-10}", item.Name, item.Profit, item.Weight);
            }

            items.Sort((x, y) => y.Profit.CompareTo(x.Profit));

            double totalProfit = 0;
            int currentWeight = 0;
            List<string> selectedItems = new List<string>();

            foreach (var item in items)
            {
                if (currentWeight + item.Weight <= capacity)
                {

                    currentWeight += item.Weight;
                    totalProfit += item.Profit;
                    selectedItems.Add(item.Name);
                    Console.WriteLine($"Taking full item {item.Name} with profit {item.Profit} and weight {item.Weight}");
                }
            }

            Console.WriteLine($"\nSelected Objects: {string.Join(", ", selectedItems)}");
            Console.WriteLine($"Total Weight: {currentWeight}");
            Console.WriteLine($"Maximum Profit: {totalProfit:F2}");

            Console.ReadLine();
        }
    }

}
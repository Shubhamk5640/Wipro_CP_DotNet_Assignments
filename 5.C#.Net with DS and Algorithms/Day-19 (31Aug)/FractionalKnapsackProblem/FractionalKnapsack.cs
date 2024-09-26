namespace Fractional_Knapsack_Problem
{
    class Item
    {
        public string Name { get; set; }
        public int Profit { get; set; }
        public int Weight { get; set; }
        public double Ratio { get; set; }

        public Item(string name, int profit, int weight)
        {
            Name = name;
            Profit = profit;
            Weight = weight;
            Ratio = (double)profit / weight;
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

            Console.WriteLine("Enter The Capacity =  ");
            int capacity = int.Parse(Console.ReadLine());

            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15}", "Object", "Profit", "Weight", "Profit/Weight Ratio");


            foreach (var item in items)
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15:F2}", item.Name, item.Profit, item.Weight, item.Ratio);
            }
            //items.Sort((x, y) => y.Ratio.CompareTo(x.Ratio));

            items.Sort((x, y) => y.Ratio == x.Ratio ? y.Profit.CompareTo(x.Profit) : y.Ratio.CompareTo(x.Ratio));


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
                else
                {

                    int remainingCapacity = capacity - currentWeight;
                    double fraction = (double)remainingCapacity / item.Weight;
                    totalProfit += item.Profit * fraction;
                    currentWeight += remainingCapacity;
                    selectedItems.Add($"{item.Name} (fraction {fraction * 100:F2}%)");
                    Console.WriteLine($"Taking {fraction * 100:F2}% of item {item.Name} with profit {item.Profit * fraction:F2} and weight {remainingCapacity}");
                    break;
                }
            }

            Console.WriteLine($"\nSelected Objects: {string.Join(", ", selectedItems)}");
            Console.WriteLine($"Total Weight: {currentWeight}");
            Console.WriteLine($"Maximum Profit: {totalProfit:F2}");

            Console.ReadLine();
        }
    }

}

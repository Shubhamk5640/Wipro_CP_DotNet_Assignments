using LINQJoinOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    /**
  Customer 

  Id
  Name
  Gender
  Age
  Pincode
  Order
  OrderId
  Address 
  Datetime
  CustomerId
  Join Operations with LINQ

  Given two lists, Order and Customer, where each Order has a CustomerId, perform the following:

        a) Use LINQ to create a list of Order objects that include the customer's name.

        b) Print the list of orders with the customer names.
 
        inner, Left,right,Full ( Lambda, sql syntax)
   **/


    internal class Program
    {
        static void Main(string[] args)
        {


            List<Customer> customers = new List<Customer>
            {
            new Customer { Id = 1, Name = "Swarali", Gender = "Female", Age = 25, Pincode = "12345" },
            new Customer { Id = 2, Name = "Shubham", Gender = "Male", Age = 25, Pincode = "54321" },
            new Customer { Id = 3, Name = "Pankaj", Gender = "Male", Age = 28, Pincode = "67890" }
            };


            List<Order> orders = new List<Order>
            {
            new Order { OrderId = 101, Address = "Street 1", Datetime = DateTime.Now, CustomerId = 1 },
            new Order { OrderId = 102, Address = "Street 2", Datetime = DateTime.Now, CustomerId = 2 },
            new Order { OrderId = 103, Address = "Street 3", Datetime = DateTime.Now, CustomerId = 4 }
            };

            Console.WriteLine("Customer List");
            foreach (var i in customers)
            {
                Console.WriteLine($"Id: {i.Id}, Name: {i.Name}, Gender: {i.Gender}, Age: {i.Age}, Pincode: {i.Pincode}");
            }

            Console.WriteLine("\nOrder List:");
            foreach (var order in orders)
            {
                Console.WriteLine($"OrderId: {order.OrderId}, Address: {order.Address}, Datetime: {order.Datetime}, CustomerId: {order.CustomerId}");
            }
            Console.WriteLine("\n\n");
            var innerJoin = orders.Join(customers,
                            order => order.CustomerId,
                            customer => customer.Id,
                            (order, customer) => new
                            {
                                order.OrderId,
                                order.Address,
                                order.Datetime,
                                customer.Name
                            });

            Console.WriteLine("Inner Join (Method Syntax):");
            foreach (var result in innerJoin)
            {
                Console.WriteLine($"OrderId: {result.OrderId}, Address: {result.Address}, Customer Name: {result.Name}");
            }


            var innerJoinQuery = from order in orders
                                 join customer in customers
                                 on order.CustomerId equals customer.Id
                                 select new
                                 {
                                     order.OrderId,
                                     order.Address,
                                     order.Datetime,
                                     customer.Name
                                 };

            Console.WriteLine("\nInner Join (Query Syntax):");
            foreach (var result in innerJoinQuery)
            {
                Console.WriteLine($"OrderId: {result.OrderId}, Address: {result.Address}, Customer Name: {result.Name}");
            }


            var leftJoin = orders.GroupJoin(customers,
                                order => order.CustomerId,
                                customer => customer.Id,
                                (order, customerGroup) => new
                                {
                                    order.OrderId,
                                    order.Address,
                                    order.Datetime,
                                    Customer = customerGroup.FirstOrDefault()
                                })
                     .Select(joinResult => new
                     {
                         joinResult.OrderId,
                         joinResult.Address,
                         joinResult.Datetime,
                         CustomerName = joinResult.Customer?.Name ?? "No Customer"
                     });

            Console.WriteLine("\nLeft Join (Method Syntax):");
            foreach (var result in leftJoin)
            {
                Console.WriteLine($"OrderId: {result.OrderId}, Address: {result.Address}, Customer Name: {result.CustomerName}");
            }



            var leftJoinQuery = from order in orders
                                join customer in customers
                                on order.CustomerId equals customer.Id into customerGroup
                                from customer in customerGroup.DefaultIfEmpty()
                                select new
                                {
                                    order.OrderId,
                                    order.Address,
                                    order.Datetime,
                                    CustomerName = customer?.Name ?? "No Customer"
                                };

            Console.WriteLine("\nLeft Join (Query Syntax):");
            foreach (var result in leftJoinQuery)
            {
                Console.WriteLine($"OrderId: {result.OrderId}, Address: {result.Address}, Customer Name: {result.CustomerName}");
            }


            var rightJoinQuery = from customer in customers
                                 join order in orders
                                 on customer.Id equals order.CustomerId into orderGroup
                                 from order in orderGroup.DefaultIfEmpty()
                                 select new
                                 {
                                     OrderId = order?.OrderId ?? 0,
                                     Address = order?.Address ?? "No Address",
                                     CustomerName = customer.Name
                                 };

            Console.WriteLine("\nRight Join (Query Syntax):");
            foreach (var result in rightJoinQuery)
            {
                Console.WriteLine($"OrderId: {result.OrderId}, Address: {result.Address}, Customer Name: {result.CustomerName}");
            }


            var RightJoin = customers.GroupJoin(orders,
                                customer => customer.Id,
                                order => order.CustomerId,
                                (customer, orderGroup) => new
                                {
                                    CustomerName = customer.Name,
                                    Order = orderGroup.FirstOrDefault()
                                })
                         .Select(joinResult => new
                         {
                             OrderId = joinResult.Order?.OrderId ?? 0,
                             Address = joinResult.Order?.Address ?? "No Address",
                             joinResult.CustomerName
                         });

            Console.WriteLine("\nRight Join (Method Syntax, Simulated):");
            foreach (var result in RightJoin)
            {
                Console.WriteLine($"OrderId: {result.OrderId}, Address: {result.Address}, Customer Name: {result.CustomerName}");
            }


            var fullOuterJoin = leftJoin
                                .Union(RightJoin.Select(rj => new
                                {
                                    OrderId = rj.OrderId,
                                    Address = rj.Address,
                                    Datetime = DateTime.Now,
                                    CustomerName = rj.CustomerName
                                }));

            Console.WriteLine("\nFull Outer Join (Union of Left and Right Joins):");
            foreach (var result in fullOuterJoin)
            {
                Console.WriteLine($"OrderId: {result.OrderId}, Address: {result.Address}, Customer Name: {result.CustomerName}");
            }

            Console.ReadLine();

        }
    }
}
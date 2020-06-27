using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            List<Product> products = DataLoader.LoadProducts();
            var customers = DataLoader.LoadCustomers();
            var NumbersA = DataLoader.NumbersA;
            var NumbersB = DataLoader.NumbersB;
            var NumbersC = DataLoader.NumbersC;
            //PrintAllProducts();
            //PrintAllCustomers();
            //Exercise1(products);
            //Exercise2(products);
            //Exercise3(customers);
            //Exercise4(products);
            //Exercise5(products);
            //Exercise6(products);
            //Exercise7(products);
            //Exercise8(products);
            //Exercise9(NumbersA);
            //Exercise10(customers);
            //Exercise11(NumbersC);
            //Exercise12(NumbersB);
            //Exercise13(customers);
            //Exercise14(NumbersC);
            //Exercise15(NumbersC);
            //Exercise16(products);
            //Exercise17(products);
            //Exercise18(products);
            //Exercise19(NumbersB);
            //Exercise20(products);
            //Exercise21(customers);
            //Exercise22(products);
            //Exercise23(products);
            //Exercise24(products);
            //Exercise25(products);
            //Exercise26(NumbersA);
            //Exercise27(customers);
            //Exercise28(products);
            //Exercise29(products);
            //Exercise30(products);
            //Exercise31(products);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1(List<Product> products)
        {
            var inStock = from product in products
                           where product.UnitsInStock > 0
                           select product;

            PrintProductInformation(inStock);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2(List<Product> products)
        {
            var inStock = from product in products
                          where product.UnitsInStock > 0 && product.UnitPrice > 3.00M
                          select product;

            PrintProductInformation(inStock);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3(List<Customer> customers)
        {
            var washingtonCustomers = from customer in customers
                                      where customer.Region == "WA"
                                      select customer;

            PrintCustomerInformation(washingtonCustomers);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4(List<Product> products)
        {
            var productNameOnly = from product in products
                                  select new
                                  {
                                      ProductName = product.ProductName
                                  };
            foreach (var product in productNameOnly)
            {
                Console.WriteLine(product.ProductName);
            }
            //PrintProductInformation(productNameOnly);
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5(List<Product> products)
        {
            var priceJump = from product in products
                                  select new
                                  {
                                      ProductID = product.ProductID,
                                      ProductName = product.ProductName,
                                      Category = product.Category,
                                      UnitPrice = product.UnitPrice * 1.25M,
                                      UnitsInStock = product.UnitsInStock
                                  };
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in priceJump)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6(List<Product> products)
        {
            var upperCase = from product in products
                            select new
                            {
                                ProductName = product.ProductName.ToUpper(),
                                Category = product.Category.ToUpper()
                            };

            foreach (var product in upperCase)
            {
                Console.WriteLine("{0} {1}", product.ProductName, product.Category);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7(List<Product> products)
        {
            var productsToReOrder = from product in products
                                    select new
                                    {
                                        ProductID = product.ProductID,
                                        ProductName = product.ProductName,
                                        Category = product.Category,
                                        UnitPrice = product.UnitPrice,
                                        UnitsInStock = product.UnitsInStock,
                                        ReOrder = product.UnitsInStock < 3 ? true : false
                                    };
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5, 10}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Re Order");
            Console.WriteLine("==============================================================================");

            foreach (var product in productsToReOrder)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.ReOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8(List<Product> products)
        {
            var productStockValue = from product in products
                                    select new
                                    {
                                        ProductID = product.ProductID,
                                        ProductName = product.ProductName,
                                        Category = product.Category,
                                        UnitPrice = product.UnitPrice,
                                        UnitsInStock = product.UnitsInStock,
                                        StockValue = product.UnitPrice * product.UnitsInStock
                                    };
            string line = "{0,-5} {1,-35} {2,-15} {3,8:c} {4,6} {5, 10}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Stock Value");
            Console.WriteLine("===================================================================================");

            foreach (var product in productStockValue)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9(Array array)
        {
            List<int> numbers = array.OfType<int>().ToList();
            var onlyEvens = from number in numbers
                           where number % 2 == 0
                           select number;
            foreach (var number in onlyEvens)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                var hasSmallOrder = false;
                foreach (var order in customer.Orders)
                {
                    if (order.Total < 500)
                    {
                        hasSmallOrder = true;
                    }
                }
                if (hasSmallOrder == true)
                {
                    Console.WriteLine("{0} has an order of less than $500.", customer.CompanyName);
                }
            }
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11(Array array)
        {
            List<int> numbers = array.OfType<int>().ToList();
            var onlyOdds = (from number in numbers
                            where number % 2 == 1
                            select number).Take(3);
            foreach (var number in onlyOdds)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12(Array array)
        {
            List<int> numbers = array.OfType<int>().ToList();
            var skipThree = (from number in numbers
                            select number).Skip(3);
            foreach (var number in skipThree)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13(List<Customer> customers)
        {
            var washingtonCustomers = from customer in customers
                                      where customer.Region == "WA"
                                      select customer;
            foreach (var customer in washingtonCustomers)
            {
                Console.WriteLine(customer.CompanyName);
                var recentOrder = (from order in customer.Orders
                                   select order).Take(1);
                foreach (var order in recentOrder)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14(Array array)
        {
            List<int> numbers = array.OfType<int>().ToList();
            //var lessThanSix = from number in numbers
            //                  where number <= 6
            //                  select number;

            foreach (var number in numbers)
            {
                if (number >= 6)
                {
                    break;
                }
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15(Array array)
        {
            List<int> numbers = array.OfType<int>().ToList();
            //var newList = from number in numbers
            //              select number;
            foreach (var number in numbers)
            {
                var divisible = false;
                while (divisible)
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16(List<Product> products)
        {
            var alphabetical = from product in products
                               orderby product.ProductName
                               select product;
            PrintProductInformation(alphabetical);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17(List<Product> products)
        {
            var alphabetical = from product in products
                               orderby product.UnitsInStock descending
                               select product;
            PrintProductInformation(alphabetical);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18(List<Product> products)
        {
            var highToLow = from product in products
                            orderby product.Category descending, product.UnitPrice descending
                            select product;
            PrintProductInformation(highToLow);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19(Array array)
        {
            List<int> numbers = array.OfType<int>().ToList();
            var orderedList = (from number in numbers
                               select number).Reverse();
            foreach (var number in orderedList)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20(List<Product> products)
        {
            var category = from product in products
                           group product by product.Category;
            foreach (var group in category)
            {
                Console.WriteLine(group.Key);

                foreach (var product in group)
                {
                    Console.WriteLine("\t{0}", product.ProductName);
                }
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.CompanyName);
                var byYear = from order in customer.Orders
                             group order by order.OrderDate.Year;
                foreach (var group in byYear)
                {
                    Console.WriteLine(group.Key);

                    foreach (var order in group)
                    {
                        Console.WriteLine("\t{0} - {1}", order.OrderDate.Month, order.Total);
                    }
                }
            }

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22(List<Product> products)
        {
            var byCategory = from product in products
                             group product by product.Category;
            foreach (var group in byCategory)
            {
                Console.WriteLine(group.Key);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23(List<Product> products)
        {
            var has789 = (from product in products
                         where product.ProductID == 789
                         select product).Any();
            //bool has = products.Any(cus => cus.ProductID == 789);
            if (has789 == false)
            {
                Console.WriteLine("That product does not exist.");
            }
            if (has789 == true)
            {
                Console.WriteLine("A product with that ID exists.");
            }
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24(List<Product> products)
        {
            var outOfStock = from product in products
                          where product.UnitsInStock == 0
                          select product;
            var byCategory = from product in outOfStock
                             group product by product.Category;

            foreach (var group in byCategory)
            {
                Console.WriteLine(group.Key);
            }

        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25(List<Product> products)
        {
            var inStock = from product in products
                             where product.UnitsInStock > 0
                             select product;
            var byCategory = from product in inStock
                             group product by product.Category;

            foreach (var group in byCategory)
            {
                Console.WriteLine(group.Key);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26(Array array)
        {
            List<int> numbers = array.OfType<int>().ToList();
            var odds = (from number in numbers
                        where number % 2 == 1
                        select number).Count();
            Console.WriteLine(odds);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27(List<Customer> customers)
        {
            var newType = from customer in customers
                          select new
                          {
                              CustomerID = customer.CompanyName,
                              OrderTotal = (customer.Orders).Count()
                          };
            foreach (var customer in newType)
            {
                Console.WriteLine("{0} {1}", customer.CustomerID, customer.OrderTotal);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28(List<Product> products)
        {
            var byCategory = from product in products
                             group product by product.Category;
            
            foreach (var group in byCategory)
            {
                Console.WriteLine(group.Key);
                var productCount = 0;
                foreach (var product in group)
                {
                    productCount += 1;
                }
                Console.WriteLine(productCount);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29(List<Product> products)
        {
            var byCategory = from product in products
                             group product by product.Category;

            foreach (var group in byCategory)
            {
                Console.WriteLine(group.Key);
                var stockCount = 0;
                foreach (var product in group)
                {
                    stockCount += product.UnitsInStock;
                }
                Console.WriteLine(stockCount);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30(List<Product> products)
        {
            var byCategory = from product in products
                             orderby product.UnitPrice descending
                             group product by product.Category;
            foreach (var group in byCategory)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    var lowestPrice = (from product in @group
                                       orderby product.UnitPrice descending
                                       select product).Last();
                    
                    Console.WriteLine("\t{0}", lowestPrice.ProductName);
                    break;
                }                
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31(List<Product> products)
        {
            var byCategory = from product in products
                             group product by product.Category into productGroup
                             select new
                             {
                                 Group = productGroup.Key,
                                 AveragePrice = productGroup.Average(x => x.UnitPrice)
                             };
            var topAverages = (from item in byCategory
                               orderby item.AveragePrice descending
                               select item).Take(3);
            foreach (var product in topAverages)
            {
                Console.WriteLine("{0} {1}", product.Group, product.AveragePrice);
            }
        }
    }
}

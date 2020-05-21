using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcProject1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new MvcProject1Context
                (serviceProvider.GetRequiredService<DbContextOptions<MvcProject1Context>>());
            if (context.Customer.Any() && context.Store.Any() && context.Defaultstore.Any() && context.Inventory.Any() && context.Order.Any() && context.Orderlist.Any())
            {
                return;
            }
            else
            {
                CustomerHelper(context);
                context.SaveChanges();
                StoreHelper(context);
                context.SaveChanges();
                DefaultStoreHelper(context);
                context.SaveChanges();
                InventoryHelper(context);
                context.SaveChanges();
                OrderHelper(context);
                OrderListHelper(context);
                context.SaveChanges();

            }
        }

        private static void OrderListHelper(MvcProject1Context context)
        {
            context.Orderlist.AddRange(
                new Orderlist
                {
                    
                    OrderID = 1,
                    InventoryID = 3,
                    Quantity = 1,
                    Price = 500.00M
                },
                new Orderlist
                {
                    
                    OrderID = 1,
                    InventoryID = 2,
                    Quantity = 1,
                    Price = 500.00M
                }

             );
            
        }

        private static void OrderHelper(MvcProject1Context context)
        {
            context.Order.AddRange(
                new Orders
                {
                   
                    CustomerId = 1,
                    OrderDate = DateTime.Parse("2020-4-1"),
                    Total = 2000.20
                },
                 new Orders
                 {
                    
                     CustomerId = 2,
                     OrderDate = DateTime.Parse("2020-2-1"),
                     Total = 1000.20
                 },
                 new Orders
                 {
                     
                     CustomerId = 1,
                     OrderDate = DateTime.Parse("2020-2-1"),
                     Total = 1000.20
                 },
                 new Orders
                 {
                    
                     CustomerId = 4,
                     OrderDate = DateTime.Parse("2019-12-11"),
                     Total = 1000.20
                 },
                 new Orders
                 {
                    
                     CustomerId = 4,
                     OrderDate = DateTime.Parse("2019-12-11"),
                     Total = 1000.20
                 }


                );
            
        }

        private static void InventoryHelper(MvcProject1Context context)
        {
            context.Inventory.AddRange(
                new Inventory
                {
                   
                    StoreID = 1,
                    Name = "Samsung TV",
                    Description = "HD 4K 44\" TV",
                    Quantity = 10,
                    ListPrice = 400.98M

                },
                new Inventory
                {
                    
                    StoreID = 2,
                    Name = "Samsung TV",
                    Description = "HD 4K 44\" TV",
                    Quantity = 10,
                    ListPrice = 400.98M

                },
                new Inventory
                {
                    
                    StoreID = 1,
                    Name = "Apple TV",
                    Description = "HD 4K 44\" TV",
                    Quantity = 10,
                    ListPrice = 500.00M

                },
                new Inventory
                {
                   
                    StoreID = 2,
                    Name = "Apple TV",
                    Description = "HD 4K 44\" TV",
                    Quantity = 10,
                    ListPrice = 500.98M

                },
                new Inventory
                {
                   
                    StoreID = 3,
                    Name = "Apple TV",
                    Description = "HD 4K 44\" TV",
                    Quantity = 10,
                    ListPrice = 500.98M

                },
                new Inventory
                {
                    
                    StoreID = 3,
                    Name = "IPhone X ",
                    Description = "Smart Phone",
                    Quantity = 10,
                    ListPrice = 1200.98M

                },
                new Inventory
                {
                   
                    StoreID = 4,
                    Name = "IPhone X ",
                    Description = "Smart Phone",
                    Quantity = 10,
                    ListPrice = 1200.98M

                },
                new Inventory
                {
                   
                    StoreID = 4,
                    Name = "IPhone XMax ",
                    Description = "Smart Phone",
                    Quantity = 20,
                    ListPrice = 1000.98M

                },
                new Inventory
                {
                  
                    StoreID = 5,
                    Name = "IPhone XMax ",
                    Description = "Smart Phone",
                    Quantity = 20,
                    ListPrice = 1000.98M

                }

            );
           
        }

        private static void DefaultStoreHelper(MvcProject1Context context)
        {
            context.Defaultstore.AddRange(
                new Defaultstore 
                { 
                    
                    CustomerID = 1,
                    StoreID = 1,
                    RegDate = DateTime.Parse("2020-1-1")
                },
                 new Defaultstore
                 {
                     
                     CustomerID = 2,
                     StoreID = 1,
                     RegDate = DateTime.Parse("2020-2-1")
                 },
                 new Defaultstore
                 {
                     
                     CustomerID = 3,
                     StoreID = 3,
                     RegDate = DateTime.Parse("2010-2-1")
                 }
                 ,
                 new Defaultstore
                 {
                     
                     CustomerID = 4,
                     StoreID = 2,
                     RegDate = DateTime.Parse("2010-2-1")
                 },
                 new Defaultstore
                 {
                     
                     CustomerID = 5,
                     StoreID = 4,
                     RegDate = DateTime.Parse("2010-2-1")
                 }

             );
            
        }

        private static void StoreHelper(MvcProject1Context context)
        {
            context.Store.AddRange(
                new Store
                {
                    
                    CityAddress = "New York City",
                    StreetAddress = "657 Fifth Ave",
                    StateAddress ="New York",
                    CountryAddress = "USA"
                },
                new Store
                {
                    
                    CityAddress = "Dallas",
                    StreetAddress = "1102 Lenon Ave",
                    StateAddress = "Taxas",
                    CountryAddress = "USA"
                },
                new Store
                {
                    
                    CityAddress = "Baltimore",
                    StreetAddress = "1102 Lenon Ave",
                    StateAddress = "Maryland",
                    CountryAddress = "USA"
                },
                new Store
                {
                    
                    CityAddress = "Bronx",
                    StreetAddress = "1102 Lenon Ave",
                    StateAddress = "New York",
                    CountryAddress = "USA"
                }
                ,
                new Store
                {
                   
                    CityAddress = "Santa Fe",
                    StreetAddress = "1102 Lenon Ave",
                    StateAddress = "New Mexico",
                    CountryAddress = "USA"
                }
                );
            

        }

        private static void CustomerHelper(MvcProject1Context context)
        {
            context.Customer.AddRange(
                new Customer
                {
                    
                    FirstName = "Maria",
                    LastName = "Andres",
                    StreetAddress = "57 obere str",
                    CityAddress = "New York City",
                    StateAddress = "New York",
                    CountryAddress = "USA",
                    UserName = "Ander1",
                    Email = "anderma@gmail.co",
                    PassWord =Crypto.Hash("NewKing$#@"),
                    RegDate = DateTime.Parse("2020-1-1")
                },
                 new Customer
                 {
                     
                     FirstName = "Andy",
                     LastName = "Andres",
                     StreetAddress = "300 obere str",
                     CityAddress = "Bronx",
                     StateAddress = "New York",
                     CountryAddress = "USA",
                     UserName = "Ander1",
                     Email = "anderma@gmail.co",
                     PassWord = Crypto.Hash("NeyKing$#@"),
                     RegDate = DateTime.Parse("2020-2-1")
                 },
                 new Customer
                 {
                     
                     FirstName = "Jack",
                     LastName = "Johnson",
                     StreetAddress = "300 Jeff str",
                     CityAddress = "Dallas",
                     StateAddress = "Taxas",
                     CountryAddress = "USA",
                     UserName = "JohJack",
                     Email = "anjokhhf@gmail.co",
                     PassWord = Crypto.Hash("NeyKing$#@"),
                     RegDate = DateTime.Parse("2019-2-1")
                 },
                 new Customer
                 {
                     
                     FirstName = "Lewi",
                     LastName = "Johnson",
                     StreetAddress = "300 Jeff Ave",
                     CityAddress = "Dallas",
                     StateAddress = "Taxas",
                     CountryAddress = "USA",
                     UserName = "JohJack",
                     Email = "lawif@gmail.co",
                     PassWord = Crypto.Hash("NeyKing$#@"),
                     RegDate = DateTime.Parse("2019-2-1")
                 },
                 new Customer
                 {
                     
                     FirstName = "Jackson",
                     LastName = "Robert",
                     StreetAddress = "5 fifth ave",
                     CityAddress = "Baltimore",
                     StateAddress = "Maryland",
                     CountryAddress = "USA",
                     UserName = "robJack",
                     Email = "robet@gmail.co",
                     PassWord = Crypto.Hash("NeyKing$#@"),
                     RegDate = DateTime.Parse("2019-2-10")
                 }
                );
            
        }
    }
}

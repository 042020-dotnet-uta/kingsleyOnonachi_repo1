using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FruitServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Fruit : IFruit
    {

        public List<string>Add(List<string>n1, string n2)
        {
            List<string> temp = n1;
             n1.Add(n2);
            List<string> fruit = n1;
            foreach(var item in temp) { 
                Console.WriteLine($"Received Add : {item},");
            // Code added to write output to the console window.
            }
            Console.WriteLine($"and {n2}");
            Console.WriteLine($"You now Have");
            foreach (var item in fruit)
            {
                Console.WriteLine($": {item},");
                // Code added to write output to the console window.
            }


            return fruit; ;

        }

        public List<string> Subtract(List<string>n1, string n2)
        {
            List<string> temp = n1;
            List<string> fruit;
            if (n1.Contains(n2))
            {
                n1.Remove(n2);
                fruit = n1;
            }
            else
            {
                Console.WriteLine($"No such fruit {n2} in the fridge");
                Console.WriteLine("These are what we have:");
                foreach (var item in temp)
                {
                    Console.WriteLine($"Received Add : {item},");
                    // Code added to write output to the console window.
                }
                fruit = n1;
            }
            return fruit;
        }
    }
}

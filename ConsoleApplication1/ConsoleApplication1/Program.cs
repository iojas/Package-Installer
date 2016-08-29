using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input should be given here.
            String[] givenArray = { "KittenService: ",

"Leetmeme: Cyberportal",

"Cyberportal: Ice",

"CamelCaser: KittenService",

"Fraudstream: Leetmeme",

"Ice: " };

            Dictionary<string, string> dict = new Dictionary<string, string>();
            
            // dependent are those who are on the Left side of each dependency, independent on right side. 
            HashSet<string> dependent = new HashSet<string>();
            HashSet<string> independent = new HashSet<string>();

            foreach (String s in givenArray)
            {
                String[] packinList = s.Split(':');
                if (!packinList[1].Trim().Equals(string.Empty))
                {
                    // Before adding to dicctionary remove the white spaces.
                    independent.Add(packinList[1].Trim());
                    dependent.Add(packinList[0].Trim());
                    dict.Add(packinList[0].Trim(), packinList[1].Trim());
                }
                else
                {
                    independent.Add(packinList[0].Trim());
                }

            }
            foreach (string x in dependent)
            {
                independent.Remove(x);
            }
            Console.WriteLine("Independents");
            foreach (string x in independent)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
            Console.WriteLine("Dependents");
            foreach (string x in dependent)
            {
                Console.WriteLine(x);
            }

            Console.ReadLine();
        }
    }
}

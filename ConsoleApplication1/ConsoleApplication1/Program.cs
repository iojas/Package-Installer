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

            //We will need total number of individual packages in order to detect if cycle is present or not.
            int totalPackages = dependent.Count + independent.Count;

            //Use count for detecting if cycle is present or not.
            int count = 0;
            //Create a stackk of Independent Packages
            Stack<string> indStack = new Stack<string>(independent);
            // LinkedList of independent packages for printing purpose.
            LinkedList<String> ret = new LinkedList<string>(independent);
            //while stack is not empty
            while (indStack.Count > 0)
            {
                //get the top element of stack
                string key = indStack.Pop();
                //compare it with each entry in dictionary
                foreach (KeyValuePair<string, string> entry in dict)
                {
                    // If Entry is matched push it on the stack, as it is nt dependent on any other dependent now.
                    if (entry.Value.Equals(key))
                    {
                        indStack.Push(entry.Key);
                        ret.AddLast(entry.Key);
                        //increament the count for each new independent variable
                        count++; 
                    }

                }
            }
            //count signifies total number of dependent packages that we were able to use once their dependency was resolved
            // when we add it with count of independent packages we get total count of installable packages.  
            int a = count + independent.Count;
            
            //if the total count of installable pacckages is equal to count of total packages then print it one by one.
            if (a == totalPackages)
            {
                foreach (string s in ret)
                {
                    Console.WriteLine(s);
                }
            }
            //if count is not equal then there must be cycles present.
            else
            {
                Console.WriteLine("There are cycles.");
            }

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        //function for removing leading and trailing blank spaces and double inverted comma from package name.
        public static string cleanIt(string package)
        {
            string returnVal = "";
            string pack = package.Trim();

            if (pack.Equals('"'))
            {
                return string.Empty;
            }
            else
            {
                if (package[0].Equals('"'))
                {
                    return package.Remove(0, 1).Trim();
                }
                else if (package[package.Count() - 1].Equals('"'))
                {
                    return package.Remove(package.Count() - 1, 1).Trim();
                }
            }
            return returnVal;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Array of packages");
            String ss = Console.ReadLine();
            
            string[] givenArray = ss.Split(',');
            
            Dictionary<string, string> dict = new Dictionary<string, string>();
            //Create two Hashsets dependent and independent. dependent ccontains all the packages on the left hand side of ':' while independent
            //contains packages on Right hand side. (Later they will be refined)
            HashSet<string> dependent = new HashSet<string>();
            HashSet<string> independent = new HashSet<string>();
            try
            {
                foreach (String s in givenArray)
                {
                    String[] packinList = s.Split(':');
                    //remove white  leading and trailing spaces and double inverted comma (") from all package names.  
                    if (!cleanIt(packinList[1]).Equals(string.Empty))
                    {

                        dependent.Add(cleanIt(packinList[0]));
                        independent.Add(cleanIt(packinList[1]));
                        dict.Add(cleanIt(packinList[0]), cleanIt(packinList[1]));
                    }
                    else
                    {
                        if (!cleanIt(packinList[1]).Equals(string.Empty))
                        {
                            independent.Add(cleanIt(packinList[1]));
                        }
                    }

                }
            }
            catch
            {
                Console.WriteLine("Invalid Input");
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
                int comma = 0;
                foreach (string s in ret)
                {
                    if (comma == 0)
                    {
                        Console.Write(s);
                        comma++;
                    }
                    else
                    {
                        Console.Write(", " + s);
                    }
                    
                }
            }
            //if count is not equal then there must be cycles present.
            else
            {
                Console.WriteLine("Cycle Detected.");
            }

            Console.ReadLine();
        }
    }
}

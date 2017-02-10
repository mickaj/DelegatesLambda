using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncActionPredicate
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func<T,R> - generic delegate that takes T type argument and returns R type value
            Func<string, int> GetLength = (string input) => input.Length;
            int result = GetLength("Text you want to get length");
            Console.WriteLine(result);

            Console.WriteLine("-----------------------");

            //Action<T> - generic delegate that takes T type argument and doesn't return anything
            Action<string> WriteBackwards = (string text) =>
                                                           {
                                                               char[] stringChars = text.ToCharArray();
                                                               Array.Reverse(stringChars);
                                                               Console.WriteLine( new string(stringChars));
                                                           };
            WriteBackwards("Action delegate");

            Console.WriteLine("-----------------------");

            //Predicate<T> - generic delegate that checks a specified condition and returns boolean
            Predicate<int> IsEven = (int input) => input % 2 == 0;
            Console.WriteLine("5 is even: {0}", IsEven(5));
            Console.WriteLine("12 is even: {0}", IsEven(12));

            //Predicates can be used to eleminate specified items in collections (for instance in Lists);
            List<int> Numbers = new List<int> { 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            Console.Write("\nInitial content of the list: ");
            foreach(int i in Numbers)
            {
                Console.Write("{0} ", i);
            }
            //removing all even numbers from the list using IsEven predicate
            Numbers.RemoveAll(IsEven);
            //List<T>.RemoveAll(Predicate<T> match) removes all items that returns true value when used with the predicate 
            Console.Write("\nContent of the list after filtering: ");
            foreach(int i in Numbers)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }
    }
}

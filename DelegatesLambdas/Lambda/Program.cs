using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        delegate int intDelegate(int arg);
        delegate void voidDelegate(string arg);
        static void Main(string[] args)
        {
            //anonymous method (pre-Lambda)
            //anonymous method that returns square value of an int
            intDelegate intInstance = delegate (int input)
                                        {
                                            return input*input;
                                        };
            int value = 5;
            Console.WriteLine("Square value of 5: {0}", intInstance(value));

            Console.WriteLine("---------------------------");

            //anonymous method (pre-Lambda)
            //anonymous method that doesn't return any value but prints given value to console
            voidDelegate voidInstance = delegate (string text)
                                        {
                                            Console.WriteLine(text);
                                        };
            voidInstance("Given text");

            Console.WriteLine("---------------------------");

            //delagate with Lambda expresion that returns int
            intDelegate intLambda = (int input) => input * input;
            value = 6;
            Console.WriteLine("Square value of 5: {0}", intLambda(value));

            Console.WriteLine("---------------------------");

            //delegate with extended Lambda expresion that returns int
            intDelegate intExtLambda = (int input) =>
                                                    {
                                                        int buffer;
                                                        buffer = input * input;
                                                        buffer = (int)Math.PI * buffer;
                                                        return buffer;
                                                    };
            Console.WriteLine("Processed value of given input: {0}", intExtLambda(value));

            Console.WriteLine("---------------------------");

            //delgate with Lambda expression that returns nothing
            voidDelegate voidLambda = (string text) => Console.WriteLine(text);
            voidLambda("Given text");

            Console.WriteLine("---------------------------");

            //delegate with extended Lambda expression that return nothing
            voidDelegate voidExtLambda = (string text) =>
                                                        {
                                                            Console.WriteLine("Given text: {0}", text);
                                                            Console.WriteLine("Length: {0}", text.Length);
                                                            Console.WriteLine("Capitalizad text: {0}", text.ToUpper());

                                                        };
            voidExtLambda("input text_XXX");
             

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        //delegates are types that can hold references to methods
        delegate int IntDelegate(int arg);
        /*the signature above means that IntDelegate type has been create which can hold references
        to methods that return int value and take one int argument*/
         
        static void Main(string[] args)
        {
            IntDelegate delegateInstance = new IntDelegate(Square); //create new instance of IntDelegate and attaching Square method
            delegateInstance += Double; //attaching another method to the invokation list for this instance of IntDelegate
            int results = delegateInstance(5); //creating new int variable and assiging results of delegateInstance
            Console.WriteLine("Results: {0}", results); //displaying results of delegateInstance(5) running;
            /*if a delegate returns a value, in case of multipe methods assigned to the delegate, 
             the delegate will return value from the last method in its invokation list*/
        }

        //the method below matches to IntDelegate signature
        static int Square(int argument)
        {
            int buffer = argument * argument;
            Console.WriteLine("Square value for given argument is: {0}", buffer);
            return buffer;
        }
        
        //the method below matches to IntDelegate signature
        static int Double(int argument)
        {
            int buffer = argument * 2;
            Console.WriteLine("Double the agrument equals to: {0}", buffer);
            return buffer;
        }
    }
}

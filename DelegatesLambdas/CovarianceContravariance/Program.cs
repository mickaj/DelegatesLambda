using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * covariance - conversion from more precise type to more generic type; from derived class to base class
 * contravariance - conversion for more generic type to more precise type; from base class to derived class 
*/

namespace CovarianceContravariance
{
    delegate Line RegularDelegate(int length); //this delegate will be used to return the same type and get the same arguments
                                               //this delegate will also be used to present covariance 

    delegate int ContraDelegate(Square input); //this delegate will be used to present contravariance

    class Program
    {
        static void Main(string[] args)
        {
            RegularDelegate regDelegate = lineMethod; //creating new instance of RegularDelagate and assigning lineMethod to it
            Line myLine = regDelegate(10);
            myLine.Display();
            Console.WriteLine("--------------------------");
            regDelegate = squareMethod; //assigning squareMethod (which returns Square object) to regDelegate
                                        //regDelegate is of type RegularDelegate, its signature indicates that its return type is Line
                                        //this concept is covariance
                                        //covariance is a rule which allows to assing also a method which return type is
                                        //derived from return type in signature 
            Square mySquare = (Square)regDelegate(7);
            mySquare.Display();
            Console.WriteLine("--------------------------");
            ContraDelegate cntDelegate = intMethod; //creating new instance of ContraDelegate and assigning intMethod to it
                                                    //cntDelegate is of type ContraDelegate, its signature indicates that
                                                    //its argument has to be of type Square. no contravariance here
            int result = intMethod(mySquare);
            Console.WriteLine("[int]result: {0}", result);
            Console.WriteLine("--------------------------");
            cntDelegate = intMethodCtr; //assiging intMethodCtr to instance of COntraDelegate. Its signature indicates that
                                        //its argument has to be of type Square, however intMethodCtr's argument is of type Line.
                                        //this concept is contravariance
            int result2 = intMethodCtr(myLine);
            Console.WriteLine("[int]result2: {0}", result2);

        }

        static Line lineMethod(int length) //method that returns Line object
        {
            Line newLine = new Line(length, 2);
            return newLine;
        }

        static Square squareMethod(int length) //method that returns Square object
        {
            Square newSquare = new Square(length, 2);
            return newSquare;
        }

        static int intMethod(Square input) //method that takes Square object as an argument
        {
            return input.Area;
        }

        static int intMethodCtr(Line input) //method that takes Line object as an argument
        {
            return input.Length;
        }
    }

    class Line //base class
    {
        public int Length;
        public int Thickness;

        public Line(int lng, int thk)
        {
            Length = lng;
            Thickness = thk;
        }

        public Line()
        {
            Length = 0;
            Thickness = 0;
        }

        public virtual void Display()
        {
            Console.WriteLine("Line length: {0}\nLine thickness: {1}", Length, Thickness);
        }
    }

    class Square :Line //derived class
    {
        public int Area;

        public Square(int lng, int thk) : base(lng, thk)
        {
            Area = lng * lng;
        }

        public Square():base()
        {
            Area = 0;
        }

        public new void Display()
        {
            base.Display();
            Console.WriteLine("Square area: {0}", Area);
        }
    }
}

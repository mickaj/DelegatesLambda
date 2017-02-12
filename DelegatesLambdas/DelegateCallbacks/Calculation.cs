using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateCallbacks
{
    public class Calculation
    {
        private int cycles;
        public int Cycles
        {
            get
            {
                return cycles;
            }
            set
            {
                cycles = value;
            }
        }

        //default constructor
        public Calculation(int _cycles)
        {
            Cycles = _cycles;
        }

        //running this method will call back to main each iteration of for loop
        public void Process(CallBack callBackMethod)
        {
            for(int i = 1; i <= cycles; i++)
            {
                //immitation of some calculations that takes 1/10 of second
                Thread.Sleep(100); //in miliseconds
                //point of calling back
                callBackMethod(i);
            } 
        }

        //delegate that determines methods of what signatures can be used as call backs
        public delegate void CallBack(int i);  
    }
}

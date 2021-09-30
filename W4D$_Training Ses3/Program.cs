using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace W4D__Training_Ses3
{
    class ThreadExample
    {
        public void CallDisplayAsynchronously()
        {
            Console.WriteLine("In CallDisplayAsynchronously ");
            Thread t = new Thread(() => { Display(); }); //line 15 is the same as line 17 and 18 combined

            ThreadStart start = new ThreadStart(Display);            
            Thread t1 = new Thread(start);
            Console.WriteLine("Before Starting Thread");
           
            t.Start();
            t1.Start();
            Console.WriteLine("Started Thread");
        }

        public void Display()
        {
            Console.WriteLine("I am in display");
        }
    }

 
    
    class Program
    {
        static void Main(string[] args)
        {
            ThreadExample t = new ThreadExample();
            Console.WriteLine("Callint the Normal Display Method");
            t.Display();
            Console.WriteLine("Callint the Thread Display Method");
            t.CallDisplayAsynchronously();
            Console.ReadLine();
        }
    }
}

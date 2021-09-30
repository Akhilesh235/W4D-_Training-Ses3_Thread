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
            Thread tp = new Thread(new ParameterizedThreadStart(DisplayParameter));

            ThreadStart start = new ThreadStart(Display1);            
            Thread t1 = new Thread(start);
            //ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart();
            Console.WriteLine("Before Starting Thread");

            //t.Start(); // will only be called after line 23
            // t1.Start(); //will only be called after line 21
            tp.Start("this is now");
            Console.WriteLine("Started Thread"); // will be called after line 19
                                                 // t = new Thread(() => { Display2(); });
                                                 // t.Start();
            for (int i = 0; i <5; i++)
            {
                Thread.Sleep(1000);
                if (i == 2)
                    t.Join();
                Console.WriteLine("I am in main thread");       //the order of execution will be different
            }
        }

        public void DisplayParameter(object str)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("I am in display");       //the order of execution will be different
            }
        }

        public void Display()               
        {
            for (int i = 0; i <10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("I am in display");       //the order of execution will be different
            }
        }


        public void Display1()
        {
            Console.WriteLine("I am in display1");
        }

        public void display2()
        {
            Console.WriteLine("i am in display2");
        }
    }

 
    
    class Program
    {
        static void Main(string[] args)
        {
            ThreadExample t = new ThreadExample();
            Console.WriteLine("Callint the Normal Display Method");
            //t.Display();
            Console.WriteLine("Callint the Thread Display Method");
            t.CallDisplayAsynchronously();
            Console.ReadLine();
        }
    }
}

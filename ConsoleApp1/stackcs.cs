using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class stackcs
    {
        Stack<int> mainStack = new Stack<int>();
        Stack<int> minStack = new Stack<int>();

        public void push(int i_Item)
        {
            mainStack.Push(i_Item);
            if (minStack.Count > 0)
            {
                if (i_Item < minStack.Peek())
                {
                    minStack.Push(i_Item);
                }
            }
            else
            {
                minStack.Push(i_Item);
            }
        }

        public int getMin()
        {
            return minStack.Peek();
        }

        public int pop()
        {
            if (mainStack.Peek() == minStack.Peek())
            {
                minStack.Pop();
            }
            return mainStack.Pop();
        }

        public int Top()
        {
            return mainStack.Peek();
        }

        public void run()
        {
            string t;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("enter number to push");
                t = Console.ReadLine();
                push(int.Parse(t));
            }

            Console.WriteLine(@"current min is {0}",getMin());

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(pop().ToString());
            }
            Console.WriteLine(@"current min is {0}", getMin());
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("enter number to push");
                t = Console.ReadLine();
                push(int.Parse(t));
            }
            Console.WriteLine(@"current min is {0}", getMin());

        }
    }
}

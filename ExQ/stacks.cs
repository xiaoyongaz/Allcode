using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQ
{
    class stacks
    {
    }

    class Queue
    {
        public static void EnqeueDequeueTest()
        {
             int[][] positives = new [] {new [] {0}, new [] {1, 2, 3}, new [] {3, 2, 1}};
            foreach (var positive in positives)
            {
                StackQueue<int> queue = new StackQueue<int>();
                foreach (var i in positive)
                {
                    queue.Enqueue(i);
                }

                Console.WriteLine("queue content is :");
                while (!queue.IsEmpty())
                {
                    var v = queue.Dequeue();
                    Console.Write("{0}:",v);
                }
                Console.WriteLine();
            }
        }

    }
    class StackQueue<T>
    {
        Stack<T> stack1 = new Stack<T>();
        Stack<T> stack2 = new Stack<T>();
        bool enqueue = true;
        public bool IsEmpty()
        {
            if (enqueue)
                return !stack1.Any();

            return !stack2.Any();
        }

        public void Enqueue(T value)
        {
            if (enqueue)
            {
                stack1.Push(value);
            }
            else
            {
                while(stack2.Any())
                {
                    stack1.Push(stack2.Pop());
                }
                enqueue = true;
            }
        }

        public T Dequeue()
        {
            if (enqueue)
            {
                while (stack1.Any())
                {
                    stack2.Push(stack1.Pop());
                }
                enqueue = false;
                return stack2.Pop();
            }
            
            return stack2.Pop();
        }
    }
}

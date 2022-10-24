using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue;

namespace Queue_and_Trees
{
    public class TimeCHeck
    {
        public void TimeCheck(string fileName, string path)
        {
            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            Stopwatch sw = Stopwatch.StartNew();
            string[] file = FileRead(path);
            for (int i = 0; i < file.Length; i += 10)
            {
                WorkForQueue(new ArraySegment<string>(file, 1, i));
                sb.Append($"{i};{(Process.GetCurrentProcess().WorkingSet64)}");
                list.Add(sb.ToString());
                sb.Clear();
            }
            /*for (int i = 0; i < file.Length; i += 10)
            {
                sw.Start();
                WorkForStack(new ArraySegment<string>(file, 1, i));
                sb.Append($"{i};{sw.Elapsed.TotalMilliseconds}");
                sw.Stop();
                list.Add(sb.ToString());
                sb.Clear();
            }*/
            File.WriteAllLines($"{fileName}.csv", list);
        }

        public void WorkForQueue(ArraySegment<string> arr)
        {
            MyQueue<string> queue = new MyQueue<string>();

            foreach (string item in arr)
            {
                switch (item[0])
                {
                    case '1':
                        string[] k = item.Split(",");
                        queue.Enqueue(k[1]);
                        break;
                    case '2':
                        queue.Dequeue();
                        break;
                    case '3':
                        var peek = queue.Peek();
                        Console.WriteLine(peek);
                        break;
                    case '4':
                        bool isEmpty = queue.IsEmpty;
                        break;
                    case '5':
                        queue.Show();
                        break;
                }
            }
        }

        public string[] FileRead(string path)
        {
            return File.ReadAllText(path).Split(" ");
        }
    }
}

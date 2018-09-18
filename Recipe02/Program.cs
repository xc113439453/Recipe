using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Recipe02
{
    class Program
    {
        static void Main(string[] args)
        {
            const string MutexName = "Multithreading";
            using (var m = new Mutex(false, MutexName))
            {
                // WaitOne方法的作用是阻止当前线程，直到收到其他实例释放的处理信号。
                // 第一个参数是等待超时时间，第二个是否退出上下文同步域。
                if (!m.WaitOne(TimeSpan.FromSeconds(10), false))
                {
                    WriteLine("Second instance is running!");
                    ReadLine();
                }
                else
                {
                    WriteLine("Running!");
                    ReadLine();
                    // 释放互斥资源
                    m.ReleaseMutex();
                }
            }
            ReadLine();
        }
    }
}

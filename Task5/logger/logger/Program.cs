using InterfaceIListener;
using System;

namespace logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger loger = new Logger();
            string path = @"D:\GitClone3.20.21\TC\Task5\ListenersConfig.json"; 
           
            
            loger.ParseConfig(path);
            loger.Log("Message", LogLevel.Warning);
            
           

            Number num1 = new Number(10);

            loger.Track(num1,path);        
        }
    }
}

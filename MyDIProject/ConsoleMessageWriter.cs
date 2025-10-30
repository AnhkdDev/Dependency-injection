using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDIProject
{
    public class ConsoleMessageWriter : IMessageWriter
    {
        private readonly INullInterface? nullInterface;
        public ConsoleMessageWriter(INullInterface nullInterface)
        {
            this.nullInterface = nullInterface;
        }
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}

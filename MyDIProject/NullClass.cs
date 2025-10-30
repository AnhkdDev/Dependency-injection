using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDIProject
{
    public class NullClass : INullInterface
    {
        public void DoSomething()
        {
            throw new NotImplementedException();
        }
    }
}

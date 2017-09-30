using IGrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Grains;
using System.Threading.Tasks;
using Orleans;

namespace Grains
{
    public class BasicGrain : Grain, IGrains.IBasic
    {
        public Task<string> sayHello(string hellostr)
        {
            Console.WriteLine(string.Format("{0}:{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm"), hellostr));
            return Task.FromResult<string>("done");
        }
    }
}

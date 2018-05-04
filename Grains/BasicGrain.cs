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
        /// <summary>
        /// 延迟的消息
        /// </summary>
        /// <param name="hellomsg"></param>
        /// <returns></returns>
        public Task<string> DelayMsg(string hellomsg)
        {
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("{0}:延迟消息---{1}",DateTime.Now.ToString("HH:mm:ss.fff"),hellomsg);
            return Task.FromResult<string>("延迟的Done");
        }
    }
}

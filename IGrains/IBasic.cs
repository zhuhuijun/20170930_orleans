using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGrains
{
    public interface IBasic: IGrainWithIntegerKey
    {
        Task<string> sayHello(string hellostr);
        /// <summary>
        /// 延迟三秒的消息
        /// </summary>
        /// <param name="hellomsg"></param>
        /// <returns></returns>
        Task<string> DelayMsg(string hellomsg);
    }

}

using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGrains;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            run();
            Console.ReadLine();
        }
        static async void run()
        {
            //利用内置方法获得一个配置类,这个类调用服务端端口1234
            //可以使用配置文件，这里先使用简单的配置类
            var config = Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo(1234);
            //初始化GrainClient
            GrainClient.Initialize(config);
            //从solr出获得一个BasicGrain的接口
            var basic = GrainClient.GrainFactory.GetGrain<IGrains.IBasic>(314);
            //调用反射方法
            string result = await basic.sayHello("你好啊");
            Console.WriteLine(result);
        }
    }
}

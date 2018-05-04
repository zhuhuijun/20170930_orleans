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
            Console.WriteLine("请输入:");
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
            var basic2 = GrainClient.GrainFactory.GetGrain<IGrains.IBasic>(315);

            //调用反射方法
            basic.DelayMsg("延迟的---你好吗?");
            basic2.sayHello("你坏啊！");
            string result = await basic.sayHello("你好啊");
            Console.WriteLine(result);


            var grainFactory = GrainClient.GrainFactory;
            var e0 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
            var e1 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
            var e2 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
            var e3 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
            var e4= grainFactory.GetGrain<IEmployee>(Guid.NewGuid());

            var m0 = grainFactory.GetGrain<IManager>(Guid.NewGuid());
            var m1 = grainFactory.GetGrain<IManager>(Guid.NewGuid());
            var m0e = m0.AsEmloyee().Result;
            var m1e = m1.AsEmloyee().Result;

            m0e.Promote(10);
            m1e.Promote(11);

            m0.AddDirectReport(e0).Wait();
            m0.AddDirectReport(e1).Wait();
            m0.AddDirectReport(e2).Wait();

            m1.AddDirectReport(m0e).Wait();
            m1.AddDirectReport(e3).Wait();
            m1.AddDirectReport(e4).Wait();
        }
    }
}

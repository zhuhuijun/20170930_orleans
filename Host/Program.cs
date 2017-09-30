using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            //获得一个配置实例
            //它需要两个端口一个端口2234是用来solr与solr之间通信的，第二个端口1234适用于向client端展示的
            var config = Orleans.Runtime.Configuration.ClusterConfiguration.LocalhostPrimarySilo(2234, 1234);
            //初始化一个solrhost,这里使用了Orleans提供的solrhost，而不是solr
            Orleans.Runtime.Host.SiloHost solrhost = new Orleans.Runtime.Host.SiloHost("Ba", config);
            solrhost.InitializeOrleansSilo();
            solrhost.StartOrleansSilo();
            //检查一下
            if (solrhost.IsStarted)
            {
                Console.WriteLine("solrhost启动成功");
            }
            else
            {
                Console.WriteLine("solrhost启动失败");

            }
            Console.ReadLine();
        }
    }
}

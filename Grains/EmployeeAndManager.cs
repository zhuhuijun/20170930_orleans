using IGrains;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grains
{
    /// <summary>
    /// Employee
    /// </summary>
    public class Employee : Grain, IEmployee
    {
        private int _level;
        private IManager _manager;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<int> GetLeval()
        {
            return Task.FromResult(_level);
        }

        public Task<IManager> GetManager()
        {
            return Task.FromResult(_manager);
        }

        public Task Greeting(IEmployee from, string msg)
        {
            Console.WriteLine("{0} said :{1}", from.GetPrimaryKey().ToString(), msg);
            return Task.CompletedTask;
        }

        public Task Promote(int level)
        {
            _level = level;
            return Task.CompletedTask;
        }

        public Task SetManager(IManager manager)
        {
            _manager = manager;
            return Task.CompletedTask;
        }
    }
    /// <summary>
    /// Manager
    /// </summary>
    public class Manager : Grain, IManager
    {
        public override Task OnActivateAsync()
        {
            //获取和自己一样标识的一个IEmployee代表自己，注意在Grain调用GetGrain的方法
            _me = this.GrainFactory.GetGrain<IEmployee>(this.GetPrimaryKey());
            return base.OnActivateAsync();
        }
        public async Task AddDirectReport(IEmployee employee)
        {
            _reports.Add(employee);
            await employee.SetManager(this);
            await employee.Greeting(_me, "welcome to team");
            return ;
        }

        public Task<IEmployee> AsEmloyee()
        {
            return Task.FromResult(_me);
        }

        public Task<List<IEmployee>> GetDirectReport()
        {
            return Task.FromResult(_reports);


        }
        private IEmployee _me;
        private List<IEmployee> _reports = new List<IEmployee>();
    }
}

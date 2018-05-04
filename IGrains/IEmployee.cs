using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGrains
{
    public interface IEmployee : IGrainWithGuidKey
    {

        /// <summary>
        /// 获得员工的等级
        /// </summary>
        /// <returns></returns>
        Task<int> GetLeval();
        /// <summary>
        /// 提升员工的等级
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        Task Promote(int level);
        /// <summary>
        /// 获得管理员工的经理
        /// </summary>
        /// <returns></returns>
        Task<IManager> GetManager();
        /// <summary>
        /// 设置此员工的管理者
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        Task SetManager(IManager manager);
        /// <summary>
        /// 标示某个员工向自己发送了一个问候
        /// </summary>
        /// <param name="from"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        Task Greeting(IEmployee from, string msg);
    }

    public interface IManager : IGrainWithGuidKey
    {
        /// <summary>
        /// 经理也可以是员工
        /// </summary>
        /// <returns></returns>
        Task<IEmployee> AsEmloyee();
        /// <summary>
        /// 获得经理的直属员工
        /// </summary>
        /// <returns></returns>
        Task<List<IEmployee>> GetDirectReport();
        /// <summary>
        /// 把员工加入到自己的直属团队
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task AddDirectReport(IEmployee employee);
    }
}

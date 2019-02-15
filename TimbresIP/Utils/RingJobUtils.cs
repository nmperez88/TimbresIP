using Newtonsoft.Json;
using Quartz;
using System;
using System.Threading.Tasks;

namespace TimbresIP.Utils
{
    /// <summary>
    /// Tareas para timbres de llamadas.
    /// </summary>

    //[DisallowConcurrentExecution, PersistJobDataAfterExecution]
    class RingJobUtils : IJob
    {

        /// <summary>
        /// Tareas para timbres, sonidos generales y otros.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.MergedJobDataMap;
            SoftPhoneUtils softPhoneUtils = (SoftPhoneUtils)JsonConvert.DeserializeObject(dataMap.GetString("softPhone"), Type.GetType("TimbresIP.Utils.SoftPhoneUtils"));

            softPhoneUtils.start();

            return Task.CompletedTask;
        }
    }
}

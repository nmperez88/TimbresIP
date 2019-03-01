using Newtonsoft.Json;
using Quartz;
using System;
using System.Threading.Tasks;

namespace STA.Utils
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

            if (dataMap.GetString("softPhone") != null && !dataMap.GetString("softPhone").Equals(""))
            {
                SoftPhoneUtils softPhoneUtils = (SoftPhoneUtils)JsonConvert.DeserializeObject(dataMap.GetString("softPhone"), Type.GetType("TimbresIP.Utils.SoftPhoneUtils"));
                softPhoneUtils.start();
            }

            if (dataMap.GetString("jackCable") != null && !dataMap.GetString("jackCable").Equals(""))
            {
                JackCableUtils jackCableUtils = (JackCableUtils)JsonConvert.DeserializeObject(dataMap.GetString("jackCable"), Type.GetType("TimbresIP.Utils.JackCableUtils"));
                jackCableUtils.start();
            }

            return Task.CompletedTask;
        }
    }
}

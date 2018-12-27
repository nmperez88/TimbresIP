using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using TimbresIP.Model;
using Newtonsoft.Json;

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

            //BaseUtils.log.Info(string.Format("Iniciando llamada({0})", callServer.domainHost));

            return Task.CompletedTask;
        }
    }
}

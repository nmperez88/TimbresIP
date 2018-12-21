using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace TimbresIP.Utils
{
    /// <summary>
    /// Tareas para timbres de llamadas.
    /// </summary>
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
            //string auto = dataMap.GetObjectData();

            switch (context.JobDetail.Key.ToString())
            {
                case "app.rings":
                    Console.WriteLine(string.Format("[{0}]: Timbres de aplicación!", DateTime.Now));
                    break;

                case "app.generalSound":
                    Console.WriteLine(string.Format("[{0}]: Sonidos generales!", DateTime.Now));
                    break;

                case "app.others":
                    Console.WriteLine(string.Format("[{0}]: Otros sonidos!.", DateTime.Now));
                    break;
            }

            return Task.CompletedTask;
        }
    }
}

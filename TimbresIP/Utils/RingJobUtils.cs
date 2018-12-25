﻿using System;
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
            Boolean registrationRequired = dataMap.GetBoolean("registrationRequired");
            String domainHost = dataMap.GetString("domainHost");
            String domainPort = dataMap.GetString("domainPort");
            ConnectionCallServerModel connectionCallServer = (ConnectionCallServerModel)JsonConvert.DeserializeObject(dataMap.GetString("connectionCallServer"));
            CallServerModel callServer = (CallServerModel)JsonConvert.DeserializeObject(dataMap.GetString("callServer"));
            SoftPhoneUtils softPhoneUtils = (SoftPhoneUtils)JsonConvert.DeserializeObject(dataMap.GetString("softPhone"));

            softPhoneUtils.start(registrationRequired, domainHost, domainPort, connectionCallServer, callServer);

            Console.WriteLine(string.Format("[{0}]: domainHost: {1}", DateTime.Now, domainHost));

            //string groupJob = dataMap.GetString("groupJob");

            //switch (context.JobDetail.Key.ToString())
            //{
            //    case "app.rings":
            //        Console.WriteLine(string.Format("[{0}]: Timbres de aplicación!", DateTime.Now));
            //        break;

            //    case "app.generalSound":
            //        Console.WriteLine(string.Format("[{0}]: Sonidos generales!", DateTime.Now));
            //        break;

            //    case "app.others":
            //        Console.WriteLine(string.Format("[{0}]: Otros sonidos!.", DateTime.Now));
            //        break;
            //}

            return Task.CompletedTask;
        }
    }
}

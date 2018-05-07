using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.Collections.Specialized;
using Quartz.Impl;
using System.Threading.Tasks;
using System.IO;

namespace Enchere.Dal {
    public class Class1 {
        ITrigger trigger = TriggerBuilder.Create()
      .WithIdentity("IDGJob", "IDG")  
      .StartNow()
      .WithSimpleSchedule(s => s
      .WithIntervalInSeconds(10)
      .RepeatForever())
      .Build();
    }

    public class IDGJob : IJob {
        Task IJob.Execute(IJobExecutionContext context) {
            throw new NotImplementedException();
        }

        public void Execute(IJobExecutionContext context) {
            using (StreamWriter streamWriter = new StreamWriter(@"D:\IDGLog.txt", true)) {
                streamWriter.WriteLine(DateTime.Now.ToString());
            }
        }
    }

    public class JobScheduler {

        public static void Start() {

            IScheduler scheduler = (IScheduler)StdSchedulerFactory.GetDefaultScheduler();

            scheduler.Start();

            IJobDetail job = JobBuilder.Create<IDGJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()

                .WithIdentity("IDGJob", "IDG")
                .WithCronSchedule("0 0/1 * 1/1 * ? *")
                .StartAt(DateTime.UtcNow)
                .WithPriority(1)
                .Build();

            scheduler.ScheduleJob(job, trigger);

        }

    }
}
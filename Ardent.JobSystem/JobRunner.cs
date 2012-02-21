using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardent.JobSystem
{
    /// <summary>
    /// This class runs the Jobs. Set the JobRepository property before you try to run the Execute() function
    /// </summary>
    public class JobRunner
    {
        /// <summary>
        /// Repository to get and update jobs (set this before running Execute())
        /// </summary>
        public IJobRepository JobRepository { get; set; }

        public delegate void OnJobErrorEventHandler(IJob job, Exception ex);
        /// <summary>
        /// Event is fired when a job fails (hook into this for logging)
        /// </summary>
        public event OnJobErrorEventHandler OnJobError;

        /// <summary>
        /// Will run all the jobs given by the IJobRepository.GetRunnableJobs()
        /// </summary>
        public void Execute()
        {
            if (JobRepository == null)
            {
                throw new NotImplementedException("No JobRepository set.");
            }

            var jobs = JobRepository.GetRunnableJobs();

            var jobTasks = new List<Task>();

            foreach (var job in jobs)
            {
                var jobTask = Task.Factory.StartNew(() =>
                    {
                        job.Execute();
                    })
                    .ContinueWith((task) =>
                    {
                        HandleJobCompleted(job, task);
                    });
            }

            //Wait for them all to continue
            Task.WaitAll(jobTasks.ToArray());
        }

        private void HandleJobCompleted(IJob job, Task task)
        {
            var success = true;
            if (task.IsFaulted)
            {
                success = false;
                if (OnJobError != null)
                {
                    Exception taskException = null;
                    if (task.Exception != null)
                    {
                        taskException = task.Exception;
                    }
                    else
                    {
                        taskException = new NullReferenceException("Job failed with no Exception");
                    }
                    OnJobError(job, taskException);
                }
            }

            JobRepository.UpdateJob(job, success);
        }

    }
}

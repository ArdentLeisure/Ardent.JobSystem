using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ardent.JobSystem
{
    /// <summary>
    /// Interface to create a runnable Job
    /// </summary>
    public interface IJob
    {
        /// <summary>
        /// unique identifier for the job (used by IJobRepository)
        /// </summary>
        int JobId { get; set; }
        /// <summary>
        /// The Minutes delay until this Jobs next run
        /// </summary>
        int DelayMinutes { get; }
        /// <summary>
        /// This function gets called by the JobRunner when its time for the job to run
        /// </summary>
        void Execute();
    }
}

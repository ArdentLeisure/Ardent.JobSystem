using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ardent.JobSystem
{
    /// <summary>
    /// Repository for storing Jobs
    /// </summary>
    public interface IJobRepository
    {
        /// <summary>
        /// Gets all runnable Jobs
        /// Should mark the job as InQueue so running the function again doesn't pickup a long running job
        /// </summary>
        /// <returns></returns>
        IList<IJob> GetRunnableJobs();

        /// <summary>
        /// Updates a job after executing it
        /// </summary>
        /// <param name="job">The instance of the job run</param>
        /// <param name="success">If the job was successful</param>
        void UpdateJob(IJob job, bool success);
    }
}

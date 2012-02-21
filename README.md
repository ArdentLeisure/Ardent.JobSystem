A Job based task library for running background integration jobs.

Used for background integration jobs for PurpleSmoke (shop.dreamworld.com.au)

Example Usage:

```csharp
    var jobRunner = new JobRunner();
    jobRunner.JobRepository = new JobRepo(); //IJobRepository implementation
    jobRunner.Execute();
```
A Programmable Task scheduler used for background integration.

Used for background integration jobs for PurpleSmoke ([shop.dreamworld.com.au](http://shop.dreamworld.com.au))

Example Usage:

```csharp
    var jobRunner = new JobRunner();
    jobRunner.JobRepository = new JobRepo(); //IJobRepository implementation
    jobRunner.Execute();
```
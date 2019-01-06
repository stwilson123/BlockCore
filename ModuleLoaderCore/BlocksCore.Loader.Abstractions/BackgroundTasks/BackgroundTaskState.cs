using System;

namespace BlocksCore.Loader.Abstractions.BackgroundTasks
{
    public class BackgroundTaskState
    {
        public string Name { get; set; }
        public DateTime LastStartTime { get; set; }
    }
}

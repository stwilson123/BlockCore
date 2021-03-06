using System;

namespace BlocksCore.Loader.Abstractions.BackgroundTasks
{
    public class BackgroundTaskSettings
    {
        public string Name { get; set; } = String.Empty;
        public bool Enable { get; set; } = true;
        public string Schedule { get; set; } = "* * * * *";
        public string Description { get; set; } = String.Empty;
    }
}
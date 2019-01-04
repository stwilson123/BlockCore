using BlocksCore.Abstractions.Modules.ModuleDescription;

[assembly: Module(Name = "TestModule",
    Author = "BlocksAuthor",
    Version = "1.0.0.0"
)]

[assembly: Feature(Id = "TestModule.Feature1"
    
)]

[assembly: Feature(Id = "TestModule.Feature2",
     Dependencies = new[] { "TestModule.Feature1" }

)]

[assembly: Feature(Id = "TestModule.Feature3",
     Dependencies = new[] { "TestModule.Feature2" }

)]
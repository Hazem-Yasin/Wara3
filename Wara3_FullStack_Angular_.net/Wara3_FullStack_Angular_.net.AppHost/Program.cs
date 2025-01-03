var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Wara3_FullStack_Angular__net_Server>("wara3-fullstack-angular-net-server");

builder.Build().Run();

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.TicketInterface>("ticketinterface");

builder.Build().Run();

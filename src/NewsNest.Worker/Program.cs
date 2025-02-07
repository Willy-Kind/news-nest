using NewsNest.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddNewsApiClient(builder.Configuration);
var host = builder.Build();
host.Run();
using MyDIProject;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddTransient<IMessageWriter, ConsoleMessageWriter>();
//builder.Services.AddTransient<INullInterface, NullClass>();
builder.Services.AddSingleton<INullInterface>(services => new NullClass());



var host = builder.Build(); 
host.Run();

using NotificarCandidatos.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddNotificadorPedidosWorker(builder.Configuration);

var host = builder.Build();
host.Run();

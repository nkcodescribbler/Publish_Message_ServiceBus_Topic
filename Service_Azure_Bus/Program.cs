using Service_Azure_Bus.AzureServiceBus;

var builder = WebApplication.CreateBuilder(args);

// DI setup
builder.Services.Configure<ServiceBusOptions>(builder.Configuration.GetSection("ServiceBus"));
builder.Services.AddSingleton<IServiceBusSenderFactory, ServiceBusSenderFactory>();
builder.Services.AddSingleton<MessagePublisher>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

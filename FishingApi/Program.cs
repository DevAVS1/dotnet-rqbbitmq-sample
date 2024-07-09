using FishingApi.Data.Repositories;
using FishingApi.Services;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<FishRepository>();
builder.Services.AddScoped<FishService>();
builder.Services.AddTransient<FishingRequestService>();


// Add services to the container.
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

app.UseRouting();

app.UseEndpoints(endpoints => 
    {
        endpoints.MapControllers();
    });

app.Run();

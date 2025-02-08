using CallStoredProcedureDemo.Models;
using CallStoredProcedureDemo.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string cnstring = "server=.\\sqlexpress;Database=IndigoAirlines;Integrated Security=true;Trust Server Certificate=true";
builder.Services.AddSqlServer<IndigoAirlinesContext>(cnstring);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserService, UserUtility>();

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

using ApiTareas.Data;
using ApiTareas.Data.Repositories;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(mySQLConfiguration);
builder.Services.AddScoped<IRolRepository,RolRepository>();
builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>();
builder.Services.AddScoped<IEstadoTareaRepository, EstadoTareaRepository>();
builder.Services.AddScoped<ITareaRepository, TareaRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

builder.Logging.AddConsole().SetMinimumLevel(LogLevel.Debug);
builder.Logging.AddDebug();

//builder.Services.AddSingleton(new MySqlConnection(builder.Configuration.GetConnectionString("MySqlConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

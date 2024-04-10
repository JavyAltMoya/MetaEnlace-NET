using CitasMedicas.BBDD;
using CitasMedicas.Implements;
using CitasMedicas.Interfaces;
using CitasMedicas.Repository;
using CitasMedicas.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CitasMedicasDB>(options => options.UseSqlServer("name=ConnectionStrings:connection"));
// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPacientService, PacientService>();
builder.Services.AddScoped<IMedicService, MedicService>();
builder.Services.AddScoped<IAppoService, AppoService>();
builder.Services.AddScoped<IDiagService, DiagService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<CitasMedicasDB>(opt => opt.UseInMemoryDatabase("CitasMedicas"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
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

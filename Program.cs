using corewebapi.Model;
using corewebapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<UserDBSettings>(
    builder.Configuration.GetSection("BlogDatabase")
);
builder.Services.Configure<StudentDBSettings>(
    builder.Configuration.GetSection("StudentDatabase")
);
builder.Services.AddSingleton<StudentService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (options) =>
    {
        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("default");

app.UseAuthorization();

app.MapControllers();

app.Run();

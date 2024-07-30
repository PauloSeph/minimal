using minimalAPIandCors;
using minimalAPIandCors.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
{
    policy.WithOrigins("http://localhost:4200/", "https://localhost:4200/");
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.PersonRouteMaps();

app.UseCors();



app.Run();













// builder.Services.AddCors(options => options.AddDefaultPolicy(policy => {
//     policy.AllowAnyOrigin();
//     policy.AllowAnyMethod();
//     policy.AllowAnyHeader();
// }));

// app.UseCors();
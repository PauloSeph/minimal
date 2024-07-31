using minimalAPIandCors;
using minimalAPIandCors.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

builder.Services.AddLogging();

builder.Services.AddCors(
options =>
{
    options.AddPolicy("DefaultPolicy",
               builder =>
               {
                   builder.WithOrigins(allowedOrigins!)
                          .AllowAnyHeader()
                          .AllowAnyMethod();
               });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("DefaultPolicy");

app.UseMiddleware<RequestLoggingMiddleware>();

app.PersonRouteMaps();
app.Run();













// builder.Services.AddCors(options => options.AddDefaultPolicy(policy => {
//     policy.AllowAnyOrigin();
//     policy.AllowAnyMethod();
//     policy.AllowAnyHeader();
// }));

// app.UseCors();
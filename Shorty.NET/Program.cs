using Shorty.NET;
using Shorty.NET.Configuration;
using Shorty.NET.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppDependencies(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

// app.UseStaticFiles();

// app.UseAuthorization();

app.UseGlobalErrorHandler(logger:app.Logger);

app.RegisterApplicationRoutes();

app.Run();
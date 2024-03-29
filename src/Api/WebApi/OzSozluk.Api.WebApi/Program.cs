using FluentValidation.AspNetCore;
using OzSozluk.Api.Application.Extensions;
using OzSozluk.Api.WebApi.Infrastructure.ActionFilters;
using OzSozluk.Api.WebApi.Infrastructure.Extensions;
using OzSozluk.Infrastructure.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers(opt => opt.Filters.Add<ValidateModelStateFilter>())
    .AddJsonOptions(opt =>
   {
       opt.JsonSerializerOptions.PropertyNamingPolicy = null;
   })
    .AddFluentValidation()
        .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add authentication
builder.Services.ConfigureAuth(builder.Configuration);


builder.Services.AddApplicationRegistiration();
builder.Services.AddInfrastructureRegistiration(builder.Configuration);

//add cors
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
 {
     builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
 }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureExceptionHandling(app.Environment.IsDevelopment());

//maplerden once auth eklenmis olmali
app.UseAuthentication();

app.UseAuthorization();

app.UseCors("MyPolicy");

app.MapControllers();

app.Run();

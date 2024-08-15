using TestLifeTime.Filter;
using TestLifeTime.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LifeTimeIndicatrorFilter>();
//builder.Services.AddTransient<IdGenerator>();
//when Register IdGenerator As Transient And call GetId , Two diffrent Guid Generate one for GetId Result Another for LifeTimeIndicatrorFilter. (with each Request this repeat again)

//builder.Services.AddSingleton<IdGenerator>();
//when Register IdGenerator As Singleton And call GetId , One  Guid Generate for GetId Result and LifeTimeIndicatrorFilter. (with All Request this dosent Change) -- the same instance will be use in life time controller

builder.Services.AddScoped<IdGenerator>();
//when Register IdGenerator As Scoped And call GetId , One  Guid Generate  for GetId Result and LifeTimeIndicatrorFilter. (With Each Request It Change) in ordre two scope mean use Same Instace in one scope.

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

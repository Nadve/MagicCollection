using aspnetserver.Models;
using aspnetserver.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My Magic the Gathering Collection",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "My Magic the Gathering Collection";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API");
    swaggerUIOptions.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.MapGet("/get-all-users", async () => await UserRepository.GetUsersAsync())
    .WithTags("Users Endpoints");

app.MapGet("/get-user-by-id/{userId}", async (int userId) =>
{
    var user = await UserRepository.GetUserByIdAsync(userId);
    return user != null
        ? Results.Ok(user)
        : Results.BadRequest();
}).WithTags("Users Endpoints");

app.MapPost("/create-user", async (User user) =>
{
    return await UserRepository.CreateUserAsync(user)
        ? Results.Ok("Create successful")
        : Results.BadRequest();
}).WithTags("Users Endpoints");

app.MapPut("/update-user", async (User user) =>
{
    return await UserRepository.UpdateUserAsync(user)
        ? Results.Ok("Update successful")
        : Results.BadRequest();
}).WithTags("Users Endpoints");

app.MapDelete("/delete-user/{userId}", async (int userId) =>
{
    return await UserRepository.DeleteUserAsync(userId)
        ? Results.Ok("Deletion successful")
        : Results.BadRequest();
}).WithTags("Users Endpoints");

var data = JsonDeserializer.Deserialize();
await FinishRepository.SyncFinishes(data);
await ImageRepository.SyncImages(data);
app.Run();

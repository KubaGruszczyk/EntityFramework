using Microsoft.EntityFrameworkCore;
using MyBoards.Entities;
using System.Collections.Immutable;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyBoardsContext>(
    option=>option.UseSqlServer(builder.Configuration.GetConnectionString("MyBoardsConnectionString")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<MyBoardsContext>();

var pendigMigrations = dbContext.Database.GetPendingMigrations();

if(pendigMigrations.Any())
{
    dbContext.Database.Migrate();
}

var users = dbContext.Users.ToList();
if(!users.Any())
{
    var user1 = new User
    {
        FullName = "Jakub Gruszczyk",
        Email = "user1@test.com",
        Address = new Address
        {
            City = "Warszawa",
            Street = "Szeroka 8"
        }
    };
    var user2 = new User
    {
        FullName = "Tomasz Knapik",
        Email = "user2@test.com",
        Address = new Address
        {
            City = "Torun",
            Street = "W¹ska 18"
        }
    };
    dbContext.Users.Add(user1);
    dbContext.Users.Add(user2);
    dbContext.SaveChanges();
}

app.MapGet("data", async (MyBoardsContext db) =>
{

    var epics = await db.Epics.Where(e => e.StateId == 4)
    .OrderBy(x => x.Priority)
    .ToListAsync();

    var theBestAuthor = await db.Comments.GroupBy(c => c.AuthorId)
    .Select(g => new { athorId = g.Key, count = g.Count() })
    .OrderByDescending(x => x.count)
    .ToListAsync();

    var userDetails = db.Users.FirstOrDefault(u => u.Id == theBestAuthor.First().athorId);
    return userDetails;
});

app.MapPost("Update", async (MyBoardsContext db) =>
{
    var epic = await db.Epics.FirstAsync(e => e.Id == 1);

    var onHoldState = await db.WorkItemStates.FirstAsync(wis => wis.Value == "On Hold");

    epic.StateId = onHoldState.Id;

    await db.SaveChangesAsync();

    return epic;

});
app.Run();


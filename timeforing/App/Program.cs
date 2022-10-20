using Microsoft.EntityFrameworkCore;
using App.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<TimekeepingContext>(options =>
options.UseSqlite($"Data Source={Path.Combine("Infrastructure", "Data", "dataSQLite.db")}"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
   if (app.Environment.IsDevelopment()){
    var db = scope.ServiceProvider.GetRequiredService<TimekeepingContext>();
     if (!db.Projects.Any())
        {
            new DatabaseSeed(db).Seed();
        }
}
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

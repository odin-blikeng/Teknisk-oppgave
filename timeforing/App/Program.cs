using Microsoft.EntityFrameworkCore;
using App.Infrastructure.Data;
using App.ClassLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddDbContext<TimekeepingContext>(options =>
// options.UseSqlite($"Data Source={Path.Combine("Infrastructure", "Data", "dataSQLite.db")}"
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
)
);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TimekeepingContext>();
     if (!db.Projects.Any())
        {
            new DatabaseSeed(db).Seed(scope.ServiceProvider.GetRequiredService<IProjectService>());
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
app.UseSession();

app.MapRazorPages();

app.Run();

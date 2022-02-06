using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using To_doProject.Business;
using To_doProject.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Get connection string to connect DB
var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<ToDoDbContext>(x => x.UseSqlServer(connectionString));


//services.AddDbContext<CoreDbContext>(op => op.UseSqlServer(Configuration.GetConnectionString("Database")));

//Dependancy injection
builder.Services.AddScoped<IToDoListManager, ToDoListManager>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "api",
    pattern:
    "api/{controller = ToDoLists}/{action = CreateToDoList}");


app.Run();

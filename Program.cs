using Microsoft.EntityFrameworkCore;
using WebApplication2.Infrastructure;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);
/*public IConfiguration Configuration { get; }*/

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAddService, AddService>();
builder.Services.AddDbContext<PersonDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.Run();

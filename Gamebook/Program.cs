using Gamebook.Model;
using Gamebook.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(SessionStorage<>));
builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(120));// samotný mechanismus session
builder.Services.AddMemoryCache(); // uložištì pro session
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // pro zpøístupnìní Session uvnitø služeb a stránek
builder.Services.AddSingleton<SessionStorage<LocationProvider>>();
builder.Services.AddSingleton<ILocationProvider, LocationProvider>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

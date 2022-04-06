using Gamebook.Model;
using Gamebook.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(SessionStorage<>));
builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(120));// samotn� mechanismus session
builder.Services.AddMemoryCache(); // ulo�i�t� pro session
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // pro zp��stupn�n� Session uvnit� slu�eb a str�nek
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

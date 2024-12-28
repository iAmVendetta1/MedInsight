using MedInsight.Models;
using Microsoft.EntityFrameworkCore;
using MedInsight.Services;
using System.Net.Http.Headers; // For configuring HttpClient handler


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the DbContext with the dependency injection container
builder.Services.AddDbContext<MedInsightDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MedInsightDB")));

// Register PredictionService with HttpClient
builder.Services.AddHttpClient<PredictionService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/");  // Match this to your Flask app's port
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

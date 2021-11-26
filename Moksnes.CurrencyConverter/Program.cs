using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using Moksnes.CurrencyConverter.Shared;

var builder = WebApplication.CreateBuilder(args);

IConfiguration config = builder.Configuration;

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new CurrencyJsonConverter());
});

builder.Services.Configure<CurrencyConfig>(config.GetSection(CurrencyConfig.ConfigName));

builder.Services.AddHttpClient(CurrencyConfig.ClientName, (provider, client) =>
{
    var options = provider.GetRequiredService<IOptions<CurrencyConfig>>();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.BaseAddress = new Uri(options.Value.BaseUri);
});

builder.Services.AddTransient<ICurrencyService, CurrencyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

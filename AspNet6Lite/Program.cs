
//
// Configure Services
//

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AspNet6Lite.AppData.AppDbContext>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages();

var mvcBuilder = builder.Services
    .AddControllersWithViews()
    .AddSessionStateTempDataProvider()
    // Install-Package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation  
    .AddRazorRuntimeCompilation()
;

//
// Configure
//

var app = builder.Build();

//IServiceScope scope = app.Services.CreateScope();
//IServiceProvider services = scope.ServiceProvider;
//AppDbContext context = services.GetRequiredService<AppDbContext>();
//if (context.Database.EnsureCreated()) await context.Database.MigrateAsync();

//IConfigurationRoot configRoot = new ConfigurationBuilder()
//    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
//    .AddEnvironmentVariables()
//    .AddJsonFile("appsettings.json", optional: false)
//    .AddCommandLine(args)
//    .Build();

await AspNet6Lite.AppData.DataGenerator.Generate(app.Services);

app.UseRouting();

app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run(async (context) => {
    await context.Response.WriteAsync("Service was unable to handle this request.");
});

app.Run();
using FinancialServices.Data;
using FinancialServices.Data.Models;
using FinancialServices.ModelBinders;

using Microsoft.EntityFrameworkCore;
using Theatre.Data.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => 
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

})
    .AddEntityFrameworkStores<FinanceDbContext>();

builder.Services.ConfigureApplicationCookie(options => 
{
    options.LoginPath = "/User/Login";
});



builder.Services.AddControllersWithViews()
     .AddMvcOptions(options =>
     {
         options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
         options.ModelBinderProviders.Insert(0, new DoubleModelBinderProvider());
     });

builder.Services.AddApplicationServices();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{idEik?}");

    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Administration}/{action=Index}/{idEik?}");

    endpoints.MapControllerRoute(
          name: "houseDetails",
          pattern: "Company/Details/{idEik}"
        );

    //app.MapControllerRoute(
    //    name: "info",
    //    pattern: "{controller=Company}/{action=CompanyInfo}/{idEik?}");


    endpoints.MapRazorPages();

});





app.Run();

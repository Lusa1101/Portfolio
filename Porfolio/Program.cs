using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using Porfolio.Data;
using Porfolio.Services;
using sib_api_v3_sdk.Client;
using Supabase;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

//Ensure the builder can access the secrets file
builder.Configuration.AddJsonFile("secrets.json", optional: true, reloadOnChange: true);

//Brevo
//Configuration.Default.ApiKey.Add("api-key", builder.Configuration["Brevo:ApiKey"]);
//builder.Services.AddTransient<BrevoEmailService>();

//Backfround running
//builder.Services.AddHostedService<BackgroundService>();

//Add Supabase api
try
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql(Environment.GetEnvironmentVariable("DefaultConnection"));
    });

    var supabaseSection = builder.Configuration.GetSection("Supabase");
    var url = supabaseSection["BaseUrl"];
    var key = supabaseSection["ApiKey"];
    var options = new SupabaseOptions
    {
        AutoRefreshToken = true,
        AutoConnectRealtime = true,
        // SessionHandler = new SupabaseSessionHandler() <-- This must be implemented by the developer
    };
    // Note the creation as a singleton.
    builder.Services.AddSingleton(provider => new Supabase.Client(url!, key, options));

    //Mailkit
    builder.Services.AddTransient<MailKitSender>();
}
catch (Exception ex)
{
    Debug.WriteLine(ex.Message);
}


//Add services for email
//builder.Services.AddTransient<IEmailSender, EmailSender>();
//builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("EMAIL_CONFIGURATION"));


//Allow razor apges
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

//For debugging on my android
//app.Urls.Add("http://0.0.0.0:5000"); // Allow access from any device
//app.Urls.Add("http://omphulusamashau.ac.za"); // Replace with your local IP

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

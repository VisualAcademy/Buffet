using Hawaso.Areas.Identity;
using Hawaso.Areas.Identity.Models;
using Hawaso.Data;
using Hawaso.Models.Candidates;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Hawaso.Areas.Identity.Services; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


#region 새로운 DbContext 추가 - CandidateAppDbContext
// 새로운 DbContext 추가 

//[a] MVC, RazorPages, Web API에서는 DbContext 사용 가능
//builder.Services.AddDbContext<CandidateAppDbContext>(options => options.UseSqlServer(connectionString));

//[b] Blazor Server에서는 DbContextFactory 사용 권장
builder.Services.AddDbContextFactory<CandidateAppDbContext>(options => options.UseSqlServer(connectionString));
#endregion


builder.Services.AddDatabaseDeveloperPageExceptionFilter();


//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
builder.Services.AddSingleton<WeatherForecastService>();


// 종속성 주입 추가 
builder.Services.AddTransient<IEmailSender, EmailSender>();


var app = builder.Build();

// 개발 환경에서 Update-Database, Seed 데이터 추가
if (app.Environment.IsDevelopment())
{
    await CheckCandidateDbMigrated(app.Services);
    CandidateSeedData(app);
    CandidateDbInitializer.Initialize(app);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();





#region CandidateSeedData: Candidates 테이블에 기본 데이터 입력
// Candidates 테이블에 기본 데이터 입력
static void CandidateSeedData(WebApplication app)
{
    // https://docs.microsoft.com/ko-kr/aspnet/core/fundamentals/dependency-injection
    // ?view=aspnetcore-6.0#resolve-a-service-at-app-start-up
    using (var serviceScope = app.Services.CreateScope())
    {
        var services = serviceScope.ServiceProvider;

        var candidateDbContext = services.GetRequiredService<CandidateAppDbContext>();

        // Candidates 테이블에 데이터가 없을 때에만 데이터 입력
        if (!candidateDbContext.Candidates.Any())
        {
            candidateDbContext.Candidates.Add(
                new Candidate { FirstName = "길동", LastName = "홍", IsEnrollment = false });
            candidateDbContext.Candidates.Add(
                new Candidate { FirstName = "두산", LastName = "백", IsEnrollment = false });

            candidateDbContext.SaveChanges();
        }
    }
}
#endregion

#region CheckCandidateDbMigrated: 데이터베이스 마이그레이션 진행
// 데이터베이스 마이그레이션 진행
async Task CheckCandidateDbMigrated(IServiceProvider services)
{
    using var scope = services.CreateScope();
    using var candidateContext = scope.ServiceProvider.GetService<CandidateAppDbContext>();
    if (candidateContext is not null)
    {
        await candidateContext.Database.MigrateAsync();
    }
}
#endregion

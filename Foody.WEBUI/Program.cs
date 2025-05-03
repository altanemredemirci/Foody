using Foody.BLL.Abstract;
using Foody.BLL.Concrete;
using Foody.CORE.Identity;
using Foody.CORE.Mapping;
using Foody.DAL.Abstract;
using Foody.DAL.Concrete;
using Foody.DAL.Concrete.EfCore;
using Foody.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<DataContext>()
              .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    //password
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;

    options.Lockout.MaxFailedAccessAttempts = 5; //5 hatalý giriþ hakký
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //5 hatalý giriþ sonrasý 5dk giriþ kilitlensin
    options.Lockout.AllowedForNewUsers = true; //Her yeni üye için bu özelliði ver.


    //user
    options.User.RequireUniqueEmail = true; //Benzersiz Email zorunluluðu
    //options.User.AllowedUserNameCharacters = ""; //Username de izin verilen özel karakterler

    options.SignIn.RequireConfirmedEmail = false; //Kayýt sonrasý giriþ yapabilmek için Emaili onaylamalý
    options.SignIn.RequireConfirmedPhoneNumber = false; //Kayýt sonrasý giriþ yapabilmek için Telefon numarasý onaylamalý
});

//Configure Cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //Oturum süresi
    options.SlidingExpiration = true; //Herhangi bir harekette süresi tekrar baþlat
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true, 
        Name = "Organic.Security.Cookie",
        SameSite = SameSiteMode.Strict //Oturumu serverdan kullanýcý browserýna taþýdýk
    };
});




// *** Dependency Injection ***
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDal, EfCoreProductDal>();

builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IAboutDal, EfCoreAboutDal>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryDal, EfCoreCategoryDal>();

builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IContactDal, EfCoreContactDal>();

builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IMailDal, EfCoreMailDal>();

#region AddScope,AddTransient,AddSingleton
/*
Service lifetimes(Servis ömürleri) ?

Asp.Net ‘te sunucuya gelen her istek ile yeni bir servis kapsamý oluþturulur, bu istek sona erdiðinde istek ile beraber çözümlenen tüm servisler, servis kapsamý ile beraber temizlenir. Bu servis ömürleri (service lifetimes) , servislerin ne þekilde çözümleneceðini ve temizleneceðini belirler.

Asp.Net Core’da varsayýlan olarak gelen Dependency injection kütüphanesi bize üç adet servis ömrü sunar.

· AddSingleton

· AddScoped

· AddTransient

Bunlarý kýsaca bir özetleyelim daha sonra örnek ile daha detaylý ele alalým.

AddSingleton ?


Uygulamamýz ilk çalýþtýðýnda , servisin bir tane instance ’ýný oluþturur ve bu bilgiyi memory de tutar. Servis her çaðrýldýðýnda en baþta oluþturulan instance ’ý kullanýlýr. Yani ICacheManager dependency injection yapýlan Controller da her hangi bir method’a istek atýldýðýnda, uygulama ilk çalýþtýðý anda memory’e attýðý MyRedisClienti getirir yeniden newlemez.

AddScoped ?


Gelen her istekte yeni bir instance oluþturur. Yani IGeneralManager dependency injection yapýlan Controller da her hangi bir method ’a istek atýldýðýnda bu servis yeniden çaðrýlmýþ olur ve yeni bir instance oluþturur. Ayný istek aþamasýnda bir instance oluþturur ve onu kullanýr, farklý isteklerde yeni bir instance oluþturur.

AddTransient ?


Servis her çaðrýldýðýn da yeni bir instance oluþturur. Yani ayný istek aþamasýnda da farklý isteklerde de servis birden fazla kez çaðrýlýyorsa servis her çaðrýldýðýnda yeni bir instance oluþturur.

Bütün bunlarý daha anlaþýlýr hale getirebilmek için birde örnekler üzerinden bakalým./
*/
#endregion


builder.Services.AddAutoMapper(typeof(MappingProfile));

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
    pattern: "{controller=Admin}/{action=Index}/{id?}");

app.Run();

#region Proje Adýmlarý
/*
Projenize en uygun ve en az revize isteyen Template karar verilmeli.
Proje Þablonu, ihtiyaç duyulan entityler, Veritabaný diagramý ve kullanýlacak mimariye karar verilmeli.
Entity Oluþturulacak
Database iþlemleri -DbContext,DbSet<>
Database CRUD(Create,Read,Update,Delete) komutlarý yazýlýr.
*NKatmalýmimari
HomeController - Index
    *Anasayfadaki elementleri veritabanýnadan gelecek þekilde kodluyoruz.
Anasayfa ve navbar da bulunan sayfalarý oluþturduktan sonra Admin Panel kýsmýna geçilir.


 */
#endregion
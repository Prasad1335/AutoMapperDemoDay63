using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Data;
using WebApplication1.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


///////////////////////////////////////////////////////////////////////////
///
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<UserManagmentContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddScoped<ICrudService<DepartmentViewModel>, DepartmentsService>();
//builder.Services.AddScoped<ICrudService<UserViewModel>, UsersService>();

builder.Services.AddDbContext<UserManagmentContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IDepartmentsService, DepartmentsService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


///////////////////////////////////////////////////////////////////////////






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

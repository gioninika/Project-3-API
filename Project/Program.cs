using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project;
using Project.Configuration;
using Project.Data;
using Project.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProjectDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectDbConnection"));
});
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShopingCartRepository, ShopingCartRepository>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 7;
    options.Password.RequiredUniqueChars = 0;
}).AddEntityFrameworkStores<ProjectDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/api/Registration/Login";
    options.LogoutPath = "/api/Registration/Logout";
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

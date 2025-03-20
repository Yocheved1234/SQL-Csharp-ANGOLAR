using Dal_Repository.Modules;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Dependency Injection for DAL and BLL
builder.Services.AddScoped<IDal_Repository.IDalProduct<Dto_Common_Enteties.ProductDto>, Dal_Repository.ProductDal>();
builder.Services.AddScoped<IBll_Services.IBllProduct, Bll_Services.ProductBll>();

builder.Services.AddScoped<IDal_Repository.IDalBuy<Dto_Common_Enteties.BuyDto>, Dal_Repository.BuyDal>();
builder.Services.AddScoped<IBll_Services.IBllBuy, Bll_Services.BuyBll>();

builder.Services.AddScoped<IDal_Repository.IDalBuyDetail<Dto_Common_Enteties.BuysDetailDto>, Dal_Repository.BuyDetailDal>();
builder.Services.AddScoped<IBll_Services.IBllBuyDetail, Bll_Services.BuyDetailBll>();

builder.Services.AddScoped<IDal_Repository.IDalUser<Dto_Common_Enteties.UserDto>, Dal_Repository.UserDal>();
builder.Services.AddScoped<IBll_Services.IBllUser, Bll_Services.UserBll>();

// Add DbContext
builder.Services.AddDbContext<ChineseAuction1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ChineseAuction1Context")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.MapControllers();

app.Run();

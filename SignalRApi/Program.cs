using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.EntityFramework;
using SignalRApi.Hubs;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddJsonOptions(options=>options.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials();
    });
});

builder.Services.AddDbContext<SignalRContext>();

builder.Services.AddSignalR();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SignalRContext>();

builder.Services.AddScoped<IAboutDal,EfAboutDal>();
builder.Services.AddScoped<IAboutService,AboutMenager>();

builder.Services.AddScoped<IBookingDal,EfBookingDal>();
builder.Services.AddScoped<IBookingService,BookingMenager>();

builder.Services.AddScoped<ICategoryDal,EfCategoryDal>();
builder.Services.AddScoped<ICategoryService,CategoryMenager>();

builder.Services.AddScoped<IContactDal,EfContactDal>();
builder.Services.AddScoped<IContactService,Contactmenager>();

builder.Services.AddScoped<IDiscountDal,EfDiscountDal>();
builder.Services.AddScoped<IDiscountService, DiscountMenager>();

builder.Services.AddScoped<IFeatureDal,EfFeatureDal>();
builder.Services.AddScoped<IFeatureService, FeatureMenager>();

builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductMenager>();

builder.Services.AddScoped<ISocialMediaDal,EfSocialMediaDal>();
builder.Services.AddScoped<ISocialMediaService,SocialMediaMenager>();

builder.Services.AddScoped<ITestimonialDal,EfTestimonialDal>();
builder.Services.AddScoped<ITestimonialService,TestimonialMenager>();

builder.Services.AddScoped<IOrderDal,EfOrderDal>();
builder.Services.AddScoped<IOrderService,OrderMenager>();

builder.Services.AddScoped<IOrderDetailDal,EfOrderDetailDal>();
builder.Services.AddScoped<IOrderDetailService,OrderDetailMenager>();

builder.Services.AddScoped<IMoneyCaseDal,EfMoneyCaseDal>();
builder.Services.AddScoped<IMoneyCaseService,MoneyCaseMenager>();

builder.Services.AddScoped<IMenuTableDal, EfMenuTableDal>();
builder.Services.AddScoped<IMenuTableService, MenuTableMenager>();

builder.Services.AddScoped<ISliderDal,EfSliderDal>();
builder.Services.AddScoped<ISliderService,SliderMenager>();

builder.Services.AddScoped<IBasketService, BasketMenager>();
builder.Services.AddScoped<IBasketDal, EfBasketDal>();

builder.Services.AddScoped<INotificationService, NotificationMenager>();
builder.Services.AddScoped<INotificationDal, EfNotificationDal>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.MapHub<SignalRHub>("/SignalRHub");

app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();

app.Run();

using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Container;

public static class Extensions
{
    public static void ContainerDependencies(this IServiceCollection services)
    {
        services.AddScoped<IAboutService, AboutManager>();
        services.AddScoped<IAboutDal, EfAaboutDal>();
        services.AddScoped<IBookingService, BookingManager>();
        services.AddScoped<IBookingDal, EfBookingDal>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<IContactDal, EfContactDal>();
        services.AddScoped<IDiscountService, DiscountManager>();
        services.AddScoped<IDiscountDal, EfDiscountDal>();
        services.AddScoped<IFeatureService, FeatureManager>();
        services.AddScoped<IFeatureDal, EfFeatureDal>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IProductDal, EfProductDal>();
        services.AddScoped<ISocialMediaService, SocialMediaManager>();
        services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
        services.AddScoped<ITestimonialService, TestimonialManager>();
        services.AddScoped<ITestimonialDal, EfTestimonialDal>();
        services.AddScoped<IOrderService, OrderManager>();
        services.AddScoped<IOrderDal, EfOrderDal>();
        services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();
        services.AddScoped<IOrderDetailsService, OrderDetailsManager>();
        services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
        services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();
        services.AddScoped<IMenuTableService, MenuTableManager>();
        services.AddScoped<IMenuTableDal, EfMenuTableDal>();
        services.AddScoped<ISliderService, SliderManager>();
        services.AddScoped<ISliderDal, EfSliderDal>();
        services.AddScoped<IBasketDal, EfBasketDal>();
        services.AddScoped<IBasketService, BasketManager>();
        services.AddScoped<INotificationService, NotificationManager>();
        services.AddScoped<INotificationDal, EfNotificationDal>();
        services.AddScoped<IMessageDal, EfMessageDal>();
        services.AddScoped<IMessageService, MessageManager>();
    }
}
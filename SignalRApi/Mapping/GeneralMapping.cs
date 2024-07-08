using AutoMapper;
using SignalR.DtoLayer.AboutDtos;
using SignalR.DtoLayer.BookingDtos;
using SignalR.DtoLayer.CategoryDtos;
using SignalR.DtoLayer.ContactDtos;
using SignalR.DtoLayer.DiscountDtos;
using SignalR.DtoLayer.FeatureDtos;
using SignalR.DtoLayer.NotificationDtos;
using SignalR.DtoLayer.ProductDtos;
using SignalR.DtoLayer.SocialMediaDtos;
using SignalR.DtoLayer.TestimonialDtos;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.BookingDtos;

namespace SignalRApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetAboutDto>().ReverseMap();

            CreateMap<Booking, ResultBookingDto>().ReverseMap();
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
            CreateMap<Booking, GetBookingDto>().ReverseMap();

            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();

            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, GetDiscountDto>().ReverseMap();

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, GetProductWithCategoryDto>().ReverseMap();

            CreateMap<SocialMedia, ResultMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetMediaDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();

            CreateMap<Notification,ResultNotificationDto>().ReverseMap();
            CreateMap<Notification,CreateNotificationDto>().ReverseMap();
            CreateMap<Notification,UpdateNotificationDto>().ReverseMap();
        }
    }
}

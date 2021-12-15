using AutoMapper;
using Peters.Cookies.Api.Models.Order;
using Peters.Cookies.Api.Models.Quote;
using Peters.Cookies.Application.Models.Order;
using Peters.Cookies.Application.Models.Quote;
using Peters.Cookies.Domain.Entities;

namespace Peters.Cookies.Api.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GenerateQuotesModel, GenerateQuotes>();
        CreateMap<Quote.OrderRowModel, Application.Models.Quote.OrderRow>();

        CreateMap<PlaceOrder, PlaceOrderModel>();
        CreateMap<Application.Models.Order.OrderRow, Order.OrderRowModel>();
        CreateMap<QuoteRow, QuoteRowModel>();

        CreateMap<PlaceOrderModel, PlaceOrder>();
        CreateMap<QuoteRowModel, QuoteRow>();
        CreateMap<Order.OrderRowModel, Application.Models.Order.OrderRow>();
        CreateMap<Application.Models.Order.OrderRow, OrderDetails>();
    }
}

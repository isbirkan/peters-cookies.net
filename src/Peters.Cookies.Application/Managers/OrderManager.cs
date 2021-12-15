using AutoMapper;
using Peters.Cookies.Application.Interfaces;
using Peters.Cookies.Application.Models.Order;
using Peters.Cookies.Domain.Entities;
using Peters.Cookies.Domain.Helpers;
using Peters.Cookies.Domain.Interfaces;
using Peters.Cookies.Infrastructure.Commands;
using Peters.Cookies.Infrastructure.Interfaces;

namespace Peters.Cookies.Application.Managers;

public class OrderManager : IOrderManager
{
    private readonly IMapper _mapper;
    private readonly IOrderCommandHandler _orderCommandHandler;
    private readonly IOrderBuilder _orderBuilder;

    public OrderManager(
        IMapper mapper,
        IOrderCommandHandler orderCommandHandler,
        IOrderBuilder orderBuilder)
    {
        _mapper = mapper;
        _orderCommandHandler = orderCommandHandler;
        _orderBuilder = orderBuilder;
    }

    public async Task<OrderReceipt> PlaceOrderAsync(PlaceOrder request)
    {
        Assertion.ArgumentNullAssert(request, nameof(request));
        Assertion.ArgumentNullAssert(request.OrderRows, nameof(request.OrderRows));

        var orderDetails = _mapper.Map<IList<OrderDetails>>(request.OrderRows);
        var groupsBySupplier = orderDetails.GroupBy(a => a.SupplierName)
                                 .Select(group => group.AsEnumerable());

        var tasks = new List<Task>();
        var orderResponses = new List<OrderResponse>();
        int totalAmount = 0;
        foreach (var group in groupsBySupplier)
        {
            var item = group.FirstOrDefault();
            if (item != null) 
            {
                var command = new OrderCommand(group.ToList(), item.SupplierName);
                tasks.Add(Task.Run(async () =>
                {
                    var response = await _orderCommandHandler.HandleAsync(command);
                    if (response != null)
                    {
                        orderResponses.Add(response);
                    }
                }));
            }

            totalAmount += group.Sum(g => g.Amount);
        }

        await Task.WhenAll(tasks);
        var receipt = _orderBuilder.CreateReceipt(orderResponses, totalAmount);

        return new OrderReceipt(receipt.TotalPricePresentation);
    }
}

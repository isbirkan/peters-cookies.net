using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peters.Cookies.Api.Models.Order;
using Peters.Cookies.Api.Models.Quote;
using Peters.Cookies.Application.Interfaces;
using Peters.Cookies.Application.Models.Order;
using Peters.Cookies.Application.Models.Quote;
using Peters.Cookies.Domain.Helpers;

namespace Peters.Cookies.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CookieController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IQuoteManager _quoteManager;
    private readonly IOrderManager _orderManager;

    public CookieController(
        IMapper mapper,
        IQuoteManager quoteManager,
        IOrderManager orderManager)
    {
        _mapper = mapper;
        _quoteManager = quoteManager;
        _orderManager = orderManager;
    }

    /// <summary>
    /// Get available products from all of the suppliers
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Products")]
    public async Task<IActionResult> GetProductsAsync()
    {
        var products = await _quoteManager.GetProductsAsync();
        return Ok(products);
    }

    /// <summary>
    /// Generates a quote for the order to come by making smart decisions
    /// </summary>
    /// <param name="generateQuotesModel"></param>
    /// <returns>PlaceOrderModel</returns>
    [HttpPost]
    [Route("Quotes")]
    public async Task<IActionResult> GenerateQuotesAsync(GenerateQuotesModel generateQuotesModel)
    {
        Assertion.ArgumentNullAssert(generateQuotesModel, nameof(generateQuotesModel));
        Assertion.ArgumentNullAssert(generateQuotesModel.OrderRows, nameof(generateQuotesModel.OrderRows));

        var requestModel = _mapper.Map<GenerateQuotes>(generateQuotesModel);
        var response = await _quoteManager.GenerateQuotesAsync(requestModel);
        var responseModel = _mapper.Map<PlaceOrderModel>(response);

        return Ok(responseModel);
    }

    /// <summary>
    /// Place the order through the quotes generating by making smart decisions
    /// </summary>
    /// <param name="placeOrderModel"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("Order")]
    public async Task<IActionResult> PlaceOrderAsync(PlaceOrderModel placeOrderModel)
    {
        Assertion.ArgumentNullAssert(placeOrderModel, nameof(placeOrderModel));
        Assertion.ArgumentNullAssert(placeOrderModel.OrderRows, nameof(placeOrderModel.OrderRows));

        var requestModel = _mapper.Map<PlaceOrder>(placeOrderModel);
        var response = await _orderManager.PlaceOrderAsync(requestModel);

        return Ok(new OrderReceiptModel(response.TotalPricePresentation));
    }
}

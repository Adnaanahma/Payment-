using Microsoft.AspNetCore.Mvc;
using Payment.Model.ViewModel;
using Payment.Service.Interfaces;

namespace Payment.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaystackService _paystackService;

    // Constructor to inject the Paystack service
    public PaymentController(IPaystackService paystackService)
    {
        _paystackService = paystackService;
    }

    /// <summary>
    /// "initialize payment"
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("InitializeTransaction")]
    public async Task<IActionResult> InitializePaymentAsync(PayStackCustomerModel model)
    {
        var response = await _paystackService.InitializePaymentAsync(model); // Call service method to initialize payment
        if (response.Status)
        {
            return Ok(response); // Return success response
        }
        else
        {
            return BadRequest(response); // Return error response
        }
    }

    /// <summary>
    /// "method to verify payment"
    /// </summary>
    /// <param name="reference"></param>
    /// <returns></returns>
    [HttpGet("VerifyTransaction")]
    public async Task<IActionResult> VerifyAsync(string reference)
    {
        var response = await _paystackService.VerifyAsync(reference); // Call service method to verify payment
        if (response.Status)
        {
            return Ok(response); // Return success response
        }
        else
        {
            return BadRequest(response); // Return error response
        }
    }

    /// <summary>
    /// "method to retrive transaction"
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("RetrieveTransaction")]
    public async Task<IActionResult> RetrieveTransactionFromDatabaseAsync(int userId)
    {
        var response = await _paystackService.RetrieveTransactionFromDatabaseAsync(userId); // Call service method to retrieve transaction details
        if (response != null)
        {
            return Ok(response); // Return success response
        }
        else
        {
            return BadRequest(response); // Return error response
        }
    }
}

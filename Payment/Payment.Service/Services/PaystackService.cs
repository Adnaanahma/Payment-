using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Payment.Model.ViewModel;
using Payment.Service.Interfaces;
using Paystack.Net.SDK;


namespace Payment.Service.Services;
public class PaystackService : IPaystackService
{
    private readonly string _paystackSecret;
    private readonly PayStackApi _api;

    public PaystackService(IConfiguration configuration)
    {
        _paystackSecret = configuration["PayStackSecret"];
        _api = new PayStackApi(_paystackSecret);
    }
    /// <summary>
    /// "Method to initialize payment"
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<PaystackResponse> InitializePaymentAsync(PayStackCustomerModel model)
    {
        var amountInKobo = (int)(model.Amount * 100); // Convert decimal amount to kobo
        var response = await _api.Transactions.InitializeTransaction(model.Email, amountInKobo, model.Name); // call Paystack Api to initialize payment

        if (response != null)
        {
            return new PaystackResponse
            {
                Status = true,
                Data = response.data,
                Message = "Payment Initialization Successful"
            };
        }
        else return new PaystackResponse { Status = false, Data = null, Message = "Invalid Email Adderess" };
    }
    /// <summary>
    /// "method to verify payment"
    /// </summary>
    /// <param name="reference"></param>
    /// <returns></returns>
    public async Task<PaystackResponse> VerifyAsync(string reference)
    {
        var response = await _api.Transactions.VerifyTransaction(reference); // call Paystack Api to verify payment
        if (response != null)
        {
            return new PaystackResponse
            {
                Status = true,
                Data = response.data,
                Message = "Payment Verification Successful"
            };
        }
        else return new PaystackResponse { Status = false, Data = null, Message = "Invalid Reference" };
    }
    /// <summary>
    /// "method to retrieve transaction data from database"
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<object> RetrieveTransactionFromDatabaseAsync(int userId)
    {
        // This is a placeholder for actual data retrieval logic.
        await Task.Delay(100); // Simulate async work
        return new
        {
            Id = userId,
            Name = "John Doe",
            Email = "john.doe@example.com",
            Amount = 1000m, // Example amount in decimal
            Status = "Successful"
        };
    }
}

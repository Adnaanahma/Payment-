using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Model.ViewModel;

namespace Payment.Service.Interfaces;
public interface IPaystackService
{
    Task<PaystackResponse> InitializePaymentAsync(PayStackCustomerModel model);
    Task<PaystackResponse> VerifyAsync(string reference);
    Task<object> RetrieveTransactionFromDatabaseAsync(int userId);
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Model.ViewModel;
public class PaystackResponse
{
    public bool Status { get; set; }
    [Required] public object? Data { get; set; }
    public string Message { get; set; }
}

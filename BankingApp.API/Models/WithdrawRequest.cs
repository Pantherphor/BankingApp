using System;
using System.ComponentModel.DataAnnotations;

namespace BankingApp.API.Models
{
    public class WithdrawRequest
    {
        [Required]
        public string AccountAccount { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }
    }

}

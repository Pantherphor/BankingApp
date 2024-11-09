using System.ComponentModel.DataAnnotations;

namespace BankingApp.Core.Models
{
    public record BankAccount
    {
        [Key]
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}

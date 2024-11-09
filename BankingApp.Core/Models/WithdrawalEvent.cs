using BankingApp.Core.Events;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BankingApp.Core.Models
{
    public enum WithdrawalStatus
    {
        Pending,
        Completed,
        Failed
    }

    public record WithdrawalEvent : IDomainEvent
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WithdrawalStatus Status { get; set; }

        public string ToJson() => JsonSerializer.Serialize(this);
    }

}

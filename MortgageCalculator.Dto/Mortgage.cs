using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MortgageCalculator.Dto
{
    public class Mortgage
    {
        public int MortgageId { get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public MortgageType MortgageType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public InterestRepayment InterestRepayment { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public int TermsInMonths { get; set; }
        public decimal CancellationFee { get; set; }
        public decimal EstablishmentFee { get; set; }
        public Guid SchemaIdentifier { get; internal set; }
        public decimal InterestRate { get; set; }
    }

    public enum MortgageType
    {
        Variable,
        Fixed

    }

    public enum InterestRepayment
    {
        InterestOnly,
        PrincipalAndInterest
    }
}
